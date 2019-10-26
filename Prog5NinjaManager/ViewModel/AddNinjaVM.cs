using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Prog5NinjaManager.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Prog5NinjaManager.ViewModel
{
   public class AddNinjaVM : ViewModelBase
    {
        public ICommand AddNinjaCommand { get; set; }

        Ninja addNinja;
        private int _gold;
        private string _name;
        private MainViewModel mainViewModel;

        public string GoldString { get; set; }

        public AddNinjaVM(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
           
            AddNinjaCommand = new RelayCommand(AddNinja);
        }

        public int Gold
        {
            get
            {
                return this._gold;
            }
            set
            {
                this._gold = value;
            }
        }

        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }


        public void AddNinja()
        {
            
            
            Gold = int.Parse(GoldString);
            addNinja = new Ninja()
            {
                Gold = this.Gold,
                Name = this.Name
            };

            
            using (NinjaManagerEntities context = new NinjaManagerEntities())
            {

               context.Ninja.Add(addNinja); 
                context.SaveChanges();


            }
            NinjaVM ninjavm = new NinjaVM(){
                Gold = this.Gold,
                Name = this.Name,
                Id = addNinja.Id
            };
            mainViewModel.Ninjas.Add(ninjavm);
            mainViewModel.HideAddNinja();
            
        }

    }
}
