using Nethereum.Hex.HexTypes;
using Nethereum.JsonRpc.Client;
using Nethereum.Util;
using Nethereum.Web3;
using System;
using System.Drawing;
using System.Media;
using System.Threading;
using System.Windows.Forms;

namespace GasTracker
{
    public class TrayIcon : ApplicationContext
    {
        private MainForm mainForm;
        public NotifyIcon notifyIcon { get; private set; }
        private Thread thread;
        private bool threadBreak;
        public int updateTime { get; private set; }
        public SolidBrush brush = new SolidBrush(Color.White);
        public int? alert;
        public string rpc;
        private DateTime lastAlert;

        public TrayIcon(MainForm mainForm, string name, string rpc, Color color, int? alert = null, int updateTime = 5000)
        {
            brush.Color = color;
            this.alert = alert;
            this.rpc = rpc;
            this.mainForm = mainForm;
            this.updateTime = updateTime;
            notifyIcon = new NotifyIcon()
            {
                Text = name,
                Icon = CreateIconFromNumber(0),
                ContextMenu = new ContextMenu(new MenuItem[] {
                new MenuItem(name),
                new MenuItem("Settings", Settings),
                new MenuItem("Exit", Exit),
                new MenuItem("With 🖤 by Ryaza")
            }),
                Visible = true
            };
            threadBreak = false;
            thread = new Thread(new ParameterizedThreadStart(ChangeTrayIcon));
            thread.Start(this.rpc);
        }

        void Exit(object sender, EventArgs e)
        {
            notifyIcon.Visible = false;
            Application.Exit();
        }

        void Settings(object sender, EventArgs e)
        {
            mainForm.ShowForm();
        }
        public void Remove() 
        {
            threadBreak = true;
            thread.Join();
            notifyIcon.Visible=false;
            notifyIcon.Dispose();
        }

        Icon CreateIconFromNumber(int number)
        {
            Bitmap bmp = new Bitmap(32, 32);
            Graphics g = Graphics.FromImage(bmp);
            Font font;
            if (number <= 99)
            {
                font = new Font("Arial", 23, FontStyle.Regular);
                g.DrawString(number.ToString(), font, brush, new PointF(-6, 0));
            }
            else
            {
                font = new Font("Arial", 16, FontStyle.Bold);
                g.DrawString(number.ToString(), font, brush, new PointF(-6, 6));
            }
            IntPtr hIcon = bmp.GetHicon();
            Icon icon = Icon.FromHandle(hIcon);
            g.Dispose();
            bmp.Dispose();
            return icon;
        }
        async void ChangeTrayIcon(object rpc)
        {
            Web3 web3 = new Web3((string)rpc);
            while (!threadBreak)
            {
                try
                {
                    HexBigInteger gasPrice = await web3.Eth.GasPrice.SendRequestAsync();
                    int value = Convert.ToInt32(Web3.Convert.FromWei(gasPrice.Value, UnitConversion.EthUnit.Gwei));
                    notifyIcon.Icon = CreateIconFromNumber(value);
                    if (alert != null)
                    {
                        if(alert >= value)
                        {
                            if (lastAlert == null || DateTime.Now >= lastAlert.AddHours(1))
                            {
                                lastAlert = DateTime.Now;
                                MessageBox.Show(new Form { TopMost = true }, notifyIcon.Text + ": " + value + " gas!", notifyIcon.Text);
                            }
                        }
                    }
                }
                catch (RpcClientUnknownException) { }
                for (int i = 0; i < updateTime; i+=500) {
                    if(threadBreak)
                        break;
                    Thread.Sleep(500);
                }
            }
        }
    }
}

