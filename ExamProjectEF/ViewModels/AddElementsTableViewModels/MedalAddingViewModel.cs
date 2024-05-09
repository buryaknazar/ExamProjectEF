using BLL.Models;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExamProjectEF.ViewModels.AddElementsTableViewModels
{
    public class MedalAddingViewModel : ViewModelBase
    {
        private MedalService _medalService;
        private MedalStatisticDTO _itemToAdd;

        public MedalStatisticDTO ItemToAdd
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
        public MedalAddingViewModel()
        {
            AddCollectionItemCommand = new ViewModelCommand(ExecuteAddCollectionItemCommand);

            _itemToAdd = new MedalStatisticDTO();

            _medalService = new MedalService();
        }

        private bool IsValidFields()
        {
            try
            {
                Convert.ToInt32(_itemToAdd.CountOfGold);
                Convert.ToInt32(_itemToAdd.CountOfSilver);
                Convert.ToInt32(_itemToAdd.CountOfBronze);
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
                _medalService.Add(_itemToAdd);
            }
        }
    }
}
