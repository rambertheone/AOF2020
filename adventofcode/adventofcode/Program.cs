namespace adventofcode;
class Program
{
    static void Main(string[] args)
    {

        string[] input = File.ReadAllLines("../../../../adventofcode.com_2020_day_8_input.txt");
        string[] input2 = { "nop +0", "acc +1", "jmp +4", "acc +3", "jmp -3", "acc -99", "acc +1", "jmp -4", "acc +6" };
        List <int> numbers = new List <int>();
        int i = 0;
        string name = "";
        int value = 0;
        int totalValue = 0;

        while (input2.Length - 1 <= i || !numbers.Contains(i))
        {
            if(i == input.Length || i > input.Length)
                break; 
            string[] array = input2[i].Split(' ');
            name = array[0];
            value = int.Parse(array[1]);

             numbers.Add(i);
            
            

            if(name == "acc")
            {
                totalValue += value;
                i++;
            }
            else if (name == "jmp")
            {
                if (i + 1 == input2.Length - 1)
                {
                    i++;
                }
                else
                {
                    i += value;
                }
            }
            else if (name == "nop")
            {
                if(i+value == input2.Length - 1)
                {
                    i += value;
                }
                else
                {
                    i++;
                }
                
            }


        }
        Console.WriteLine(totalValue);
    }




}


