using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class DrinkLoader
    {
        public async Task LoadDrink(DrinkSearchParameters parameters = null)
        {
            var Drinks = await DrinkProcessor.LoadDrink(parameters);
           
        }
    }
}
