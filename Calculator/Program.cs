using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Calculator
{
    public class Loader
    {
        public static async Task LoadDrinks(DrinkSearchParameters parameters)
        {
            var _Drinks = await DrinkProcessor.LoadDrink(parameters);
            Program.Drinks = _Drinks;
        }
        public static async Task LoadIngredients(IngredientSearchParameters parameters)
        {
            var _Ingredients = await DrinkProcessor.LoadIngredient(parameters);
            Program.Ingredients = _Ingredients;
        }
    }

    public class Program
    {
        public static List<DrinkModel> Drinks = new List<DrinkModel>();
        public static List<IngredientModel> Ingredients = new List<IngredientModel>();
        public static void Main(string[] Args)
        {
            ApiHelper.InitializeClient();
            while (true)
            {
                Console.WriteLine("1. Search Drinks.\n" + "2. Random Drink.\n----------------------------------------------------------------");

                switch (Console.ReadLine())
                {
                    case "1":
                        {
                            Console.Clear();
                            Console.WriteLine("1 |Search by name\n2 |List by first letter\n3 |Search by ID\n4 |Alcohol type\n5 |Drink Type|\n6 |Glass Type\n7 |Ingredient\n------------------------");
                            Console.WriteLine("8 |Categories list\n9 |Glasses list\n10 |Ingredient list\n11 |Alcohol list");
                            Console.WriteLine("A |Ingredient Name\nB |Ingredient ID\n");
                            switch (Console.ReadLine())
                            {
                                case "1":
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Name :");
                                        string parameter = Console.ReadLine();
                                        Console.Clear();
                                        Loader.LoadDrinks(new DrinkSearchParameters() { Name = parameter }).Wait();
                                        DrinkProcessor.ShowDrinks(Drinks);
                                        break;
                                    }
                                case "2":
                                    {
                                        Console.Clear();
                                        Console.WriteLine("First Letter :");
                                        string parameter = Console.ReadLine();
                                        Console.Clear();
                                        Loader.LoadDrinks(new DrinkSearchParameters() { FirstLetter = parameter }).Wait();
                                        DrinkProcessor.ShowDrinks(Drinks);
                                        break;
                                    }
                                case "3":
                                    {
                                        Console.Clear();
                                        Console.WriteLine("ID :");
                                        string parameter = Console.ReadLine();
                                        Console.Clear();
                                        Loader.LoadDrinks(new DrinkSearchParameters() { Id = int.Parse(parameter) }).Wait();
                                        DrinkProcessor.ShowDrinks(Drinks);
                                        break;
                                    }
                                case "4":
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Alcohol Type :");
                                        string parameter = Console.ReadLine();
                                        Console.Clear();
                                        Loader.LoadDrinks(new DrinkSearchParameters() { Alcoholic = parameter }).Wait();
                                        DrinkProcessor.ShowDrinks(Drinks);
                                        break;
                                    }
                                case "5":
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Drink Type :");
                                        string parameter = Console.ReadLine();
                                        Console.Clear();
                                        Loader.LoadDrinks(new DrinkSearchParameters() { Category = parameter }).Wait();
                                        DrinkProcessor.ShowDrinks(Drinks);
                                        break;
                                    }
                                case "6":
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Glass Type :");
                                        string parameter = Console.ReadLine();
                                        Console.Clear();
                                        Loader.LoadDrinks(new DrinkSearchParameters() { Glass = parameter }).Wait();
                                        DrinkProcessor.ShowDrinks(Drinks);
                                        break;
                                    }
                                case "7":
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Ingredient :");
                                        string parameter = Console.ReadLine();
                                        Console.Clear();
                                        Loader.LoadDrinks(new DrinkSearchParameters() { Ingredient = parameter }).Wait();
                                        DrinkProcessor.ShowDrinks(Drinks);
                                        break;
                                    }
                                case "8":
                                    {
                                        Console.Clear();
                                        Loader.LoadDrinks(new DrinkSearchParameters() { CategoryList = true }).Wait();
                                        DrinkProcessor.ShowDrinks(Drinks);
                                        break;
                                    }
                                case "9":
                                    {
                                        Console.Clear();
                                        Loader.LoadDrinks(new DrinkSearchParameters() { GlassesList = true }).Wait();
                                        DrinkProcessor.ShowDrinks(Drinks);
                                        break;
                                    }
                                case "10":
                                    {
                                        Console.Clear();
                                        Loader.LoadDrinks(new DrinkSearchParameters() { IngredientList = true }).Wait();
                                        DrinkProcessor.ShowDrinks(Drinks);
                                        break;
                                    }
                                case "11":
                                    {
                                        Console.Clear();
                                        Loader.LoadDrinks(new DrinkSearchParameters() { AlcoholList = true }).Wait();
                                        DrinkProcessor.ShowDrinks(Drinks);
                                        break;
                                    }
                                case "A":
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Ingredient Name :");
                                        string parameter = Console.ReadLine();
                                        Console.Clear();
                                        Loader.LoadIngredients(new IngredientSearchParameters() { Name = parameter }).Wait();
                                        DrinkProcessor.ShowIngredients(Ingredients);
                                        break;
                                    }
                                case "B":
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Ingredient ID :");
                                        string parameter = Console.ReadLine();
                                        Console.Clear();
                                        Loader.LoadIngredients(new IngredientSearchParameters() { ID = int.Parse(parameter) }).Wait();
                                        DrinkProcessor.ShowIngredients(Ingredients);
                                        break;
                                    }
                            }
                            break;
                        }
                    case "2":
                        {
                            Loader.LoadDrinks(new DrinkSearchParameters() { Random = true }).Wait();
                            Console.Clear();
                            DrinkProcessor.ShowDrinks(Drinks);
                            break;
                        }
                }
                Console.WriteLine("Press enter key to return");
                Console.ReadLine();
                Console.Clear();
            }
        }
        
    }
}
