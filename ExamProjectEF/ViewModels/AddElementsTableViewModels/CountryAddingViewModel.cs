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
    public class CountryAddingViewModel : ViewModelBase
    {
        private CountryService _countryService;
        private CountryDTO _itemToAdd;

        public CountryDTO ItemToAdd
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

        //Commands
        public ICommand AddCollectionItemCommand { get; }

        //Constructors
        public CountryAddingViewModel()
        {
            AddCollectionItemCommand = new ViewModelCommand(ExecuteAddCollectionItemCommand);

            _itemToAdd = new CountryDTO();

            _countryService = new CountryService();
        }

        private bool IsValidFields()
        {
            if (String.IsNullOrEmpty(_itemToAdd.Name) && String.IsNullOrWhiteSpace(_itemToAdd.Name))
                return false;
            if (String.IsNullOrEmpty(_itemToAdd.City) && String.IsNullOrWhiteSpace(_itemToAdd.City))
                return false;

            return true;
        }

        private void ExecuteAddCollectionItemCommand(object obj)
        {
            if (IsValidFields())
            {
                _countryService.Add(_itemToAdd);

                _itemToAdd.Name = string.Empty;
                _itemToAdd.City = string.Empty;
            }
        }
    }
}
