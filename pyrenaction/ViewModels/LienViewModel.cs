using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pyrenaction.ViewModels
{
    class LienViewModel:ViewModelBase
    {
        private Models.Lien _lien;

        public LienViewModel(Models.Lien lien)
        {
            _lien = lien;

        }



        public Models.Lien Lien
        {
            get
            {
                return _lien;
            }
        }

        public String Nom
        {
            get { return _lien.nom; }
            set
            {
                if (_lien.nom != value)
                {
                    _lien.nom = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public String Url
        {
            get { return _lien.url; }
            set
            {
                if (_lien.url != value)
                {
                        _lien.url = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}
