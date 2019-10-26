using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog5NinjaManager.ViewModel
{
    public class NinjaVM : ViewModelBase
    {
        private Ninja n;

        public NinjaVM(Ninja n)
        {
            this.n = n;
        }

        public NinjaVM()
        {
            n = new Ninja();
        }
      

        public string Name
        {
            
            get { return n.Name; }
            set { n.Name = value; }
        }
        public int Gold
        {
            get { return n.Gold; }
            set { n.Gold = value; }
        }
        public int Id
        {
            get { return n.Id; }
            set { n.Id = value; }
        }
    }
}
