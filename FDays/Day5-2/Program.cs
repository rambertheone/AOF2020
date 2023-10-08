using System.Diagnostics;
using System.Linq;

namespace adventofcode;
class Program
{
    static void Main(string[] args)
    {
        string file = "../../../adventofcode.com_2020_day_5_input.txt";
        string[] fileInfo = File.ReadAllLines(file);
        //string[] fileInfo = { "BBFBFFBLRL", "FFFBBBFRRR", "BBFFBBFRLL", "FBFBBFFRLR", "FBFBBBFRLL", "FFBFBFBLLR" };

        const int ROW = 127;
        const int COL = 7;

        int[,] data = new int[fileInfo.Length, 2];
        GetData(fileInfo, ROW, COL, data);

        int result = 0;
        int[] ID = new int[data.GetLength(0)];

        CalculateId(data, ref result, ID);

        Console.WriteLine(result);

        ShellSort(ID);

        SearchMyID(ID);      
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

    static int CalculateId(int[,] data, ref int result, int[] ID)
    {

        for (int i = 0; i < data.GetLength(0); i++)
        {

            ID[i] = data[i, 0] * 8 + data[i, 1];
            if (ID[i] > result)
            {
                result = data[i, 0] * 8 + data[i, 1];
                
            }


        }
        return result;

    }

    static void ShellSort(int[] ID)
    {
        for(int gap = ID.Length / 2; gap > 0; gap /= 2)
        {

            for(int i = gap; i < ID.Length; i ++)
            {

                for(int j = i - gap; j >=0; j = j-gap)
                {
                    int key = ID[j + gap];
                    int k = j;

                    if(key < ID[k])
                    {
                        ID[j + gap] = ID[k];
                        ID[k] = key;
                    }

                }
            }

        }
    }

    static void SearchMyID(int[] data)
    {
        for(int i=0; i < data.Length; i+=2)
        {
    
        if (data[i+1] - data[i] == 2)
        {
                Console.WriteLine(data[i] + " " + data[i + 1]);
        }


        }
    }

}

