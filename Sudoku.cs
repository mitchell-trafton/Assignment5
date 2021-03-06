using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    /************************************************************
    * Assignment 5
    * Programmers: Robert Tyler Trotter z1802019
    *              Mitchell Trafton     z1831076
    ***********************************************************/
    class Sudoku
    {
        //variables
        private int rows;
        private int columns;
        private int[,] board;
        private int[,] solution;
        private bool[,] validInput;
        private TimeSpan time;
        //properties
        public int this[int i, int j]//creating a direct indexer for the board
        {
            get { return board[i, j]; }
            set { board[i, j] = value; }
        }
        public TimeSpan Time
        {
            get { return time; }
            set { time = value; }
        }
        public int Rows
        {
            get { return rows; }
            set { }
        }
        public int Columns
        {
            get { return columns; }
            set { }
        }
        public int[,] Solution
        {
            get { return solution; }
            set { }
        }
        public bool[,] ValidInput
        {
            get { return validInput; }
            set { }
        }
        //default constructor
        public Sudoku()
        {
            int rows = 1;
            int columns = 1;
            board = new int[rows, columns];
            solution = new int[rows, columns];
            board[0, 0] = 0;
            solution[0, 0] = 0;
            time = new TimeSpan(0);
        }
        /************************
         * Dummy constructor
         ***********************/
        public Sudoku(string filePath)
        {
            loadIn(filePath);
            time = new TimeSpan(0);
        }
        /**************************************
         * void loadin
         * purpose: Read from a file and populate
         * the sudoku, whether that's an origional
         * or a save
         * 
         *************************************/
        private void loadIn(string fileName)
        {
            using (StreamReader file = new StreamReader(fileName))
            {
                string line;
                int index = 0;
                int index2 = 0;
                int blockCount = 0; //used for counting the blocks of data read and controlling storage, initial puzzles will have 2, save files will have 3
                Dictionary<int, int[]> loading = new Dictionary<int, int[]>(); //used for extracting the problem and solution grids
                Dictionary<int, bool[]> markers = new Dictionary<int, bool[]>(); // used for labeling the valid changing values for user
                while ((line = file.ReadLine()) != null)
                {
                    if (line.Length != 0 && blockCount < 2)//detect the blank line that seperates problem and solution
                    {
                        columns = line.Length;
                        rows = line.Length;
                        loading.Add(index, new int[line.Length]);
                        if(blockCount < 1)
                        markers.Add(index, new bool[line.Length]);
                        for (int i = 0; i < rows; i++)
                        {

                            loading[index][i] = Int32.Parse(line.Substring(i, 1));
                            //checks to see if this is a default input or not, and then sets the permissions accordingly.
                            if (blockCount < 1)
                            {
                                if (loading[index][i] != 0)
                                {
                                    markers[index][i] = false;
                                }
                                else
                                {
                                    markers[index][i] = true;
                                }
                            }
                        }
                        index++;
                    }
                    else if (line.Length == 0 && blockCount < 1) // when we get to the blank line we need to record the board and then use a new dictonary to record the solution
                    {
                        blockCount++;
                        board = new int[rows, columns];
                        for (int i = 0; i < rows; i++)
                        {
                            for (int j = 0; j < columns; j++)
                            {
                                board[i, j] = loading[i][j];
                                Console.WriteLine(board[i, j]);//debug output
                            }
                        }
                        loading = new Dictionary<int, int[]>();//create a new dictionary to dynamically store the information
                        index = 0;

                    }
                    else if (line.Length == 0 && blockCount >=2)
                    {
                        if((line = file.ReadLine()) != null)
                        {
                            long t = Int64.Parse(line); //converts the timespan to an int to load
                            time = new TimeSpan(t);//load the timespan from the save, to be used to create the timer
                        }
                    }
                    else if (blockCount >=2)//save file boolean checker
                    {
                        blockCount++;
                        for (int i =0; 1 < rows; i++)
                        {
                            if(Int32.Parse(line.Substring(i, 1)) == 0)
                            {
                                markers[index2][i] = true;
                            }
                            else
                            {
                                markers[index2][i] = false;
                            }
                        }
                        index2++;
                    }

                }
                //now we store solution
                solution = new int[rows, columns];
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        solution[i, j] = loading[i][j];
                        Console.WriteLine(solution[i, j]);
                    }
                }
                //save the valid input
                validInput = new bool[rows, columns];
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        validInput[i, j] = markers[i][j];
                    }
                }
            }
        }
        /*********************************************************
         * void Save
         * Purpose: saves the current puzzle by block
         * first is the current work
         * second block is the solution
         * third is the user modifyable section
         * fourth is the current time of the save
         *********************************************************/

        public void save(string filepath)
        {
            string line = "";
            using (StreamWriter file = new StreamWriter(filepath))
            {
                //write in the current board state
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        line.Append((char)board[i, j]);
                    }
                    line.Append('\n');
                    file.Write(line);
                    line = "";
                }
                // empty line and solution
                line = "\n";
                file.Write(line);
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        line.Append((char)solution[i, j]);
                    }
                    line.Append('\n');
                    file.Write(line);
                    line = "";
                }
                //valid moves
                line = "\n";
                file.Write(line);
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        int conversion;
                        if (validInput[i, j])
                            conversion = 1;
                        else
                            conversion = 0;
                        line.Append((char)conversion);
                    }
                    line.Append('\n');
                    file.Write(line);
                    line = "";
                    line = "\n";
                    file.Write(line);
                    file.Write(time.Ticks); // writes the amount of ticks in the clock
                }
            }
        }


    }
}
