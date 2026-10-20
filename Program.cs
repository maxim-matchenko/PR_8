//****************************************************************************
//* Практическая работа N8                                                   *
//* Выполнил: Матченко M.C., группа 2-ИСП-оКФ                                *
//* Вариант 4                                                                *
//* Задание: Составление программ циклической структуры: Итерационный цикл   *
//****************************************************************************
using System;
namespace PR_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Практическая работа №8";
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Clear(); // очистка консоли
            Console.WriteLine("Здравствуйте!");
            try
            {
                string select; // переменная для контроля повторного запуска
                do // внешний цикл для повторного запуска 
                {
                    Console.WriteLine("\n--- Новый расчет ---");
                    Console.Write("Введите стартовый капитал: ");
                    double initialCapital = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Введите ежемесячный рост дохода в процентах: ");
                    double monthlyGrowthPercent = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Введите целевую сумму: ");
                    double targetAmount = Convert.ToDouble(Console.ReadLine());
                    if (initialCapital <= 0 || monthlyGrowthPercent <= 0 || targetAmount <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\nОшибка: Введенные значения должны быть больше нуля!");
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        return;
                    }
                    if (targetAmount <= initialCapital)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\nОшибка: Целевая сумма должна быть больше стартового капитала!");
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        return;
                    }
                    double sum = 0;
                    double currentIncome = initialCapital;
                    int month = 0;
                    int maxMonth = 10000;
                    do // внутренний цикл с постусловием для расчета накоплений
                    {
                        month++;
                        sum += currentIncome;
                        if (sum >= targetAmount) break;
                        currentIncome *= 1 + monthlyGrowthPercent / 100; // расчет увеличения дохода
                    }
                    while (month <= maxMonth);
                    double year = (double)month / 12.0;
                    Console.WriteLine($"\nДаня М. сможет отправиться в тур через {Math.Round(year, 1)} лет.");
                    Console.Write("\nХотите выполнить программу еще раз? (да - 1/нет - любая клавиша): ");
                    select = Console.ReadLine();
                }
                while (select == "1"); // проверка ответа (1 - да)
                Console.WriteLine("\nПрограмма завершена. Нажмите любую клавишу для выхода...");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\nЧто-то пошло не так. Ошибка: " + ex.Message);
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.ReadKey();
            }
        }
    }
