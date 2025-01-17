﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Tenant_App.Models.Data;

namespace Tenant_App.Services.Handler.DataAccess
{
    public class AccessDataLayer
    {
        private readonly AppDbContext _context;
        public AccessDataLayer(AppDbContext context)
        {
            _context = context;
        }


        public void DeletePermissionByRoleID(IDbDataParameter[] parameters, string StoreProcedureName)
        {
            DBManager dBManager = new DBManager(_context);
            dBManager.Delete(StoreProcedureName, CommandType.StoredProcedure, parameters);
            
        }

        public DataTable FetchRecordByDataTable(string StoreProcedureName)
        {
            DBManager dBManager = new DBManager(_context);
            DataTable dt  = dBManager.GetDataTable(StoreProcedureName, CommandType.StoredProcedure);
            return dt;
        }

        public long AddUserRolePerission(IDbDataParameter[] parameters, string StoreProcedureName, int lastId =0)
        {
            DBManager dBManager = new DBManager(_context);
          return  dBManager.Insert(StoreProcedureName, CommandType.StoredProcedure, parameters.ToArray(), out lastId);

        }
        


        public DataTable FetchRolePermissionsByRoleId(IDbDataParameter[] parameters, string StoreProcedureName)
        {
            DBManager dBManager = new DBManager(_context);
           return dBManager.GetDataTable(StoreProcedureName, CommandType.StoredProcedure, parameters);
        }

        public DataTable ProcessStoreProcedure(IDbDataParameter[] parameters, string StoreProcedureName)
        {
            DBManager dBManager = new DBManager(_context);
            return dBManager.GetDataTable(StoreProcedureName, CommandType.StoredProcedure, parameters);
        }

        public DataSet ProcessDataSetStoreProcedure(IDbDataParameter[] parameters, string StoreProcedureName)
        {
            DBManager dBManager = new DBManager(_context);
            return dBManager.GetDataSet(StoreProcedureName, CommandType.StoredProcedure, parameters);
        }

        public DataTable FetchUserPermissionAndRole(IDbDataParameter[] parameters, string StoreProcedureName)
        {
            DBManager dBManager = new DBManager(_context);
            return dBManager.GetDataTable(StoreProcedureName, CommandType.StoredProcedure, parameters);
        }

        public DataTable FetchDailyIncidentByDay(string StoreProcedureName)
        {
            DBManager dBManager = new DBManager(_context);
            return dBManager.GetDataTable(StoreProcedureName, CommandType.StoredProcedure,null);
        }

        public DataTable FetchWeeklyIncidentByWeek(string StoreProcedureName)
        {
            DBManager dBManager = new DBManager(_context);
            return dBManager.GetDataTable(StoreProcedureName, CommandType.StoredProcedure, null);
        }



    }
}
