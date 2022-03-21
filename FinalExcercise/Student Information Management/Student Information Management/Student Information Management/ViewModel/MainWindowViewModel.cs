
using MaterialDesignThemes.Wpf;
using Student_Information_Management.Command;
using Student_Information_Management.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Student_Information_Management.ViewModel
{
    class MainWindowViewModel : BaseViewModel
    {
        private string _SearchBox;
        private List<string> _ListClass = new List<string> { "Item 1", "Item 2", "Item 3" };
        private string _SelectedClass;
        public ObservableCollection<String> ClassList { get; set; }

        public MainWindowViewModel()
        {
            SearchCommand = new RelayCommand(m => Search(), m => !string.IsNullOrEmpty(SearchBox) ||  !string.IsNullOrEmpty(_SelectedClass));
            ResetCommand = new RelayCommand(m => Reset(), m => !string.IsNullOrEmpty(SearchBox) || !string.IsNullOrEmpty(_SelectedClass));
            MenuCommand = new RelayCommand(m => Menu());

            //get data
            StudentService = new StudentService();
            StudentList = new ObservableCollection<Student>(StudentService.SearchStudent(new StudentSearchCriteria()));
            ClassList = new ObservableCollection<String>(StudentService.GetAllClasses());
        }
        public  StudentService StudentService{get;set ;}
        
        public ObservableCollection<Student> StudentList { get; set; }
        public string SearchBox
        {
            get => _SearchBox;
            set
            {
                _SearchBox = value;
                OnPropertyChanged(nameof(SearchBox));
            }
        }
        


        public string SelectedClass
        {
            get => _SelectedClass; 
            set
            {
                _SelectedClass = value;
                OnPropertyChanged(nameof(SelectedClass));
            }
        }

        #region command
        //Search Button
        public ICommand SearchCommand { get; set; }
        public void Search()
        {
            StudentList.Clear();
            var result = StudentService.SearchStudent(new StudentSearchCriteria { SearchText = SearchBox, ClassName = SelectedClass});
            foreach (var item in result)
            {
                StudentList.Add(item);
            }
        }
        //Reset Button
        public ICommand ResetCommand { get; set; }
        public void Reset()
        {
            SearchBox = null;
            SelectedClass = null;
            StudentList.Clear();
            var result = StudentService.SearchStudent(new StudentSearchCriteria { SearchText = SearchBox, ClassName = SelectedClass });
            foreach (var item in result)
            {
                StudentList.Add(item);

            }
        }
        //Menu
        public ICommand MenuCommand { get; set; }
        public void Menu()
        {
            Window window = new NewStudent();
            window.ShowDialog();

        }
        #endregion


    }
}
