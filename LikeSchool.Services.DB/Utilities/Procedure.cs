using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LikeSchool.Services.DB
{
    public class Procedure :ICloneable
    {
        private string procedureParameter;
        private object procedureValue;
        private bool isOut;
        private object outputValue = null;
        public string ProcedureParameter
        {
            get
            {
                return procedureParameter;
            }
            set
            {
                procedureParameter = value;
            }

        }

        public object ProcedureValue
        {
            get
            {
                return procedureValue;
            }
            set
            {
                procedureValue = value;
            }
        }
        public bool IsOutParemeter
        {
            get
            {
                return isOut;

            }
            set
            {
                isOut = value;
            }
        }
        public object OutValue
        {
            get
            {
                return outputValue;
            }
            set
            {
                outputValue = value;
            }
        }

        public object Clone()
        {
          return this.MemberwiseClone();
        }
    }
}