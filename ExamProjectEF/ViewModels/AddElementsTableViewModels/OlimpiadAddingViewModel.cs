using BLL.Models;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ExamProjectEF.ViewModels.AddElementsTableViewModels
{
    public class OlimpiadAddingViewModel : ViewModelBase
    {
        private CountryService _countryService;
        private OlimpiadService _olimpiadService;

        private ObservableCollection<CountryDTO> _countries;
        private CountryDTO _selectedItem;
        private OlimpiadDTO _itemToAdd;

        public OlimpiadDTO ItemToAdd
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

        public CountryDTO SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
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

        //Commands
        public ICommand ShowCollectionCommand { get; }
        public ICommand AddCollectionItemCommand { get; }

        //Constructors
        public OlimpiadAddingViewModel()
        {
            ShowCollectionCommand = new ViewModelCommand(ExecuteShowCollectionCommand);
            AddCollectionItemCommand = new ViewModelCommand(ExecuteAddCollectionItemCommand);

            _countries = new ObservableCollection<CountryDTO>();
            _itemToAdd = new OlimpiadDTO();

            _countryService = new CountryService();
            _olimpiadService = new OlimpiadService();

            ExecuteShowCollectionCommand(null);
        }

        private bool IsValidFields()
        {
            if (String.IsNullOrEmpty(_itemToAdd.Name) && String.IsNullOrWhiteSpace(_itemToAdd.Name))
                return false;
            if (String.IsNullOrEmpty(_itemToAdd.Season) && String.IsNullOrWhiteSpace(_itemToAdd.Season))
                return false;
            if (_itemToAdd.EventDate == null)
                return false;
            if(_selectedItem == null)
            {
                return false;
            }
            try
            {
                Convert.ToInt32(_itemToAdd.CountOfMembers);
                Convert.ToDateTime(_itemToAdd.EventDate);
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
                _itemToAdd.EventCountry = _selectedItem;
                _olimpiadService.Add(_itemToAdd);

                _itemToAdd.Name = string.Empty;
                _itemToAdd.Season = string.Empty;
                _itemToAdd.EventDate = DateTime.Now;
                _itemToAdd.CountOfMembers = 0;
            }
        }

        private void ExecuteShowCollectionCommand(object obj)
        {
            foreach (var item in _countryService.GetAll()) 
            {
                _countries.Add(item);
            }
        }
    }
}
