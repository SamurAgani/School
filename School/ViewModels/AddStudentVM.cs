using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SchoolApp.Models;
using SchoolApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SchoolApp.ViewModels
{
    public class AddStudentVM : ViewModelBase
    {
        private IRepository<Class> classRepository;
        private IRepository<Student> studentRepository;
        private IRepository<Gender> genderRepository;
        private RelayCommand addCommand;
        private Gender selectedGender;
        private Class selectedClass;
        private string name;
        private string surname;
        private List<Gender> genders;
        private List<Class> classes;
        private DateTime birthDate;

        public AddStudentVM(IRepository<Class> classRepository, IRepository<Student> studentRepository,
                            IRepository<Gender> genderRepository)
        {
            this.classRepository = classRepository;
            this.genderRepository = genderRepository;
            this.studentRepository = studentRepository;

            Genders = this.genderRepository.GetAll().ToList();
            Classes = this.classRepository.GetAll().ToList();
            BirthDate = DateTime.Now;
        }

        public string Name
        {
            get => name;
            set
            {
                Set(ref name, value);
                AddCommand.RaiseCanExecuteChanged();

            }
        }
        public string Surname
        {
            get => surname;
            set
            {
                Set(ref surname, value);
                AddCommand.RaiseCanExecuteChanged();
            }
        }

        public List<Gender> Genders { get => genders; set => Set(ref genders, value); }
        public Gender SelectedGender
        {
            get => selectedGender;
            set
            {
                Set(ref selectedGender, value);
                AddCommand.RaiseCanExecuteChanged();
            }
        }
        public List<Class> Classes { get => classes; set => Set(ref classes, value); }

        public Class SelectedClass
        {
            get => selectedClass;
            set
            {
                Set(ref selectedClass, value);
                AddCommand.RaiseCanExecuteChanged();
            }
        }
        public DateTime BirthDate { get => birthDate; set => Set(ref birthDate, value); }

        public RelayCommand AddCommand => addCommand ?? (addCommand = new RelayCommand(() =>
        {
            var count = studentRepository.GetAll().Count(x => x.Name == Name);
            studentRepository.Add(new Student()
            {
                Name = Name,
                Surname = Surname,
                Gender = SelectedGender,
                Class = SelectedClass,
                BirthDate = BirthDate,
                Username = $"{Name}{count}",
                Password = $"{Name}{count}"
            });
            MessageBox.Show($"Username: {Name}{count}\nPassword: {Name}{count}");
            studentRepository.Save();

            Name = string.Empty;
            Surname = string.Empty;
            SelectedClass = null;
            SelectedGender = null;


        }, () => !string.IsNullOrWhiteSpace(Name)
         && !string.IsNullOrWhiteSpace(Surname)
         && SelectedClass != null
         && SelectedGender != null));
    }
}
