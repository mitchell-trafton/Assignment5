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
        private TimeSpan time;

        public TimeSpan Time
        {
            get { return time + stopWatch.Elapsed; }
            set { time = value; }
        }
        /***********************************************
         * Simple no fuss constructor that creates a 
         * stopwatch object for our wrapper.
         * 
         * 
         ***********************************************/
        public Clock()
        {
            stopWatch = new Stopwatch();
            time = new TimeSpan(0);
        }
        public Clock(TimeSpan ttime)
        {
            stopWatch = new Stopwatch();
            time = ttime;
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
            TimeSpan ttime = stopWatch.Elapsed + time;
            string output = "";
            output = (ttime.Hours + ":" + ttime.Minutes + ":" + ttime.Seconds);
            return output;
        }

    }
}
