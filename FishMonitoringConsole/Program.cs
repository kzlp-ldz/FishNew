using System;
using System.Collections.Generic;

namespace FishMonitoringConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // temperature data
            int interval = 10; //min
            string tempData = "-1, -2, -3, -6, -7";
            //fish data
            int maxTemp = -4;
            int maxTempTime = 10; // min


            TempQuality quality = new TempQuality(interval , tempData);
            Fish mentai = new FrozenFish(quality, (double)maxTemp, new TimeSpan(0, maxTempTime, 0));
	
	    Console.WriteLine("Content-Type: text/html \n\n");
            Console.WriteLine("<html><head><title> Fish</title><meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\"> </head>");
            Console.WriteLine("<body>");
            
            Console.WriteLine($"{ResultCore.ShowTable(tempData, maxTemp, quality.GetTimeMeasure())}");
            Console.WriteLine("</body></html>");
        }
    }
 
}
