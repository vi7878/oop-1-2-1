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
                    break;
                case 2:
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
}

