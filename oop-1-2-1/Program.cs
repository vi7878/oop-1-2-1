using System;
class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Виберіть дії над двома матрицями:");
            Console.WriteLine("1. Додавання");
            Console.WriteLine("2. Множення");
            Console.WriteLine("3. Транспонування");
            Console.WriteLine("4. Вийти");
            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Неправильний ввід. Введіть ще раз.");
                continue;
            }
            switch (choice)
            {
                case 1:
                    PerformAddition();
                    break;
                case 2:
                    PerformMultiplication();
                    break;
                case 3:
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("Неправильний вибір. Введіть ще раз.");
                    break;
            }
        }
    }
    static MyMatrix InputMatrix(string matrixName)
    {
        Console.WriteLine($"Введіть розміри матриці {matrixName} (Записати у вигляді:рядки стовпці):");
        string[] dimensions = Console.ReadLine().Split();
        int rows = int.Parse(dimensions[0]);
        int cols = int.Parse(dimensions[1]);
        Console.WriteLine($"Введіть елементи матриці {matrixName} (по одному рядку, числа розділені пробілами):");
        string[] matrixRows = new string[rows];
        for (int i = 0; i < rows; i++)
        {
            matrixRows[i] = Console.ReadLine();
        }
        return new MyMatrix(matrixRows);
    }
    static void PerformAddition()
    {
        try
        {
            MyMatrix matrix1 = InputMatrix("A");
            MyMatrix matrix2 = InputMatrix("B");
            MyMatrix result = matrix1 + matrix2;
            Console.WriteLine("\nРезультат додавання:");
            Console.WriteLine(result.ToString());
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
    }
    static void PerformMultiplication()
    {
        try
        {
            MyMatrix matrix1 = InputMatrix("A");
            MyMatrix matrix2 = InputMatrix("B");
            MyMatrix result = matrix1 * matrix2;
            Console.WriteLine("\nРезультат множення:");
            Console.WriteLine(result.ToString());
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
    }
    static void PerformTransposition()
    {
        try
        {
            MyMatrix matrix = InputMatrix("A");
            Console.WriteLine("\nВихідна матриця:");
            Console.WriteLine(matrix.ToString());
            MyMatrix transposed = matrix.GetTransponedCopy();
            Console.WriteLine("\nТранспонована матриця:");
            Console.WriteLine(transposed.ToString());
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
    }
}

