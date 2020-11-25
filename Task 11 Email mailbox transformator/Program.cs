using System;
using System.IO;
using System.Collections.Generic;


namespace Task_11_Email_mailbox_transformator
{
    class Program
    {
        static string ReadString(string prompt)
        {
            string result;
            do
            {
                Console.Write(prompt);
                result = Console.ReadLine();
            } 
            while (result == "");
            return result;
        }
        static void Main()
        {
            string content = File.ReadAllText(@"C:\Temp\Misc\InfoForComms.txt"); //(ReadString("Please provide the path and file name: "));
            List<string> rows = new List<string>(content.Split('\n'));
            var data = new Dictionary<string, string>();
            for (int i = 0; i < rows.Count; i++)
            {
                if (rows[i].Contains("@"))
                {
                    var col = rows[i].Trim().Split('\t');
                    if (col[1].Contains(","))
                    {
                        foreach (var email in col[1].Split(','))
                        {
                            if (data.TryGetValue(email, out string dls))
                            {
                                dls += col[0]; //atskrit kableliais
                            }
                            else
                            {
                                data.Add(email, col[0]);
                            }
                        }
                    }
                }
            }
        }
    }
}