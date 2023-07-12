using System;
using System.Drawing;
using System.Windows.Forms;

namespace GasTracker
{
    public partial class GasListEditor : Form
    {
        MainForm mainForm;
        string trayName;
        public GasListEditor(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        public GasListEditor(MainForm mainForm, string name, string rpc, string color, int? alert)
        {
            InitializeComponent();
            this.trayName = name;
            this.mainForm = mainForm;
            textBoxName.Text = name;
            textBoxRpc.Text = rpc;
            comboBoxColor.SelectedIndex = comboBoxColor.FindString(color);
            if (alert != null)
            {
                checkBoxAlert.Checked = true;
                numericUpDownThreshold.Value = (decimal)alert;
            }

        }

        private void checkBoxAlert_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAlert.Checked)
                numericUpDownThreshold.Enabled = true;
            else
                numericUpDownThreshold.Enabled = false;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text == "" || textBoxRpc.Text == "" || comboBoxColor.SelectedIndex == -1)
            {
                MessageBox.Show("Fill all the fields", "Empty fields");
            }
            else
            {
                if (trayName == null)
                {
                    if (!checkBoxAlert.Checked)
                    {
                        mainForm.config.chains.Add(new Chain(textBoxName.Text, textBoxRpc.Text, Color.FromName(Convert.ToString(comboBoxColor.SelectedItem))));
                        mainForm.trayIcons.Add(new TrayIcon(mainForm, textBoxName.Text, textBoxRpc.Text, Color.FromName(Convert.ToString(comboBoxColor.SelectedItem))));
                    }
                    else
                    {
                        mainForm.config.chains.Add(new Chain(textBoxName.Text, textBoxRpc.Text, Color.FromName(Convert.ToString(comboBoxColor.SelectedItem)), (int)numericUpDownThreshold.Value));
                        mainForm.trayIcons.Add(new TrayIcon(mainForm, textBoxName.Text, textBoxRpc.Text, Color.FromName(Convert.ToString(comboBoxColor.SelectedItem)), (int)numericUpDownThreshold.Value));
                    }
                    mainForm.AddValueToListBox(textBoxName.Text);
                }
                else
                {
                    Chain ch = mainForm.config.chains.Find(x => x.name == trayName);
                    TrayIcon tri = mainForm.trayIcons.Find(x => x.notifyIcon.Text == trayName);
                    tri.notifyIcon.Text = ch.name = textBoxName.Text;
                    tri.rpc = ch.rpc = textBoxRpc.Text;
                    tri.brush.Color = ch.color = Color.FromName(Convert.ToString(comboBoxColor.SelectedItem));
                    if (!checkBoxAlert.Checked)
                        tri.alert = ch.alert = null;
                    else
                        tri.alert = ch.alert = (int)numericUpDownThreshold.Value;

                }
                Close();
            }
        }
    }
}
