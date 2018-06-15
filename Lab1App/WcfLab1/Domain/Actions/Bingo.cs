using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WcfLab1.Domain.Respositories;

namespace WcfLab1.Domain.Actions
{
    public class Bingo
    {
        /// <summary>
        /// Create the matrix
        /// </summary>
        /// <returns></returns>
        public BingoElement[,] CreateCardboard()
        {
            return new BingoElement[5, 5];
        }

        /// <summary>
        /// Ony Get a random number that its inside of this range
        /// </summary>
        /// <param name="FistNumber"></param>
        /// <param name="LastNumber"></param>
        /// <returns></returns>
        public int CalculateNumber(int FistNumber, int LastNumber)
        {
            Random rnd = new Random();
            return rnd.Next(FistNumber, LastNumber + 1);
        }

        /// <summary>
        /// Fill each column with the value 
        /// </summary>
        /// <param name="CurrentColumn"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public BingoElement[,] FillColumn(char CurrentColumn, BingoElement[,] m)
        {
            int ColumnIndex = 0;
            int FistNumber = 0;
            int LastNumber = 0;

            switch (CurrentColumn)
            {
                case 'B':
                    ColumnIndex = 0;
                    FistNumber = 1;
                    LastNumber = 15;
                    break;
                case 'I':
                    ColumnIndex = 1;
                    FistNumber = 16;
                    LastNumber = 30;
                    break;
                case 'N':
                    ColumnIndex = 2;
                    FistNumber = 31;
                    LastNumber = 45;
                    break;
                case 'G':
                    ColumnIndex = 3;
                    FistNumber = 46;
                    LastNumber = 60;
                    break;
                case 'O':
                    ColumnIndex = 4;
                    FistNumber = 61;
                    LastNumber = 75;
                    break;
                default:
                    return null;
            }

            List<int> SelectedNumbers = new List<int>();

            for (int i = 0; i < 5; i++)
            {
                if (CurrentColumn == 'N' && i == 2)
                {
                    m[i, ColumnIndex] = new BingoElement("XX", false);
                }
                else
                {
                    int CurrentNumber = CalculateNumber(FistNumber, LastNumber);
                    while (SelectedNumbers.Contains(CurrentNumber))
                    {
                        CurrentNumber = CalculateNumber(FistNumber, LastNumber);
                    }
                    SelectedNumbers.Add(CurrentNumber);
                    m[i, ColumnIndex] = new BingoElement(CurrentNumber + "", false);
                }
            }
            return m;
        }

        /// <summary>
        /// Fill all the matrix with the numbers
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public BingoElement[,] InitializeCardboard(BingoElement[,] m)
        {
            char[] Columns = new char[]
            {
                'B','I','N','G','O'
            };

            for (int i = 0; i < Columns.Length; i++)
            {
                FillColumn(Columns[i], m);
            }

            return m;
        }

        /// <summary>
        /// Show the matrix in the screen
        /// </summary>
        /// <param name="m"></param>
        public void PrintCardboard(BingoElement[,] m)
        {
            Console.WriteLine(" B  I  N  G  O ");
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (i == 2 && j == 2)
                    {
                        Console.Write(m[i, j].Number + "|");
                    }
                    else
                    {
                        if (int.Parse(m[i, j].Number) < 10)
                        {
                            Console.Write("0" + m[i, j].Number + "|");
                        }
                        else
                        {
                            Console.Write(m[i, j].Number + "|");
                        }
                    }
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}