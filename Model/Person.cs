using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMvvm.Model
{
    public class Person :INotifyPropertyChanged
    {
        private string FName;
        private string SNAME;
        private string PHONE;
        private string FN;
        public string fName { get { return FName;  } 
            set {
                FName = value;
                OnPropertyChang(FName);

            }
        
        }
        public string sName {
            get { return SNAME; }
            set
            {
                SNAME = value;
                OnPropertyChang(SNAME);

            }
        }
        public string fullName { 
            get {
             //   FN = " ";
                return FN= fName + sName; }
            set {
                if (FN != value)
                {
                    FN = value;
                }    
            }
        }
        public string phone {
            get { return PHONE; }
            set
            {
                PHONE = value;
                OnPropertyChang(PHONE);

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
   
    private void OnPropertyChang(string p)
        {
            PropertyChangedEventHandler handler = PropertyChanged;  
            if(handler != null)
            {
                handler(this, new PropertyChangedEventArgs(p)); 
            }
        }
    }


}
