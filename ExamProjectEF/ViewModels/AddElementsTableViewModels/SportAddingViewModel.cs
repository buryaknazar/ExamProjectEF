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
    public class SportAddingViewModel : ViewModelBase
    {
        private SportService _sportService;
        private OlimpiadService _olimpiadService;

        private ObservableCollection<OlimpiadDTO> _olimpiads;
        private OlimpiadDTO _selectedItem;
        private SportDTO _itemToAdd;

        public SportDTO ItemToAdd
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

        public OlimpiadDTO SelectedItem
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
        public ICommand ShowCollectionCommand { get; }
        public ICommand AddCollectionItemCommand { get; }

        //Constructors
        public SportAddingViewModel()
        {
            ShowCollectionCommand = new ViewModelCommand(ExecuteShowCollectionCommand);
            AddCollectionItemCommand = new ViewModelCommand(ExecuteAddCollectionItemCommand);

            _olimpiads = new ObservableCollection<OlimpiadDTO>();
            _itemToAdd = new SportDTO();

            _sportService = new SportService();
            _olimpiadService = new OlimpiadService();

            ExecuteShowCollectionCommand(null);
        }

        private bool IsValidFields()
        {
            if (String.IsNullOrEmpty(_itemToAdd.Name) && String.IsNullOrWhiteSpace(_itemToAdd.Name))
                return false;
            if (_selectedItem == null)
            {
                return false;
            }
            try
            {
                Convert.ToInt32(_itemToAdd.CountOfTeams);
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
                _itemToAdd.Olimpiad = _selectedItem;
                _sportService.Add(_itemToAdd);
            }
        }

        private void ExecuteShowCollectionCommand(object obj)
        {
            foreach (var item in _olimpiadService.GetAll())
            {
                _olimpiads.Add(item);
            }
        }
    }
}
