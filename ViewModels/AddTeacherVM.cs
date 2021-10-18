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
    class AddTeacherVM : ViewModelBase
    {
        private IRepository<Teacher> teacherRepository;
        private IRepository<Gender> genderRepository;
        private string name;
        private string surname;
        private List<Gender> genders;
        private Gender selectedGender;
        private RelayCommand addCommand;
        private DateTime birthDate;

        public AddTeacherVM(IRepository<Teacher> teacherRepository, IRepository<Gender> genderRepository)
        {
            this.teacherRepository = teacherRepository;
            this.genderRepository = genderRepository;

            Genders = this.genderRepository.GetAll().ToList();
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
        public DateTime BirthDate { get => birthDate; set => Set(ref birthDate, value); }

        public RelayCommand AddCommand => addCommand ?? (addCommand = new RelayCommand(() =>
        {


            var count = teacherRepository.GetAll().Count(x => x.Name == Name);
            teacherRepository.Add(new Teacher()
            {
                Name = Name,
                Surname = Surname,
                BirthDate = BirthDate,
                Gender = SelectedGender,
                Username = $"{Name}{count}",
                Password = $"{Name}{count}"
            });
            teacherRepository.Save();
            MessageBox.Show("Teacher added");
            Name = string.Empty;
            Surname = string.Empty;
            BirthDate = DateTime.Now;
            SelectedGender = null;

        }, () => !string.IsNullOrWhiteSpace(Name)
         && !string.IsNullOrWhiteSpace(Surname)
         && SelectedGender != null));

    }
}
