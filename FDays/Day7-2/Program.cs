namespace adventofcode;
class Program
{
    static void Main(string[] args)
    {

        string[] input = File.ReadAllLines("../../../../adventofcode.com_2020_day_7_input.txt");
        //string[] input = File.ReadAllLines("../../../../light red bags contain 1 bright whi.txt");
        List<string> contains = new List<string>();
        const string SHINNYBAG = "shiny bag";
        int numberOfBags = 0;
        List<int> bag = new List<int>();
        List<string> everythin = new List<string>();
        AddShinyBagNames(contains, input, ref numberOfBags, bag, everythin);
        FindBagsInsideShiny(contains, input, ref numberOfBags, bag, everythin);
        //ContainsShinny(contains, input, ref colorThatContain);
        //Console.WriteLine(colorThatContain);
        Console.WriteLine(numberOfBags);
        //string[] input = { "abc", "", "a", "b", "c", "", "ab", "ac", "", "a", "a", "a", "a","", "b" };
    }

    static void FindBagsInsideShiny(List<string> contains, string[] input, ref int numberOfBags, List<int> bag, List<string> every)
    {



        for (int i = 0; i < contains.Count(); i++)
        {
            if (contains.Count == 0)
            {
                break;
            }
            AddBagNames(contains, contains[i], ref numberOfBags, bag[i], input, bag, every);
            if (bag.Count > 0)
            {
                bag.Remove(bag[i]);
            }


        }
    }

    static void AddShinyBagNames(List<string> contains, string[] input, ref int numberBags, List<int> bag, List<string> every)
    {

        const int numberShiny = 1;
        for (int i = 0; i < input.Length; i++)
        {

            string[] bagContent = input[i].Split("bags contain");

            if (bagContent[0].Contains("shiny gold"))
            {

                string[] content = bagContent[1].Split(',');

                for (int j = 0; j < content.Length; j++)
                {
                    string[] content2 = content[j].Split(' ', '.');
                    contains.Add(content2[2] + " " + content2[3]);
                    every.Add(content2[2] + " " + content2[3]);
                    numberBags += AddBags(int.Parse(content2[1]), numberShiny);
                    bag.Add(int.Parse(content2[1]));
                }

            }
        }


    }
    static void AddBagNames(List<string> contains, string input, ref int numberBags, int NumberbagInsideBag, string[] fileContent, List<int> bag, List<string> every)
    {

        for (int i = 0; i < fileContent.Length; i++)
        {

            string[] bagContent = fileContent[i].Split("bags contain");

            if (bagContent[0].Contains(input))
            {
                bag.Remove(bag[0]);
                string[] content = bagContent[1].Split(',');
                string fullInput = bagContent[1];
                contains.Remove(input);


                for (int j = 0; j < content.Length; j++)
                {
                    string[] content2 = content[j].Split(' ', '.');
                    
                    if (!fullInput.Contains("no other"))
                    {

                        contains.Add(content2[2] + " " + content2[3]);
                        numberBags += AddBags(int.Parse(content2[1]), NumberbagInsideBag);
                        bag.Add(AddBags(int.Parse(content2[1]), NumberbagInsideBag));
                        every.Add(content2[2] + " " + content2[3]);
                    }

                    


                }

            }
        }

        FindBagsInsideShiny(contains, fileContent, ref numberBags, bag, every);



    }




    static int AddBags(int a, int b)
    {
        return a * b;
    }


    //static void ContainsShinny(List<string> containsShiny, string[] input, ref int contains)
    //{

    //    for (int i = 0; i < input.Length; i++)
    //    {
    //        string[] bagContent = input[i].Split("contain");

    //        bool value = CheckTheNameOfBag(containsShiny, bagContent[0], ref contains);


    //        if (value == false)
    //        {
    //            CheckTheContentOfBag(containsShiny, bagContent[1], ref contains);
    //        }
    //    }

    //}

    //static bool CheckTheNameOfBag(List<string> containsShiny, string bagContent, ref int contains)
    //{
    //    for (int i = 0; i < containsShiny.Count; i++)
    //    {
    //        if (bagContent.Contains(containsShiny[i]))
    //        {
    //            contains++;
    //            return true;
    //        }
    //    }

    //    return false;
    //}

    //static void CheckTheContentOfBag(List<string> containsShiny, string bagContent, ref int contains)
    //{
    //    for (int i = 0; i < containsShiny.Count; i++)
    //    {
    //        if (bagContent.Contains(containsShiny[i]))
    //        {

    //            contains++;
    //            break;

    //        }
    //    }

    //}


}


