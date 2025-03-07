using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nвыбери действие:");
            Console.WriteLine("1. проверить телефон");
            Console.WriteLine("2. найти даты");
            Console.WriteLine("3. скрыть цифры");
            Console.WriteLine("4. разделить текст");
            Console.WriteLine("5. выход");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("введи номер телефона:");
                    string phone = Console.ReadLine();
                    Console.WriteLine(CheckPhone(phone) ? "телефон верный" : "телефон неверный");
                    break;

                case "2":
                    Console.WriteLine("введи текст с датами:");
                    string textWithDates = Console.ReadLine();
                    Console.WriteLine("найдены даты: " + string.Join(", ", FindDates(textWithDates)));
                    break;

                case "3":
                    Console.WriteLine("введи текст с цифрами:");
                    string textWithDigits = Console.ReadLine();
                    Console.WriteLine("результат: " + ReplaceDigits(textWithDigits));
                    break;

                case "4":
                    Console.WriteLine("введи текст для разделения:");
                    string textToSplit = Console.ReadLine();
                    Console.WriteLine("разделенные части: " + string.Join(" | ", SplitText(textToSplit)));
                    break;

                case "5":
                    return;

                default:
                    Console.WriteLine("неверный выбор, попробуй снова");
                    break;
            }
        }
    }

    // проверка формата телефона (+7/8 и 10 цифр)
    static bool CheckPhone(string text) => Regex.IsMatch(text, @"^(\+7|8)\d{10}$");

    // поиск дат вида 31.12.2023
    static List<string> FindDates(string text) =>
        new List<string>(Regex.Matches(text, @"\b\d{2}\.\d{2}\.\d{4}\b").Cast<Match>().Select(m => m.Value));

    // замена всех цифр на *
    static string ReplaceDigits(string text) => Regex.Replace(text, @"\d", "*");

    // разделение по запятым/точкам/пробелам
    static string[] SplitText(string text) => Regex.Split(text, @"[ ,.]+").Where(s => s != "").ToArray();
}
