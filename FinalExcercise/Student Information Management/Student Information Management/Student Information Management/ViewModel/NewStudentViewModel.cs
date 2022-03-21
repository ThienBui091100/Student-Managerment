using Student_Information_Management.Command;
using Student_Information_Management.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Student_Information_Management.ViewModel
{
    class NewStudentViewModel : BaseViewModel, IDataErrorInfo

    {
        private int _StudentID;
        private string _FirstName;
        private string _LastName;
        private DateTime _Birthdate = DateTime.Now;
        private string _Male;
        private string _Female;
        private string _Address;
        private string _Email;   
        private string _SelectedClass;
        public NewStudentViewModel()
        {
            SaveCommand = new RelayCommand(m => Save(), m => StudentID > 0 && !string.IsNullOrEmpty(LastName) && !string.IsNullOrEmpty(FirstName)&&  Birthdate < DateTime.Now);
            CancelCommand = new RelayCommand(Cancel);

            StudentService = new StudentService();
        }



        public string FirstName
        {
            get => _FirstName; set
            {
                _FirstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        #region get set
        public string LastName { get => _LastName; set => _LastName = value; }
        public string Male { get => _Male; set => _Male = value; }
        public string Female { get => _Female; set => _Female = value; }
        public string Address { get => _Address; set => _Address = value; }
        public string Email { get => _Email; set => _Email = value; }
       
        public string SelectedClass { get => _SelectedClass; set => _SelectedClass = value; }
        public DateTime Birthdate{ get => _Birthdate; set => _Birthdate= value; }
        public int StudentID { get => _StudentID; set => _StudentID = value; }
        #endregion

        #region baodo 
        public string this[string columnName]
        {
            get
            {
                string result = string.Empty;
                if (nameof(FirstName) == columnName)
                {
                    if (string.IsNullOrEmpty(FirstName))
                    {
                        result = "Name is mandatory";
                    }
                }
                if (nameof(LastName) == columnName)
                {
                    if (string.IsNullOrEmpty(LastName))
                    {
                        result = "Name is mandatory";
                    }
                }
                if (nameof(StudentID) == columnName)
                {
                    if (string.IsNullOrEmpty(LastName))
                    {
                        result = "ID is mandatory";
                    }
                }
                if (nameof(Birthdate) == columnName)
                {
                    if (Birthdate > DateTime.Now)
                    {
                        result = "date is mandatory";
                    }
                }

                return result;
            }
        }
        #endregion

        #region command
        public string Error => throw new NotImplementedException();


        public StudentService StudentService { get; set; }

        public ICommand SaveCommand { get; set; }
        public void Save()
        {
           
        }


        public ICommand CancelCommand { get; set; }
        public void Cancel(object o)
        {
         
        }
        #endregion
    }
}

