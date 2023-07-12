using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace GasTracker
{
    public partial class MainForm : Form
    {
        bool allowshowdisplay = false;
        public Config config;
        public List<TrayIcon> trayIcons;
        public MainForm()
        {
            config = new Config("Config.txt", this);
            InitializeComponent();
            loadConfig();
        }

        private void loadConfig()
        {
            trayIcons = new List<TrayIcon>();
            foreach (Chain ch in config.chains)
            {
                trayIcons.Add(new TrayIcon(this, ch.name, ch.rpc, ch.color, ch.alert));
                listBoxGasTracker.Items.Add(ch.name);
            }
            if (config.runOnStartUp)
                checkBoxRunOnStartup.Checked = true;
            else
                checkBoxRunOnStartup.Checked = false;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            new GasListEditor(this).ShowDialog();
        }

        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(allowshowdisplay ? value : allowshowdisplay);
        }

        public void ShowForm()
        {
            if (allowshowdisplay == false)
            {
                allowshowdisplay = true;
                this.Visible = !this.Visible;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            config.RebuildConfigFile();
            if (e.CloseReason == CloseReason.WindowsShutDown
                || e.CloseReason == CloseReason.ApplicationExitCall
                || e.CloseReason == CloseReason.TaskManagerClosing
                || trayIcons.Count == 0)
            {
                return;
            }
            e.Cancel = true;

            allowshowdisplay = false;
            this.Visible = !this.Visible;
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Chain ch = config.chains.Find(x => x.name == listBoxGasTracker.SelectedItem.ToString());
                new GasListEditor(this, ch.name, ch.rpc, ch.color.Name, ch.alert).ShowDialog();
            }
            catch (NullReferenceException)
            {
                if (listBoxGasTracker.Items.Count == 0)
                    MessageBox.Show("Chain list is empty!", "Empty list");
                else
                    MessageBox.Show("Choose chain from list!");
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            try
            {
                string value = listBoxGasTracker.SelectedItem.ToString();
                foreach (TrayIcon tr in trayIcons)
                {
                    if (tr.notifyIcon.Text == value)
                    {
                        trayIcons.Remove(tr);
                        tr.Remove();
                        listBoxGasTracker.Items.Remove(value);
                        foreach (Chain ch in config.chains)
                        {
                            if (ch.name == value)
                            {
                                config.chains.Remove(ch);
                                break;
                            }
                        }
                        break;
                    }

                }
            }
            catch (NullReferenceException)
            {
                if (listBoxGasTracker.Items.Count == 0)
                    MessageBox.Show("Chain list is empty!", "Empty list");
                else
                    MessageBox.Show("Choose chain from list!");
            }
        }

        private void checkBoxRunOnStartup_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxRunOnStartup.Checked && !config.taskAdded)
            {
                config.taskAdded = config.runOnStartUp = checkBoxRunOnStartup.Checked;
                SetStartup(checkBoxRunOnStartup.Checked);

            }
            else if (checkBoxRunOnStartup.Checked && config.taskAdded)
            {
                config.runOnStartUp = checkBoxRunOnStartup.Checked;
            }
            else if (!checkBoxRunOnStartup.Checked && config.taskAdded)
            {
                config.runOnStartUp = checkBoxRunOnStartup.Checked;
                SetStartup(checkBoxRunOnStartup.Checked);
                config.taskAdded = false;
            }
            else if (!checkBoxRunOnStartup.Checked && !config.taskAdded)
            {
                config.runOnStartUp = checkBoxRunOnStartup.Checked;
            }
        }

        public void AddValueToListBox(string name)
        {
            listBoxGasTracker.Items.Add(name);
        }

        public void SetStartup(bool value)
        {
            Process prc = new Process();
            prc.StartInfo.FileName = Application.StartupPath + "\\" + "GasTrackerRunOnStartUp.exe";
            if (value)
            {
                try
                {
                    prc.StartInfo.Arguments = "add \"" + Application.ExecutablePath + "\"";
                    prc.Start();
                    prc.WaitForExit();
                }
                catch (Exception)
                {
                    MessageBox.Show("Can not add application to task sheduler", "Error");
                }
            }
            else
            {
                try
                {
                    prc.StartInfo.Arguments = "delete \"" + Application.ExecutablePath + "\"";
                    prc.Start();
                    prc.WaitForExit();
                }
                catch (Exception)
                {
                    MessageBox.Show("Can not delete application from task sheduler", "Error");
                }
            }
        }
    }
}

