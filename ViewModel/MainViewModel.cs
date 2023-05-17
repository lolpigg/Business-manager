using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using Money.ViewModel.Helpers;
using Money.View;

namespace Money.ViewModel
{
    public class MainViewModel : BindingHelper
    {
        #region
        private Zapis selected;
        public Zapis Selected
        {
            get
            {
                return selected;
            }
            set
            {
                selected = value;
                if (value == null)
                {
                    ForInsert = new Zapis();
                }
                else
                {
                ForInsert = new Zapis(value.Name, value.Type, value.Money, value.Date, value.IsIncome);

                }
                OnPropertyChanged();
            }
        }
        private Zapis forInsert = new Zapis();

        public Zapis ForInsert
        {
            get { return forInsert; }
            set
            {
                forInsert = value;
                OnPropertyChanged();
            }
        }

        public List<Zapis> zapisi;
        private ObservableCollection<Zapis> todayZapisi = new ObservableCollection<Zapis>();
        public ObservableCollection<Zapis> TodayZapisi
        {
            get { return todayZapisi; }
            set
            {
                todayZapisi = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<string> types;
        public ObservableCollection<string> Types
        {
            get { return types; }
            set
            {
                types = value;
                OnPropertyChanged();
            }
        }

        private string allCashNum = "0";
        private string today = "";
        private int selectindex = 0;
        public int SelectIndex
        {
            get
            {
                return selectindex;
            }
            set
            {
                selectindex = value;
                OnPropertyChanged();
            }
        }
        public string Today
        {
            get
            {
                return today;
            }
            set
            {
                today = value;
                OnPropertyChanged();
            }
        }

        public string AllCashNum
        {
            get
            {
                return allCashNum;
            }
            set
            {
                allCashNum = value;
                OnPropertyChanged();
            }
        }
        private DateTime? seldate;

        public DateTime? SelDate
        {
            get { return seldate; }
            set { seldate = value; OnPropertyChanged(); }
        }
        public BindableCommand Delete_Command { get; set; }
        public BindableCommand Add_Command { get; set; }
        public BindableCommand AddType_Command { get; set; }
        public BindableCommand Change_Command { get; set; }
        public BindableCommand Day_Command { get; set; }
        public BindableCommand Observe_Command { get; set; }
        #endregion
        public MainViewModel()
        {
            Observe_Command = new BindableCommand(_ => Observe_Click());
            Add_Command = new BindableCommand(_ => Add_Click());
            AddType_Command = new BindableCommand(_ => AddType_Click());
            Delete_Command = new BindableCommand(_ => Delete_Click());
            Change_Command = new BindableCommand(_ => Change_Click());
            Day_Command = new BindableCommand(_ => Day_SelectedDateChanged());
            zapisi = Jdaughter.Deserialize<List<Zapis>>();
            Types = Jdaughter.Deserialize2<ObservableCollection<string>>();
            if (Types == null)
            {
                Types = new ObservableCollection<string>();
            }
            if (zapisi == null)
            {
                zapisi = new List<Zapis>();
            }
            Today = DateTime.Now.ToString();
            Clear();
        }
        public void Add_Click()
        {
            if (ForInsert.Name != "" && ForInsert.Type != null)
            {
                if (ForInsert.Money < 0)
                {
                    ForInsert.IsIncome = false;
                    ForInsert.Money *= -1;
                }
                zapisi.Add(new Zapis(ForInsert.Name, ForInsert.Type, ForInsert.Money, Convert.ToDateTime(SelDate), ForInsert.IsIncome));
                Clear();
            }
        }
        private void Clear()
        {
            if (zapisi != null)
            {
                TodayZapisi.Clear();
                foreach (Zapis z in zapisi)
                {
                    if (z.Date.Date == Convert.ToDateTime(SelDate).Date)
                    {
                        TodayZapisi.Add(z);
                    }
                }
                int summ = 0;
                foreach (Zapis item in TodayZapisi)
                {
                    summ += item.IsIncome ? item.Money : item.Money * -1;
                }
                AllCashNum = summ.ToString();
                Jdaughter.Serialize(zapisi, 1);
                Jdaughter.Serialize(Types, 0);
            }
        }

        private void AddType_Click()
        {
            Type type = new Type();
            TypeViewModel a =  type.type;
            type.ShowDialog();
            if (a.DialogResultPer)
            {
                Types.Add(a.TextB);
            }
            Clear();
        }

        private void Day_SelectedDateChanged()
        {
            Clear();
        }

        private void Delete_Click()
        {
            if (SelectIndex != -1)
            {
                zapisi.RemoveAt(zapisi.IndexOf(TodayZapisi[SelectIndex]));
                Clear();
            }
        }

        private void Observe_Click()
        {
            ObserveWindow observeWindow = new ObserveWindow(this);
            observeWindow.Show();
        }
        private void Change_Click()
        {
            if (Selected != null)
            {
                zapisi[zapisi.IndexOf(TodayZapisi[SelectIndex])].Name = ForInsert.Name;
                zapisi[zapisi.IndexOf(TodayZapisi[SelectIndex])].Type = ForInsert.Type;
                if (Convert.ToInt32(ForInsert.Money) < 0)
                {
                    zapisi[zapisi.IndexOf(TodayZapisi[SelectIndex])].Money = ForInsert.Money * -1;
                    zapisi[zapisi.IndexOf(TodayZapisi[SelectIndex])].IsIncome = false;
                }
                else
                {
                    zapisi[zapisi.IndexOf(TodayZapisi[SelectIndex])].Money = ForInsert.Money;
                    zapisi[zapisi.IndexOf(TodayZapisi[SelectIndex])].IsIncome = true;
                }
                Clear();
            }
        }
    }
}
