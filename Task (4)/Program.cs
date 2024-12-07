

namespace Task__4_
{
    class VowelsCheckException : Exception {
        
        public VowelsCheckException() { }

        public VowelsCheckException(string message) : base(message) { }
    }
    class DuplicateException : Exception
    {
        public DuplicateException() : base() { }

        public DuplicateException(string message) : base(message) { }
    }
    internal class Program
    {

        static void checkDuplicate()
        {

            List<int> nums = new List<int>();

            Console.WriteLine("Enter integers (duplicates will cause an exception):");

            while (true)
            {
                try
                {
                    Console.Write("Enter a number: ");
                    int num = Convert.ToInt32(Console.ReadLine());

                    if (nums.Contains(num))
                    {
                        throw new DuplicateException("You entered a duplicate number!");
                    }

                    nums.Add(num);
                }
                catch (DuplicateException ex)
                {
                    Console.WriteLine(ex.Message);
                    break;
                }

                Console.WriteLine("Numbers entered so far:");
                for (int i = 0; i < nums.Count; i++)
                {
                    Console.Write(nums[i] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Numbers entered so far:");
            for (int i = 0; i < nums.Count; i++)
            {
                Console.Write(nums[i] + " ");
            }
            Console.WriteLine();
        }
       
        static void checkVowels (){


            Console.Write("Enter A string: ");
            string str = Convert.ToString(Console.ReadLine());

            try
            {

                str.ToLower();

                if (str.Contains('a') || str.Contains('e') || str.Contains('i') || 
                    str.Contains('u') || str.Contains('o'))
                {
                    return;
                }else
                    throw new VowelsCheckException("This string contain no vowels");

            }
            catch (VowelsCheckException ex)
            {

                Console.WriteLine(ex.Message);

            }
            finally { 
                
                Console.WriteLine($"Your String is : {str}");
            }

        }
        static void Main(string[] args)
        {
            checkDuplicate();

           
            checkVowels();

        }
    }
}
