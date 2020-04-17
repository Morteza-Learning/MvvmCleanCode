using CommonServiceLocator;
using Core;
using Data;
using GalaSoft.MvvmLight.Ioc;
using System;

namespace MvvmCleanCode.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<IService, Service>();
            SimpleIoc.Default.Register<IRepository, Repository>();

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<SaleMaliViewModel>();
        }
        
        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>(Guid.NewGuid().ToString());
            }
        }

       

        public SaleMaliViewModel SaleMali
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SaleMaliViewModel>(Guid.NewGuid().ToString());
            }
        }

        public static void Cleanup()
        {
        }
    }
}