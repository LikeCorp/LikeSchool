using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LikeSchool.Services.DB.Insert
{
    public class InsertSP : Connection
    {
        public List<Procedure> Parameters { get; set; }
        public virtual List<Procedure> InsertProcedure(string procedureName)
        {
            OpenConnection();

            SqlCommand command = new SqlCommand(procedureName, DbConnection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            foreach (Procedure pro in Parameters)
            {
                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = pro.ProcedureParameter;
                parameter.Value = pro.ProcedureValue;
                parameter.Direction = pro.IsOutParemeter ? ParameterDirection.Output : ParameterDirection.Input;
                if (pro.IsOutParemeter)
                    parameter.Size = 20;
                command.Parameters.Add(parameter);
            }
            command.ExecuteReader();

            CloseConnection();

            return GetOutValues(command);
        }

        private List<Procedure> GetOutValues(SqlCommand cmd)
        {
            List<Procedure> outs = (from para in Parameters where para.IsOutParemeter == true select para).ToList<Procedure>();
            List<Procedure> result = new List<Procedure>();
            foreach(Procedure pro in outs)
            {
                Procedure clonePro = pro.Clone() as Procedure;
                clonePro.OutValue = cmd.Parameters[pro.ProcedureParameter].Value;
                result.Add(clonePro);
            }
            return result;

        }
        
    }
}