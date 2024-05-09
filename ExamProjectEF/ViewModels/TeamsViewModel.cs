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
    public class TeamsViewModel : ViewModelBase
    {
        private MemberService _service;

        private string _propertyText = "Search...";
        private string _selectedProperty = "Search by...";
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


        //Constructor
        public TeamsViewModel()
        {
            //Initialize Commands
            ShowItemsCollectionCommand = new ViewModelCommand(ExecuteShowItemsCollectionCommand);
            ClearFilterCollectionCommand = new ViewModelCommand(ExecuteClearFilterCollectionCommand);

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
                _members.Clear();

                foreach (var item in _service.GetByCountry(_propertyText))
                {
                    _members.Add(item);
                }
            }
        }
    }
}
