using BLL.Models;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExamProjectEF.ViewModels.AddElementsTableViewModels
{
    public class MemberAddingViewModel : ViewModelBase
    {
        private CountryService _countryService;
        private SportService _sportService;
        private MedalService _medalService;
        private MemberService _memberService;

        private ObservableCollection<CountryDTO> _countries;
        private ObservableCollection<SportDTO> _sports;
        private ObservableCollection<MedalStatisticDTO> _medals;

        private CountryDTO _selectedItemCountry;
        private SportDTO _selectedItemSport;
        private MedalStatisticDTO _selectedItemMedals;

        private MemberDTO _itemToAdd;

        public MemberDTO ItemToAdd
        {
            get
            {
                return _itemToAdd;
            }
            set
            {
                _itemToAdd = value;
                OnPropertyChanged(nameof(ItemToAdd));
            }
        }

        public SportDTO SelectedItemSport
        {
            get
            {
                return _selectedItemSport;
            }
            set
            {
                _selectedItemSport = value;
                OnPropertyChanged(nameof(SelectedItemSport));
            }
        }

        public MedalStatisticDTO SelectedItemMedals
        {
            get
            {
                return _selectedItemMedals;
            }
            set
            {
                _selectedItemMedals = value;
                OnPropertyChanged(nameof(SelectedItemMedals));
            }
        }

        public CountryDTO SelectedItemCountry
        {
            get
            {
                return _selectedItemCountry;
            }
            set
            {
                _selectedItemCountry = value;
                OnPropertyChanged(nameof(SelectedItemCountry));
            }
        }

        public ObservableCollection<CountryDTO> Countries
        {
            get
            {
                return _countries;
            }
            set
            {
                _countries = value;
                OnPropertyChanged(nameof(Countries));
            }
        }

        public ObservableCollection<SportDTO> Sports
        {
            get
            {
                return _sports;
            }
            set
            {
                _sports = value;
                OnPropertyChanged(nameof(Sports));
            }
        }

        public ObservableCollection<MedalStatisticDTO> Medals
        {
            get
            {
                return _medals;
            }
            set
            {
                _medals = value;
                OnPropertyChanged(nameof(Medals));
            }
        }

        //Commands
        public ICommand ShowCollectionCommand { get; }
        public ICommand AddCollectionItemCommand { get; }

        //Constructors
        public MemberAddingViewModel()
        {
            ShowCollectionCommand = new ViewModelCommand(ExecuteShowCollectionCommand);
            AddCollectionItemCommand = new ViewModelCommand(ExecuteAddCollectionItemCommand);

            _countries = new ObservableCollection<CountryDTO>();
            _sports = new ObservableCollection<SportDTO>();
            _medals = new ObservableCollection<MedalStatisticDTO>();

            _itemToAdd = new MemberDTO();

            _countryService = new CountryService();
            _sportService = new SportService();
            _medalService = new MedalService();
            _memberService = new MemberService();
            

            ExecuteShowCollectionCommand(null);
        }

        private bool IsValidFields()
        {
            if (String.IsNullOrEmpty(_itemToAdd.Name) && String.IsNullOrWhiteSpace(_itemToAdd.Name))
                return false;
            if (String.IsNullOrEmpty(_itemToAdd.LastName) && String.IsNullOrWhiteSpace(_itemToAdd.LastName))
                return false;
            if (_selectedItemCountry == null)
            {
                return false;
            }
            if (_selectedItemSport == null)
            {
                return false;
            }
            if (_selectedItemMedals == null)
            {
                return false;
            }
            try
            {
                Convert.ToInt32(_itemToAdd.Age);
                Convert.ToDateTime(_itemToAdd.Birthday);
            }
            catch
            {
                return false;
            }

            return true;
        }

        private void ExecuteAddCollectionItemCommand(object obj)
        {
            if (IsValidFields())
            {
                _itemToAdd.Country = _selectedItemCountry;
                _itemToAdd.Sport = _selectedItemSport;
                _itemToAdd.Medals = _selectedItemMedals;
                _memberService.Add(_itemToAdd);
            }
        }

        private void ExecuteShowCollectionCommand(object obj)
        {
            foreach (var item in _countryService.GetAll())
            {
                _countries.Add(item);
            }

            foreach (var item in _medalService.GetAll())
            {
                _medals.Add(item);
            }

            foreach (var item in _sportService.GetAll())
            {
                _sports.Add(item);
            }
        }
    }
}
