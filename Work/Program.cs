namespace HomeWork;

public static class First
{
    public static void Main()
    {
        // Task 1
        double absoluteZero = -273.15;

        Console.WriteLine("Задание 1");

        Console.Write($"Введите температуру в цельсиях (не ниже {absoluteZero}): ");
        string input = Console.ReadLine();
        double tempC = double.Parse(input);

        if (tempC >= absoluteZero)
        {
            double tempF = tempC * 1.8 + 32;
            double tempK = tempC + 273.15;
            Console.Write($"\nТемпература {tempC}°C в\nфаренгейтах равна {tempF}°F\nкельвинах равна {tempK}°K\n\n");
        }
        else
        {
            Console.WriteLine($"Температуратне может быть ниже {absoluteZero}\n\n");
        }


        //Task 2
        string operators = "+-/*%";

        Console.WriteLine("Задание 2");

        Console.Write($"Оператор ({operators}): ");
        string operation = Console.ReadLine();

        Console.Write("Введите число a: ");
        double a = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите число b: ");
        double b = Convert.ToDouble(Console.ReadLine());

        double result = 0;

        switch (operation)
        {
            case "+":
                result = a + b;
                Console.WriteLine($"\nСумма чисел a и b равняется: {result}.\n\n");
                break;
            case "-":
                result = a - b;
                Console.WriteLine($"\nРазность чисел a и b равняется: {result}.\n\n");
                break;
            case "*":
                result = a * b;
                Console.WriteLine($"\nПроизведение чисел a и b равняется: {result}.\n\n");
                break;
            case "/":
                if (b != 0)
                {
                    result = a / b;
                    Console.WriteLine($"\nЧастное чисел a и b равняется: {result}.\n\n");
                }
                else
                {
                    Console.WriteLine("\nОшибка: деление на ноль невозможно.\n\n");
                }
                break;
            case "%":
                if (b != 0)
                {
                    result = a % b;
                    Console.WriteLine($"\nОстаток от деления чисел a и b равняется: {result}.\n\n");
                }
                else
                {
                    Console.WriteLine("\nОшибка: деление на ноль невозможно.\n\n");
                }
                break;
            default:
                Console.WriteLine("\nОшибка: недопустимый оператор.\n\n");
                break;
        }


        // Task 3
        Console.WriteLine("Задание 3");

        Console.Write("Введите первый однозначный множитель: ");
        int firstMultiplier;
        bool isFirstMultiplierValid = int.TryParse(Console.ReadLine(), out firstMultiplier);

        Console.Write("Введите второй однозначный множитель: ");
        int secondMultiplier;
        bool isSecondMultiplierValid = int.TryParse(Console.ReadLine(), out secondMultiplier);

        if (isFirstMultiplierValid && isFirstMultiplierValid && firstMultiplier >= 0 && firstMultiplier <= 9 && secondMultiplier >= 0 && secondMultiplier <= 9)
        {
            int composition = firstMultiplier * secondMultiplier;

            Console.Write("Введите произведение введенных чисел: ");
            int userComposition;
            bool isUserCompositionValid = int.TryParse(Console.ReadLine(), out userComposition);

            // Проверка правильности введенного произведения
            if (isUserCompositionValid && composition == userComposition)
            {
                Console.WriteLine($"Верно, ответ {userComposition}.\n\n");
            }
            else
            {
                Console.WriteLine($"Неверно, верный ответ {composition}.\n\n");
            }
        }
        else
        {
            Console.WriteLine("Неверный ввод чисел.\n\n");
        }


        // Task 4
        string yearName = "";

        Console.WriteLine("Задание 4");

        Console.Write("Введите возраст от 1 до 99: ");
        int age = int.Parse(Console.ReadLine());

        if (age < 1 || age > 99)
        {
            Console.WriteLine("Неверное значение.\n\n");
        }
        else
        {
            switch (age)
            {
                case int i when (i >= 11 && i <= 14):
                    yearName = "лет";
                    break;
                default:
                    int remainder = age % 10;

                    if (remainder >= 5 || remainder == 0)
                    {
                        yearName = "лет";
                    }
                    else if (remainder == 1)
                    {
                        yearName = "год";
                    }
                    else
                    {
                        yearName = "года";
                    }
                    break;
            }

            Console.WriteLine($"Возраст равняется {age} {yearName}.\n\n");
        }


        // *
        Console.WriteLine("Дополнительные задания, которые мы не успели сделать на занятиях.\n");

        Console.WriteLine("Задача про банк:");

        decimal depositAmount = 0;
        bool isValidAmount = false;

        while (!isValidAmount)
        {
            Console.Write("Введите сумму вклада: ");
            input = Console.ReadLine();

            if (decimal.TryParse(input, out depositAmount))
            {
                isValidAmount = true;
            }
            else
            {
                Console.WriteLine("Неверный формат суммы. Попробуйте ещё раз.\n\n");
            }
        }

        decimal interestRate;

        if (depositAmount < 100)
        {
            interestRate = 0.05m;
        }
        else if (depositAmount >= 100 && depositAmount <= 200)
        {
            interestRate = 0.07m;
        }
        else
        {
            interestRate = 0.1m;
        }

        decimal totalAmount = depositAmount + (depositAmount * interestRate);

        Console.WriteLine($"Сумма вклада с начисленными процентами: {totalAmount}\n\n");


        Console.WriteLine("Задача про перевод валют:");
        decimal usdAmount = 0;
        isValidAmount = false;

        while (!isValidAmount)
        {
            Console.Write("Введите сумму в долларах США: ");
            input = Console.ReadLine();

            if (decimal.TryParse(input, out usdAmount))
            {
                isValidAmount = true;
            }
            else
            {
                Console.WriteLine("Неверный формат суммы. Попробуйте ещё раз.");
            }
        }

        decimal exchangeRate = 6.75m;
        decimal cnyAmount = usdAmount * exchangeRate;

        string reslt = cnyAmount.ToString("0.00");
        Console.WriteLine($"{reslt} Китайский юань");


        Console.ReadKey();
    }
}