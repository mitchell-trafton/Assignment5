using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    static class Globals
    {
        public static string selectedPuzzleLoc;//path to selected puzzle
        public static Sudoku selectedPuzzle = new Sudoku();//Sudoku object for puzzle being played

        public static List<string> get_availible_puzzles(string difficulty = null, bool unused = false)
        {
            StreamReader directoryInput = new StreamReader(@"./a5/directory.txt");//streamreader for the directory file in a5 folder
            string lineIn;//will store each line from the directory file
            List<string> puzzles = new List<string>();//list of the file directories to puzzle files to return

            difficulty = difficulty.ToLower();

            while ((lineIn = directoryInput.ReadLine()) != null)
            {
                if (difficulty == null) puzzles.Add(lineIn);

                else if (lineIn.Split('/')[0] == difficulty)
                    puzzles.Add(lineIn);
            }

            directoryInput.Close();

            if (unused)
            {
                StreamReader playedInput = new StreamReader(@"./a5/played.txt");

                while ((lineIn = playedInput.ReadLine()) != null)
                    if (puzzles.Contains(lineIn)) puzzles.Remove(lineIn);

                playedInput.Close();
            }

            return puzzles;
        }

        public static List<string> get_saved_puzzles()
        {
            StreamReader directoryInput = new StreamReader(@"./Saves/directory.txt");//streamreader for directory.txt in Saves folder
            string lineIn;//will store each line from the directory file
            List<string> puzzles = new List<string>();//list of names of save files; return variable

            while ((lineIn = directoryInput.ReadLine()) != null)
                puzzles.Add(lineIn);

            directoryInput.Close();

            return puzzles;
        }
    }
}
