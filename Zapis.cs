using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money
{
    internal class Zapis
    {
        public string Name { get; set;}
        public string Type { get; set;}
        private int _money;

        public int Money
        {
            get { return _money; }
            set
            {
                if (value < 0)
                {
                    //Money = value * -1;
                    IsIncome = false;
                    _money = value * -1;
                }
                else
                {
                    _money = value;
                }
            }
        }
        public bool IsIncome { get; set;}
        public DateTime Date;
        public Zapis(string Name, string Type, int Money, DateTime Date)
        {
            this.Name = Name;
            this.Type = Type;
            IsIncome = true;
            this.Money = Money;
            if (Money < 0)
            {
                this.Money = Money * -1;
                IsIncome = false;
            }
            this.Date = Date;
        }
    }
}
