using System.Globalization;

namespace exercise1
{
    internal class StartUp
    {
        static void Main(string[] args)
        {

            int[] input1 = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int[] input2 = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            List<int> challenges = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

            Queue<int> tools = new Queue<int>(input1);
            Stack<int> substances = new Stack<int>(input2);
            bool isEqual = false;
            bool isFound = false;

            while (challenges.Any() && tools.Any() && substances.Any())
            {
                int toolValue = tools.Peek();
                int substanceValue = substances.Peek();
                int result = toolValue * substanceValue;

                if (challenges.Contains(result))
                {
                    tools.Dequeue();
                    substances.Pop();
                    for (int i = 0; i < challenges.Count; i++)
                    {
                        if (result == challenges[i])
                        {
                            challenges.Remove(challenges[i]);                            
                            isEqual = true;
                            break;
                        }
                    }
                }                
                else
                {
                    if (tools.Count > 0)
                    {
                        int toolElement = tools.Dequeue();
                        toolElement++;
                        tools.Enqueue(toolElement);
                    }

                    if (substances.Count > 0)
                    {
                        substances.Push(substances.Pop() - 1);
                    }
                    if (substances.Peek() == 0)
                    {
                        substances.Pop();
                    }
                }                            
            }

            if (challenges.Count == 0)
            {
                Console.WriteLine("Harry found an ostracon, which is dated to the 6th century BCE.");
            }
            else
            {
                Console.WriteLine("Harry is lost in the temple. Oblivion awaits him.");

            }


            if (tools.Count > 0)
            {
                Console.WriteLine($"Tools: {string.Join(", ",tools)}");
            }
            if (substances.Count > 0)
            {
                Console.WriteLine($"Substances: {string.Join(", ", substances)}");

            }
            if (challenges.Count > 0)
            {
                Console.WriteLine($"Challenges: {string.Join(", ", challenges)}");

            }
        }
    }
}