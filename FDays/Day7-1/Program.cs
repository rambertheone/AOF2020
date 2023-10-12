using System.Diagnostics;
using System.Linq;

namespace adventofcode;
class Program
{
    static void Main(string[] args)
    {

        string[] input = File.ReadAllLines("../../../../adventofcode.com_2020_day_7_input.txt");
        //string[] input = { "light red bags contain 1 bright white bag, 2 muted yellow bags.", "dark orange bags contain 3 bright white bags, 4 muted yellow bags.", "bright white bags contain 1 shiny gold bag.", "muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.", "shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.", "dark olive bags contain 3 faded blue bags, 4 dotted black bags." };
        List<string> containsShiny = new List<string> ();
        const string SHINNYBAG = "shiny bag";
        int colorThatContain = 0;

        FindBagsWithshiny(containsShiny, input);
        ContainsShinny(containsShiny, input, ref colorThatContain);
        Console.WriteLine(colorThatContain);
        Console.ReadLine();
        //string[] input = { "abc", "", "a", "b", "c", "", "ab", "ac", "", "a", "a", "a", "a","", "b" };
    }

    static void FindBagsWithshiny(List<string> containsShiny, string[] input)
    {

        for(int i=0; i < input.Length; i++)
        {
            bool a = false;
            string[] bagContent = input[i].Split("bags contain");

            if (bagContent[1].Contains("shiny gold"))
            {
                a = true;
            }
            for (int j = 0; j < containsShiny.Count; j++)
            {
                if (bagContent[1].Contains(containsShiny[j]))
                {
                    a = true;
                }
                if(bagContent[0].Contains(containsShiny[j]))
                {
                    a = false;
                    break;
                }
            }
            if (a)
            {
                containsShiny.Add(bagContent[0]);
                FindBagsWithshiny(containsShiny, input);
            }


        }

    }

    static void ContainsShinny(List<string> containsShiny, string[] input, ref int contains)
    {

        for(int i = 0; i < input.Length; i++)
        {
            string[] bagContent = input[i].Split("contain");

            bool value = CheckTheNameOfBag(containsShiny, bagContent[0], ref contains);


            if (value == false)
            {
                CheckTheContentOfBag(containsShiny, bagContent[1], ref contains);
            }
        }

    }

    static bool CheckTheNameOfBag(List<string> containsShiny, string bagContent, ref int contains)
    {
        for(int i = 0; i < containsShiny.Count; i++)
        {
            if(bagContent.Contains(containsShiny[i]))
            {
                contains++;
                return true;
            }
        }

        return false;
    }

    static void CheckTheContentOfBag(List<string> containsShiny, string bagContent, ref int contains)
    {
        for (int i = 0; i < containsShiny.Count; i++)
        {
            if (bagContent.Contains(containsShiny[i]))
            {
                
                contains++;
                break;
                
            }
        }
       
    }

}

