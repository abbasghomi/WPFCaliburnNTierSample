using Caliburn.Micro;
using WPFCaliburnNTierSample.DomainLayer.Common.Interfaces;
using WPFCaliburnNTierSample.DomainLayer.Common.Validators;
using WPFCaliburnNTierSample.DomainLayer.Persistence;
using WPFCaliburnNTierSample.DomainLayer.Persistence.Interfaces;
using WPFCaliburnNTierSample.DomainLayer.Persistence.Repositories;
using WPFCaliburnNTierSample.DomainLayer.Persistence.Repositories.Interfaces;
using WPFCaliburnNTierSample.DomainLayer.Services;
using WPFCaliburnNTierSample.DomainLayer.Services.Interfaces;
using WPFCaliburnNTierSample.PresentationLayer.ViewModels;
using WPFCaliburnNTierSample.PresentationLayer.ViewModels.Interfaces;
using System;
using System.Collections.Generic;

namespace WPFCaliburnNTierSample.PresentationLayer
{

    public class AppBootstrapper : BootstrapperBase {
        SimpleContainer _container;

        public AppBootstrapper() {
            Initialize();
        }

        protected override void Configure() {
            _container = new SimpleContainer();

            _container.Singleton<IWindowManager, WindowManager>();
            _container.Singleton<IEventAggregator, EventAggregator>();

            RegisterViewModels();
            RegisterRepositories();
            RegisterServices();
            RegisterValidators();

            _container.Singleton<IWPFCaliburnNTierSampleContextFactory, WPFCaliburnNTierSampleContextFactory>();
            _container.Singleton<IWPFCaliburnNTierSampleContext, WPFCaliburnNTierSampleContext>();
        }

        private void RegisterValidators()
        {
            _container.Singleton<ICustomerValidatorFactory, CustomerValidatorFactory>();
        }

        public void RegisterViewModels()
        {
            _container.PerRequest<IShell, ShellViewModel>();
            _container.PerRequest<IEditCustomer, EditCustomerViewModel>();
        }

        public void RegisterRepositories()
        {
            _container.Singleton<ICustomerRepository, CustomerRepository>();
        }

        public void RegisterServices()
        {
            _container.Singleton<ICustomerService, CustomerService>();
        }

        protected override object GetInstance(Type service, string key) {
            return _container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service) {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance) {
            _container.BuildUp(instance);
        }

        protected override void OnStartup(object sender, System.Windows.StartupEventArgs e) {
            DisplayRootViewFor<IShell>();
        }
    }
}