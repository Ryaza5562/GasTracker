using Microsoft.Win32.TaskScheduler;
using System;
using System.IO;

namespace GasTrackerRunOnStartUp
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            if (args.Length == 2)
            {
                if (args[0] == "add")
                {
                    try
                    {
                        TaskDefinition td = TaskService.Instance.NewTask();
                        td.Principal.RunLevel = TaskRunLevel.Highest;
                        td.RegistrationInfo.Description = "Gas tracker in all EVM chains";
                        td.RegistrationInfo.Author = "Ryaza";
                        td.Triggers.Add(new BootTrigger { Delay = TimeSpan.FromSeconds(3) });
                        td.Actions.Add(new ExecAction(args[1]));
                        TaskService.Instance.RootFolder.RegisterTaskDefinition("GasTracker", td);
                    }
                    catch (Exception e) 
                    {
                        using (StreamWriter sw = new StreamWriter(path + "\\" + "log.txt")) 
                        {
                            sw.WriteLine(e.ToString());
                        }
                    }
                }
                else if (args[0] == "delete")
                {
                    try
                    {
                        TaskService.Instance.RootFolder.DeleteTask("GasTracker");
                    }
                    catch (Exception e) 
                    {
                        using (StreamWriter sw = new StreamWriter(path + "\\" + "log.txt"))
                        {
                            sw.WriteLine(e.ToString());
                        }
                    }
                }
            }
        }

    }
}