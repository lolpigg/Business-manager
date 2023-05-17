using Money.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Money.ViewModel
{
    public class TypeViewModel : BindingHelper
    {
        public BindableCommand Add_Command { get; set; }
        Type type;
        public TypeViewModel(Type type) 
        {
           Add_Command = new BindableCommand(_ => Button1_Click());
           this.type = type;
        }
        private string text = "";
        public string TextB
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                OnPropertyChanged();
            }
        }
        private bool dialogresult;

        public bool DialogResultPer
        {
            get { return dialogresult; }
            set { dialogresult = value; }
        }


        private void Button1_Click()
        {
            DialogResultPer = true;
            type.Close();
        }
    }
}
