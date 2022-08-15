using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using DemoMvvm.Model;
using System.Windows.Input;
using DemoMvvm.Command;

namespace DemoMvvm.ViewModel
{
    public class PersonViewModel : INotifyPropertyChanged
    {

        public string emptyText = "";
        private Person _person;

        private ObservableCollection<Person> _PersonsList;

        public PersonViewModel()
            {
            person = new Person();
            persons = new ObservableCollection<Person>();   
            }


    public Person person
        {
            get { return _person; }
            set { _person = value;
                NotifyPropertyChanged("person");
            }
        }

        //
      //  private ObservableCollection<Person> _persons;

        public ObservableCollection<Person> persons
        {
            get { return _PersonsList; }
            set {
                _PersonsList = value;
                NotifyPropertyChanged("persons");
            }
        }


        private ICommand _SubmitCommand;
        public ICommand SubmitCommand
        {
            get
            {
                if (_SubmitCommand == null)
                {
                    _SubmitCommand = new TheCommand(SumbitExecute, CanSumbitExecute,false);
                    
                }
                return _SubmitCommand;  
            }
        }
        private void SumbitExecute(object parameter)
        {
            persons.Add(person);
        }
        private bool CanSumbitExecute(object parameter)
        {
            if (string.IsNullOrEmpty(person.fName) || string.IsNullOrEmpty(person.sName) ) //|| string.IsNullOrEmpty(person.fullName || string.IsNullOrEmpty(person.phone
            {
                Console.WriteLine("is false");

                return false;

            }
            else
            {
                Console.WriteLine("is true");
                return true;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string proprtyname )
        {
            if(PropertyChanged != null)
            {
                PropertyChanged( this, new PropertyChangedEventArgs( proprtyname ) );   
            }
        }
    }
}
