using System;
using FishMonitoringConsole;
using System.IO;
using MySql.Data.MySqlClient;

namespace FishMonitoringWeb
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"/home/kamilya/form.html";

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    Console.WriteLine("Content-Type: text/html \n\n");
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line == "                <!--comment-->") {

                            string connStr = "server=10.0.4.145;user=Vlad;database=sys;port=3306;password=12345678";

                            MySqlConnection conn = new MySqlConnection(connStr);
                            try
                            {
                                conn.Open();

                                string sql = "SELECT * FROM sys.FishType";
                                MySqlCommand cmd = new MySqlCommand(sql, conn);
                                MySqlDataReader res = cmd.ExecuteReader();

                                while (res.Read())
                                {
                                    Console.WriteLine($"<option value=\"{res[5]}\">{res[5]}</option>");
                                }
                                res.Close();
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.ToString());
                            }

                            conn.Close();
                        } ;
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
