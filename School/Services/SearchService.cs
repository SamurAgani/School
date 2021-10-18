using GalaSoft.MvvmLight;
using SchoolApp.Models;
using SchoolApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SchoolApp.Services
{
    public class SearchService
    {
        private StudentsVM viewModel;
        public List<Student> Students { get; set; }
        private List<Student> newStudents;
        public SearchService(List<Student> students,StudentsVM studentsVM)
        {
            Students = students;
            viewModel = studentsVM;
        }

        public IEnumerable<Student> Search()
        {
            newStudents = Students;

            if (!string.IsNullOrWhiteSpace(viewModel.Name)) newStudents = newStudents.Where(x => x.Name.ToLower().IndexOf(viewModel.Name).ToString() == "0").ToList();
            if (!string.IsNullOrWhiteSpace(viewModel.Surname)) newStudents = newStudents.Where(x => x.Surname.ToLower().IndexOf(viewModel.Surname).ToString() == "0").ToList();
            if (viewModel.SelectedGender != null) newStudents = newStudents.Where(x => x.Gender.Id == viewModel.SelectedGender.Id).ToList();
            if(viewModel.SelectedClass != null) newStudents = newStudents.Where(x => x.Class.Id == viewModel.SelectedClass.Id).ToList();
            if (viewModel.Searchalbe)
            {
                if (viewModel.DateButtonContent == '-') newStudents = newStudents.Where(x => x.BirthDate > viewModel.FirstDate && x.BirthDate <= viewModel.LastDate).ToList();
                else if (viewModel.DateButtonContent == '>') newStudents = newStudents.Where(x => x.BirthDate < viewModel.FirstDate).ToList();
                else if (viewModel.DateButtonContent == '<') newStudents = newStudents.Where(x => x.BirthDate > viewModel.FirstDate).ToList();
                else if (viewModel.DateButtonContent == '=') newStudents = newStudents.Where(x => x.BirthDate == viewModel.FirstDate).ToList();
            }
            return newStudents;

        }
    }
}
