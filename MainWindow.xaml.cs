using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Money
{

    public partial class MainWindow : Window
    {
        List<Zapis> zapisi = new List<Zapis>();
        List<Zapis> TodayZapisi = new List<Zapis>();
        List<string> types = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            zapisi = Jdaughter.Deserialize<List<Zapis>>();
            types = Jdaughter.Deserialize2<List<string>>();
            Day.Text = DateTime.Now.ToString();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (Name.Text != "" && TypeSpisok.SelectedItem != null && Summ.Text != "")
            {
                zapisi.Add(new Zapis(Name.Text, TypeSpisok.Text, Convert.ToInt32(Summ.Text), Convert.ToDateTime(Day.SelectedDate)));
                Clear();
            }
        }
        private void Clear()
        {
            TodayZapisi.Clear();
            foreach (Zapis z in zapisi)
            {
                if (z.Date.Date == Convert.ToDateTime(Day.SelectedDate).Date)
                {
                    TodayZapisi.Add(z);
                }
            }
            Spisok.ItemsSource = null;
            Spisok.ItemsSource = TodayZapisi;
            int summ = 0;
            foreach (Zapis item in TodayZapisi)
            {
                summ += item.IsIncome ? item.Money : item.Money * -1;
            }
            AllCash.Text = "Итого: " + summ;
            Name.Text = "";
            Summ.Text = "";
            TypeSpisok.SelectedItem = null;
            TypeSpisok.Items.Clear();
            foreach (string item in types)
            {
                TypeSpisok.Items.Add(item);
            }
            Jdaughter.Serialize(zapisi, 1);
            Jdaughter.Serialize(types, 0);
        }

        private void AddType_Click(object sender, RoutedEventArgs e)
        {
            Type type = new Type();
            type.ShowDialog();
            if ((bool)type.DialogResult)
            {   
                types.Add(type.Type1.Text);
                TypeSpisok.Items.Add(type.Type1.Text);
            }
            Clear();
        }

        private void Day_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Clear();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (Spisok.SelectedItems.Count != 0)
            {
                zapisi.RemoveAt(zapisi.IndexOf(TodayZapisi[Spisok.SelectedIndex]));
                Clear();
            }
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            if (Spisok.SelectedItems.Count != 0)
            {
                zapisi[zapisi.IndexOf(TodayZapisi[Spisok.SelectedIndex])].Name = Name.Text;
                zapisi[zapisi.IndexOf(TodayZapisi[Spisok.SelectedIndex])].Type = TypeSpisok.Text;
                if (Convert.ToInt32(Summ.Text) < 0)
                {
                    zapisi[zapisi.IndexOf(TodayZapisi[Spisok.SelectedIndex])].Money = Convert.ToInt32(Summ.Text) * -1;
                    zapisi[zapisi.IndexOf(TodayZapisi[Spisok.SelectedIndex])].IsIncome = false;
                }
                else
                {
                    zapisi[zapisi.IndexOf(TodayZapisi[Spisok.SelectedIndex])].Money = Convert.ToInt32(Summ.Text);
                    zapisi[zapisi.IndexOf(TodayZapisi[Spisok.SelectedIndex])].IsIncome = true;
                }
                Clear();
            }
        }

        private void Spisok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Spisok.SelectedIndex != -1)
            {
                Name.Text = zapisi[zapisi.IndexOf(TodayZapisi[Spisok.SelectedIndex])].Name;
                TypeSpisok.Text = zapisi[zapisi.IndexOf(TodayZapisi[Spisok.SelectedIndex])].Type;
                Summ.Text = Convert.ToString(zapisi[zapisi.IndexOf(TodayZapisi[Spisok.SelectedIndex])].Money);
            }
        }
    }
}
