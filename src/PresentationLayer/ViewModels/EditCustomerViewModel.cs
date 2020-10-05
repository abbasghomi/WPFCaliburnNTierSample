using Caliburn.Micro;
using WPFCaliburnNTierSample.DomainLayer.Common.Interfaces;
using WPFCaliburnNTierSample.DomainLayer.Entities;
using WPFCaliburnNTierSample.DomainLayer.Services.Interfaces;
using WPFCaliburnNTierSample.PresentationLayer.Models;
using WPFCaliburnNTierSample.PresentationLayer.ViewModels.Interfaces;
using System;
using System.Collections.Generic;

namespace WPFCaliburnNTierSample.PresentationLayer.ViewModels
{
    /// <summary>
    /// Edit Customer view ViewModel
    /// </summary>
    public class EditCustomerViewModel : PropertyChangedBase, IEditCustomer, IHandle<Customer>
    {
        //used to keep the buisy state of view
        private bool _isBusy;
        private readonly IEventAggregator _events;
        //Customer service interface for IOC to inject
        private readonly ICustomerService _customerService;
        //Customer validation service interface for IOC to inject
        private readonly ICustomerValidatorFactory _customerValidator;
        //selected Customer for edit
        private Customer _currentCustomer;

        //validation message, will be filled if field value is invalid
        private string _firstNameValidationMessage;
        private string _lastNameValidationMessage;
        private string _address1ValidationMessage;
        private string _stateValidationMessage;
        private string _cityValidationMessage;
        private string _zipValidationMessage;
        private string _ageValidationMessage;

        //used to view the list of US states
        private List<USState> _usStates;

        #region properties

        public List<USState> USStates
        {
            get => _usStates;
            set
            {
                _usStates = value;
                NotifyOfPropertyChange(() => USStates);
            }
        }

        public Customer CurrentCustomer
        {
            get => _currentCustomer;
            set
            {
                _currentCustomer = value;
                NotifyOfPropertyChange(() => CurrentCustomer);
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

        #endregion

        public EditCustomerViewModel(IEventAggregator events, ICustomerService customerService, ICustomerValidatorFactory customerValidator)
        {
            this._events = events;
            this._events.Subscribe(this);

            this._customerService = customerService;
            this._customerValidator = customerValidator;

            InitData();
        }

        private void InitData()
        {
            IsBusy = false;

            _usStates = new List<USState> {
            new USState("AL", "Alabama"),
            new USState("AK", "Alaska"),
            new USState("AZ", "Arizona"),
            new USState("AR", "Arkansas"),
            new USState("CA", "California"),
            new USState("CO", "Colorado"),
            new USState("CT", "Connecticut"),
            new USState("DE", "Delaware"),
            new USState("DC", "District of Columbia"),
            new USState("FL", "Florida"),
            new USState("GA", "Georgia"),
            new USState("HI", "Hawaii"),
            new USState("ID", "Idaho"),
            new USState("IL", "Illinois"),
            new USState("IN", "Indiana"),
            new USState("IA", "Iowa"),
            new USState("KS", "Kansas"),
            new USState("KY", "Kentucky"),
            new USState("LA", "Louisiana"),
            new USState("ME", "Maine"),
            new USState("MD", "Maryland"),
            new USState("MA", "Massachusetts"),
            new USState("MI", "Michigan"),
            new USState("MN", "Minnesota"),
            new USState("MS", "Mississippi"),
            new USState("MO", "Missouri"),
            new USState("MT", "Montana"),
            new USState("NE", "Nebraska"),
            new USState("NV", "Nevada"),
            new USState("NH", "New Hampshire"),
            new USState("NJ", "New Jersey"),
            new USState("NM", "New Mexico"),
            new USState("NY", "New York"),
            new USState("NC", "North Carolina"),
            new USState("ND", "North Dakota"),
            new USState("OH", "Ohio"),
            new USState("OK", "Oklahoma"),
            new USState("OR", "Oregon"),
            new USState("PA", "Pennsylvania"),
            new USState("RI", "Rhode Island"),
            new USState("SC", "South Carolina"),
            new USState("SD", "South Dakota"),
            new USState("TN", "Tennessee"),
            new USState("TX", "Texas"),
            new USState("UT", "Utah"),
            new USState("VT", "Vermont"),
            new USState("VA", "Virginia"),
            new USState("WA", "Washington"),
            new USState("WV", "West Virginia"),
            new USState("WI", "Wisconsin"),
            new USState("WY", "Wyoming")
        };
        }

        public string FirstNameValidationMessage
        {
            get
            {
                return _firstNameValidationMessage;
            }

            set
            {
                _firstNameValidationMessage = value;
                NotifyOfPropertyChange(() => FirstNameValidationMessage);
                NotifyOfPropertyChange(() => FirstNameIsNotValid);
            }
        }

        public bool FirstNameIsNotValid { get => !string.IsNullOrWhiteSpace(FirstNameValidationMessage); }

        public string LastNameValidationMessage
        {
            get
            {
                return _lastNameValidationMessage;
            }

            set
            {
                _lastNameValidationMessage = value;
                NotifyOfPropertyChange(() => LastNameValidationMessage);
                NotifyOfPropertyChange(() => LastNameIsNotValid);
            }
        }

        public bool LastNameIsNotValid { get => !string.IsNullOrWhiteSpace(LastNameValidationMessage); }

        public string Address1ValidationMessage
        {
            get
            {
                return _address1ValidationMessage;
            }

            set
            {
                _address1ValidationMessage = value;
                NotifyOfPropertyChange(() => Address1ValidationMessage);
                NotifyOfPropertyChange(() => Address1IsNotValid);
            }
        }

        public bool Address1IsNotValid { get => !string.IsNullOrWhiteSpace(Address1ValidationMessage); }

        public string StateValidationMessage
        {
            get
            {
                return _stateValidationMessage;
            }

            set
            {
                _stateValidationMessage = value;
                NotifyOfPropertyChange(() => StateValidationMessage);
                NotifyOfPropertyChange(() => StateIsNotValid);
            }
        }

        public bool StateIsNotValid { get => !string.IsNullOrWhiteSpace(StateValidationMessage); }

        public string CityValidationMessage
        {
            get
            {
                return _cityValidationMessage;
            }

            set
            {
                _cityValidationMessage = value;
                NotifyOfPropertyChange(() => CityValidationMessage);
                NotifyOfPropertyChange(() => CityIsNotValid);
            }
        }

        public bool CityIsNotValid { get => !string.IsNullOrWhiteSpace(CityValidationMessage); }

        public string ZipValidationMessage
        {
            get
            {
                return _zipValidationMessage;
            }

            set
            {
                _zipValidationMessage = value;
                NotifyOfPropertyChange(() => ZipValidationMessage);
                NotifyOfPropertyChange(() => ZipIsNotValid);
            }
        }

        public bool ZipIsNotValid { get => !string.IsNullOrWhiteSpace(ZipValidationMessage); }

        public string AgeValidationMessage
        {
            get
            {
                return _ageValidationMessage;
            }

            set
            {
                _ageValidationMessage = value;
                NotifyOfPropertyChange(() => AgeValidationMessage);
                NotifyOfPropertyChange(() => AgeIsNotValid);
            }
        }

        public bool AgeIsNotValid { get => !string.IsNullOrWhiteSpace(AgeValidationMessage); }

        public void Save()
        {
            if (!_customerValidator.IsValid(CurrentCustomer))
            {
                ClearErrorMessages();

                foreach (var item in _customerValidator.ValidationErrors(CurrentCustomer))
                {
                    if (item.PropertyName == "FirstName")
                    {
                        FirstNameValidationMessage += item.ErrorMessage + Environment.NewLine;
                    }
                    if (item.PropertyName == "LastName")
                    {
                        LastNameValidationMessage += item.ErrorMessage + Environment.NewLine;
                    }
                    if (item.PropertyName == "Address1")
                    {
                        Address1ValidationMessage += item.ErrorMessage + Environment.NewLine;
                    }
                    if (item.PropertyName == "State")
                    {
                        StateValidationMessage += item.ErrorMessage + Environment.NewLine;
                    }
                    if (item.PropertyName == "City")
                    {
                        CityValidationMessage += item.ErrorMessage + Environment.NewLine;
                    }
                    if (item.PropertyName == "Age")
                    {
                        AgeValidationMessage += item.ErrorMessage + Environment.NewLine;
                    }
                }
            }
            else
            {
                ClearErrorMessages();
                _customerService.UpdateCustomer(CurrentCustomer);
                _events.PublishOnUIThread(true);
            }
        }

        private void ClearErrorMessages()
        {
            FirstNameValidationMessage = "";
            LastNameValidationMessage = "";
            Address1ValidationMessage = "";
            StateValidationMessage = "";
            CityValidationMessage = "";
            ZipValidationMessage = "";
            AgeValidationMessage = "";
        }

        public void Handle(Customer message)
        {
            this.CurrentCustomer = message;
        }
    }
}