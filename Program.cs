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
                string Select; // переменная для контроля повторного запуска
                do // внешний цикл для повторного запуска 
                {
                    Console.WriteLine("\n--- Новый расчет ---");
                    Console.Write("Введите стартовый капитал (initialCapital): ");
                    double initialCapital = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Введите ежемесячный рост дохода в процентах (monthlyGrowthPercent): ");
                    double monthlyGrowthPercent = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Введите целевую сумму (stargetAmount): ");
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
                        Console.WriteLine("\nОшибка: Целевая сумма (stargetAmount) должна быть больше стартового капитала (initialCapital)!");
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        return;
                    }
                    double sum = 0; // инициализация накопленной суммы
                    double currentIncome = initialCapital; // текущий ежемесячный доход
                    int month = 0; // месяц
                    int maxMonth = 10000; // верхняя граница цикла
                    do // внутренний цикл с постусловием для расчета накоплений
                    {
                        month ++; // изменение шага, инкремент
                        sum += currentIncome; // накопление текущей суммы
                        if (sum >= targetAmount)
                        {
                            break; // досрочный выход из цикла
                        }
                        currentIncome = currentIncome * (1 + monthlyGrowthPercent / 100); // расчет увеличения дохода
                    }
                    while (month <= maxMonth);
                    double year = (double)month / 12.0;
                    Console.WriteLine($"\nДаня М. сможет отправиться в тур через {Math.Round(year, 1)} лет.");
                    Console.Write("\nХотите выполнить программу еще раз? (да - 1/нет - любая клавиша): ");
                    Select = Console.ReadLine();
                }
                while (Select == "1"); // проверка ответа (1 - да)
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
}
