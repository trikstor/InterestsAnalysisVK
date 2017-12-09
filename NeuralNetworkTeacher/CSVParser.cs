using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NeuralNetworkTeacher
{
    public class CSVParser
    {
        public Dictionary<string, IList<string>> Parse(string csvFilePath)
        {
            var result = new Dictionary<string, IList<string>>();
            using (var streamReader = new StreamReader(csvFilePath, Encoding.GetEncoding(1251)))
            {
                // Первая строка содержит формат и не нужна нам.
                var line = streamReader.ReadLine();
                while ((line = streamReader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                    var operatedRow = CSVRowReader(line);
                    if (!result.ContainsKey(operatedRow.Item1))
                        result.Add(operatedRow.Item1, new List<string>{operatedRow.Item2});
                    else
                        result[operatedRow.Item1].Add(operatedRow.Item2);
                }
            }
            return result;
        }

        private (string, string) CSVRowReader(string tableRow)
        {
            var row = tableRow.Split(';').ToList();
            var category = row[row.Count - 1].Replace(".txt", "");
            row.RemoveAt(row.Count - 1);
            
            return (category, string.Join("", row));
        }
    }
}