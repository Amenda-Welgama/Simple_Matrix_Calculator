using System;

class MatrixCalculator
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n=== Matrix Calculator ===");
            Console.WriteLine("1. Add Matrices");
            Console.WriteLine("2. Subtract Matrices");
            Console.WriteLine("3. Multiply Matrices");
            Console.WriteLine("4. Transpose Matrix");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice (1-5): ");

            string input = Console.ReadLine();
            if (!int.TryParse(input, out int choice))
            {
                Console.WriteLine("Invalid input. Try again.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    MatrixAddition();
                    break;
                case 2:
                    MatrixSubtraction();
                    break;
                case 3:
                    MatrixMultiplication();
                    break;
                case 4:
                    MatrixTranspose();
                    break;
                case 5:
                    Console.WriteLine("Exiting... Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice! Try again.");
                    break;
            }
        }
    }

    static int[,] ReadMatrix(int rows, int cols)
    {
        int[,] matrix = new int[rows, cols];
        Console.WriteLine("Enter matrix elements:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write($"Element [{i},{j}]: ");
                matrix[i, j] = int.Parse(Console.ReadLine());
            }
        }
        return matrix;
    }

    static void PrintMatrix(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        Console.WriteLine("Result:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    static void MatrixAddition()
    {
        Console.Write("Enter rows: ");
        int rows = int.Parse(Console.ReadLine());
        Console.Write("Enter columns: ");
        int cols = int.Parse(Console.ReadLine());

        Console.WriteLine("Matrix A:");
        int[,] A = ReadMatrix(rows, cols);

        Console.WriteLine("Matrix B:");
        int[,] B = ReadMatrix(rows, cols);

        int[,] result = new int[rows, cols];
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                result[i, j] = A[i, j] + B[i, j];

        PrintMatrix(result);
    }

    static void MatrixSubtraction()
    {
        Console.Write("Enter rows: ");
        int rows = int.Parse(Console.ReadLine());
        Console.Write("Enter columns: ");
        int cols = int.Parse(Console.ReadLine());

        Console.WriteLine("Matrix A:");
        int[,] A = ReadMatrix(rows, cols);

        Console.WriteLine("Matrix B:");
        int[,] B = ReadMatrix(rows, cols);

        int[,] result = new int[rows, cols];
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                result[i, j] = A[i, j] - B[i, j];

        PrintMatrix(result);
    }

    static void MatrixMultiplication()
    {
        Console.Write("Enter rows for Matrix A: ");
        int r1 = int.Parse(Console.ReadLine());
        Console.Write("Enter columns for Matrix A / rows for Matrix B: ");
        int c1 = int.Parse(Console.ReadLine());
        Console.Write("Enter columns for Matrix B: ");
        int c2 = int.Parse(Console.ReadLine());

        Console.WriteLine("Matrix A:");
        int[,] A = ReadMatrix(r1, c1);

        Console.WriteLine("Matrix B:");
        int[,] B = ReadMatrix(c1, c2);

        int[,] result = new int[r1, c2];

        for (int i = 0; i < r1; i++)
        {
            for (int j = 0; j < c2; j++)
            {
                result[i, j] = 0;
                for (int k = 0; k < c1; k++)
                {
                    result[i, j] += A[i, k] * B[k, j];
                }
            }
        }

        PrintMatrix(result);
    }

    static void MatrixTranspose()
    {
        Console.Write("Enter rows: ");
        int rows = int.Parse(Console.ReadLine());
        Console.Write("Enter columns: ");
        int cols = int.Parse(Console.ReadLine());

        Console.WriteLine("Matrix:");
        int[,] A = ReadMatrix(rows, cols);

        int[,] transpose = new int[cols, rows];
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                transpose[j, i] = A[i, j];

        PrintMatrix(transpose);
    }
}
