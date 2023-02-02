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
        private static string FormattedUrl(string str)
        {
            if (str.Any(x => Char.IsWhiteSpace(x))) return str;
            var newStr = "";
            newStr += str[0].ToString().ToUpper();
            newStr += str.Substring(1, str.IndexOf(" "));
            newStr += "_";
            newStr += str[str.IndexOf(" ") + 1].ToString().ToUpper();
            newStr += str.Substring(str.IndexOf(" ") + 2);
            return newStr;
        }

        public static async Task<List<DrinkModel>> LoadDrink(DrinkSearchParameters Params)
        {
            string url = "";
            
                if(!Params.Random.HasValue)
                {
                    if (!string.IsNullOrEmpty(Params.Name))
                    {
                        url = $"https://www.thecocktaildb.com/api/json/v1/1/search.php?s={FormattedUrl(Params.Name)}";

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
                        url = $"https://www.thecocktaildb.com/api/json/v1/1/filter.php?i={FormattedUrl(Params.Ingredient)}";
                    }
                    if (!string.IsNullOrEmpty(Params.Alcoholic))
                    {
                        url = $"https://www.thecocktaildb.com/api/json/v1/1/filter.php?a={FormattedUrl(Params.Alcoholic)}";
                    }
                if (!string.IsNullOrEmpty(Params.Category))
                {
                    url = $"https://www.thecocktaildb.com/api/json/v1/1/filter.php?a={FormattedUrl(Params.Category)}";
                }
                if (!string.IsNullOrEmpty(Params.Glass))
                {
                    url = $"https://www.thecocktaildb.com/api/json/v1/1/filter.php?a={FormattedUrl(Params.Category)}";
                }
                if (Params.CategoryList.HasValue && Params.CategoryList==true)
                {
                    url = $"https://www.thecocktaildb.com/api/json/v1/1/list.php?c=list";
                }
                if (Params.GlassesList.HasValue && Params.GlassesList == true)
                {
                    url = $"https://www.thecocktaildb.com/api/json/v1/1/list.php?g=list";
                }
                if (Params.IngredientList.HasValue && Params.IngredientList == true)
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
        public static async Task<List<IngredientModel>> LoadIngredient(IngredientSearchParameters Params)
        {
            var url = "";
            if (Params.ID.HasValue)
            {
                url = $"https://www.thecocktaildb.com/api/json/v1/1/lookup.php?iid={Params.ID}";
            }
            if (!string.IsNullOrEmpty(Params.Name))
            {
                url = $"https://www.thecocktaildb.com/api/json/v1/1/search.php?i={Params.Name}";
            }
           

            using(HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    JObject rss = JObject.Parse(data);
                    JArray JDrinks = (JArray)rss["ingredients"];
                    var x = JDrinks.ToObject<List<IngredientModel>>();
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
        public static void ShowIngredients(List<IngredientModel> ingredients)
        {
            foreach (var i in ingredients)
            {
                Console.WriteLine(i.ToString());
            }
        }
    }
}
