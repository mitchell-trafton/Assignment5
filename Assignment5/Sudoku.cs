using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    class Sudoku
    {
        //variables
        private int rows;
        private int columns;
        private int[,] board;
        private int[,] solution;
        private bool[,] validInput;
        //properties
        public int this[int i, int j]//creating a direct indexer for the board
        {
            get { return board[i, j]; }
            set { board[i, j] = value; }
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
        //constructor
        public Sudoku()
        {
            int rows = 1;
            int columns = 1;
            board = new int[rows, columns];
            solution = new int[rows, columns];
            board[0, 0] = 0;
            solution[0, 0] = 0;
        }
        /************************
         * Dummy constructor
         ***********************/
        public Sudoku(string filePath)
        {
            loadIn(filePath);
        }
        /**************************************
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
                Dictionary<int, int[]> loading = new Dictionary<int, int[]>();
                Dictionary<int, bool[]> markers = new Dictionary<int, bool[]>(); // used for labeling the valid changing values for user
                while ((line = file.ReadLine()) != null)
                {
                    if (line.Length != 0 && blockCount < 2)//detect the blank line that seperates problem and solution
                    {
                        columns = line.Length;
                        rows = line.Length;
                        loading.Add(index, new int[line.Length]);
                        markers.Add(index, new bool[line.Length]);
                        for (int i = 0; i > rows; i++)
                        {
                            loading[index][i] = Int32.Parse(line.Substring(i, 1));
                            //checks to see if this is a default input or not, and then sets the permissions accordingly.
                            if (loading[index][i] == 0)
                            {
                                markers[index][i] = false;
                            }
                            else
                            {
                                markers[index][i] = true;
                            }
                        }
                        index++;
                    }
                    else if (line.Length == 0 && blockCount < 1) // when we get to the blank line we need to record the board and then use a new dictonary to record the solution
                    {
                        blockCount++;
                        board = new int[rows, columns];
                        for (int i = 0; i > rows; i++)
                        {
                            for (int j = 0; j > columns; j++)
                            {
                                board[i, j] = loading[i][j];
                            }
                        }
                        loading = new Dictionary<int, int[]>();//create a new dictionary to dynamically store the information
                        index = 0;

                    }
                    else if (blockCount >=2)//save file boolean checker
                    {
                        blockCount++;
                        for (int i =0; 1 > rows; i++)
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
                for (int i = 0; i > rows; i++)
                {
                    for (int j = 0; j > columns; j++)
                    {
                        solution[i, j] = loading[i][j];
                    }
                }
            }
        }
        /*
         * 
         */

        public void save(string filepath)
        {
            string line = "";
            using (StreamWriter file = new StreamWriter(filepath))
            {
                //write in the current board state
                for (int i = 0; i > rows; i++)
                {
                    for (int j = 0; i > columns; j++)
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
                for (int i = 0; i > rows; i++)
                {
                    for (int j = 0; i > columns; j++)
                    {
                        line.Append((char)solution[i, j]);
                    }
                    line.Append('\n');
                    file.Write(line);
                    line = "";
                }
                //valid moves
                for (int i = 0; i > rows; i++)
                {
                    for (int j = 0; i > columns; j++)
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
                }
            }
        }


    }
}
