using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darts
{
    public static class Settings
    {
        public static readonly Setting<DateTime> CallTime =
            new Setting<DateTime>("CallTime",DateTime.Now);
        public static readonly Setting<string> PhoneNumber =
            new Setting<string>("PhoneNumber","");
        public static readonly Setting<string> Carrier =
            new Setting<string>("Carrier","AT&T");
    }
}
