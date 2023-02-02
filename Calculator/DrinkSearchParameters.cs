using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class DrinkSearchParameters
    {
        public string Name { get; set; }
        public string FirstLetter { get; set; }
        public int? Id { get; set; }
        public string Ingredient { get; set; }
        public string Alcoholic { get; set; }
        public string Category { get; set; }
        public string Glass { get; set; }
        public bool? CategoryList { get; set; }
        public bool? GlassesList { get; set; }
        public bool? IngredientList { get; set; }
        public bool? AlcoholList { get; set; }
        public bool? Random { get; set; }
    }
}
