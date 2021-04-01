using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
/************************************************************
 * Assignment 5
 * Programmers: Robert Tyler Trotter z1802019
 *              Mitchell Trafton     z1831076
 ***********************************************************/
namespace Assignment5
{
    class Clock
    {
        private Stopwatch stopWatch;

        /***********************************************
         * Simple no fuss constructor that creates a 
         * stopwatch object for our wrapper.
         * 
         * 
         ***********************************************/
        public Clock()
        {
            stopWatch = new Stopwatch();
        }


        /********************************************
         * void Start()
         * starts the stopwatch, can also be used to 
         * unpause
         * 
         * 
         * 
         *******************************************/
        public void Start()
        {
            stopWatch.Start();
        }
        /*******************************************
         * String stop
         * returns: a H:MM:SS time elapsed
         * purpose: Stops and clears the timer, returns
         * how much time had elapsed since start
         * 
         *******************************************/
        public string Stop()
        {
            stopWatch.Stop();
            string output = getTime();
            stopWatch.Reset();
            return output;
        }
        /**********************************************
         * Void Pause
         * purpose: Pauses the timer with no further interaction
         * 
         * 
         *********************************************/
        public void Pause()
        {
            stopWatch.Stop();
        }
        /**********************************************
         * String getTime
         * returns: a H:MM:SS time elapsed
         * purpose: allows access to the time of the running timer
         * without clearing it.
         * 
         *********************************************/
        public string getTime()
        {
            TimeSpan time = stopWatch.Elapsed;
            string output = "";
            output = (time.Hours + ":" + time.Minutes + ":" + time.Seconds);
            return output;
        }
    }
}
