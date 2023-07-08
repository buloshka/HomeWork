using System;
using System.Collections.Generic;

namespace VendingMachine
{
    public class VendingMachine
    {
        private int balance;
        private List<Transaction> transactions;
        private Dictionary<int, Product> products;

        public VendingMachine()
        {
            balance = 0;
            transactions = new List<Transaction>();
            products = new Dictionary<int, Product>();
        }

        public void AddMoney(ATMUser user)
        {
            Console.WriteLine("Выберите тип оплаты: 1 - наличными, 2 - картой данного банка, 3 - с карты другого банка");
            int paymentType = GetIntegerInput(0);

            if (paymentType == 1)
            {
                Console.WriteLine("Введите количество монет номиналом 1 рубль:");
                int coin1Count = GetIntegerInput(0);
                int coin1Total = coin1Count;

                Console.WriteLine("Введите количество монет номиналом 2 рубля:");
                int coin2Count = GetIntegerInput(0);
                int coin2Total = coin2Count * 2;

                Console.WriteLine("Введите количество монет номиналом 5 рублей:");
                int coin5Count = GetIntegerInput(0);
                int coin5Total = coin5Count * 5;

                Console.WriteLine("Введите количество монет номиналом 10 рублей:");
                int coin10Count = GetIntegerInput(0);
                int coin10Total = coin10Count * 10;

                int totalAmount = coin1Total + coin2Total + coin5Total + coin10Total;
                balance += totalAmount;
                user.Balance += totalAmount;

                Console.WriteLine($"Добавлено {totalAmount} рублей на баланс.");
                transactions.Add(new Transaction(DateTime.Now, $"Пополнение наличными: {totalAmount} рублей"));
            }
            else if (paymentType == 2)
            {
                Console.WriteLine("Оплата картой данного банка.");
                Console.WriteLine("Введите сумму для перевода:");
                int amount = GetIntegerInput(0);

                balance += amount;
                user.Balance += amount;

                Console.WriteLine($"Добавлено {amount} рублей на баланс.");
                transactions.Add(new Transaction(DateTime.Now, $"Пополнение картой данного банка: {amount} рублей"));
            }
            else if (paymentType == 3)
            {
                Console.WriteLine("Оплата с карты другого банка.");
                Console.WriteLine("Введите сумму для перевода:");
                int amount = GetIntegerInput(0);

                int commission = (int)Math.Round(amount * 0.05);
                int totalAmount = amount - commission;

                Console.WriteLine($"Внимание! Будет списана комиссия в размере {commission} рублей.");
                Console.WriteLine($"Итоговая сумма для перевода: {totalAmount} рублей.");

                Console.WriteLine("Подтвердите перевод (Y/N):");
                string confirmation = Console.ReadLine();

                if (confirmation.ToUpper() == "Y")
                {
                    balance += totalAmount;
                    user.Balance += totalAmount;

                    Console.WriteLine($"Добавлено {totalAmount} рублей на баланс.");
                    transactions.Add(new Transaction(DateTime.Now, $"Пополнение с карты другого банка: {totalAmount} рублей (комиссия: {commission} рублей)"));
                }
                else
                {
                    Console.WriteLine("Отмена перевода.");
                }
            }
            else
            {
                Console.WriteLine("Неверный тип оплаты.");
            }
        }

        public void GetChange(ATMUser user)
        {
            if (balance > 0)
            {
                Console.WriteLine("Сумма сдачи:");
                int remainingBalance = balance;

                int tenRubles = remainingBalance / 10;
                remainingBalance %= 10;

                int fiveRubles = remainingBalance / 5;
                remainingBalance %= 5;

                int twoRubles = remainingBalance / 2;
                remainingBalance %= 2;

                int oneRuble = remainingBalance;

                Console.WriteLine($"10 рублей: {tenRubles}");
                Console.WriteLine($" 5 рублей: {fiveRubles}");
                Console.WriteLine($" 2 рубля : {twoRubles}");
                Console.WriteLine($" 1 рубль : {oneRuble}");

                Console.WriteLine("Подтвердите получение сдачи (Y/N):");
                string confirmation = Console.ReadLine();

                if (confirmation.ToUpper() == "Y")
                {
                    Console.WriteLine("Сдача получена.");
                    transactions.Add(new Transaction(DateTime.Now, $"Получение сдачи: {balance} рублей"));

                    balance = 0;
                    user.Balance = 0;
                }
                else
                {
                    Console.WriteLine("Отмена получения сдачи.");
                }
            }
            else
            {
                Console.WriteLine("На балансе нет денег.");
            }
        }

        public void ShowGoods()
        {
            if (products.Count > 0)
            {
                Console.WriteLine("Товары:");
                Console.WriteLine("ID\tName\t\tCount\tPrice (₽)");

                foreach (var product in products.Values)
                {
                    Console.WriteLine($"{product.Id}\t{product.Name}\t{product.Count}\t{product.Price}");
                }
            }
            else
            {
                Console.WriteLine("Товары отсутствуют.");
            }
        }

        public void BuyGood(ATMUser user)
        {
            if (products.Count > 0)
            {
                int selectedProductId = 1;
                int selectedProductQuantity = 0;

                ConsoleKeyInfo keyInfo;
                bool confirmPurchase = false;

                do
                {
                    Console.Clear();
                    Console.WriteLine("Выберите товар:");

                    foreach (var product in products.Values)
                    {
                        string isSelected = (product.Id == selectedProductId) ? ">" : " ";
                        Console.WriteLine($"{isSelected} {product.Id}. {product.Name} ({product.Price} ₽)");
                    }

                    Console.WriteLine("\nИспользуйте стрелки для выбора товара. Нажмите Enter для продолжения.");

                    keyInfo = Console.ReadKey();

                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.UpArrow:
                            selectedProductId = Math.Max(selectedProductId - 1, 1);
                            break;
                        case ConsoleKey.DownArrow:
                            selectedProductId = Math.Min(selectedProductId + 1, products.Count);
                            break;
                        case ConsoleKey.Enter:
                            confirmPurchase = true;
                            break;
                        default:
                            break;
                    }
                }
                while (!confirmPurchase);

                Console.WriteLine($"\nВыбран товар: {products[selectedProductId].Name}.");

                Console.WriteLine("Введите количество товара: ");
                selectedProductQuantity = GetIntegerInput(0);

                if (selectedProductQuantity <= 0)
                {
                    Console.WriteLine("Неверное количество товара.");
                    return;
                }

                if (selectedProductQuantity > products[selectedProductId].Count)
                {
                    Console.WriteLine("Недостаточное количество товара.");
                    return;
                }

                int totalPrice = products[selectedProductId].Price * selectedProductQuantity;

                Console.WriteLine($"Итого к оплате: {totalPrice} ₽");
                Console.WriteLine("Подтвердите покупку (Y/N):");
                string confirmation = Console.ReadLine();

                if (confirmation.ToUpper() == "Y")
                {
                    if (user.Balance >= totalPrice)
                    {
                        balance += totalPrice;
                        user.Balance -= totalPrice;

                        products[selectedProductId].Count -= selectedProductQuantity;

                        Console.WriteLine("Покупка совершена.");

                        transactions.Add(new Transaction(DateTime.Now, $"Покупка товара: {products[selectedProductId].Name} (количество: {selectedProductQuantity}, сумма: {totalPrice} рублей)"));

                        if (products[selectedProductId].Count == 0)
                        {
                            products.Remove(selectedProductId);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Недостаточно средств на балансе.");
                    }
                }
                else
                {
                    Console.WriteLine("Отмена покупки.");
                }
            }
            else
            {
                Console.WriteLine("Товары отсутствуют.");
            }
        }

        public void ShowAccountInfo(ATMUser user)
        {
            Console.WriteLine($"Баланс счета: {user.Balance} рублей");
            Console.WriteLine("Операции со счетом:");

            foreach (Transaction transaction in transactions)
            {
                Console.WriteLine($"{transaction.Timestamp}: {transaction.Description}");
            }
        }

        private int GetIntegerInput(int minValue)
        {
            int input;

            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out input))
                {
                    Console.WriteLine("Неверный ввод. Пожалуйста, введите целое число.");
                }
                else if (input < minValue)
                {
                    Console.WriteLine($"Неверное значение. Введите число {minValue} или больше.");
                }
                else
                {
                    break;
                }
            }

            return input;
        }

        public void AddProduct(int id, string name, int count, int price)
        {
            if (products.ContainsKey(id))
            {
                Console.WriteLine($"Товар с ID {id} уже существует.");
                return;
            }

            Product product = new Product(id, name, count, price);
            products.Add(id, product);
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }

        public Product(int id, string name, int count, int price)
        {
            Id = id;
            Name = name;
            Count = count;
            Price = price;
        }
    }

    public class ATMUser
    {
        public string Bank { get; set; }
        public int Balance { get; set; }

        public ATMUser(string bank, int balance)
        {
            Bank = bank;
            Balance = balance;
        }
    }

    public class Transaction
    {
        public DateTime Timestamp { get; set; }
        public string Description { get; set; }

        public Transaction(DateTime timestamp, string description)
        {
            Timestamp = timestamp;
            Description = description;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            VendingMachine vendingMachine = new VendingMachine();

            vendingMachine.AddProduct(1, "Шоколадка Snickers", 5, 70);
            vendingMachine.AddProduct(2, "Чипсы Lay's", 3, 50);
            vendingMachine.AddProduct(3, "Газировка Coca-Cola", 8, 80);
            vendingMachine.AddProduct(4, "Печенье Oreo", 2, 60);
            vendingMachine.AddProduct(5, "Конфеты Raffaello", 1, 120);
            vendingMachine.AddProduct(6, "Мороженое Magnum", 4, 90);
            vendingMachine.AddProduct(7, "Сок Tropicana", 7, 100);
            vendingMachine.AddProduct(8, "Шоколад KitKat", 6, 65);
            vendingMachine.AddProduct(9, "Сникерс Минис", 10, 55);
            vendingMachine.AddProduct(10, "Попкорн Pop Secret", 1, 85);
            vendingMachine.AddProduct(11, "Вода газ", 10, 35);
            vendingMachine.AddProduct(12, "Вода минерал", 10, 35);
            vendingMachine.AddProduct(13, "Сок вишня", 10, 76);
            vendingMachine.AddProduct(14, "Конфеты кислые", 10, 56);
            vendingMachine.AddProduct(15, "Энергетик", 10, 75);

            ATMUser user = new ATMUser("МойБанк", 0);

            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Выберите команду:");
                Console.WriteLine("1 - AddMoney");
                Console.WriteLine("2 - GetChange");
                Console.WriteLine("3 - ShowGoods");
                Console.WriteLine("4 - BuyGood");
                Console.WriteLine("5 - ShowAccountInfo");
                Console.WriteLine("0 - Выход");

                string command = Console.ReadLine();

                switch (command)
                {
                    case "1":
                        vendingMachine.AddMoney(user);
                        break;
                    case "2":
                        vendingMachine.GetChange(user);
                        break;
                    case "3":
                        vendingMachine.ShowGoods();
                        break;
                    case "4":
                        vendingMachine.BuyGood(user);
                        break;
                    case "5":
                        vendingMachine.ShowAccountInfo(user);
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Найдено 0 команд");
                        Console.ResetColor();
                        break;
                }

                Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                Console.ReadKey();
            }
        }
    }
}
