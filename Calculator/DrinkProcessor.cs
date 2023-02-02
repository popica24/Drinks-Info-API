using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class DrinkProcessor
    {
        public static async Task<List<DrinkModel>> LoadDrink(DrinkSearchParameters Params)
        {
            string url = "";
            
                if(!Params.Random.HasValue)
                {
                    if (!string.IsNullOrEmpty(Params.Name))
                    {
                        url = $"https://www.thecocktaildb.com/api/json/v1/1/search.php?s={Params.Name}";

                    }
                    if (!string.IsNullOrEmpty(Params.FirstLetter))
                    {
                        url = $"https://www.thecocktaildb.com/api/json/v1/1/search.php?f={Params.FirstLetter}";
                    }
                    if (Params.Id.HasValue)
                    {
                        url = $"https://www.thecocktaildb.com/api/json/v1/1/lookup.php?i={Params.Id}";
                    }
                    if (!string.IsNullOrEmpty(Params.Ingredient))
                    {
                        url = $"https://www.thecocktaildb.com/api/json/v1/1/filter.php?i={Params.Ingredient}";
                    }
                    if (!string.IsNullOrEmpty(Params.Alcoholic))
                    {
                        url = $"https://www.thecocktaildb.com/api/json/v1/1/filter.php?a={Params.Alcoholic}";
                    }
                if (!string.IsNullOrEmpty(Params.Category))
                {
                    url = $"https://www.thecocktaildb.com/api/json/v1/1/filter.php?a={Params.Category}";
                }
                if (!string.IsNullOrEmpty(Params.Glass))
                {
                    url = $"https://www.thecocktaildb.com/api/json/v1/1/filter.php?a={Params.Glass}";
                }
                if (Params.CategoryList.HasValue && Params.CategoryList==true)
                {
                    url = $"https://www.thecocktaildb.com/api/json/v1/1/list.php?c=list";
                }
                if (Params.GlassesList.HasValue && Params.GlassesList == true)
                {
                    url = $"https://www.thecocktaildb.com/api/json/v1/1/list.php?g=list";
                }
                if (Params.GlassesList.HasValue && Params.IngredientList == true)
                {
                    url = $"https://www.thecocktaildb.com/api/json/v1/1/list.php?i=list";
                }
                if (Params.AlcoholList.HasValue && Params.AlcoholList == true)
                {
                    url = $"https://www.thecocktaildb.com/api/json/v1/1/list.php?a=list";
                }

            }
                else if(Params.Random==true) url = "https://www.thecocktaildb.com/api/json/v1/1/random.php";
                    
                
            

            using(HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                     string data = await response.Content.ReadAsStringAsync();
                    JObject rss = JObject.Parse(data);
                    JArray JDrinks = (JArray)rss["drinks"];
                    var x = JDrinks.ToObject<List<DrinkModel>>();
                    return x;
                }
                else throw new Exception(response.ReasonPhrase);
            }
        }
        public static void ShowDrinks(List<DrinkModel> drinks)
        {
            foreach (var drink in drinks)
            {
                Console.WriteLine(drink.ToString());
            }
        }
    }
}
