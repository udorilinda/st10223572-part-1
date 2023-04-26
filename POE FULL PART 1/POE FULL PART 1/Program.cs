using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POE_FULL_PART_1   
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Recipe recipe = new Recipe();

            while (true)
            {
                //prompt the user to select from the menu bar
                Console.WriteLine("1. Enter recipe details");
                Console.WriteLine("2. Display recipe");
                Console.WriteLine("3. Scale recipe");
                Console.WriteLine("4. Reset quantities");
                Console.WriteLine("5. Clear all data");
                Console.WriteLine("6. Exit");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    //calling all the method from the call recipe
                    case "1":
                        recipe.EnterDetails();
                        break;
                    case "2":
                        recipe.Display();
                        break;
                    case "3":
                        recipe.Scale();
                        break;
                    case "4":
                        recipe.ResetQuantities();
                        break;
                    case "5":
                        recipe.ClearData();
                        break;
                    case "6":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

                Console.WriteLine();
            }
        }
    }

    class Recipe
    {
        private Ingredient[] ingredients;
        private string[] steps;
        private Ingredient[] originalQuantities;

        public double Quantity { get; private set; }

        public void EnterDetails()
        {
            Console.Write("Enter the number of ingredients: ");//prompt the user to enter number of ingredients
            int numIngredients = int.Parse(Console.ReadLine());
            Console.WriteLine();
            //create an ingredient object and add it to the array ofingredients
            ingredients = new Ingredient[numIngredients];
            originalQuantities = new Ingredient[numIngredients];

            //loop through the number of ingredients specified by the user
            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine($"Ingredient {i + 1}: ");
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Quantity: ");
                double quantity = double.Parse(Console.ReadLine());
                Console.Write("Unit of measurement: ");
                string unit = Console.ReadLine();
                Console.WriteLine();
                //create an ingredient object and add it to the array of ingredients
                ingredients[i] = new Ingredient(name, quantity, unit);
                originalQuantities[i] = new Ingredient(name, quantity, unit);
            }

            Console.Write("Enter the number of steps: ");//prompt the user to enter number of steps
            int numSteps = int.Parse(Console.ReadLine());
            Console.WriteLine();
            //create an array that will store the steps
            steps = new string[numSteps];

            //then we will loop through the number of steps specified by the user
            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine($"Step {i + 1}:");
                string step = Console.ReadLine();
                steps[i] = step;
                Console.WriteLine();
            }
        }

        public void Display()
        {
            Console.WriteLine("Ingredients: ");//displaying all the quantities for the application
            
            foreach (Ingredient ingredient in ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} {ingredient.Name}");
            }

            Console.WriteLine();
            Console.WriteLine("Steps:");
            for (int i = 0; i < steps.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {steps[i]}");
            }
        }

        public void Scale()
        {
            Console.Write("Enter scaling factor (0.5, 2, or 3): ");//prompt the user to enter the scale factors
            double factor = double.Parse(Console.ReadLine());
            Console.WriteLine();
            //loop through the scale specified by the user
            for (int i = 0; i < ingredients.Length; i++)
            {
                Ingredient original = originalQuantities[i];
                Ingredient current = ingredients[i];

                double newQuantity = Quantity * factor;
                current.Quantity = newQuantity;
            }
        }

        public void ResetQuantities()
        {
            //loop through the reset quantities specified by the user
            for (int i = 0; i < ingredients.Length; i++)
            {
                Ingredient original = originalQuantities[i];
                Ingredient current = ingredients[i];

                current.Quantity = original.Quantity;
            }
        }

        public void ClearData()
        {
            //clearing all the data entered by the user
            ingredients = null;
            steps = null;
            originalQuantities = null;
        }
    }
}
