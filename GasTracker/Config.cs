using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GasTracker
{
    public class Config
    {
        public bool runOnStartUp;
        public bool taskAdded;
        public List<Chain> chains;
        private string fileName;

        public Config(string fileName, MainForm mm)
        {
            taskAdded = false;
            this.fileName = fileName;
            chains = new List<Chain>();
            if (!File.Exists(this.fileName) || !ReadConfigFile(this.fileName))
                CreateDefaultConfigFile(this.fileName, mm);
        }

        bool ReadConfigFile(string fileName)
        {
            int Counter = 0;
            try
            {
                using (StreamReader reader = new StreamReader(Application.StartupPath + "\\" + fileName))
                {
                    string line;
                    //Read runOnStartUp
                    if ((line = reader.ReadLine()) != null)
                    {
                        if (line.Contains("true"))
                            runOnStartUp = true;
                        else if (line.Contains("false"))
                            runOnStartUp = false;
                        else if(line.Contains("TRUE"))
                            runOnStartUp = taskAdded = true;
                        else
                            return false;
                        Counter++;
                    }
                    //Read chains
                    while ((line = reader.ReadLine()) != null)
                    {
                        Chain ch = new Chain();
                        string[] result = line.Split('|');
                        if (result.Length != 3 && result.Length != 4)
                            return false;
                        ch.name = result[0];
                        ch.rpc = result[1];
                        ch.color = Color.FromName(result[2]);
                        if (result.Length == 4)
                            ch.alert = Int32.Parse(result[3]);
                        else
                            ch.alert = null;
                        chains.Add(ch);
                        Counter++;
                    }
                }
            }catch (Exception) 
            { return false; }
            if (Counter < 2)
                return false;
            return true;
        }
        void CreateDefaultConfigFile(string fileName, MainForm mm)
        {
            try
            {
                FileStream fs = File.Create(Application.StartupPath + "\\" + fileName);
                fs.Close();
                fs.Dispose();
                using (StreamWriter writer = new StreamWriter(Application.StartupPath + "\\"+fileName))
                {
                    writer.WriteLine("TRUE");
                    writer.WriteLine("Ethereum|https://endpoints.omniatech.io/v1/eth/mainnet/public|White");
                }
                runOnStartUp = true;
                taskAdded = false;
                chains.Add(new Chain("Ethereum", "https://endpoints.omniatech.io/v1/eth/mainnet/public", Color.FromName("White")));
            }
            catch (IOException)
            {
                MessageBox.Show("File " + fileName + " is occupied", "IOException");
                Application.Exit();
            }
        }
        public void RebuildConfigFile()
        {
            while (true)
            {
                try
                {
                    File.WriteAllText(Application.StartupPath + "\\" + fileName, string.Empty);
                    using (StreamWriter writer = new StreamWriter(Application.StartupPath + "\\" + fileName))
                    {
                        if (runOnStartUp && taskAdded)
                            writer.WriteLine("TRUE");
                        else if (runOnStartUp && !taskAdded)
                            writer.WriteLine("true");
                        else if (!runOnStartUp)
                            writer.WriteLine("false");

                        foreach (Chain ch in chains)
                            if (ch.alert == null)
                                writer.WriteLine(ch.name + "|" + ch.rpc + "|" + ch.color.Name);
                            else
                                writer.WriteLine(ch.name + "|" + ch.rpc + "|" + ch.color.Name + "|" + ch.alert.ToString());
                    }
                    break;
                }
                catch (IOException)
                {
                    MessageBox.Show("File " + fileName + " is occupied\nClose it!", "IOException");
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error: " + e, "Unexpected error");
                    break;
                }
            }
        }
    }
}
