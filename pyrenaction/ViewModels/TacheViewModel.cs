using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pyrenaction.ViewModels
{
    class TacheViewModel
    {
        private Models.Tache _tache;

        public TacheViewModel(Models.Tache tache)
        {
            _tache = tache;
        }
    }
}
