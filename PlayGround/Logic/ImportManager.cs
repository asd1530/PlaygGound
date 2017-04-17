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

        public ImportManager(PlaygroundContext DBContext,DocumentClient docClient) : this(DBContext)
        {
            this.docClient = docClient;
        }

        public List<Imports> GetAll()
        {
            return DBContext.Imports.ToList();
        }
        public void ExecuteImport(Stream data)
        {
            SieDocument sd = this.ParseSieStream(data);
            this.Persist(sd);
            this.FinishImport(sd);
        }

        private void FinishImport(SieDocument sd)
        {
            this.DBContext.Imports.Add(new Imports()
            {
                Name = "FirstTest",
                PeriodStart = sd.RAR[0].Start.GetValueOrDefault(DateTime.Now),
                PeriodEnd = sd.RAR[0].End.GetValueOrDefault(DateTime.Now)
            });
        }

        private void Persist(SieDocument sd)
        {
            
            var r = new Repository<ImportData>(docClient, "accounts");
            var id = new ImportData() {
                Name = "Test",
                Description = "None",
                Accounts = sd.KONTO.Values.ToList()
            };
            r.Create(id);
           
        }

        private ICollection<SieBookingYear> ComputePeriods(Dictionary<int, SieBookingYear> rAR)
        {
            return rAR.Values.ToList();
        }


        private SieDocument ParseSieStream(Stream data)
        {
            SieDocument doc = new SieDocument();
            doc.ReadStreamDocument(new StreamReader(data));
            return doc;
                
        }
    }

}
