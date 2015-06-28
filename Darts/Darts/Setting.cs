using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darts
{
    public class Setting<T>
    {
        string Name;
        T value;
        T DefautValeu;
        bool hasValeu;

        public Setting(string name,T defautValue)
        {
            this.Name = name;
            this.DefautValeu = defautValue;
        }

        public T Value
        {
            get
            {
                if(!this.hasValeu)
                {
                    if(!IsolatedStorageSettings.ApplicationSettings.TryGetValue(this.Name, out this.value))
                    {
                        this.value = this.DefautValeu;
                        IsolatedStorageSettings.ApplicationSettings[this.Name] = this.value;
                    }
                    this.hasValeu = true;
                }
                return this.value;
            }
            set
            {
                IsolatedStorageSettings.ApplicationSettings[this.Name] = value;
                this.value = value;
                this.hasValeu = true;
            }
        }

        public T DefautValue
        {
            get { return this.DefautValeu; }
        }

        public void ForceRefresh()
        {
            this.hasValeu = false;
        }
    }
}
