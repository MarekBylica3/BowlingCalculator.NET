using System;
using System.IO;
using BowlingApp.Resources;

namespace BowlingApp.Src
{
    public class TextFileLoader : ITextFileLoader
    {
        private readonly string DefaultFile = "test.txt";

        public string LoadFile(string path, bool defaultFileIfNotFound = false)
        {
            var output = string.Empty;

            try
            {
                if (string.IsNullOrEmpty(Path.GetExtension(path)))
                    path += ".txt";

                if (!path.Contains(Path.DirectorySeparatorChar))
                    output = ReadFileIfExist("../../../" + path);

                if (string.IsNullOrWhiteSpace(output))
                    output = ReadFileIfExist(path);

                if (defaultFileIfNotFound)
                { 
                    if (string.IsNullOrWhiteSpace(output))
                        output = ReadFileIfExist("../../../" + DefaultFile);

                    if (string.IsNullOrWhiteSpace(output))
                        output = ReadFileIfExist(DefaultFile);
                }

            }
            catch (Exception)
            {
                Console.WriteLine(BowlingResources.FileLoadingError);
            }

            return output;
        }

        private string ReadFileIfExist(string path)
        {
            var output = string.Empty;

            if (File.Exists(path))
            {
                output = File.ReadAllText(path);
            }

            return output;
        }

    }
}
