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
            Random rnd = new Random();
 
            for (int r = 0; r < rowsLength; ++r)
            {
                for (int c = 0; c < columnsLength; ++c)
                {
                    numberArray[r, c] = rnd.Next(1,400);     
                    Console.Write(numberArray[r, c] + "\t");
                }
                Console.WriteLine();
            }

            int? minValue = null;
            int? minRow = null;
            int? minCol = null;
            int? maxValue = null;
            int? maxRow = null;
            int? maxCol = null;

            for (int r = 0; r < rowsLength; ++r)
            {
                for (int c = 0; c < columnsLength; ++c)
                {
                    int cell = numberArray[r, c];
                    int maxCell = numberArray[r, c];

                    if (!minValue.HasValue || cell < minValue)
                    {
                        minValue = cell;
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
                Console.WriteLine("\nMinimum: value[{0},{1}] is {2}", minRow, minCol, minValue);
                Console.WriteLine("Maximum: value[{0},{1}] is {2}\n", maxRow, maxCol, maxValue);
            }
            else
            {
                Console.WriteLine("no value");
            }

            for (int r = 0; r < rowsLength; r++)
            {
                for (int c = 0; c < columnsLength; c++)
                {
                    for (int k = 0; k < columnsLength - c - 1; k++)
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

            for (int r = 0; r < rowsLength; r++)
            {
                for (int c = 0; c < columnsLength; c++)
                    Console.Write(numberArray[r, c] + "\t");
                Console.WriteLine();
            }
        }
    }
}
