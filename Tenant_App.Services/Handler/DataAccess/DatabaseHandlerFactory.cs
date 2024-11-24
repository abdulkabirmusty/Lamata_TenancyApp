using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Tenant_App.Services.Contract.DataAccess;
using Tenant_App.Models.Data;

namespace Tenant_App.Services.Handler.DataAccess
{
    public class DatabaseHandlerFactory
    {
      
          private readonly AppDbContext _context;
        public DatabaseHandlerFactory(AppDbContext context)
        {
            _context = context;
           // connectionStringSettings = context.Database.GetDbConnection().ConnectionString();
        }

        public IDataAccess CreateDatabase()
        {
            IDataAccess database = null;

            switch (_context.Database.ProviderName.ToLower())
            {
                case "microsoft.entityframeworkcore.sqlserver":
                    database = new SqlDataAccess(_context.Database.GetDbConnection().ConnectionString);
                        break;
                case "system.data.oracleclient":
                        database = new OracleDataAccess(_context.Database.GetDbConnection().ConnectionString);
                        break;
               
            }

            return database;
        }

        public string GetProviderName()
        {
            return _context.Database.ProviderName;
        }
    }
}
