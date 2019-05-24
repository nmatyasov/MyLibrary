/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocatorTemplate xmlns:vm="clr-namespace:BooksOrganizer.ViewModel"
                                   x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using BooksOrganizer.Model;
using CommonServiceLocator;
using System;
using BooksOrganizer.Helpers;

namespace BooksOrganizer.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class ViewModelLocator
    {

        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);



            if (ViewModelBase.IsInDesignModeStatic)
            {
                SimpleIoc.Default.Register<IDataService, Design.DesignDataService>();
            }
            else
            {
                SimpleIoc.Default.Register<IDataService, DataService>();
            }

            SimpleIoc.Default.Register<IDialogService, DialogService>();

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<DetailViewModel>();
            SimpleIoc.Default.Register<SearchViewModel>();
            SimpleIoc.Default.Register<SettingsViewModel>();
        }


        /// <summary>
        /// Gets the Main property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public MainViewModel MainViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }



        ///// <summary>
        ///// Gets the DetailViewModel property.
        ///// </summary>
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
        //    "CA1822:MarkMembersAsStatic",
        //    Justification = "This non-static member is needed for data binding purposes.")]
        //public DetailViewModel DetailViewModel
        //{
        //    get
        //    {
        //        return ServiceLocator.Current.GetInstance<DetailViewModel>();
        //    }
        //}




        ///// <summary>
        ///// Gets the ViewModelPropertyName property.
        ///// </summary>
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
        //    "CA1822:MarkMembersAsStatic",
        //    Justification = "This non-static member is needed for data binding purposes.")]
        //public SearchViewModel SearchViewModel
        //{
        //    get
        //    {
        //        return ServiceLocator.Current.GetInstance<SearchViewModel>();
        //    }
        //}


        ///// <summary>
        ///// Gets the SettingsViewModel property.
        ///// </summary>
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
        //    "CA1822:MarkMembersAsStatic",
        //    Justification = "This non-static member is needed for data binding purposes.")]
        //public SettingsViewModel SettingsViewModel
        //{
        //    get
        //    {
        //        return ServiceLocator.Current.GetInstance<SettingsViewModel>();
        //    }
        //}

 

        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
        }
    }
}