using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class IngredientModel
    {
       public int idIngredient { get; set; }
        public string strIngredient { get; set; }
        public string strDescription { get; set; }
        public string strType { get; set; }
        public string strAlcohol { get; set; }
        public string strABV { get; set; }

        public override string ToString()
        {
            var result = "";
            foreach(var prop in this.GetType().GetProperties())
            {
                if (prop.GetValue(this) != null)
                {
                    result += prop.GetValue(this).ToString() + '\n';
                }
            }
            result += "----------------------------------------------------------------";
            return result;

        }
    }
}
