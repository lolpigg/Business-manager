using Money.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money.ViewModel
{
    internal class ObserveViewModel : BindingHelper
    {
        private MainViewModel mainViewModel;
        private List<Zapis> zapisi;
        public List<Zapis> Zapisi
        {
            get { return zapisi; }
            set
            {
                zapisi = value;
                OnPropertyChanged();
            }
        }
        public ObserveViewModel(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
            zapisi = mainViewModel.zapisi;
        }
    }
}
