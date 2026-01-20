using System;

namespace PersonalizedMealPlanGenerator
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("\n--- Personalized Meal Plan Generator ---");
                Console.WriteLine("1. Vegetarian");
                Console.WriteLine("2. Vegan");
                Console.WriteLine("3. Keto");
                Console.WriteLine("4. High Protein");
                Console.WriteLine("5. Exit");
                Console.Write("Choose meal type: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1: MealUtility.GenerateMeal<VegetarianMeal>(); break;
                    case 2: MealUtility.GenerateMeal<VeganMeal>(); break;
                    case 3: MealUtility.GenerateMeal<KetoMeal>(); break;
                    case 4: MealUtility.GenerateMeal<HighProteinMeal>(); break;
                    case 5: return;
                    default: Console.WriteLine("Invalid choice"); break;
                }
            }
        }
    }
}
