using System;
using System.Collections.Generic;
using System.Text;

namespace Kamni
{
    public class Node
    {
        List<Node> nextNumber;
        List<int> values;
        int value1, value2, value3;

        public Node()
        {
            nextNumber = new List<Node>();
            values = new List<int>();
        }

        public List<int> CreateNewListOfStones(int value1, int value2, int value3)
        {
            List<int> newListOfStones = new List<int>();
            newListOfStones.Add(value1);
            newListOfStones.Add(value2);
            newListOfStones.Add(value3);
            return newListOfStones;
        }

        public Node CreateNewNode(int numberOfStones)
        {
            Node newnode = new Node();
            foreach (int v in values)
            {
                newnode.values.Add(v);
            }
            newnode.values.Add(numberOfStones);
            nextNumber.Add(newnode);
            return newnode;
        }

        public void AddBranchesOfTurns(List<int> stones, int k, int[] a, string[] b)
        {
            foreach (int numberOfStones in stones)
            {
                Node nN = CreateNewNode(numberOfStones);

                if (numberOfStones >= k || values.Count == 4)
                {
                    continue;
                }

                if (b[0] == "+")
                {
                    value1 = numberOfStones + a[0];
                }
                else
                {
                    value1 = numberOfStones * a[0];
                }
                if (b[1] == "+")
                {
                    value2 = numberOfStones + a[1];
                }
                else
                {
                    value2 = numberOfStones * a[1];
                }
                if (b[2] == "+")
                {
                    value3 = numberOfStones + a[2];
                }
                else
                {
                    value3 = numberOfStones * a[2];
                }

                List<int> newNumberOfStones = CreateNewListOfStones(value1, value2, value3);
                nN.AddBranchesOfTurns(newNumberOfStones, k, a, b);
            }
        }

        public void CreateListsOfStoneNumber(int val)
        {
            if (nextNumber.Count != 0)
            {
                foreach (Node n in nextNumber)
                {
                    n.CreateListsOfStoneNumber(val);
                }
            }
            else
            {
                if (values.Count == 4 && values[1] == val)
                {
                    if (!ListOfTurns.stonesToWin.Contains(values[0]))
                    {
                        ListOfTurns.stonesToWin.Add(values[0]);
                    }

                    if (!ListOfTurns.listOfFirstAttemptOfPlayer2.Contains(values[2]))
                    {
                        ListOfTurns.listOfFirstAttemptOfPlayer2.Add(values[2]);
                    }
                }
            }
        }
    }
}