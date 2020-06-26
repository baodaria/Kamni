
using System;
using System.Collections.Generic;
using System.Text;

namespace Kamni
{
    public class MainClass
    {
        Node start;
        List<int> stones;

        public MainClass()
        {
            start = new Node();
            stones = new List<int>();
        }

        public void CreateGraph(int val, int[] numbers, string[] conditions)
        {
            for (int i = 1; i < val - 1; i++)
            {
                stones.Add(i);
            }
            start.AddBranchesOfTurns(stones, val, numbers, conditions);
        }

        public int FindNGNumber(int val, int[] numbers, string[] conditions) // ng = not good
        {
            int value1, value2, value3;
            if (conditions[0] == "+")
            {
                value1 = val - numbers[0];
            }
            else
            {
                value1 = (int)Math.Ceiling(val / (double)numbers[0]);
            }
            if (conditions[1] == "+")
            {
                value2 = val - numbers[1];
            }
            else
            {
                value2 = (int)Math.Ceiling(val / (double)numbers[1]);
            }
            if (conditions[2] == "+")
            {
                value3 = val - numbers[2];
            }
            else
            {
                value3 = (int)Math.Ceiling(val / (double)numbers[2]);
            }
            int value4 = Math.Min(value1, value2);
            int var = Math.Min(value4, value3);
            return var - 1;
        }

        public void ShowResult(int val, int[] numbers, string[] conditions)
        {
            int value = FindNGNumber(val, numbers, conditions);
            start.CreateListsOfStoneNumber(value);
            foreach (int newval in ListOfTurns.stonesToWin)
            {
                Console.Write(val + " ");
            }
            Console.WriteLine(" ");
            Console.WriteLine("2. Возможные стратегии первого игрока: ");
            Console.WriteLine("   первый ход первого игрока ");
            Strategies s = new Strategies();
            s.ShowPetyaFirstTurn(value, numbers, conditions);
            Console.WriteLine("   первый ход второго игрока ");
            s.ShowVanyaFirstTurn(value, numbers, conditions);
            Console.WriteLine("   последний ход ");
            s.ShowPetyaSecondTurn(val, numbers, conditions);
        }
    }
}