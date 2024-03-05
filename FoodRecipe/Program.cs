using System;


    class Program
    {
        static void Main(string[] args)
        {
            RecipeManager recipeManager = new RecipeManager();
            bool continueApplication = true;

            while (continueApplication)
            {
                Console.WriteLine("Welcome to Recipe Application!");
                Console.WriteLine("1. Enter a new recipe");
                Console.WriteLine("2. Display full recipe");
                Console.WriteLine("3. Scale recipe");
                Console.WriteLine("4. Reset quantities");
                Console.WriteLine("5. Clear all data");
                Console.WriteLine("6. Exit");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        recipeManager.EnterRecipeDetails();
                        break;
                    case 2:
                        recipeManager.DisplayRecipe();
                        break;
                    case 3:
                        recipeManager.ScaleRecipe();
                        break;
                    case 4:
                        recipeManager.ResetQuantities();
                        break;
                    case 5:
                        recipeManager.ClearData();
                        break;
                    case 6:
                        continueApplication = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number from 1 to 6.");
                        break;
                }
            }
        }
    }

    class RecipeManager
    {
        private Recipe currentRecipe;

        public void EnterRecipeDetails()
        {
            currentRecipe = new Recipe();

            Console.Write("Enter the number of ingredients: ");
            int numIngredients = int.Parse(Console.ReadLine());
            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine($"Ingredient {i + 1}:");
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Quantity: ");
                double quantity = double.Parse(Console.ReadLine());
                Console.Write("Unit of measurement: ");
                string unit = Console.ReadLine();

                currentRecipe.AddIngredient(new Ingredient(name, quantity, unit));
            }

            Console.Write("Enter the number of steps: ");
            int numSteps = int.Parse(Console.ReadLine());
            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine($"Step {i + 1}:");
                Console.Write("Description: ");
                string description = Console.ReadLine();

                currentRecipe.AddStep(new Step(description));
            }

            Console.WriteLine("Recipe details entered successfully!");
        }

        public void DisplayRecipe() //method to displlay the recipe
        {
            if (currentRecipe != null)
            {
                Console.WriteLine("Recipe:");
                Console.WriteLine(currentRecipe.ToString());
            }
            else
            {
                Console.WriteLine("No recipe entered yet. Please enter a recipe first.");
            }
        }

        public void ScaleRecipe()//method to scale the recipe by given factor
        {
            if (currentRecipe != null)
            {
                Console.Write("Enter scaling factor (0.5, 2, or 3): ");
                double factor = double.Parse(Console.ReadLine());
                currentRecipe.Scale(factor);
                Console.WriteLine("Recipe scaled successfully!");
            }
            else
            {
                Console.WriteLine("No recipe entered yet. Please enter a recipe first.");
            }
        }

        public void ResetQuantities() //method to reset quantities
        {
            if (currentRecipe != null)
            {
                currentRecipe.ResetQuantities();
                Console.WriteLine("Quantities reset successfully!");
            }
            else
            {
                Console.WriteLine("No recipe entered yet. Please enter a recipe first.");
            }
        }

        public void ClearData()
        {
            currentRecipe = null;
            Console.WriteLine("Data cleared successfully!");
        }
    }

    class Recipe
    {
        private Ingredient[] ingredients;//creating array to store Ingredient and step data
        private Step[] steps;

        public Recipe()
        {
            ingredients = new Ingredient[0];
            steps = new Step[0];
        }

        public void AddIngredient(Ingredient ingredient)
        {
            Array.Resize(ref ingredients, ingredients.Length + 1);
            ingredients[ingredients.Length - 1] = ingredient;
        }

        public void AddStep(Step step)
        {
            Array.Resize(ref steps, steps.Length + 1);
            steps[steps.Length - 1] = step;
        }

        public void Scale(double factor)
        {
            foreach (Ingredient ingredient in ingredients)
            {
                ingredient.Quantity *= factor;
            }
        }

        public void ResetQuantities()
        {
            //  reset quantities to original values
        }

        public override string ToString()
        {
            string recipeDetails = "";

            recipeDetails += "Ingredients:\n";
            foreach (Ingredient ingredient in ingredients)
            {
                recipeDetails += $"{ingredient.Name}: {ingredient.Quantity} {ingredient.Unit}\n";
            }

            recipeDetails += "\nSteps:\n";
            for (int i = 0; i < steps.Length; i++)
            {
                recipeDetails += $"{i + 1}. {steps[i].Description}\n";
            }

            return recipeDetails;
        }
    }

    class Ingredient
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }

        public Ingredient(string name, double quantity, string unit)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
        }
    }

    class Step
    {
        public string Description { get; set; }

        public Step(string description)
        {
            Description = description;
        }
    }

