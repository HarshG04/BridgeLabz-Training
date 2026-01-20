namespace PersonalizedMealPlanGenerator
{
     interface IMealPlan
    {
        string GetMealType();
        int GetCalories();
    }
    class VegetarianMeal : IMealPlan
    {
        public string GetMealType() => "Vegetarian";
        public int GetCalories() => 600;
    }

    class VeganMeal : IMealPlan
    {
        public string GetMealType() => "Vegan";
        public int GetCalories() => 550;
    }

    class KetoMeal : IMealPlan
    {
        public string GetMealType() => "Keto";
        public int GetCalories() => 700;
    }

    class HighProteinMeal : IMealPlan
    {
        public string GetMealType() => "High Protein";
        public int GetCalories() => 800;
    }

    class Meal<T> where T : IMealPlan, new()
    {
        public T MealPlan { get; private set; }

        public Meal()
        {
            MealPlan = new T();
        }

        public override string ToString()
        {
            return $"Meal Type: {MealPlan.GetMealType()}, Calories: {MealPlan.GetCalories()}";
        }
    }


     class MealUtility
    {
        public static void GenerateMeal<T>() where T : IMealPlan, new()
        {
            Meal<T> meal = new Meal<T>();
            Console.WriteLine(meal);
        }
    }
}
