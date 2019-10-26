using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Prog5NinjaManager.View;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Prog5NinjaManager.ViewModel
{

    public class MainViewModel : ViewModelBase
    {
        private AddNinjaWindow _addNinjaWindow;


        public ICommand ShowAddNinjaCommand { get; set; }
        public ICommand DeleteNinjaCommand { get; set; }
        public ObservableCollection<NinjaVM> Ninjas { get; set; }

        private NinjaVM _selectedNinja;
        public NinjaVM SelectedNinja
        {
            get { return _selectedNinja; }
            set
            {
                _selectedNinja = value;
                base.RaisePropertyChanged();
            }
        }
        public MainViewModel()
        {
            ShowAddNinjaCommand = new RelayCommand(ShowAddNinja);
            DeleteNinjaCommand = new RelayCommand(DeleteNinja);
            CreateNinjaList();

        }

        public void ShowAddNinja()
        {
            _addNinjaWindow = new AddNinjaWindow();
            _addNinjaWindow.Show();
        }

        public void HideAddNinja()
        {
            _addNinjaWindow.Hide();
        }



        public void CreateNinjaList()
        {
            var context = new NinjaManagerEntities();
            
                var ninjas = context.Ninja.ToList();
                Ninjas = new ObservableCollection<NinjaVM>(ninjas.Select(n => new NinjaVM(n)));
            context.Dispose();
        }

        public void DeleteNinja()
        {

            using (var context = new NinjaManagerEntities())
            {
                var ninjas = context.Ninja.ToList();

                foreach (Ninja ninja in ninjas)
                {
                    if (ninja.Id == SelectedNinja.Id)
                    {
                        context.Ninja.Remove(ninja);
                    }

                }
            }
            Ninjas.Remove(SelectedNinja);


        }
    }
}