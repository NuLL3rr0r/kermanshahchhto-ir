using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace proxymode
{
    class Program
    {
        static string errPrefix = "\n\n\n\t\tError: {0}";
        static string errInvalidProxy = "Invalid proxy format!";

        static void Main(string[] args)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("\n\n\t\t\t\t");
                sb.Append("Mac CMS X Launcher v1.0");
                sb.Append("\n\n\n\n\t\t");
                sb.Append("1. Using IE proxy settings");
                sb.Append("\n\n\t\t");
                sb.Append("2. Using CMS proxy settings");
                sb.Append("\n\n\t\t");
                sb.Append("3. Using your own proxy");
                sb.Append("\n\n\t\t");
                sb.Append("4. Exit [ESC]");
                sb.Append("\n\n\n\t\t");
                sb.Append("Choose Action: ");

                Console.Write(sb.ToString());

                ConsoleKeyInfo key = new ConsoleKeyInfo();

                string cargs = string.Empty;

                do
                {
                    key = Console.ReadKey();

                    switch (key.Key)
                    {
                        case (ConsoleKey.D1):
                        case (ConsoleKey.NumPad1):
                            //cargs = "/proxy:ie";
                            cargs = "ie";
                            break;
                        case (ConsoleKey.D2):
                        case ConsoleKey.NumPad2:
                            //cargs = "/proxy:pref";
                            cargs = "pref";
                            break;
                        case (ConsoleKey.D3):
                        case ConsoleKey.NumPad3:
                            do
                            {
                                Console.Clear();
                                Console.Write("\n\n\n\n\t\tPlease enter your proxy in the following format:\n\n\n\t\t{PROXY}:{PORT}\n\n\t\t");
                                string proxy = Console.ReadLine();
                                int pos1 = proxy.IndexOf(":");
                                int pos2 = proxy.LastIndexOf(":");

                                if (pos1 != -1 && (pos1 != 0 && pos1 != proxy.Length - 1) && pos1 == pos2)
                                {
                                    //cargs = string.Format("/proxy:{0}", proxy);
                                    cargs = proxy;
                                    break;
                                }
                                else
                                    Error(errInvalidProxy);
                            } while (true);
                            break;
                        default:
                            Console.Clear();
                            Console.Write(sb.ToString());
                            break;
                    }

                    if (cargs != string.Empty)
                    {
                        Console.Clear();
                        RunCMS(cargs);
                        break;
                    }

                } while (key.Key != ConsoleKey.Escape);
            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
            finally
            {
                Environment.Exit(0);
            }
        }

        private static void RunCMS(string args)
        {
            try
            {
                string path = Environment.CurrentDirectory;
                path += path.EndsWith(Path.DirectorySeparatorChar.ToString()) ? string.Empty : Path.DirectorySeparatorChar.ToString();

                Process p = new Process();
                p.StartInfo.Arguments = args;
                p.StartInfo.FileName = String.Concat(path, "krchhto.exe");
                p.Start();
            }
            catch (ObjectDisposedException ex)
            {
                Error(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                Error(ex.Message);
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                Error(ex.Message);
            }
            catch (SystemException ex)
            {
                Error(ex.Message);
            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
            finally
            {
            }
        }

        private static void Error(string err)
        {
            Console.Write(errPrefix, err);
            Console.ReadKey();
        }
    }
}
