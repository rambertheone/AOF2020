using System.Diagnostics;
using System.Linq;

namespace adventofcode;
class Program
{
    static void Main(string[] args)
    {
        string file = "../../../adventofcode.com_2020_day_5_input.txt";
        string[] fileInfo = File.ReadAllLines(file);
        const int ROW = 127;
        const int COL = 8;

        int row = FindRow(fileInfo, ROW);
        int col = FindColumn(fileInfo, COL);

        Console.WriteLine(CalculateId(row, col));

    }
    
    static int FindRow(string[] fileInfo, int totalRow)
    {
        int left = 0;
        int right = totalRow;
        int row = 0;
        int finalRow = 0;
        
        for (int i = 0; i < fileInfo.Length; i++)
        {

            for (int j = 0; j < fileInfo[i].Length - 3; j++)
            {
                int middle = (left + right) / 2;

                if (fileInfo[i][j] == 'F')
                {
                    right = middle;
                    if(j == fileInfo[i].Length - 4)
                    {
                        row = right;
                    }
                    
                }
                else
                {
                    left = middle;
                    if (j == fileInfo[i].Length - 4)
                    {
                        row = left;
                    }
                    
                }
            }
            if(finalRow < row)
            {
                finalRow = row;
            }

        }
        return row;
       

    }

    static int FindColumn(string[] fileInfo, int totalColumn)
    {
        int left = 0;
        int right = totalColumn;
        int col = 0;
        int finalCol = 0;

        for (int i = 0; i < fileInfo.Length; i++)
        {

            for (int j = 7; j < fileInfo[i].Length; j++)
            {
                int middle = (left + right) / 2;

                if (fileInfo[i][j] == 'L')
                {
                    right = middle;
                    
                    if (j == fileInfo[i].Length - 1)
                    {
                        col = right;
                    }
                }
                else
                {
                    left = middle;
                    if (j == fileInfo[i].Length - 1)
                    {
                        col = left;
                    }
                }
            }
            if (finalCol < col)
            {
                finalCol = col;
            }

        }
        return finalCol;

    }
    
    static int CalculateId(int row, int column)
    {

        return row * 8 + column;

    }

}

