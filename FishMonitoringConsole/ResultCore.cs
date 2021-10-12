using System;
using System.Collections.Generic;
using System.Text;

namespace FishMonitoringConsole
{
    public interface ResultCore
    {
        public static string ShowTable(string temp, int maxTemp, Dictionary<DateTime, double> dtList)
        {
            string result = "<span style=\"margin-left: 25px;\">Время</span><span style=\"margin-left: 65px;\">Факт</span><span style=\"margin-left: 35px;\">Норма</span><span style=\"margin-left: 30px;\">Отклонение от нормы</span><br>";
            List<int> tempData = ArrayStrToInt(temp.Split(", "));
            List<string> timeList = new List<string>();

            foreach (DateTime key in dtList.Keys)
            {
                timeList.Add(DateTimeToString(key));
            }

            for (int i = 0; i < tempData.Count; i++)
            {
                if (tempData[i] > maxTemp)
                    result += $"<span>{timeList[i]}</span><span style=\"margin-left: 50px;\">{tempData[i]}</span>" + $"<span style=\"margin-left: 50px;\">{maxTemp}</span>" + 
                        $"<span style=\"margin-left: 120px;\">{tempData[i]-maxTemp}<span>" + "<br>";
            }
            
            return result;
        }

        private static List<int> ArrayStrToInt(string[] t)
        {
            List<int> res = new List<int>();

            for (int i = 0; i < t.Length; i++)
            {
                res.Add(int.Parse(t[i]));
            }

            return res;
        }

        private static string DateTimeToString(DateTime dt)
        {
            return $"{dt.Day}.{dt.Month}.{dt.Year} {dt.Hour}:{dt.Minute}";
        }
    }
}
