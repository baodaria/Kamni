using System;
using System.Collections.Generic;
using System.Text;


namespace Kamni
{
   public class Program
    {
        static void Main(string[] args)
        {
            bool ThisisError;
            int sum = 0;
            int firstValue = 0;
            int secondValue = 0;
            int thirdValue = 0;
            string firstsymbol = "+";
            string secondsymbol = "+";
            string thirdsymbol = "+";
            string firstvariant = "";
            string secondvariant = "";


            do
            {
                ThisisError = false;
                try
                {
                    Console.Write("введи кол-во камней в куче для определения победы");
                    sum = Convert.ToInt32(Console.ReadLine());
                    ExceptionClass.CheckFinishNumber(sum);
                }
                catch (CheckNumberException ex)
                {
                    Console.WriteLine(ex.Message);
                    ThisisError = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("ввели не число, попробуйте снова");
                    ThisisError = true;
                }
            }
            while (ThisisError);

            String symbols = @"([+*])+(\d+)";

            do
            {
                ThisisError = true;
                try
                {
                    Console.Write("1 вариант добавления камней в общую кучу, например, '+1'): ");
                    firstvariant = Console.ReadLine();
                    foreach (var expression in firstvariant)
                    {
                        foreach (System.Text.RegularExpressions.Match r in
                        System.Text.RegularExpressions.Regex.Matches(firstvariant, symbols))
                        {
                            firstValue = Int32.Parse(r.Groups[2].Value);
                            firstsymbol = r.Groups[1].Value;
                        }
                    }
                    ExceptionClass.CheckTheOperatorAndOperand(firstValue);
                }
                catch (CheckWrittennumbers ex)
                {
                    Console.WriteLine(ex.Message);
                    ThisisError = false;
                }
            }
            while (ThisisError == false);

            do
            {
                ThisisError = false;
                try
                {
                    Console.Write("2 вариант добавления камней в кучу ");
                    secondvariant = Console.ReadLine();
                    foreach (var expression in secondvariant)
                    {
                        foreach (System.Text.RegularExpressions.Match r in
                        System.Text.RegularExpressions.Regex.Matches(secondvariant, symbols))
                        {
                            secondValue = Int32.Parse(r.Groups[2].Value);
                            secondsymbol = r.Groups[1].Value;
                        }
                    }
                    ExceptionClass.CheckTheOperatorAndOperand(secondValue);
                    ExceptionClass.CheckVariant(firstvariant, secondvariant);
                }
                catch (CheckWrittennumbers ex)
                {
                    Console.WriteLine(ex.Message);
                    ThisisError = true;
                }
                catch (CheckVariantException ex)
                {
                    Console.WriteLine(ex.Message);
                    ThisisError = true;
                }
            }
            while (ThisisError);

            do
            {
                ThisisError = true;
                try
                {
                    Console.Write("3 вариант добавления камней в кучу ");
                    string thirdvariant = Console.ReadLine();
                    foreach (var expression in thirdvariant)
                    {
                        foreach (System.Text.RegularExpressions.Match r in
                        System.Text.RegularExpressions.Regex.Matches(thirdvariant, symbols))
                        {
                            thirdValue = Int32.Parse(r.Groups[2].Value);
                            thirdsymbol = r.Groups[1].Value;
                        }
                    }
                    ExceptionClass.CheckTheOperatorAndOperand(thirdValue);
                    ExceptionClass.CheckVariant(firstvariant, secondvariant, thirdvariant);
                }
                catch (CheckWrittennumbers ex)
                {
                    Console.WriteLine(ex.Message);
                    ThisisError = false;
                }
                catch (CheckVariantException ex)
                {
                    Console.WriteLine(ex.Message);
                    ThisisError = false;
                }
            }
            while (ThisisError == false);

            int[] numbers = new int[3] { firstValue, secondValue, thirdValue };
            string[] condition = new string[3] { firstsymbol, secondsymbol, thirdsymbol };

            Console.WriteLine("");
            Console.WriteLine("Решение: ");
            MainClass f = new MainClass();
            ListOfTurns.stonesToWin = new List<int>();
            ListOfTurns.listOfFirstAttemptOfPlayer2 = new List<int>();
            f.CreateGraph(sum, numbers, condition);
            f.ShowResult(sum, numbers, condition);
        }
    }
}
