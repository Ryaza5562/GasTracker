using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasTracker
{
    public class Chain
    {
        public string name;
        public string rpc;
        public Color color;
        public int? alert;
        public Chain(string name, string rpc, Color color, int? alert = null) 
        {
            this.name = name;
            this.rpc = rpc;
            this.color = color;
            this.alert = alert;
        }

        public Chain() 
        { }
    }
}
