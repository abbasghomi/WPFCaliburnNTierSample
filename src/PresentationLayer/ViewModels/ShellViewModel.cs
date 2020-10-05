

using Caliburn.Micro;
using WPFCaliburnNTierSample.DomainLayer.Common.Interfaces;
using WPFCaliburnNTierSample.DomainLayer.Entities;
using WPFCaliburnNTierSample.DomainLayer.Services.Interfaces;
using WPFCaliburnNTierSample.PresentationLayer.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPFCaliburnNTierSample.PresentationLayer.ViewModels
{
    /// <summary>
    /// Shell view ViewModel
    /// </summary>
    public class ShellViewModel : PropertyChangedBase, IShell, IHandle<bool>
    {
        private int _currentPageNumber;
        private int _totalPageNumber;
        private bool _isBusy;
        private bool _isEditPopupOpened;
        private string _currentListOrder;
        private readonly IEventAggregator _events;
        private readonly ICustomerService _customerService;
        private List<Customer> _customersList;
        private Customer _selectedCustomer;
        private EditCustomerViewModel _editCustomerView;


        #region properties

        public int CurrentPageNumber
        {
            get => _currentPageNumber;
            set
            {
                _currentPageNumber = value;
                NotifyOfPropertyChange(() => CurrentPageNumber);
                NotifyOfPropertyChange(() => GetFormattedPageNumber);
            }
        }

        public int TotalPageNumber
        {
            get => _totalPageNumber;
            set
            {
                _totalPageNumber = value;
                NotifyOfPropertyChange(() => TotalPageNumber);
                NotifyOfPropertyChange(() => GetFormattedPageNumber);
            }
        }

        public List<Customer> CustomersList
        {
            get => _customersList;
            set
            {
                _customersList = value;
                NotifyOfPropertyChange(() => CustomersList);
            }
        }

        public Customer SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                _selectedCustomer = value;
                NotifyOfPropertyChange(() => SelectedCustomer);
            }
        }

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                NotifyOfPropertyChange(() => IsBusy);
            }
        }

        public bool IsEditPopupOpened
        {
            get => _isEditPopupOpened;
            set
            {
                _isEditPopupOpened = value;
                NotifyOfPropertyChange(() => IsEditPopupOpened);
            }
        }

        public string CurrentListOrder
        {
            get => _currentListOrder;
            set
            {
                _currentListOrder = value;
                NotifyOfPropertyChange(() => CurrentListOrder);
            }
        }

        public EditCustomerViewModel EditCustomerView
        {
            get => _editCustomerView;
            set
            {
                _editCustomerView = value;
                //NotifyOfPropertyChange(() => EditCustomerVM); 
            }
        }

        #endregion

        public ShellViewModel(IEventAggregator events, ICustomerService customerService, ICustomerValidatorFactory customerValidator)
        {
            this._events = events;
            this._events.Subscribe(this);

            this._customerService = customerService;
            EditCustomerView = new EditCustomerViewModel(events, customerService, customerValidator);
            InitData();
        }

        private void InitData()
        {
            CustomersList = new List<Customer>();
            IsBusy = false;
            IsEditPopupOpened = false;
            CurrentPageNumber = 1;
            CurrentListOrder = "Customer Id";
            
        }

        private async Task SortAndReloadCustomers<TOrder>(Expression<Func<Customer, TOrder>> order)
        {
            if (!this.IsBusy)
            {
                this.IsBusy = true;

                var paginatedCustomersList = await _customerService.GetPaginatedCustomersList(order, CurrentPageNumber, 10);

                CustomersList = paginatedCustomersList.PageItems.ToList();
                TotalPageNumber = paginatedCustomersList.ItemsCount;
                this.IsBusy = false;
            }
        }

        public async Task LoadCustomerDataAsync()
        {
            await SortAndReloadCustomers(order => order.CustomerId);
        }

        public void EditCustomer()
        {
            if (SelectedCustomer != null)
            {
                _events.PublishOnUIThread(SelectedCustomer);
                this.IsEditPopupOpened = true;
            }
            
        }
        
        public void CloseEditPopup()
        {
            this.IsEditPopupOpened = false;
        }

        public string GetFormattedPageNumber { get => $"{this.CurrentPageNumber}/{this.TotalPageNumber}"; }

        public async Task CustomerGridSorting(DataGridSortingEventArgs e)
        {
            e.Handled = true;
            CurrentListOrder = e.Column.Header.ToString();
            await JustLoadCustomersList();
        }

        private async Task JustLoadCustomersList()
        {
            switch (CurrentListOrder)
            {
                case "Customer Id":
                    await SortAndReloadCustomers(order => order.CustomerId);
                    break;
                case "First Name":
                    await SortAndReloadCustomers(order => order.FirstName);
                    break;
                case "Last Name":
                    await SortAndReloadCustomers(order => order.LastName);
                    break;
                case "Age":
                    await SortAndReloadCustomers(order => order.Age);
                    break;
                case "State":
                    await SortAndReloadCustomers(order => order.State);
                    break;
                case "City":
                    await SortAndReloadCustomers(order => order.City);
                    break;
                case "Zip":
                    await SortAndReloadCustomers(order => order.Zip);
                    break;
                case "Phone":
                    await SortAndReloadCustomers(order => order.Phone);
                    break;
            }
        }

        public async Task GotoNextPage()
        {
            if (!IsBusy)
            {
                if (CurrentPageNumber < TotalPageNumber)
                {
                    CurrentPageNumber++;
                    await JustLoadCustomersList();
                }
            }
        }

        public async Task GotoPreviousPage()
        {
            if (!IsBusy)
            {
                if (CurrentPageNumber > 1)
                {
                    CurrentPageNumber--;
                    await JustLoadCustomersList();
                }
            }
        }

        public void Handle(bool message)
        {
            CloseEditPopup();
        }
    }
}