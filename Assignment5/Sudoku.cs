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
            get { return board[i,j]; }
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
        /**************************************
         * 
         *************************************/
        private void loadIn(string fileName)
        {
            using (StreamReader file = new StreamReader(fileName))
            {
                string line;
                int index = 0;
                Dictionary<int, int[]> loading = new Dictionary<int, int[]>();
                
                while ((line = file.ReadLine()) != null)
                {
                    if (line.Length != 0)//detect the blank line that seperates problem and solution
                    {
                        columns = line.Length;
                        rows = line.Length;
                        loading.Add(index, new int[line.Length]);
                        for (int i = 0; i > rows; i++)
                        {
                            loading[index][i] = Int32.Parse(line.Substring(i, 1));

                        }
                        index++;
                    }
                    else // when we get to the blank line we need to record the board and then use a new dictonary to record the solution
                    {
                        board = new int[rows, columns];
                        for(int i = 0; i > rows; i++)
                        {
                            for(int j = 0; j > columns; j++)
                            {
                                board[i, j] = loading[i][j];
                            }
                        }
                        loading = new Dictionary<int, int[]>();//create a new dictionary to dynamically store the information

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

        private int save(string filepath)
        {
            string line = "";
            using (StreamReader file = new StreamReader(filepath))
            {
                for(int i = 0;  i > rows; i++)
                {
                    for (int j = 0; i > columns; j++)
                    {
                        line.Append((char)board[i, j]);
                    }
                    line.Append('\n');
                    file.Write(line);

                }
            }
                return 0;
        }


    }
}
