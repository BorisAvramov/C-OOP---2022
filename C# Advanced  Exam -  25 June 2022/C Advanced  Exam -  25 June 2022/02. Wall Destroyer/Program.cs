using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Wall_Destroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {




            int rowCOl = int.Parse(Console.ReadLine());

            char[,] matrix = new char[rowCOl, rowCOl];

            List<List<char>> list = new List<List<char>>();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                List<char> row = Console.ReadLine().ToList();

                list.Add(row);

            }

            foreach (var l in list)
            {
                Console.WriteLine(String.Join("", l));

            }
           


            //    matrix = ReadMatrix(matrix, rowCOl);

            //    int rowV = 0;
            //    int colV = 0;
            //    int countHoles = 1;
            //    int countRods = 0;

            //    bool getElectrolucted = false;


            //    for (int row = 0; row < rowCOl; row++)
            //    {
            //        for (int col = 0; col < rowCOl; col++)
            //        {
            //            if (matrix[row, col] == 'V')
            //            {
            //                rowV = row;
            //                colV = col;
            //            }
            //        }
            //    }
            //    string input = Console.ReadLine();
            //    while (input != "End")
            //    {
            //        int nextRow = NextRow(input, rowV);
            //        int nextCol = NextCol(input, colV);

            //        if (!IsInRange(matrix, nextRow, nextCol))
            //        {
            //            input = Console.ReadLine();
            //            continue;
            //        }
            //        if (matrix[nextRow, nextCol] == 'C')
            //        {
            //            matrix[rowV, colV] = '*';
            //            matrix[nextRow, nextCol] = 'E';
            //            countHoles++;
            //            getElectrolucted = true;
            //            break;

            //        }
            //        if (matrix[nextRow, nextCol] == '-')
            //        {
            //            matrix[rowV, colV] = '*';
            //            matrix[nextRow, nextCol] = 'V';
            //            countHoles++;

            //            rowV = nextRow;
            //            colV = nextCol;

            //        }
            //        if (matrix[nextRow, nextCol] == 'R')
            //        {
            //            countRods++;
            //            Console.WriteLine($"Vanko hit a rod!");
            //            input = Console.ReadLine();
            //            continue;

            //        }
            //        if (matrix[nextRow, nextCol] == '*')
            //        {
            //            matrix[rowV, colV] = '*';
            //            matrix[nextRow, nextCol] = 'V';
            //            Console.WriteLine($"The wall is already destroyed at position [{nextRow}, {nextCol}]!");

            //            rowV = nextRow;
            //            colV = nextCol;

            //        }


            //        input = Console.ReadLine();
            //    }

            //    if (getElectrolucted)
            //    {
            //        Console.WriteLine($"Vanko got electrocuted, but he managed to make {countHoles} hole(s).");
            //    }
            //    else
            //    {
            //        Console.WriteLine($"Vanko managed to make {countHoles} hole(s) and he hit only {countRods} rod(s).");
            //    }



            //    PrintMatrix(matrix);
            //}


            //public static bool IsInRange(char[,] matrix, int row, int col)
            //{
            //    return row >= 0
            //        && row < matrix.GetLength(0)
            //        && col >= 0
            //        && col < matrix.GetLength(1);
            //}

            //private static int NextCol(string command, int initialCol)
            //{
            //    if (command == "right")
            //    {
            //        return ++initialCol;
            //    }
            //    if (command == "left")
            //    {
            //        return --initialCol;
            //    }
            //    return initialCol;

            //}
            //private static int NextRow(string command, int initialRow)
            //{
            //    if (command == "up")
            //    {
            //        return --initialRow;
            //    }
            //    if (command == "down")
            //    {
            //        return ++initialRow;
            //    }

            //    return initialRow;
            //}

            //private static void PrintMatrix(char[,] matrix)
            //{
            //    for (int row = 0; row < matrix.GetLength(0); row++)
            //    {
            //        for (int col = 0; col < matrix.GetLength(1); col++)
            //        {
            //            Console.Write(matrix[row, col]);
            //        }
            //        Console.WriteLine();
            //    }
            //}
            //private static char[,] ReadMatrix(char[,] matrix, int rowCol)
            //{
            //    for (int row = 0; row < matrix.GetLength(0); row++)
            //    {
            //        char[] charArr = Console.ReadLine().ToCharArray();


            //        for (int col = 0; col < charArr.Length; col++)
            //        {
            //            matrix[row, col] = charArr[col];
            //        }

            //    }

            //    return matrix;
            //}
        }
    }
}
