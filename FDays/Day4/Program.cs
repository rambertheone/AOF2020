using System.Linq;

namespace adventofcode;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Day4();
    }
    static void Day4()
    {

        string[] content = File.ReadAllLines("../../../adventofcode.com_2020_day_4_input.txt");
        //string[] content = File.ReadAllLines("../../../Untitled.txt");
        int spaces = 0;
        int complete = 0;

        for (int i = 0; i < content.Length; i++)
        {
            if (content[i] == "")
            {
                spaces++;
            }
        }

        int place = 0;
        string words = "";
        int valid = 0;
        string[] content2 = new string[spaces + 1];

        for (int i = 0; i < content.Length; i++)
        {

            if (content[i] != "" )
            {
                words = content[i] + " " + words;
            }
            else
            {
                content2[place] = words;
                place++;
                words = "";
                
            }
            if (content.Length -1 == i)
            {
                content2[place] = words;
            }


        }

        for (int i = 0; i < content2.Length; i++)
        {
            
            if (content2[i].Contains("ecl") == true && content2[i].Contains("pid") == true && content2[i].Contains("eyr") == true && content2[i].Contains("hcl") == true && content2[i].Contains("byr") == true && content2[i].Contains("iyr") == true && content2[i].Contains("hgt"))
            {
                for(int k=0; k < content2.Length; k++)
                {

                    string[] value = content2[i].Split(' ');
                    
                    string[,] values2 = new string[value.Length - 1, 2];
                    int iteration = 0;
                    int iteration2 = 0;
                    for(int j=0; j < value.Length - 1; j++)
                    {
                       
                        string[] values = value[j].Split(':');
                        values2[j, iteration2] = values[iteration2];
                        iteration2++;
                        iteration++;
                        values2[j, iteration2] = values[iteration2];
                        iteration2 = 0;
                        
                    }
                    

                    if( k == content2.Length - 1)
                    {
                        for (int n = 0; n < values2.GetLength(0); n++)
                        {
                            for (int m = 0; m < values2.GetLength(1) - 1; m++)
                            {
                                if (values2[n, m] == "byr" && int.Parse(values2[n, m + 1]) < 2003)
                                {
                                    valid++;
                                }
                                else if (values2[n, m] == "hgt")
                                {

                                    if (values2[n, m + 1].Contains("cm") == true)
                                    {
                                        if (values2[n, m + 1].Count() == 5)
                                        {
                                            valid++;
                                        }
                                    }
                                    else if (values2[n, m + 1].Contains("in") == true)
                                    {
                                        if (values2[n, m + 1].Count() == 4)
                                        {
                                            valid++;
                                        }
                                    }

                                }
                                else if (values2[n, m] == "hcl" && values2[n, m + 1].Contains("#") == true)
                                {
                                    valid++;
                                }
                                else if (values2[n, m] == "ecl" && values2[n, m + 1].Contains("brn") == true)
                                {
                                    valid++;
                                }
                                else if (values2[n, m] == "pid" && values2[n, m + 1].Count() == 9)
                                {
                                    valid++;
                                }

                            }
                            if (valid == 5)
                            {
                                complete++;
                                valid = 0;
                            }

                        }
                    }

                }
              
            }

                
        }
        Console.WriteLine(complete);
        Console.ReadLine();


    }



}

