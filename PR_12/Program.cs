/************************************************************************************
/* Практическая работа №12                                                          *
/* Выполнила: Корнеева В.Е., 2-ИСП                                                  *
/* Задание: Перевод из верхнего регистра в нижний                                   *
/************************************************************************************/
using System;

public class Program
{
    static void Errors(Exception exception)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Упс.. ошибочка вышла: {exception.Message}");
    }
    public static string ToLowerCase(string str)  // Функция для перевода строки в нижний регистр
    {
        str = str.Trim(); // Обрезаем пробелы
        if (string.IsNullOrEmpty(str))
        {
            throw new Exception("Вы ничего не ввели или текст указан некорректно");
        }
        bool onlyLatinLetters = true;
        foreach (char c in str) 
        {
            if (!((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z')))
            {
                onlyLatinLetters = false;
                break; 
            }
        }
        if (!onlyLatinLetters)
        {
            // Преобразуем в нижний регистр только если есть НЕ латинские буквы
            char[] chars = str.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (char.IsUpper(chars[i]))
                {
                    chars[i] = char.ToLower(chars[i]);
                }
            }
            return new string(chars);
        }
        else
        {
            return str; // Возвращаем исходную строку, если только латинские буквы
        }
    }
    public static void Main(string[] args)
    {
        for (; ; )
        {
            try
            {
                Console.Title = "Практическа работа №12";
                Console.ForegroundColor = ConsoleColor.Yellow; //ввод исходной строки
                Console.Write("Введите строку: ");
                string n = Console.ReadLine();
                string g = ToLowerCase(n);
                Console.ForegroundColor = ConsoleColor.Cyan; //вывод обеих строк
                Console.WriteLine($"\nИсходная строка: {n}");
                Console.WriteLine($"Строка в нижнем регистре: {g}");
                Console.ReadKey();
            }
            catch (ArgumentException aex)
            {
                Console.Clear();
                Errors(aex);
            }
            catch (Exception ex)
            {
                Console.Clear();
                Errors(ex);
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Хотите выполнить команду еще раз? \nНажмите Y для продолжение программы, иначе любую другую кнопку для завершения!");
            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                Console.Clear();
                continue;

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Программа завершена. До свидания!");
                Console.ReadKey();
                break;
            }
        }
    } 
}

