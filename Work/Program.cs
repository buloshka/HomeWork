namespace HomeWork;

public static class First
{
    public static void Main()
    {
        // Task 1
        Console.WriteLine("Задание 1.");
        for (int i = 1; i < 101; i++)
        {
            if (i % 2 != 0) Console.Write(i + " ");
        }


        // Task 2
        Console.WriteLine("\n\nЗадание 2");
        int firstNum = 0;
        int secondNum = 1;

        for (int i = 0; i < 10; i++)
        {
            Console.Write(firstNum + " ");

            firstNum = firstNum + secondNum;
            secondNum = firstNum - secondNum;
        }


        // Task 3
        Console.WriteLine("\n\nЗадание 3");

        int start = 10;
        double percent = 0.1;
        int finish = 100;

        double days = Math.Round(Math.Log(finish / start, (1 + percent) * 10 / start), 5);
        int seconds = (int)(days * 24 * 60 * 60);
        int totalD = seconds / (24 * 60 * 60);
        int totalH = (seconds / (60 * 60)) % 24;
        int totalM = (seconds / 60) % 60;
        int totalS = seconds % 60;


        Console.WriteLine($"Лыжнику потребуется {totalD} дня " +
                          $"{totalH} часа {totalM} минут {totalS} секунд");

        Console.ReadKey();
    }
}