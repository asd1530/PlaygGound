using Microsoft.Azure.Documents.Client;
using PlayGround.Data;
using PlayGround.Data.Doc;
using PlayGround.Data.Entity;
using Santhos.DocumentDb.Repository;
using System.Collections.Generic;
using System.Linq;

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
        public void SaveDocs(ImportData data)
        {
            var repository = new Repository<ImportData>(this.docClient, "imports");
            repository.Create(data);
        }
    }

}
