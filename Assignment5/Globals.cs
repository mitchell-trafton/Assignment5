using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/************************************************************
 * Assignment 5
 * Programmers: Robert Tyler Trotter z1802019
 *              Mitchell Trafton     z1831076
 ***********************************************************/

namespace Assignment5
{
    static class Globals
    {
        public static string selectedPuzzleLoc;//path to selected puzzle
        public static Sudoku selectedPuzzle = new Sudoku();//Sudoku object for puzzle being played
        public static string savePath = null;//original puzzle filepath (will be the same as selectedPuzzleLoc if puzzle is not resumed from a save)

        public static List<string> get_availible_puzzles(string difficulty = null, bool unused = false)
        {
            /****************************************************
             * Retrieves a list of file locations of puzzles that match the specified difficulty.
             * 
             * Filters by unplayed puzzles if specified.
             * 
             * 
             * Parameters:
             * 
             * @difficulty = Dificulty to filter by ("easy", "medium", "hard").
             * @unused     = True if only unplayed puzzles should be returned.
             ****************************************************/
            StreamReader directoryInput = new StreamReader(@"./a5/directory.txt");//streamreader for the directory file in a5 folder
            string lineIn;//will store each line from the directory file
            List<string> puzzles = new List<string>();//list of the file directories to puzzle files to return

            difficulty = difficulty.ToLower();

            //retrieve puzzle files from a5/directory.txt
            while ((lineIn = directoryInput.ReadLine()) != null)
            {
                if (difficulty == null) puzzles.Add(lineIn);

                else if (lineIn.Split('/')[0] == difficulty)
                    puzzles.Add(lineIn);
            }

            directoryInput.Close();

            //filter out played puzzles if unused = true (see a5/played.txt)
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
            /**************************************************
             * Gets list of file locations for puzzles in Saves directory.
             **************************************************/
            StreamReader directoryInput = new StreamReader(@"./Saves/directory.txt");//streamreader for directory.txt in Saves folder
            string lineIn;//will store each line from the directory file
            List<string> puzzles = new List<string>();//list of names of save files; return variable

            while ((lineIn = directoryInput.ReadLine()) != null)
                puzzles.Add(lineIn);

            directoryInput.Close();

            return puzzles;
        }

        public static bool save_puzzle(string name)
        {
            /********************************************
             * Saves current selectedPuzzle to file by name of name. 
             ********************************************/

            name = name.Replace(' ', '_');//replace spaces in name with underlines

            StreamReader directoryInput = new StreamReader(@"./Saves/directory.txt");
            string linein;
            while ((linein = directoryInput.ReadLine()) != null)
                if (linein == (name + ".txt"))
                {
                    directoryInput.Close();
                    return false;
                }
            directoryInput.Close();


            selectedPuzzle.save("./Saves/"+name+".txt");
            File.AppendAllText("./Saves/directory.txt", (name + ".txt") + " " + savePath + Environment.NewLine);

            return true;
        }
    }
}
