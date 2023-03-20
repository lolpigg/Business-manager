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
        public int Money {
            get {
                return Money;
            }
            set {
                if (value < 0)
                {
                    Money = value * -1;
                    IsIncome = false;
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
