using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ExamProjectEF.Models;
using BLL.Services;
using System.Configuration;
using System.Threading;
using System.Windows;

namespace ExamProjectEF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase _currentChildView;
        private string _caption;
        private IconChar _icon;

        private UserAccountModel _userAccount;
        private UserService _userService;

        public UserAccountModel UserAccount
        {
            get
            {
                return _userAccount;
            }
            set
            {
                _userAccount = value;
                OnPropertyChanged(nameof(UserAccount));
            }
        }

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
        public string Caption 
        {
            get
            {
                return _caption;
            }
            set
            {
                _caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        } 
        public IconChar Icon 
        { 
            get 
            {
                return _icon;
            }
            set
            {
                _icon = value;
                OnPropertyChanged(nameof(Icon));
            }
        }

        // --> Commands
        public ICommand ShowOlimpiadsViewCommand { get; }
        public ICommand ShowCountriesViewCommand { get; }
        public ICommand ShowMembersViewCommand { get; }
        public ICommand ShowSportsViewCommand { get; }
        public ICommand ShowTeamsViewCommand { get; }
        public ICommand ShowMedalsViewCommand { get; }
        public ICommand ShowAddElementsViewCommand { get; }

        public MainViewModel()
        {
            // Initialize Commands
            ShowOlimpiadsViewCommand = new ViewModelCommand(ExecuteShowOlimpiadsViewCommand);
            ShowCountriesViewCommand = new ViewModelCommand(ExecuteShowCountriesViewCommand);
            ShowMembersViewCommand = new ViewModelCommand(ExecuteShowMembersViewCommand);
            ShowSportsViewCommand = new ViewModelCommand(ExecuteShowSportsViewCommand);
            ShowTeamsViewCommand = new ViewModelCommand(ExecuteShowTeamsViewCommand);
            ShowMedalsViewCommand = new ViewModelCommand(ExecuteShowMedalsViewCommand);
            ShowAddElementsViewCommand = new ViewModelCommand(ExecuteShowAddElementsViewCommand);

            _userService = new UserService();

            LoadCurrentUserData();

            //Default View
            ExecuteShowOlimpiadsViewCommand(null);
        }


        private void LoadCurrentUserData()
        {
            var user = _userService.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            if (user != null)
            {
                UserAccount = new UserAccountModel()
                {
                    Username = user.Username,
                    DisplayName = $"{user.Name} {user.LastName}",
                    ProfilePicture = null
                };
            }
            else
            {
                MessageBox.Show("Invalid user, not logged in");
                Application.Current.Shutdown();
            }
        }

        private void ExecuteShowMembersViewCommand(object obj)
        {
            CurrentChildView = new MembersViewModel();
            Caption = "Members";
            Icon = IconChar.Person;
        }

        private void ExecuteShowCountriesViewCommand(object obj)
        {
            CurrentChildView = new CountriesViewModel();
            Caption = "Countries";
            Icon = IconChar.Globe;
        }

        private void ExecuteShowOlimpiadsViewCommand(object obj)
        {
            CurrentChildView = new OlimpiadsViewModel();
            Caption = "Olimpiads";
            Icon = IconChar.Calendar;
        }

        private void ExecuteShowSportsViewCommand(object obj)
        {
            CurrentChildView = new SportsViewModel();
            Caption = "Sports";
            Icon = IconChar.Futbol;
        }

        private void ExecuteShowTeamsViewCommand(object obj)
        {
            CurrentChildView = new TeamsViewModel();
            Caption = "Teams";
            Icon = IconChar.PeopleGroup;
        }

        private void ExecuteShowMedalsViewCommand(object obj)
        {
            CurrentChildView = new MedalsViewModel();
            Caption = "Medals";
            Icon = IconChar.Medal;
        }

        private void ExecuteShowAddElementsViewCommand(object obj)
        {
            CurrentChildView = new AddElementsViewModel();
            Caption = "AddElements";
            Icon = IconChar.Plus;
        }
    }
}
