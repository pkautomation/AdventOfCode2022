namespace SharedUtilities
{
        public class FileReader
        {
            public static List<string> ReadFile(string fileName = "puzzle.txt")
            {
                var projectName = System.Reflection.Assembly.GetEntryAssembly().GetName().Name;
                string[] lines = File.ReadAllLines(@$"C:\repos\AdventOfCode2022\AdventOfCode2022\{projectName}\{fileName}");
                var values = new List<string>();

                foreach (var line in lines)
                {
                    values.Add(line);
                }

                return values;
            }
        }
}