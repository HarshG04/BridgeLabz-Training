using System;

class DataTypesAndCasting
{
    static void Main()
    {
        // ---------------------------
        // INTEGER DATA TYPE
        // ---------------------------
        int num1 = 150;
        Console.WriteLine("Integer value stored: " + num1);

        // ---------------------------
        // FLOAT DATA TYPE
        // ---------------------------
        float decimalFloat = 18.75f;
        Console.WriteLine("Float value stored: " + decimalFloat);

        // ---------------------------
        // DOUBLE DATA TYPE
        // ---------------------------
        double preciseNumber = 987.654;
        Console.WriteLine("Double value stored: " + preciseNumber);

        // ---------------------------
        // CHARACTER DATA TYPE
        // ---------------------------
        char letter = 'C';
        Console.WriteLine("Character stored: " + letter);

        // ---------------------------
        // BOOLEAN DATA TYPE
        // ---------------------------
        bool statusFlag = false;
        Console.WriteLine("Boolean value stored: " + statusFlag);

        // ---------------------------
        // STRING DATA TYPE
        // ---------------------------
        string userName = "Rahul";
        Console.WriteLine("String value stored: " + userName);

        Console.WriteLine();
        Console.WriteLine("===== TYPE CONVERSION DEMO =====");

        // ---------------------------
        // AUTOMATIC TYPE CONVERSION
        // ---------------------------
        int baseValue = 60;
        double convertedValue = baseValue;
        Console.WriteLine("Implicit conversion (int → double): " + convertedValue);

        // ---------------------------
        // MANUAL TYPE CONVERSION
        // ---------------------------
        double largeValue = 345.89;
        int reducedValue = (int)largeValue;
        Console.WriteLine("Explicit conversion (double → int): " + reducedValue);

        // ---------------------------
        // STRING TO NUMBER USING CONVERT
        // ---------------------------
        string numericText = "450";
        int parsedInt = Convert.ToInt32(numericText);
        Console.WriteLine("Converted string to int: " + parsedInt);

        double parsedDouble = Convert.ToDouble("678.90");
        Console.WriteLine("Converted string to double: " + parsedDouble);

        // ---------------------------
        // ACCESS CHARACTER FROM STRING
        // ---------------------------
        string greeting = "Welcome";
        char firstLetter = greeting[0];
        Console.WriteLine("First letter of \"" + greeting + "\": " + firstLetter);

        // ---------------------------
        // NUMBER TO STRING CONVERSION
        // ---------------------------
        int rollNumber = 101;
        string rollText = rollNumber.ToString();
        Console.WriteLine("Integer converted to string: " + rollText);

        // ---------------------------
        // CHARACTER TO ASCII NUMBER
        // ---------------------------
        char symbol = 'D';
        int asciiCode = symbol;
        Console.WriteLine("ASCII code of '" + symbol + "': " + asciiCode);

        Console.WriteLine();
    }
}
