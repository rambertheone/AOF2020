using System.Diagnostics;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace AdventOfCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Day3();
        }

        static void Day1()
        {
            string[] array = File.ReadAllLines("../../../adventofcode.com_2020_day_1_input.txt");
            int[] intArr = new int[array.Length];
            int first = 0;
            int second = 0;
            int third = 0;

            for (int i = 0; i < array.Length; i++)
            {
                intArr[i] = int.Parse(array[i]);
            }

            for (int i = 0; i < intArr.Length; i++)
            {
                for (int j = 0; j < intArr.Length; j++)
                {
                    for (int k = 0; k < intArr.Length; k++)
                    {

                        if (intArr[i] + intArr[j] + intArr[k] == 2020 && j != i && j != k && k != i)
                        {
                            first = intArr[i];
                            second = intArr[j];
                            third = intArr[k];
                        }

                    }
                }
            }

            Console.WriteLine(first + " " + second + " " + third + " = " + first * second * third);
        }

        static void Day2()
        {
            string[] array = File.ReadAllLines("../../../adventofcode.com_2020_day_2_input.txt");
            int count = 0;
            int valid = 0;
            char[] delimiterChars = { '-', ' ', ':' };

            for (int i = 0; i < array.Length; i++)
            {
                string[] words = array[i].Split(delimiterChars);


         
                
                    if (words[2][0] == words[4][int.Parse(words[0]) - 1] && words[2][0] != words[4][int.Parse(words[1]) - 1])
                    {
                        valid++;
                    }
                    else if (words[2][0] == words[4][int.Parse(words[1]) - 1] && words[2][0] != words[4][int.Parse(words[0]) - 1])
                    {
                        valid++;
                    }

                



            }
            Console.WriteLine(valid);

        }

        static void Day3()
        {
            string[] array = File.ReadAllLines("../../../adventofcode.com_2020_day_3_input.txt");
            int repetitions = 200;
            char[,] DArray = new char[array.Length, array[0].Length * repetitions];
            
            for (int i = 0;i < array.Length;i++)
            {
                
                Console.WriteLine(array[i]);
                for (int j = 0;j < array[i].Length;j++)
                {

                    DArray[i, j] = array[i][j];
                    for (int k = 1;k < repetitions;k++)
                    {
                        DArray[i, (array[0].Length) * k + j] = array[i][j];
                    }
                    
                }

            }



            int y = 0;
            int x = 0;
            int trees = 0;

            for (int row = 0; row < DArray.GetLength(0);row++) 
            {
                if (y < DArray.GetLength(0) && x < DArray.GetLength(1))
                {
                    if (DArray[y, x] == '#')
                    {
                        trees++;
                        
                        
                    }
                }
                
                y+=1;
                x += 7;
                
                
                
                
                


            }
            Console.WriteLine(trees);
        }
    }
}