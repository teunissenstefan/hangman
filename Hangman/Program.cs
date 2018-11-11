using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            List<string> wordList = new List<string>();
            wordList.Add("pizza");
            wordList.Add("apple");
            wordList.Add("pinecone");
            wordList.Add("mouse");
            wordList.Add("santa");
            wordList.Add("christmas");
            wordList.Add("hangman");
            wordList.Add("supercalifragilisticexpialidocious");

            bool keepPlaying = true;
            while (keepPlaying)
            {
                GameLoop(wordList[rnd.Next(wordList.Count)], ref keepPlaying);
            }
        }

        static void GameLoop(string word, ref bool keepPlaying)
        {
            Console.Clear();
            List<Char> acceptableLetters = ("abcdefghijklmnopqrstuvwxyz").ToCharArray().ToList();
            char[] wordLetters = (word).ToCharArray();
            List<Char> correctLetters = new List<Char>();
            for (int i=0;i<wordLetters.Length;i++) { correctLetters.Add('_'); }
            ConsoleKeyInfo prevCKI = new ConsoleKeyInfo();
            bool gameRunning = true;
            int errors = 0;
            while (gameRunning)
            {
                Console.Clear();
                Console.WriteLine("Hangman" + Environment.NewLine);
                DrawHeader(prevCKI, wordLetters, acceptableLetters, correctLetters, ref gameRunning, ref errors);
                if (gameRunning)
                {
                    prevCKI = Console.ReadKey();
                }
            }
            GameOver(correctLetters, ref keepPlaying);
        }

        static void GameOver(List<Char> correctLetters, ref bool keepPlaying)
        {
            string goText = "won";
            if (correctLetters.Contains('_'))
            {
                goText = "lost";
            }
            Console.WriteLine(Environment.NewLine+"GameOver, you "+goText+"!");
            Console.WriteLine("Press [y] to play again");
            if (Console.ReadKey().KeyChar!='y')
            {
                keepPlaying = false;
            }
        }

        static void DrawHeader(ConsoleKeyInfo prevCKI, char[] wordLetters, List<Char> acceptableLetters, List<Char> correctLetters, ref bool gameRunning, ref int errors)
        {
            if (acceptableLetters.Contains(prevCKI.KeyChar))
            {
                if (wordLetters.Contains(prevCKI.KeyChar))
                {
                    for (int i = 0; i < wordLetters.Length; i++)
                    {
                        if (wordLetters[i] == prevCKI.KeyChar)
                        {
                            correctLetters[i] = prevCKI.KeyChar;
                        }
                    }
                    if (!correctLetters.Contains('_'))
                    {
                        gameRunning = false;//GameOver
                    }
                }
                else
                {
                    errors++;
                    if (errors>7)
                    {
                        gameRunning = false;//GameOver
                    }
                }
                acceptableLetters.Remove(prevCKI.KeyChar);
            }
            else
            {
                if (prevCKI.KeyChar!='\0')
                {
                    Console.WriteLine("You've already tried that letter, try another one");
                }
            }

            DrawBottom(prevCKI, wordLetters, acceptableLetters, correctLetters, errors);
        }

        static void DrawBottom(ConsoleKeyInfo prevCKI, char[] wordLetters, List<Char> acceptableLetters, List<Char> correctLetters, int errors)
        {
            foreach (char c in correctLetters)
            {
                Console.Write(c.ToString().ToUpper() + " ");
            }
            Console.WriteLine(Environment.NewLine + Environment.NewLine + "Letters remaining: ");
            foreach (char c in acceptableLetters)
            {
                Console.Write(c.ToString().ToUpper() + " ");
            }

            DrawHangMan(errors);
        }

        static void DrawHangMan(int errors)
        {
            switch(errors){
                case 0:
                    break;
                case 1:
                    Console.WriteLine(Environment.NewLine);
                    Console.WriteLine("----------------------");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    break;
                case 2:
                    Console.WriteLine(Environment.NewLine);
                    Console.WriteLine("----------------------");
                    Console.WriteLine("|");
                    Console.WriteLine("|         ---");
                    Console.WriteLine("|        /   \\");
                    Console.WriteLine("|       |     |");
                    Console.WriteLine("|        \\___/");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    break;
                case 3:
                    Console.WriteLine(Environment.NewLine);
                    Console.WriteLine("----------------------");
                    Console.WriteLine("|");
                    Console.WriteLine("|         ---");
                    Console.WriteLine("|        /   \\");
                    Console.WriteLine("|       |     |");
                    Console.WriteLine("|        \\___/");
                    Console.WriteLine("|          |");
                    Console.WriteLine("|          |");
                    Console.WriteLine("|          |");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    break;
                case 4:
                    Console.WriteLine(Environment.NewLine);
                    Console.WriteLine("----------------------");
                    Console.WriteLine("|");
                    Console.WriteLine("|         ---");
                    Console.WriteLine("|        /   \\");
                    Console.WriteLine("|       |     |");
                    Console.WriteLine("|        \\___/");
                    Console.WriteLine("|        \\ |");
                    Console.WriteLine("|         \\|");
                    Console.WriteLine("|          |");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    break;
                case 5:
                    Console.WriteLine(Environment.NewLine);
                    Console.WriteLine("----------------------");
                    Console.WriteLine("|");
                    Console.WriteLine("|         ---");
                    Console.WriteLine("|        /   \\");
                    Console.WriteLine("|       |     |");
                    Console.WriteLine("|        \\___/");
                    Console.WriteLine("|        \\ | /");
                    Console.WriteLine("|         \\|/");
                    Console.WriteLine("|          |");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    break;
                case 6:
                    Console.WriteLine(Environment.NewLine);
                    Console.WriteLine("----------------------");
                    Console.WriteLine("|");
                    Console.WriteLine("|         ---");
                    Console.WriteLine("|        /   \\");
                    Console.WriteLine("|       |     |");
                    Console.WriteLine("|        \\___/");
                    Console.WriteLine("|        \\ | /");
                    Console.WriteLine("|         \\|/");
                    Console.WriteLine("|          |");
                    Console.WriteLine("|         /");
                    Console.WriteLine("|        /");
                    Console.WriteLine("|       /");
                    Console.WriteLine("|");
                    break;
                case 7:
                    Console.WriteLine(Environment.NewLine);
                    Console.WriteLine("----------------------");
                    Console.WriteLine("|");
                    Console.WriteLine("|         ---");
                    Console.WriteLine("|        /   \\");
                    Console.WriteLine("|       |     |");
                    Console.WriteLine("|        \\___/");
                    Console.WriteLine("|        \\ | /");
                    Console.WriteLine("|         \\|/");
                    Console.WriteLine("|          |");
                    Console.WriteLine("|         / \\");
                    Console.WriteLine("|        /   \\");
                    Console.WriteLine("|       /     \\");
                    Console.WriteLine("|");
                    break;
                case 8:
                    Console.WriteLine(Environment.NewLine);
                    Console.WriteLine("----------------------");
                    Console.WriteLine("|          |");
                    Console.WriteLine("|         ---");
                    Console.WriteLine("|        /   \\");
                    Console.WriteLine("|       |     |");
                    Console.WriteLine("|        \\___/");
                    Console.WriteLine("|        \\ | /");
                    Console.WriteLine("|         \\|/");
                    Console.WriteLine("|          |");
                    Console.WriteLine("|         / \\");
                    Console.WriteLine("|        /   \\");
                    Console.WriteLine("|       /     \\");
                    Console.WriteLine("|");
                    break;
            }
        }
    }
}
