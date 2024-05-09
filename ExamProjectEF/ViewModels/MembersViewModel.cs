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
    public class MembersViewModel : ViewModelBase
    {
        private MemberService _service;

        private string _propertyText = "Search...";
        private string _selectedProperty = "Search by...";
        private MemberDTO _itemToDelete;
        private ObservableCollection<MemberDTO> _members;


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

        public MemberDTO ItemToDelete
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

        public ObservableCollection<MemberDTO> Members
        {
            get
            {
                return _members;
            }
            set
            {
                _members = value;
                OnPropertyChanged(nameof(Members));
            }
        }

        //Commands
        public ICommand ShowItemsCollectionCommand { get; }
        public ICommand ClearFilterCollectionCommand { get; }
        public ICommand DeleteCollectionItemCommand { get; }


        //Constructor
        public MembersViewModel()
        {
            //Initialize Commands
            ShowItemsCollectionCommand = new ViewModelCommand(ExecuteShowItemsCollectionCommand);
            ClearFilterCollectionCommand = new ViewModelCommand(ExecuteClearFilterCollectionCommand);
            DeleteCollectionItemCommand = new ViewModelCommand(ExecuteDeleteCollectionItemCommand);

            //Initialize Other Resources
            _members = new ObservableCollection<MemberDTO>();
            _service = new MemberService();
        }

        private void UpdateCollectionItems()
        {
            _members.Clear();

            foreach (var item in _service.GetAll())
            {
                _members.Add(item);
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

            _members.Clear();

            foreach (var item in _service.GetAll())
            {
                _members.Add(item);
            }
        }

        private void ExecuteShowItemsCollectionCommand(object obj)
        {
            if (_selectedProperty != "Search by..." && _propertyText != "Search...")
            {
                switch (_selectedProperty)
                {
                    case "System.Windows.Controls.ComboBoxItem: Country":
                        _members.Clear();

                        foreach (var item in _service.GetByCountry(_propertyText))
                        {
                            _members.Add(item);
                        }
                        break;

                    case "System.Windows.Controls.ComboBoxItem: Name":
                        _members.Clear();

                        foreach (var item in _service.GetElementsByName(_propertyText))
                        {
                            _members.Add(item);
                        }
                        break;

                    case "System.Windows.Controls.ComboBoxItem: GoldenMedals":
                        _members.Clear();

                        foreach (var item in _service.GetByGoldenMedals(Convert.ToInt32(_propertyText)))
                        {
                            _members.Add(item);
                        }
                        break;

                    case "System.Windows.Controls.ComboBoxItem: LastName":
                        _members.Clear();

                        foreach (var item in _service.GetByLastName(_propertyText))
                        {
                            _members.Add(item);
                        }
                        break;

                    case "System.Windows.Controls.ComboBoxItem: Age":
                        _members.Clear();

                        foreach (var item in _service.GetByAge(Convert.ToInt32(_propertyText)))
                        {
                            _members.Add(item);
                        }
                        break;

                    case "System.Windows.Controls.ComboBoxItem: Sport":
                        _members.Clear();

                        foreach (var item in _service.GetBySport(_propertyText))
                        {
                            _members.Add(item);
                        }
                        break;
                }
            }
        }
    }
}
