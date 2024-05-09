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
    public class SportsViewModel : ViewModelBase
    {
        private SportService _service;

        private string _propertyText = "Search...";
        private string _selectedProperty = "Search by...";
        private SportDTO _itemToDelete;
        private ObservableCollection<SportDTO> _sports;


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

        public SportDTO ItemToDelete
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

        //Commands
        public ICommand ShowItemsCollectionCommand { get; }
        public ICommand ClearFilterCollectionCommand { get; }
        public ICommand DeleteCollectionItemCommand { get; }


        //Constructor
        public SportsViewModel()
        {
            //Initialize Commands
            ShowItemsCollectionCommand = new ViewModelCommand(ExecuteShowItemsCollectionCommand);
            ClearFilterCollectionCommand = new ViewModelCommand(ExecuteClearFilterCollectionCommand);
            DeleteCollectionItemCommand = new ViewModelCommand(ExecuteDeleteCollectionItemCommand);

            //Initialize Other Resources
            _sports = new ObservableCollection<SportDTO>();
            _service = new SportService();
        }

        private void UpdateCollectionItems()
        {
            _sports.Clear();

            foreach (var item in _service.GetAll())
            {
                _sports.Add(item);
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

            _sports.Clear();

            foreach (var item in _service.GetAll())
            {
                _sports.Add(item);
            }
        }

        private void ExecuteShowItemsCollectionCommand(object obj)
        {
            if (_selectedProperty != "Search by..." && _propertyText != "Search...")
            {
                switch (_selectedProperty)
                {
                    case "System.Windows.Controls.ComboBoxItem: Name":
                        _sports.Clear();

                        foreach (var item in _service.GetElementsByName(_propertyText))
                        {
                            _sports.Add(item);
                        }
                        break;

                    case "System.Windows.Controls.ComboBoxItem: Olimpiad":
                        _sports.Clear();

                        foreach (var item in _service.GetByOlimpiad(_propertyText))
                        {
                            _sports.Add(item);
                        }
                        break;

                    case "System.Windows.Controls.ComboBoxItem: Teams":
                        _sports.Clear();

                        foreach (var item in _service.GetByMaxTeams(Convert.ToInt32(_propertyText)))
                        {
                            _sports.Add(item);
                        }
                        break;
                }
            }
        }
    }
}
