using System.Diagnostics;
using System.Linq;

namespace adventofcode;
class Program
{
    static void Main(string[] args)
    {
        string file = "../../../adventofcode.com_2020_day_5_input.txt";
        //string[] fileInfo = File.ReadAllLines(file);
        string[] fileInfo = { "BFFFBBFRRR", "FFFBBBFRRR", "BBFFBBFRLL" };

        int[] data = new int[fileInfo.Length];
        int result = 0;

        int dataInside = 0;


        for (int i = 0; i < fileInfo.Length; i++)
        {
           
            string row1 = "";
            string col1 = "";

            row1 += fileInfo[i].Replace('F', '0').Replace('B', '1').Replace('R', '1').Replace('L', '0');

            Console.WriteLine(Convert.ToInt32(row1, 2));


        }


        Console.WriteLine(dataInside);
        Console.ReadLine();

    }
}


