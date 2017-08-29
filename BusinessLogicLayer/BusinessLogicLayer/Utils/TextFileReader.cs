using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BusinessLogicLayer.Utils
{
    public class TextFileReader
    {
        public string Read(string filePath)
        {
            var list = new List<string>();

            using (var reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    list.Add(line);
                }
            }

            return list.ToString();
        }

        public void Write(string filePath, string fileContent)
        {
            using (var file = new StreamWriter(filePath))
            {
                file.Write(fileContent);
            }
        }

        public List<string[]> ReadCsv(string filePath)
        {
            var results = new List<string[]>();

            using (var reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    var lineContent = new List<string>();
                    for (var index = 0; index < values.Length; index++)
                    {
                        lineContent.Add(values[index]);
                    }

                    results.Add(lineContent.ToArray());
                }
            }

            return results;
        }
    }
}