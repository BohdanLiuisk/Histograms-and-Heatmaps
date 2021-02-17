using System.IO;
using System.Linq;

namespace HistogramsHeatMap
{
    class Program
    {
        private static readonly string dataFilePath = "names.txt";

        private static void Main(string[] args)
        {
            var namesData = ReadData();
            Charts.ShowHeatmap(HeatmapTask.GetBirthsPerDateHeatmap(namesData));

            Charts.ShowHistogram(HistogramTask.GetBirthsPerDayHistogram(namesData, "роман"));
            Charts.ShowHistogram(HistogramTask.GetBirthsPerDayHistogram(namesData, "богдан"));
        }

        private static NameData[] ReadData()
        {
            var lines = File.ReadAllLines(dataFilePath);
            var names = new NameData[lines.Length];
            for (var i = 0; i < lines.Length; i++)
                names[i] = NameData.ParseFrom(lines[i]);
            return names;
        }

        //by LINQ
        private static NameData[] ReadData2()
        {
            return File
                .ReadLines(dataFilePath)
                .Select(NameData.ParseFrom)
                .ToArray();
        }
    }
}