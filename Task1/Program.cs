using System;

namespace Task1
{
	class Program
	{
		static void Main(string[] args)
		{
            int rowsLength = 20;
            int columnsLength = 20;
            int[,] numberArray = new int[rowsLength, columnsLength];

            FillArray(numberArray);
            FindMinMaxValues(numberArray);
            SortByRows(numberArray);
        }

        public static void FillArray(int[,]numberArray)
        {
            Random rnd = new Random();

            for (int r = 0; r < numberArray.GetLength(0); r++)
            {
                for (int c = 0; c < numberArray.GetLength(1); c++)
                {
                    numberArray[r, c] = rnd.Next(1, 400);
                    Console.Write(numberArray[r, c] + "\t");
                }
                Console.WriteLine();
            }
        }

        public static void FindMinMaxValues(int[,] numberArray)
        {
            int? minValue = null;
            int? minRow = null;
            int? minCol = null;
            int? maxValue = null;
            int? maxRow = null;
            int? maxCol = null;

            for (int r = 0; r < numberArray.GetLength(0); r++)
            {
                for (int c = 0; c < numberArray.GetLength(1); c++)
                {
                    int minCell = numberArray[r, c];
                    int maxCell = numberArray[r, c];
                  
                    if (!minValue.HasValue || minCell < minValue)
                    {
                        minValue = minCell;
                        minRow = r;
                        minCol = c;
                    }
                    if (!maxValue.HasValue || maxCell > maxValue)
                    {
                        maxValue = maxCell;
                        maxRow = r;
                        maxCol = c;
                    }
                }
            }

            if (minValue.HasValue && maxValue.HasValue)
            {
                Console.WriteLine("\nMin: value[{0},{1}] is {2}", minRow, minCol, minValue);
                Console.WriteLine("Max: value[{0},{1}] is {2}\n", maxRow, maxCol, maxValue);
            }
            else
            {
                Console.WriteLine("no value");
            }
        }

        public static void SortByRows(int[,] numberArray)
        {
            for (int r = 0; r < numberArray.GetLength(0); r++)
            {
                for (int c = 0; c < numberArray.GetLength(1); c++)
                {
                    for (int k = 0; k < numberArray.GetLength(1) - c - 1; k++)
                    {
                        if (numberArray[r, k] > numberArray[r, k + 1])
                        {
                            int t = numberArray[r, k];
                            numberArray[r, k] = numberArray[r, k + 1];
                            numberArray[r, k + 1] = t;
                        }
                    }
                }
            }

            for (int r = 0; r < numberArray.GetLength(0); r++)
            {
                for (int c = 0; c < numberArray.GetLength(1); c++)
                {
                    Console.Write(numberArray[r, c] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
