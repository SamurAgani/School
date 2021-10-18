using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using SchoolApp.Models;
using SchoolApp.Repository;
using SchoolApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static System.Collections.Specialized.BitVector32;

namespace SchoolApp.ViewModels
{
    public class StudentsVM : ViewModelBase
    {
        private List<Student> students;

        private string name;
        private string surname;
        private DateTime firstDate;
        private DateTime lastDate;
        private List<Gender> genders;
        private Gender selectedGender;


        private char dateButtonContent;
        private RelayCommand dateCommand;
        private bool lastDateEnabled;
        private RelayCommand clearCommand;
        private RelayCommand saveCSVCommand;

        private IRepository<Student> studentRepository;
        private IRepository<Gender> genderRepository;
        private IRepository<Class> classRepository;
        private ICsvService csvService;
        private List<Class> classes;
        private Class selectedClass;
        private SearchService searchService;
        private Student student;
        private RelayCommand removeCommand;

        public StudentsVM(IRepository<Student> studentRepository, IRepository<Gender> genderRepository,
            IRepository<Class> classRepository, ICsvService csvService)
        {
            this.studentRepository = studentRepository;
            this.genderRepository = genderRepository;
            this.classRepository = classRepository;
            this.csvService = csvService;

            Students = this.studentRepository.GetAll().ToList();
            Genders = this.genderRepository.GetAll().ToList();
            Classes = this.classRepository.GetAll().ToList();
            this.searchService = new SearchService(Students, this);
            DateButtonContent = '-';
            LastDateEnabled = true;

        }

        public List<Student> Students { get => students; set => Set(ref students, value); }
        public string Name
        {
            get => name;
            set
            {
                Set(ref name, value);
                Students = searchService.Search().ToList();
            }
        }
        public string Surname
        {
            get => surname;
            set
            {
                Set(ref surname, value);
                Students = searchService.Search().ToList();
            }
        }
        public Student Student { get => student; set => Set(ref student, value); }
        public List<Class> Classes { get => classes; set => Set(ref classes, value); }
        public Class SelectedClass
        {
            get => selectedClass;
            set
            {
                Set(ref selectedClass, value);
                Students = searchService.Search().ToList();
            }
        }
        public DateTime FirstDate
        {
            get => firstDate;
            set
            {
                Set(ref firstDate, value);
                Searchalbe = true;
                Students = searchService.Search().ToList();
            }
        }
        public bool Searchalbe { get; set; } = false;
        public DateTime LastDate
        {
            get => lastDate;
            set
            {
                if (value > FirstDate) Set(ref lastDate, value);
                Searchalbe = true;
                Students = searchService.Search().ToList();
            }
        }
        public bool LastDateEnabled { get => lastDateEnabled; set => Set(ref lastDateEnabled, value); }
        public List<Gender> Genders { get => genders; set => Set(ref genders, value); }
        public Gender SelectedGender
        {
            get => selectedGender; set
            {
                Set(ref selectedGender, value);
                Students = searchService.Search().ToList();
            }
        }

        public char DateButtonContent { get => dateButtonContent; set => Set(ref dateButtonContent, value); }





        public RelayCommand DateCommand => dateCommand ?? (dateCommand = new RelayCommand(() =>
        {
            Searchalbe = true;
            if (DateButtonContent == '-')
            {
                DateButtonContent = '=';
                LastDateEnabled = false;
            }
            else if (DateButtonContent == '=')
            {
                DateButtonContent = '>';
            }
            else if (DateButtonContent == '>')
            {
                DateButtonContent = '<';
            }
            else
            {
                DateButtonContent = '-';
                LastDateEnabled = true;
                LastDate = FirstDate;
            }
            Students = searchService.Search().ToList();
        }));

        public RelayCommand ClearCommand => clearCommand ?? (clearCommand = new RelayCommand(() =>
        {
            Name = string.Empty;
            Surname = string.Empty;
            SelectedGender = null;
            SelectedClass = null;
            SelectedGender = null;
            LastDate = DateTime.MinValue;
            FirstDate = DateTime.MinValue;
            Searchalbe = false;
            Students = searchService.Search().ToList();


        }));

        public RelayCommand SaveCSVCommand => saveCSVCommand ?? (saveCSVCommand = new RelayCommand(() =>
        {
            var fileDialog = new SaveFileDialog();
            fileDialog.Filter = "CSV | *.csv";
            fileDialog.ShowDialog();
            StringBuilder content = new StringBuilder();
            foreach (var std in Students)
            {
                content.AppendLine($"{std.Name},{std.Surname},{std.BirthDate.Date.Date},{std.Gender.Name},{std.Class.Name}");
            }
            if (fileDialog.FileName.Length > 0) csvService.WriteCSV(fileDialog.FileName, content.ToString());
            MessageBox.Show("Saved");
        }));

        public RelayCommand RemoveCommand => removeCommand ?? (removeCommand = new RelayCommand(() =>
        {
            if(Student != null)studentRepository.Remove(Student);
            studentRepository.Save();
            Students = studentRepository.GetAll().ToList();
        }));
    }
}
