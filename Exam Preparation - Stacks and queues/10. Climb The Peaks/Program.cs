namespace _10._Climb_The_Peaks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input1 = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[] input2 = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            Dictionary<string, int> peaks = new Dictionary<string, int>()
            {
                { "Vihren", 80},
                { "Kutelo", 90},
                { "Banski Suhodol", 100},
                { "Polezhan", 60},
                { "Kamenitza", 70}
            };


            Stack<int> dailyPortions = new Stack<int>(input1);
            Queue<int> dailyStamina = new Queue<int>(input2);
            Queue<string> peaksNames = new Queue<string>();
            Queue<string> climbedPeaks = new Queue<string>();

            foreach (var peak in peaks)
            {
                peaksNames.Enqueue(peak.Key);
            }

            while (dailyPortions.Any() && dailyStamina.Any() && peaksNames.Any())
            {
                int portionValue = dailyPortions.Peek();
                int staminaValue = dailyStamina.Peek();
                int result = portionValue + staminaValue;

                if (result >= peaks[peaksNames.Peek()])
                {
                    climbedPeaks.Enqueue(peaksNames.Dequeue());
                    dailyPortions.Pop();
                    dailyStamina.Dequeue();
                }
                else
                {
                    dailyPortions.Pop();
                    dailyStamina.Dequeue();
                }
            }

            if (peaksNames.Any())
            {
                Console.WriteLine("Alex failed! He has to organize his journey better next time -> @PIRINWINS");
            }
            else
            {
                Console.WriteLine("Alex did it! He climbed all top five Pirin peaks in one week -> @FIVEinAWEEK");
            }
            if (climbedPeaks.Any())
            {
                Console.WriteLine("Conquered peaks:");
                foreach (var peak in climbedPeaks)
                {
                    Console.WriteLine($"{peak}");
                }
            }



        }
    }
}