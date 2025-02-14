﻿using System;

namespace SIS_September2020
{
    public class Program
    {        
        static void Main(string[] args)
        {      
            string inputCommand = string.Empty;
            Chronometer chronometer = new Chronometer();

            while ((inputCommand = Console.ReadLine()) != "exit")            
            {
                if (inputCommand == "start")
                {
                    chronometer.Start();
                }
                else if (inputCommand == "stop")
                {
                    chronometer.Stop();
                }
                else if (inputCommand == "lap")
                {
                    Console.WriteLine(chronometer.Lap());
                }
                else if (inputCommand == "laps")
                {
                    if (chronometer.Laps.Count > 0)
                    {
                        Console.WriteLine(chronometer.ToString());
                    }
                    else
                    {
                        Console.WriteLine("Laps: no laps");
                    }                    
                }
                else if (inputCommand == "time")
                {
                    Console.WriteLine(chronometer.GetTime);
                }
                else if (inputCommand == "reset")
                {
                    chronometer.Reset();
                }                
            }
        }
    }
}
