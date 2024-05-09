using BLL.Models;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExamProjectEF.ViewModels
{
    public class CountriesViewModel : ViewModelBase
    {
        private CountryService _service;

        private string _propertyText = "Search...";
        private string _selectedProperty = "Search by...";
        private CountryDTO _itemToDelete;
        private ObservableCollection<CountryDTO> _countries;


        public string PropertyText
        {
            get
            {
                return _propertyText;
            }
            set
            {
                _propertyText = value;
                OnPropertyChanged(nameof(PropertyText));
            }
        }

        public CountryDTO ItemToDelete
        {
            get
            {
                return _itemToDelete;
            }
            set
            {
                _itemToDelete = value;
                OnPropertyChanged(nameof(ItemToDelete));
            }
        }

        public string SelectedProperty
        {
            get
            {
                return _selectedProperty;
            }
            set
            {
                _selectedProperty = value;
                OnPropertyChanged(nameof(SelectedProperty));
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
        public ICommand ShowItemsCollectionCommand { get; }
        public ICommand ClearFilterCollectionCommand { get; }
        public ICommand DeleteCollectionItemCommand { get; }


        //Constructor
        public CountriesViewModel()
        {
            //Initialize Commands
            ShowItemsCollectionCommand = new ViewModelCommand(ExecuteShowItemsCollectionCommand);
            ClearFilterCollectionCommand = new ViewModelCommand(ExecuteClearFilterCollectionCommand);
            DeleteCollectionItemCommand = new ViewModelCommand(ExecuteDeleteCollectionItemCommand);

            //Initialize Other Resources
            _countries = new ObservableCollection<CountryDTO>();
            _service = new CountryService();
        }

        private void UpdateCollectionItems()
        {
            _countries.Clear();

            foreach (var item in _service.GetAll())
            {
                _countries.Add(item);
            }
        }

        private void ExecuteDeleteCollectionItemCommand(object obj)
        {
            if (_itemToDelete != null)
            {
                _service.Delete(_itemToDelete);

                UpdateCollectionItems();
            }
        }

        private void ExecuteClearFilterCollectionCommand(object obj)
        {
            _propertyText = "Search...";
            _selectedProperty = "Search by...";

            _countries.Clear();

            foreach (var item in _service.GetAll())
            {
                _countries.Add(item);
            }
        }

        private void ExecuteShowItemsCollectionCommand(object obj)
        {
            if (_selectedProperty != "Search by..." && _propertyText != "Search...")
            {
                switch (_selectedProperty)
                {
                    case "System.Windows.Controls.ComboBoxItem: Country":
                        _countries.Clear();

                        foreach (var item in _service.GetElementsByName(_propertyText))
                        {
                            _countries.Add(item);
                        }
                        break;

                    case "System.Windows.Controls.ComboBoxItem: City":
                        _countries.Clear();

                        foreach (var item in _service.GetByCity(_propertyText))
                        {
                            _countries.Add(item);
                        }
                        break;

                    case "System.Windows.Controls.ComboBoxItem: GoldenMedals":
                        _countries.Clear();

                        foreach (var item in _service.GetByGoldenMedals(Convert.ToInt32(_propertyText)))
                        {
                            _countries.Add(item);
                        }
                        break;

                    case "System.Windows.Controls.ComboBoxItem: Hosts":
                        _countries.Clear();

                        foreach (var item in _service.GetByHosts(Convert.ToInt32(_propertyText)))
                        {
                            _countries.Add(item);
                        }
                        break;

                    case "System.Windows.Controls.ComboBoxItem: Olimpiad":
                        _countries.Clear();

                        foreach (var item in _service.GetByOlimpiadName(_propertyText))
                        {
                            _countries.Add(item);
                        }
                        break;
                }
            }
        }
    }
}
