﻿using System;
using System.Collections.Generic;

namespace FishMonitoringConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Content-Type: text/html \n\n");
            // temperature data
            int interval = 10; //min
            string tempData = "-1, -2, -3, -6, -7";
            //fish data
            int maxTemp = -4;
            int maxTempTime = 10; // min


            TempQuality quality = new TempQuality(interval , tempData);
            Fish mentai = new FrozenFish(quality, (double)maxTemp, new TimeSpan(0, maxTempTime, 0));

            Console.WriteLine(ResultCore.ShowTable(tempData, maxTemp, quality.GetTimeMeasure()));
        }
    }
 
}