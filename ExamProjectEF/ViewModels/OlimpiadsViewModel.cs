using BLL.Models;
using BLL.Services;
using ExamProjectEF.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace ExamProjectEF.ViewModels
{
    public class OlimpiadsViewModel : ViewModelBase
    {
        private OlimpiadService _service;

        private string _propertyText = "Search...";
        private string _selectedProperty = "Search by...";
        private OlimpiadDTO _itemToDelete;
        private ObservableCollection<OlimpiadDTO> _olimpiads;


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

        public OlimpiadDTO ItemToDelete
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

        public ObservableCollection<OlimpiadDTO> Olimpiads
        {
            get
            {
                return _olimpiads;
            }
            set
            {
                _olimpiads = value;
                OnPropertyChanged(nameof(Olimpiads));
            }
        }

        //Commands
        public ICommand ShowOlimpiadsCollectionCommand { get; }
        public ICommand ClearFilterCollectionCommand { get; }
        public ICommand DeleteCollectionItemCommand { get; }


        //Constructor
        public OlimpiadsViewModel()
        {
            //Initialize Commands
            ShowOlimpiadsCollectionCommand = new ViewModelCommand(ExecuteShowOlimpiadsCollectionCommand);
            ClearFilterCollectionCommand = new ViewModelCommand(ExecuteClearFilterCollectionCommand);
            DeleteCollectionItemCommand = new ViewModelCommand(ExecuteDeleteCollectionItemCommand);

            //Initialize Other Resources
            _olimpiads = new ObservableCollection<OlimpiadDTO>();
            _service = new OlimpiadService();
        }

        private void UpdateCollectionItems()
        {
            _olimpiads.Clear();

            foreach (var item in _service.GetAll())
            {
                _olimpiads.Add(item);
            }
        }

        private void ExecuteDeleteCollectionItemCommand(object obj)
        {
            if(_itemToDelete != null)
            {
                _service.Delete(_itemToDelete);

                UpdateCollectionItems();
            }
        }

        private void ExecuteClearFilterCollectionCommand(object obj)
        {
            _propertyText = "Search...";
            _selectedProperty = "Search by...";

            _olimpiads.Clear();

            foreach (var item in _service.GetAll())
            {
                _olimpiads.Add(item);
            }
        }

        private void ExecuteShowOlimpiadsCollectionCommand(object obj)
        {
            if(_selectedProperty != "Search by..." && _propertyText != "Search...")
            {
                switch (_selectedProperty)
                {
                    case "System.Windows.Controls.ComboBoxItem: Name":
                        _olimpiads.Clear();

                        _olimpiads.Add(_service.GetByName(_propertyText));
                        break;

                    case "System.Windows.Controls.ComboBoxItem: Country":
                        _olimpiads.Clear();

                        foreach (var item in _service.GetByCountry(_propertyText))
                        {
                            _olimpiads.Add(item);
                        }
                        break;

                    case "System.Windows.Controls.ComboBoxItem: Season":
                        _olimpiads.Clear();

                        foreach (var item in _service.GetBySeason(_propertyText))
                        {
                            _olimpiads.Add(item);
                        }
                        break;

                    case "System.Windows.Controls.ComboBoxItem: EventDate":
                        _olimpiads.Clear();

                        foreach (var item in _service.GetByEventDate(Convert.ToDateTime(_propertyText)))
                        {
                            _olimpiads.Add(item);
                        }
                        break;

                    case "System.Windows.Controls.ComboBoxItem: CountOfMembers":
                        _olimpiads.Clear();

                        foreach (var item in _service.GetByCountOfMembers(Convert.ToInt32(_propertyText)))
                        {
                            _olimpiads.Add(item);
                        }
                        break;
                }
            }
        }
    }
}
