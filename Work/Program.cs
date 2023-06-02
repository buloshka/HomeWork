namespace HomeWork;

public static class Third
{
    static void Main()
    {
        First();
        Second();
        Additionaly();
    }

    static void First()
    {
        string[,] table = {
            { "Ученик", "Информатика(1)", "Разработка игр(2)", "Основы алгоритмизации(3)" },
            { "1", "", "", "" },
            { "2", "", "", "" },
            { "3", "", "", "" },
            { "4", "", "", "" },
            { "5", "", "", "" }
        };

        Console.WriteLine("Задание 1");

        DisplayTable(table);

        bool exit = false;

        while (!exit)
        {
            Console.Write("Хотите заполнить таблицу? (y/n): ");
            string input = Console.ReadLine();

            if (input == "y")
            {
                Console.Clear();
                Console.WriteLine("Задание 1");
                DisplayTable(table);

                for (int studentIndex = 1; studentIndex < table.GetLength(0); studentIndex++)
                {
                    for (int subjectIndex = 1; subjectIndex < table.GetLength(1); subjectIndex++)
                    {
                        Console.Write($"Введите оценку {studentIndex} ученика {subjectIndex} предмета: ");
                        string gradeString = Console.ReadLine();
                        int grade;

                        if (int.TryParse(gradeString, out grade) && grade > 1 && grade < 6)
                        {
                            table[studentIndex, subjectIndex] = grade.ToString();
                            Console.Clear();
                            DisplayTable(table);
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ввод.");
                            subjectIndex--;
                        }
                    }
                }

                break;
            }
            else
            {
                exit = true;
            }
        }

        Console.WriteLine("Изменение таблицы");

        while (!exit)
        {
            Console.Write("Введите номер ученика (1-5): ");
            string student = Console.ReadLine();
            int studentIndex;

            if (int.TryParse(student, out studentIndex) && studentIndex >= 1 && studentIndex <= 5)
            {
                Console.Write("Введите номер предмета (1-3): ");
                string subject = Console.ReadLine();
                int subjectIndex;

                if (int.TryParse(subject, out subjectIndex) && subjectIndex >= 1 && subjectIndex <= 3)
                {
                    Console.Write("Введите новую оценку(2, 3, 4, 5): ");
                    string gradeString = Console.ReadLine();
                    int grade;

                    if (int.TryParse(gradeString, out grade) && grade > 1 && grade < 6)
                    {
                        table[studentIndex, subjectIndex] = grade.ToString();
                        Console.Clear();
                        DisplayTable(table);
                    }
                    else
                    {
                        Console.WriteLine("Некорректный ввод.");
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный ввод. Введите номер предмета от 1 до 3.");
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод. Введите номер ученика от 1 до 5.");
            }

            Console.WriteLine("Хотите внести еще изменения? (y/n): ");
            string choice = Console.ReadLine();

            if (choice.ToLower() != "y")
            {
                exit = true;
                Console.Clear();
            }
        }

        Console.Clear();
    }

    static void DisplayTable(string[,] table)
    {
        int rowCount = table.GetLength(0);
        int columnCount = table.GetLength(1);

        for (int row = 0; row < rowCount; row++)
        {
            for (int col = 0; col < columnCount; col++)
            {
                Console.Write($"{table[row, col],-20} | ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    static void Second()
    {
        int[] array = GenerateRandomArray(10);

        Console.WriteLine("Задание 2");

        Console.WriteLine("1) Все элементы массива:");
        PrintArray(array);

        Console.WriteLine("\n\n2) Элементы массива в обратном порядке:");
        PrintReverseArray(array);

        Console.WriteLine("\n\n3) Элементы массива через 1:");
        PrintEvenIndex(array);

        Console.WriteLine("\n\n4) Элементы массива до элемента -1:");
        PrintArrayUntilMinusOne(array);

        Console.WriteLine("\n\nНажмите любую клавишу, что перейти к след. заданию");
        Console.ReadKey();
        Console.Clear();
    }

    static int[] GenerateRandomArray(int length)
    {
        int[] array = new int[length];
        Random random = new Random();

        for (int i = 0; i < length; i++)
        {
            array[i] = random.Next(-100, 100);
        }

        return array;
    }

    static void PrintArray(int[] array)
    {
        foreach (int element in array)
        {
            Console.Write(element + " ");
        }
    }

    static void PrintReverseArray(int[] array)
    {
        for (int i = array.Length - 1; i >= 0; i--)
        {
            Console.Write(array[i] + " ");
        }
    }

    static void PrintEvenIndex(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (i % 2 == 0)
            {
                Console.Write(array[i] + " ");
            }
        }
    }

    static void PrintArrayUntilMinusOne(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == -1)
            {
                break;
            }

            Console.Write(array[i] + " ");
        }
    }

    static void Additionaly()
    {
        int[,] temp =
        {
            { -8, -14, -19, -18 },
            { 25, 28, 26, 20 },
            { 11, 18, 20, 25 }
        };

        Console.WriteLine("Задание 3");

        Console.WriteLine("1) Температура на 2 метеостанции за 4 день: " + temp[1, 3]);
        Console.WriteLine("   Температура на 3 метеостанции за 1 день: " + temp[2, 0]);

        Console.WriteLine("\n2) Значения температур всех метеостанций за 2 день:");
        for (int i = 0; i < temp.GetLength(0); i++)
        {
            Console.WriteLine("   Метеостанция " + (i + 1) + ": " + temp[i, 1]);
        }

        Console.WriteLine("\n3) Значения температур всех метеостанций за все дни:");
        Console.WriteLine("   Метеостанция | День 1 | День 2 | День 3 | День 4");
        Console.WriteLine("   --------------------------------------------");
        for (int i = 0; i < temp.GetLength(0); i++)
        {
            Console.Write("   Метеостанция " + (i + 1) + ": ");
            for (int j = 0; j < temp.GetLength(1); j++)
            {
                Console.Write(temp[i, j] + "     ");
            }
            Console.WriteLine();
        }

        Console.Write("\n4) Средняя температура на 3 метеостанции: ");
        int totalTemperature = 0;
        int count = 0;

        for (; count < temp.GetLength(1); count++)
        {
            totalTemperature += temp[2, count];
        }

        double averageTemperature = (double)totalTemperature / count;

        Console.WriteLine(averageTemperature);

        Console.WriteLine("\n5) Метеостанции и дни с температурой в диапазоне 24-26 градусов:");
        for (int i = 0; i < temp.GetLength(0); i++)
        {
            for (int j = 0; j < temp.GetLength(1); j++)
            {
                if (temp[i, j] >= 24 && temp[i, j] <= 26)
                {
                    Console.WriteLine("   Метеостанция " + (i + 1) + ", День " + (j + 1));
                }
            }
        }

        Console.WriteLine("Для завершения нажмите любую клавишу");
        Console.ReadKey();
    }
}