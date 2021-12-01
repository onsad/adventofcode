namespace AdventOfCode2021.Day1
{
    public class Day1Service
    {
       private List<int> Load()
        {
            string fileName = @"..\..\..\Day1\input.txt";

            IEnumerable<string> lines = File.ReadLines(fileName);

            return lines.Select(l => int.Parse(l)).ToList();
        }

        private int SumOfWindow(List<int> window)
        {
            return window.Sum();
        }

        private int Process(List<int> lines)
        {
            int counter = 0;
            int prevLine = lines[0];

            foreach (var line in lines)
            {
                if (line > prevLine)
                {
                    counter++;
                }

                prevLine = line;
            }

            return counter;
        }

        private int ProcessWindow(List<int> lines)
        {
            int counter = 0;
            int prevWindow = SumOfWindow(lines.Take(3).ToList());

            for (int i = 0; i < lines.Count; i++)
            {
                var actualWindow = SumOfWindow(lines.Skip(i).Take(3).ToList());

                if (actualWindow > prevWindow)
                {
                    counter++;
                }

                prevWindow = actualWindow;
            }

            return counter;
        }

        public void Start()
        {
            var lines = Load();
            Console.WriteLine(Process(lines));
            Console.WriteLine(ProcessWindow(lines));
        }
    }
}
