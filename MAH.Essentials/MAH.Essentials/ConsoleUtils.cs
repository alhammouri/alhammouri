﻿using System;

namespace MAH.Essentials
{
    public static class ConsoleUtils
    {
        public static void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public static ConsoleKeyInfo ReadKey()
        {
            var key = Console.ReadKey();
            Console.WriteLine();
            return key;
        }

        public static string GetUserInput(string message)
        {
            Console.Write(message + ": ");
            return Console.ReadLine();
        }

        public static string GetPasswordInput(string message)
        {
            Console.Write($"{message}:");

            var pass = string.Empty;
            ConsoleKey key;
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && pass.Length > 0)
                {
                    Console.Write("\b \b");
                    pass = pass.Substring(0, pass.Length - 2);
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    pass += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);

            Console.WriteLine();

            return pass;
        }

        public static ConfirmationResult Confirm(string message)
        {
            Console.Write($"{message}? (y or n): ");
            var answer = ReadKey();

            if (answer.Key == ConsoleKey.Y)
            {
                return ConfirmationResult.Yes;
            }
            else if (answer.Key == ConsoleKey.N)
            {
                return ConfirmationResult.No;
            }
            else
            {
                return ConfirmationResult.Unknown;
            }
        }

        public static void WriteSuccessLine(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        public static void WriteErrorLine(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void PressAnyKeyToContinue()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public static void WriteCleanLine(string message, params string[] args)
        {
            WriteCleanLine(string.Format(message, args));
        }

        public static void WriteCleanLine(string message)
        {
            Console.WriteLine();
            Console.WriteLine(message);
            Console.WriteLine();
        }

        public static void WriteException(Exception ex)
        {
            Console.WriteLine("----------------- ERROR -----------------");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Message: {ex.Message}");
            Console.WriteLine($"Exception: {ex}");
            Console.ResetColor();
            Console.WriteLine("-----------------------------------------");
        }
    }
}