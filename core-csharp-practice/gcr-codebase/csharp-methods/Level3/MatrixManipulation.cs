using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter rows for Matrix A: ");
        int r1 = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter columns for Matrix A: ");
        int c1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter rows for Matrix B: ");
        int r2 = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter columns for Matrix B: ");
        int c2 = Convert.ToInt32(Console.ReadLine());

        double[,] A = CreateRandomMatrix(r1, c1);
        double[,] B = CreateRandomMatrix(r2, c2);

        Console.WriteLine("\nMatrix A:");
        DisplayMatrix(A);

        Console.WriteLine("\nMatrix B:");
        DisplayMatrix(B);

        if (r1 == r2 && c1 == c2)
        {
            Console.WriteLine("\nA + B:");
            DisplayMatrix(AddMatrices(A, B));

            Console.WriteLine("\nA - B:");
            DisplayMatrix(SubtractMatrices(A, B));
        }

        if (c1 == r2)
        {
            Console.WriteLine("\nA × B:");
            DisplayMatrix(MultiplyMatrices(A, B));
        }

        Console.WriteLine("\nTranspose(A):");
        DisplayMatrix(Transpose(A));

        Console.WriteLine("\nTranspose(B):");
        DisplayMatrix(Transpose(B));

        if (A.Length == 4)   // 2x2
        {
            Console.WriteLine("\nDeterminant of A (2x2): " + Determinant2x2(A));
            Console.WriteLine("\nInverse of A (2x2):");
            DisplayMatrix(Invert2x2(A));
        }

        if (A.Length == 9)  // 3x3
        {
            Console.WriteLine("\nDeterminant of A (3x3): " + Determinant3x3(A));
            Console.WriteLine("\nInverse of A (3x3):");
            DisplayMatrix(Invert3x3(A));
        }
    }

    // a) Create random matrix
    static double[,] CreateRandomMatrix(int rows, int cols)
    {
        double[,] m = new double[rows, cols];
        Random rnd = new Random();

        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                m[i, j] = rnd.Next(1, 10); // 1–9

        return m;
    }

    // b) Addition
    static double[,] AddMatrices(double[,] A, double[,] B)
    {
        int r = A.GetLength(0);
        int c = A.GetLength(1);
        double[,] res = new double[r, c];

        for (int i = 0; i < r; i++)
            for (int j = 0; j < c; j++)
                res[i, j] = A[i, j] + B[i, j];

        return res;
    }

    // c) Subtraction
    static double[,] SubtractMatrices(double[,] A, double[,] B)
    {
        int r = A.GetLength(0);
        int c = A.GetLength(1);
        double[,] res = new double[r, c];

        for (int i = 0; i < r; i++)
            for (int j = 0; j < c; j++)
                res[i, j] = A[i, j] - B[i, j];

        return res;
    }

    // d) Multiplication
    static double[,] MultiplyMatrices(double[,] A, double[,] B)
    {
        int r1 = A.GetLength(0);
        int c1 = A.GetLength(1);
        int c2 = B.GetLength(1);

        double[,] res = new double[r1, c2];

        for (int i = 0; i < r1; i++)
            for (int j = 0; j < c2; j++)
                for (int k = 0; k < c1; k++)
                    res[i, j] += A[i, k] * B[k, j];

        return res;
    }

    // Transpose
    static double[,] Transpose(double[,] A)
    {
        int r = A.GetLength(0), c = A.GetLength(1);
        double[,] t = new double[c, r];

        for (int i = 0; i < r; i++)
            for (int j = 0; j < c; j++)
                t[j, i] = A[i, j];

        return t;
    }

    // e) Determinant 2x2
    static double Determinant2x2(double[,] A)
    {
        return A[0,0] * A[1,1] - A[0,1] * A[1,0];
    }

    // f) Determinant 3x3
    static double Determinant3x3(double[,] A)
    {
        return
            A[0,0] * (A[1,1] * A[2,2] - A[1,2] * A[2,1]) -
            A[0,1] * (A[1,0] * A[2,2] - A[1,2] * A[2,0]) +
            A[0,2] * (A[1,0] * A[2,1] - A[1,1] * A[2,0]);
    }

    // g) Inverse 2x2
    static double[,] Invert2x2(double[,] A)
    {
        double det = Determinant2x2(A);
        if (det == 0) throw new Exception("Matrix not invertible");

        double[,] inv = new double[2, 2];
        inv[0, 0] =  A[1, 1] / det;
        inv[0, 1] = -A[0, 1] / det;
        inv[1, 0] = -A[1, 0] / det;
        inv[1, 1] =  A[0, 0] / det;

        return inv;
    }

    // h) Inverse 3x3 (Adjoint / determinant)
    static double[,] Invert3x3(double[,] A)
    {
        double det = Determinant3x3(A);
        if (det == 0) throw new Exception("Matrix not invertible");

        double[,] adj = new double[3, 3];

        adj[0,0] =  (A[1,1]*A[2,2] - A[1,2]*A[2,1]);
        adj[0,1] = -(A[1,0]*A[2,2] - A[1,2]*A[2,0]);
        adj[0,2] =  (A[1,0]*A[2,1] - A[1,1]*A[2,0]);

        adj[1,0] = -(A[0,1]*A[2,2] - A[0,2]*A[2,1]);
        adj[1,1] =  (A[0,0]*A[2,2] - A[0,2]*A[2,0]);
        adj[1,2] = -(A[0,0]*A[2,1] - A[0,1]*A[2,0]);

        adj[2,0] =  (A[0,1]*A[1,2] - A[0,2]*A[1,1]);
        adj[2,1] = -(A[0,0]*A[1,2] - A[0,2]*A[1,0]);
        adj[2,2] =  (A[0,0]*A[1,1] - A[0,1]*A[1,0]);

        double[,] inv = new double[3, 3];

        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                inv[i, j] = adj[i, j] / det;

        return inv;
    }

    // i) Display matrix
    static void DisplayMatrix(double[,] A)
    {
        int r = A.GetLength(0), c = A.GetLength(1);
        for (int i = 0; i < r; i++)
        {
            for (int j = 0; j < c; j++)
                Console.Write(A[i,j] + "\t");
            Console.WriteLine();
        }
    }
}
