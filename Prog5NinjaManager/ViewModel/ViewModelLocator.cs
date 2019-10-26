

using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;

namespace Prog5NinjaManager.ViewModel
{

    public class ViewModelLocator
    {
  
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

        

            SimpleIoc.Default.Register<MainViewModel>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public AddNinjaVM AddNinja
        {
            get
            {
                return new AddNinjaVM(Main);
            }

        }
        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}