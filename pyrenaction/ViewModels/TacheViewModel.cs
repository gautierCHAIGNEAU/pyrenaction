using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pyrenaction.ViewModels
{
    class TacheViewModel : ViewModelBase
    {
        private Models.Tache _tache;

        public TacheViewModel(Models.Tache tache)
        {
            _tache = tache;
            if(_tache.statut == null)
            {
                _tache.statut = false;
            }
        
        }



        public Models.Tache Tache
        {
            get
            {
                return _tache;
            }
        }

        public String Nom
        {
            get { return _tache.nom; }
            set
            {
                if (_tache.nom != value)
                {
                    _tache.nom = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public bool? Statut
        {
            get { return _tache.statut; }
            set
            {
               if( _tache.statut != value)
                {
                    _tache.statut = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}
