using System.Diagnostics;
using System.Linq;

namespace adventofcode;
class Program
{
    static void Main(string[] args)
    {
        string file = "../../../adventofcode.com_2020_day_5_input.txt";
        //string[] fileInfo = File.ReadAllLines(file);
        string[] fileInfo = { "BBFBFFBLRL", "FFFBBBFRRR", "BBFFBBFRLL", "FBFBBFFRLR", "FBFBBBFRLL", "FFBFBFBLLR" };
        const int ROW = 127;
        const int COL = 7;
        int[,] data = new int[fileInfo.Length, 2];
        GetData(fileInfo, ROW, COL, data);
        int result = 0;
        CalculateId(data, ref result);


        Console.WriteLine(result);
        Console.ReadLine();

    }

    static int GetData(string[] fileInfo, int totalRow, int totalCol, int[,] data)
    {
        int row = 0;
        int col = 0;
        int ID = 0;

        for (int i = 0; i < fileInfo.Length; i++)
        {
            row = FindRow(fileInfo, totalRow, i);
            col = FindColumn(fileInfo, totalCol, i);
            data[i, ID] = row;
            ID++;
            data[i, ID] = col;
            if(row == 105 && col == 2)
            {
                Console.WriteLine(fileInfo[i]);
                Console.WriteLine(row + " " + col);
            }
            ID = 0;
        }

        return ID;
    }

    static int FindRow(string[] fileInfo, int totalRow, int i)
    {

        int left = 0;
        int right = totalRow;
        int row = 0;


        for (int j = 0; j < fileInfo[i].Length - 3; j++)
        {
            int middle = (left + right) / 2;

            if (fileInfo[i][j] == 'F')
            {
                right = middle;



            }
            else
            {

                    left = middle + 1;
                

            }

        }


        return left;


    }

    static int FindColumn(string[] fileInfo, int totalColumn, int i)
    {

        int left = 0;
        int right = totalColumn;
        int col = 0;

        for (int j = 7; j < fileInfo[i].Length; j++)
        {
            int middle = (left + right) / 2;
            if (fileInfo[i][j] == 'L')
            {
                right = middle;


            }
            else
            {


                    left = middle + 1;
                

            }

        }


        return left;

    }

    static int CalculateId(int[,] data, ref int result)
    {

        for (int i = 0; i < data.GetLength(0); i++)
        {
            
            if(data[i, 0] * 8 + data[i, 1] == 842)
            {
                Console.WriteLine("842");
            }
            if (data[i, 0] * 8 + data[i, 1] > result)
            {
                result = data[i, 0] * 8 + data[i, 1];
                
            }


        }
        return result;

    }

}

