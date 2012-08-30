using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using LikeSchool.Services.DB.Modals;

namespace LikeSchool.Services.DB.AccesLayer
{
    public class ClassAccessLayer : Connection
    {
        IClassTableModal modal;
        public ClassAccessLayer()
        {

        }
        public ClassAccessLayer(IClassTableModal mod)
        {
            modal = mod;
        }

        public IClassTableModal Modal
        {
            get
            {
                return modal;
            }
            set
            {
                modal = value;
            }
        }
        public List<IClassTableModal> SelectClass(string procedureName)
        {
            OpenConnection();
            List<IClassTableModal> result = DbConnection.Query<ClassTableModal>(procedureName,
            commandType: System.Data.CommandType.StoredProcedure).ToList<IClassTableModal>();
            CloseConnection();
            return result;
        }

        public IClassTableModal SelectClassById(string procedureName)
        {
            OpenConnection();
            var dynamic = new DynamicParameters();
            dynamic.Add(Constants.ClassId, modal.ClassId);
            IClassTableModal result = DbConnection.Query<ClassTableModal>(procedureName,dynamic,
            commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault<ClassTableModal>();
            CloseConnection();
            return result;
        }
    }
}