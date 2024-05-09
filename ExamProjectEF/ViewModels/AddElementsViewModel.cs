using BLL.Services;
using ExamProjectEF.ViewModels.AddElementsTableViewModels;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExamProjectEF.ViewModels
{
    public class AddElementsViewModel : ViewModelBase
    {
        private ViewModelBase _currentChildView;

        public ViewModelBase CurrentChildView
        {
            get
            {
                return _currentChildView;
            }
            set
            {
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }

        public ICommand ShowOlimpiadsAddElemViewCommand { get; }
        public ICommand ShowCountriesAddElemViewCommand { get; }
        public ICommand ShowMembersAddElemViewCommand { get; }
        public ICommand ShowSportsAddElemViewCommand { get; }
        public ICommand ShowTeamsAddElemViewCommand { get; }
        public ICommand ShowMedalsAddElemViewCommand { get; }

        public AddElementsViewModel()
        {
            // Initialize Commands
            ShowOlimpiadsAddElemViewCommand = new ViewModelCommand(ExecuteShowOlimpiadsAddElemViewCommand);
            ShowCountriesAddElemViewCommand = new ViewModelCommand(ExecuteShowCountriesAddElemViewCommand);
            ShowMembersAddElemViewCommand = new ViewModelCommand(ExecuteShowMembersAddElemViewCommand);
            ShowSportsAddElemViewCommand = new ViewModelCommand(ExecuteShowSportsAddElemViewCommand);
            ShowTeamsAddElemViewCommand = new ViewModelCommand(ExecuteShowTeamsAddElemViewCommand);
            ShowMedalsAddElemViewCommand = new ViewModelCommand(ExecuteShowMedalsAddElemViewCommand);


            //Default View
            ExecuteShowOlimpiadsAddElemViewCommand(null);
        }

        private void ExecuteShowTeamsAddElemViewCommand(object obj)
        {
            CurrentChildView = new TeamAddingViewModel();
        }

        private void ExecuteShowSportsAddElemViewCommand(object obj)
        {
            CurrentChildView = new SportAddingViewModel();
        }

        private void ExecuteShowMembersAddElemViewCommand(object obj)
        {
            CurrentChildView = new MemberAddingViewModel();
        }

        private void ExecuteShowMedalsAddElemViewCommand(object obj)
        {
            CurrentChildView = new MedalAddingViewModel();
        }

        private void ExecuteShowCountriesAddElemViewCommand(object obj)
        {
            CurrentChildView = new CountryAddingViewModel();
        }

        private void ExecuteShowOlimpiadsAddElemViewCommand(object obj)
        {
            CurrentChildView = new OlimpiadAddingViewModel();
        }
    }
}
