using System;
using BowlingApp.Src;
using System.Reflection;

namespace BowlingApp
{
    public class ProgramClass
    {
        private readonly IBowling _bowling;
        private readonly ITextFileLoader _textFileLoader;

        public ProgramClass()
        {
            _bowling = new Bowling();
            _textFileLoader = new TextFileLoader();
        }

        public void Run(string[] args)
        {
            DisplayStartingMessage();

            var textFile = string.Empty;

            if (args.Length == 1)
            {
                textFile = _textFileLoader.LoadFile(args[0]);
            }

            if (string.IsNullOrWhiteSpace(textFile))
            {
                do
                {
                    var input = Console.ReadLine();
                    textFile = _textFileLoader.LoadFile(input, true);
                } while (textFile.Length <= 0);
            }

            CreateConsoleGap(2);

            var loadGameResult = _bowling.LoadGame(textFile);

            if (loadGameResult.IsValid)
            {
                foreach (var player in _bowling.Players)
                {
                    var calculationResult = _bowling.CalculatePoints(player.Frames);

                    if (calculationResult.IsValid)
                    {
                        var formatter = new BowlingScoreFormatter();
                        formatter.DisplayScoreBoard(player, calculationResult.Model);
                    }
                    else
                    {
                        Console.WriteLine(calculationResult.ErrorMessage);
                    }
                }
            }
            else
            {
                Console.WriteLine(loadGameResult.ErrorMessage);
            }
        }

        private void DisplayStartingMessage()
        {
            Console.WriteLine($"Bowling score calculator v{Assembly.GetExecutingAssembly().GetName().Version}");
            Console.WriteLine("For this application, put your .txt file in the \"BowlingApp\" project folder,");
            Console.WriteLine("where the .exe file exist or give the absolute path to the file.");
            Console.WriteLine("There is also an example file created in the project directory - test.txt");
            Console.WriteLine("This file will be loaded as a default if you just click enter or your file will not be found.");
            Console.WriteLine();
            Console.WriteLine("Enter the name of the file from which the data will be loaded: ");
        }

        private void CreateConsoleGap(int writeLineCount)
        {
            for (int i = 0; i < writeLineCount; i++)
            {
                Console.WriteLine();
            }
        }
    }
}
