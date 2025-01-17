﻿using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Data.OracleClient;
using Tenant_App.Services.Contract.DataAccess;

namespace Tenant_App.Services.Handler.DataAccess
{
    public class OracleDataAccess : IDataAccess
    {
        private string ConnectionString { get; set; } 

        public OracleDataAccess(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public IDbConnection CreateConnection()
        {
            return new OracleConnection(ConnectionString);
        }

        public void CloseConnection(IDbConnection connection)
        {
            var oracleConnection = (OracleConnection)connection;
            oracleConnection.Close();
            oracleConnection.Dispose();
        }

        public IDbCommand CreateCommand(string commandText, CommandType commandType, IDbConnection connection)
        {
            return new OracleCommand
            {
                CommandText = commandText,
                Connection = (OracleConnection)connection,
                CommandType = commandType
            };
        }

        public IDataAdapter CreateAdapter(IDbCommand command)
        {
            return new OracleDataAdapter((OracleCommand)command);
        }

        public IDbDataParameter CreateParameter(IDbCommand command)
        {
            OracleCommand SQLcommand = (OracleCommand)command;
            return SQLcommand.CreateParameter();
        }
    }
}
