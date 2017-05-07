using Common.Sie;
using Microsoft.Azure.Documents.Client;
using PlayGround.Data;
using PlayGround.Data.Doc;
using PlayGround.Data.Entity;
using Santhos.DocumentDb.Repository;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Globalization;
using System;
using PlayGround.Common.Sie;
using PlayGround.Common.Sie.Transaction;
using PlayGround.Common.Dto;

namespace PlayGround.Logic
{
    public class ImportManager
    {
        private PlaygroundContext DBContext { get; set; }
        private DocumentClient docClient;
        public ImportManager(PlaygroundContext DBContext)
        {
            this.DBContext = DBContext;
        }

        public ImportManager(PlaygroundContext DBContext, DocumentClient docClient) : this(DBContext)
        {
            this.docClient = docClient;
        }

        public List<Imports> GetAll()
        {
            return DBContext.Imports.ToList();
        }

        public ReportDto GetReportData(string dimensionType=null, string dimension = null)
        {
            var r = new Repository<ByDimension>(docClient, "PG");
            var allAccountsForDim = r.Get(d => "_" == d.DimensionKey).Result;
            var structure= this.GetGroupStructure(allAccountsForDim.Transactions.Select(t => t.AccountNumber).ToList());
            return new ReportDto()
            {
                Groupping = structure,
                AccountData = allAccountsForDim.Transactions
            };
        }

        public List<GroupDto> GetGroupStructure(List<string> accounts)
        {
            List<AccountGroups> groups = this.DBContext.AccountGroups.ToList();

            List<GroupDto> result = new List<GroupDto>();
            foreach (var gr in groups.Where(g => g.Parent == null))
            {
                var g = new GroupDto()
                {
                    Key = gr.GroupKey,
                    SubGroups = new List<SubGroupDto>()
                };
                foreach (var sgr in groups.Where(sg => sg.Parent == gr.GroupKey))
                {
                    var sg = new SubGroupDto()
                    {
                        Key = sgr.GroupKey
                    };
                    sg.Accounts = accounts.Where(a => a.CompareTo(sgr.AccountStart) >= 0 && a.CompareTo(sgr.AccountEnd) <= 0).ToList();
                    g.SubGroups.Add(sg);
                }
                result.Add(g);
            }
            return result;
        }
        
        public void ExecuteImport(Stream data)
        {
            var currentImport = this.DBContext.Imports.Add(new Imports());
            this.DBContext.SaveChanges();
            SieDocument doc = new SieDocument(currentImport.Entity.Id);
            doc.ReadStreamDocument(new StreamReader(data));
            this.Persist(doc);
            // this.ComputeTransactions(doc);
            this.FinishImport(currentImport.Entity, doc);
        }

        private void FinishImport(Imports currentImport, SieDocument sd)
        {
            currentImport.Name = string.Format("{0}[{1}]", sd.FNAMN.Name, sd.FNAMN.OrgIdentifier);
            currentImport.PeriodStart = sd.RAR[0].Start.GetValueOrDefault(DateTime.Now);
            currentImport.PeriodEnd = sd.RAR[0].End.GetValueOrDefault(DateTime.Now);
            currentImport.Status = 1;
            DBContext.SaveChanges();
        }

        private List<ByDimension> ComputeTransactions(SieDocument sd)
        {
            var list = new List<GrouppedAccount>();
            List<ByDimension> result = new List<ByDimension>();
            foreach (var byDim in sd.GrouppedTransactions)
            {
                foreach (var byAcc in byDim.Value)
                {
                    var start = new DateMonth(sd.RAR[0].Start.Value);
                    var end = new DateMonth(sd.RAR[0].End.Value);
                    var current = start;
                    GrouppedAccount ga = new GrouppedAccount();
                    ga.AccountNumber = byAcc.Key;

                    while (current <= end)
                    {
                        ga.Amounts.Add(current.ToString(), byAcc.Value.Where(a => a.RowDate == current).Sum(x => x.Amount));
                        current = current.AddMonths(1);
                    }
                    list.Add(ga);
                }

                result.Add(new ByDimension()
                {
                    DimensionKey = byDim.Key,
                    Transactions = list
                });
            }
            return result;
        }
        private async void Persist(SieDocument sd)
        {
            var s = this.ComputeTransactions(sd);

            var r = new Repository<ByDimension>(docClient, "PG");
            foreach (var entry in s)
            {
                var w = await r.Create(entry);
            }
            System.Console.WriteLine("------------------------------------------THE END");

        }
    }
}
