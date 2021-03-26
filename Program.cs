using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediff_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the algorithm to work");
            int n = Convert.ToInt32(Console.ReadLine());
            string path = Environment.CurrentDirectory;
            path = path.Replace("\\bin\\Debug", "");
            StreamWriter sw = null;
            try
            {
                if (n == 1)
                {
                    sw = new StreamWriter(path + "\\log.txt");
                    sw.WriteLine("Owner Information");
                    Owners owners = new Owners();
                    owners.Add(sw,null);//please pass the dictionary
                    Dictionary<string, List<string>> groupdic = owners.Group_By_Owners();
                    sw.WriteLine("Owner Information Group by fetched \t" + groupdic.Count);
                    foreach (string name in groupdic.Keys)
                    {
                        Console.Write(name + "\t:");
                        Console.Write(string.Join(",", groupdic[name]));
                        sw.WriteLine(name + ":" + string.Join(",", groupdic[name]));
                        Console.WriteLine();
                    }
                    sw.WriteLine("Owner Information Completed");
                    sw.Flush();
                }
                if (n == 2)
                {
                    sw = new StreamWriter(path + "\\log.txt");
                    sw.WriteLine("palindrome started");
                    palindrome palindrome = new palindrome("kdoodk");
                    if (palindrome.checkIsPalindrome())
                        Console.WriteLine("It is palindrome");
                    else
                        Console.WriteLine("It is not a palindrome");
                    sw.WriteLine("palindrome Completed");
                }
                if (n == 3)
                {
                    //Parsing Log File
                    //Reading LogFile written by me manually.
                    StreamReader sr = new StreamReader(path + "\\log.txt");
                    StreamWriter errlog = new StreamWriter(path + "\\Errorlog.txt");
                    string line;
                    while((line=sr.ReadLine())!=null)
                    {
                        if (line.Contains("[Error]") || line.Contains("[Warning]"))
                            errlog.WriteLine(line);
                    }
                    errlog.Flush();
                    errlog.Close();
                }
                if(n==4)
                {
                    sw = new StreamWriter(path + "\\log.txt");
                    Console.WriteLine("Enter the valid path");
                    string p = Console.ReadLine();
                    DirectoryProgram directoryProgram = new DirectoryProgram(p);
                    directoryProgram.cd("../x");
                    Console.WriteLine(directoryProgram.getCurrentPath());
                    sw.WriteLine(directoryProgram.getCurrentPath());
                }
            }
            catch(Exception ex)
            {
                sw.WriteLine("[Error]:\t"+ex.Message+"\t"+ex.StackTrace);
            }
            finally
            {
                if (sw != null)
                {
                    sw.Flush();
                    sw.Close();
                }
            }
        }
    }
}
