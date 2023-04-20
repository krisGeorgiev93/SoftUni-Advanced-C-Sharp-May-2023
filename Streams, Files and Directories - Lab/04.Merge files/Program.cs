namespace MergeFiles
{
    using System;
    using System.IO;
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {

            using (StreamReader reader1 = new StreamReader(firstInputFilePath))
            {
                string line = "";
                line = reader1.ReadLine();

                using (StreamReader reader2 = new StreamReader(secondInputFilePath))
                {
                    string secondLine = "";
                    secondLine = reader2.ReadLine();
                    using (StreamWriter writer = new StreamWriter(outputFilePath))
                    {
                        while (true)
                        {
                            if (line != null)
                            {
                                writer.WriteLine(line);
                            }
                            if (secondLine != null)
                            {
                                writer.WriteLine(secondLine);
                            }
                            else
                            {
                                break;
                            }
                            line = reader1.ReadLine();
                            secondLine = reader2.ReadLine();
                        }
                    }
                }




            }
        }
    }
}
