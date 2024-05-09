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
    public class MedalsViewModel : ViewModelBase
    {
        private MedalStatisticWithMemberService _service;

        private string _propertyText = "Search...";
        private string _selectedProperty = "Search by...";
        private MedalStatisticWithMemberDTO _itemToDelete;
        private ObservableCollection<MedalStatisticWithMemberDTO> _members;


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

        public MedalStatisticWithMemberDTO ItemToDelete
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

        public ObservableCollection<MedalStatisticWithMemberDTO> Members
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
        public MedalsViewModel()
        {
            //Initialize Commands
            ShowItemsCollectionCommand = new ViewModelCommand(ExecuteShowItemsCollectionCommand);
            ClearFilterCollectionCommand = new ViewModelCommand(ExecuteClearFilterCollectionCommand);
            DeleteCollectionItemCommand = new ViewModelCommand(ExecuteDeleteCollectionItemCommand);

            //Initialize Other Resources
            _members = new ObservableCollection<MedalStatisticWithMemberDTO>();
            _service = new MedalStatisticWithMemberService();
        }

        private void UpdateCollectionItems()
        {
            _members.Clear();

            foreach (var item in _service.GetAllElements())
            {
                _members.Add(item);
            }
        }

        private void ExecuteDeleteCollectionItemCommand(object obj)
        {
            if (_itemToDelete != null)
            {
                _service.DeleteElement(_itemToDelete);

                UpdateCollectionItems();
            }
        }

        private void ExecuteClearFilterCollectionCommand(object obj)
        {
            _propertyText = "Search...";
            _selectedProperty = "Search by...";

            UpdateCollectionItems();
        }

        private void ExecuteShowItemsCollectionCommand(object obj)
        {
            if (_selectedProperty != "Search by..." && _propertyText != "Search...")
            {
                switch (_selectedProperty)
                {
                    case "System.Windows.Controls.ComboBoxItem: Name":
                        _members.Clear();

                        foreach (var item in _service.GetMembersStatisticByName(_propertyText))
                        {
                            _members.Add(item);
                        }
                        break;

                    case "System.Windows.Controls.ComboBoxItem: LastName":
                        _members.Clear();

                        foreach (var item in _service.GetMembersStatisticByLastName(_propertyText))
                        {
                            _members.Add(item);
                        }
                        break;

                    case "System.Windows.Controls.ComboBoxItem: GoldenMedals":
                        _members.Clear();

                        foreach (var item in _service.GetMedalStatisticByGoldenAmount(Convert.ToInt32(_propertyText)))
                        {
                            _members.Add(item);
                        }
                        break;

                    case "System.Windows.Controls.ComboBoxItem: BronzeMedals":
                        _members.Clear();

                        foreach (var item in _service.GetMedalStatisticByBronzeAmount(Convert.ToInt32(_propertyText)))
                        {
                            _members.Add(item);
                        }
                        break;

                    case "System.Windows.Controls.ComboBoxItem: SilverMedals":
                        _members.Clear();

                        foreach (var item in _service.GetMedalStatisticBySilverAmount(Convert.ToInt32(_propertyText)))
                        {
                            _members.Add(item);
                        }
                        break;
                }
            }
        }
    }
}
