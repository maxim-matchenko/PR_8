//****************************************************************************
//* Практическая работа N8                                                   *
//* Выполнил: Матченко M.C., группа 2-ИСП-оКФ                                *
//* Вариант 4                                                                *
//* Задание: Составление программ циклическкой структуры: Итерационный цикл  *
//****************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PR_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Практическая работа №8";
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Clear();
            Console.WriteLine("Здравствуйте!");
            try
            {
                string Select;// Переменная для контроля повторного запуска
                do // внешний цикл для повторного запуска 
                {
                    Console.WriteLine("\n--- Новый расчет ---");
                    Console.Write("Введите стартовый капитал (n): ");
                    double n = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Введите ежемесячный рост дохода в процентах (p): ");
                    double p = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Введите целевую сумму (s): ");
                    double s = Convert.ToDouble(Console.ReadLine());
                    double sum = 0;
                    double d = n;
                    int m = 0;
                    int max = 10000;
                    do// Внутренний цикл с постусловием для расчета накоплений
                    {
                        m++; // Изменение шага, инкремент
                        sum += d; // Накопление суммы
                        if (sum >= s)
                        {
                            break; // Досрочный выход из цикла
                        }
                        d = d * (1 + p / 100); // Расчет увеличения дохода
                    }
                    while (m <= max);
                    double year = m / 12.0;
                    Console.WriteLine($"Даня М. сможет отправиться в тур через {Math.Round(year, 1)} лет.");
                    Console.Write("\nХотите выполнить программу еще раз? (да - 1/нет - любая клавиша): ");
                    Select = Console.ReadLine();
                }
                while (Select == "1"); // Проверка ответов  1- да)
                Console.WriteLine("\nПрограмма завершена. Нажмите любую клавишу для выхода...");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Что-то пошло не так. Ошибка: " + ex.Message);
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
            }
            Console.ReadKey();
        }
    }
}
