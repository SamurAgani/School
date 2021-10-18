using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SchoolApp.Models;
using SchoolApp.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SchoolApp.ViewModels
{
    class AddClassVM : ViewModelBase
    {
        private IRepository<Class> classRepository;
        private string name;
        
        private RelayCommand addCommand;

        public AddClassVM(IRepository<Class> classRepository)
        {
            this.classRepository = classRepository;
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
        
        public RelayCommand AddCommand => addCommand ?? (addCommand = new RelayCommand(() =>
        {

            if (!classRepository.GetAll().Any(x => x.Name == Name))
            {
                classRepository.Add(new Class()
                {
                    Name = Name,
                });
                classRepository.Save();
                MessageBox.Show("Class added");
            }
            else MessageBox.Show("The class has already been added");
            Name = string.Empty;

        },()=>!string.IsNullOrWhiteSpace(Name)));

    }
}
