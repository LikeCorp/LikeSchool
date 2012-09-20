using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using LikeSchool.Helpers;
using LikeSchool.Modals;
using LikeSchool.Services.DB;

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
        public ClassCollection SelectClass(string procedureName)
        {
            OpenConnection();
            ClassCollection result = DbConnection.Query<ClassTableModal>(procedureName,
            commandType: System.Data.CommandType.StoredProcedure) as ClassCollection;
            CloseConnection();
            return result;
        }

        public IClassTableModal SelectClassById(string procedureName)
        {
            OpenConnection();
            var dynamic = new DynamicParameters();
            dynamic.Add(Constants.ClassName, modal.ClassName);
            dynamic.Add(Constants.Section, modal.Section);
            IClassTableModal result = DbConnection.Query<ClassTableModal>(procedureName,dynamic,
            commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault<ClassTableModal>();
            CloseConnection();
            return result;
        }
    }
}