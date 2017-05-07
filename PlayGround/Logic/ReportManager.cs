using Microsoft.Azure.Documents.Client;
using PlayGround.Common.Dto;
using PlayGround.Data;
using PlayGround.Data.Entity;
using System.Linq;
using System.Collections.Generic;
using System;
using PlayGround.Common.Sie.Transaction;
using Santhos.DocumentDb.Repository;

namespace PlayGround.Logic
{
    public class ReportManager
    {
        private PlaygroundContext DBContext { get; set; }
        private DocumentClient docClient;
        public ReportManager(PlaygroundContext DBContext)
        {
            this.DBContext = DBContext;
        }
        public List<TreeNode<ReportRow>> GenerateReport()
        {
            List<TreeNode<ReportRow>> result = new List<TreeNode<ReportRow>>();
            var r1 = new TreeNode<ReportRow>();
            r1.Data = new ReportRow() { Name ="qqq", Size="11"};
            r1.Children = new List<TreeNode<ReportRow>>();
            r1.Children.Add(new TreeNode<ReportRow>()
            {
                Data = new ReportRow()
                {
                    Name = "sss",
                    Size = "22"

                }
            });
            result.Add(r1);
            return result;
        }
        public List<GroupDto> GetGroupStructure(List<string> accounts)
        {
            List<AccountGroups> groups = this.DBContext.AccountGroups.ToList();
            var r = new Repository<ByDimension>(docClient, "PG");
            var allAccountsForDim = r.Get(d => "_" == d.DimensionKey).Result;
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
                    var sgAccounts = accounts.Where(a => a.CompareTo(sgr.AccountStart) >= 0 && a.CompareTo(sgr.AccountEnd) <= 0).ToList();
                    this.BuildAccountRow(sgAccounts, allAccountsForDim.Transactions);
                    g.SubGroups.Add(sg);
                }
                result.Add(g);
            }
            return result;
        }

        private List<TreeNode<GrouppedAccount>> BuildAccountRow(List<string> sgAccounts, List<GrouppedAccount> transactions)
        {
            
            return transactions.Where(t => sgAccounts.Contains(t.AccountNumber)).Select(q => new TreeNode<GrouppedAccount>() { Data = q }).ToList();
        }
    }
}
