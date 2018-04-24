using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pyrenaction.ViewModels
{
    class ActionViewModel : ViewModelBase
    {
        private Models.Action _action;
        private Models.pyrenactionEntities _context;
        

        public ActionViewModel(Models.Action action)
        {
            _action = action;
            _context = new Models.pyrenactionEntities();

        }

        public Models.Action getAction
        {
            get
            {
                return _action;
            }
        }

        public List<Models.Importance> Importances
        {
            get
            {
                var query = from U in _context.Importances select U;
                List<Models.Importance> listeImportances = query.ToList();
                return listeImportances;
            }
            
        }

        public List<Models.Famille> Familles
        {
            get
            {
                var query = from U in _context.Familles select U;
                List<Models.Famille> listeFamilles = query.ToList();
                return listeFamilles;
            }

        }

        public List<Models.Site> Sites
        {
            get
            {
                var query = from U in _context.Sites select U;
                List<Models.Site> listeSites = query.ToList();
                return listeSites;
            }

        }

        public List<Models.Utilisateur> Utilisateurs
        {
            get
            {
                var query = from U in _context.Utilisateurs select U;
                List<Models.Utilisateur> listeUtilisateurs = query.ToList();
                return listeUtilisateurs;
            }

        }

        public List<Models.Questionnaire> Questionnaires
        {
            get
            {
                var query = from U in _context.Questionnaires select U;
                List<Models.Questionnaire> listeQuestionnaires = query.ToList();
                return listeQuestionnaires;
            }

        }

        public List<Models.Action> Actions
        {
            get
            {
                var query = from U in _context.Actions select U;
                List<Models.Action> listeActions = query.ToList();
                return listeActions;
            }

        }

        public DateTime? Date_a
        {
            get { return _action.date_a; }
            set
            {
                if (_action.date_a != value)
                {
                    _action.date_a = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public DateTime? Delais
        {
            get { return _action.delais; }
            set
            {
                if (_action.delais != value)
                {
                    _action.delais = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public String Source
        {
            get { return _action.source; }
            set
            {
                if (_action.source != value)
                {
                    _action.source = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public String Analyse
        {
            get { return _action.analyse; }
            set
            {
                if (_action.analyse != value)
                {
                    _action.analyse = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public String Description
        {
            get { return _action.description; }
            set
            {
                if (_action.description != value)
                {
                    _action.description = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public bool? Statut
        {
            get { return _action.statut; }
            set
            {
                if (_action.statut != value)
                {
                    _action.statut = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public Models.Importance Importance
        {
            get { return _action.Importance; }
            set
            {
                if (_action.Importance != value)
                {
                    _action.Importance = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public Models.Famille Famille
        {
            get { return _action.Famille; }
            set
            {
                if (_action.Famille != value)
                {
                    _action.Famille = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public Models.Site Site
        {
            get { return _action.Site; }
            set
            {
                if (_action.Site != value)
                {
                    _action.Site = value;
                    NotifyPropertyChanged();
                }
            }
        }


        public Models.Questionnaire Questionnaire
        {
            get { return _action.Questionnaire; }
            set
            {
                if (_action.Questionnaire != value)
                {
                    _action.Questionnaire = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public Models.Action Action
        {
            get { return _action.Action2; }
            set
            {
                if (_action.Action2 != value)
                {
                    _action.Action2 = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public Models.Utilisateur Utilisateur1
        {
            get { return _action.Utilisateur; }
            set
            {
                if (_action.Utilisateur != value)
                {
                    _action.Utilisateur = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public Models.Utilisateur Utilisateur2
        {
            get { return _action.Utilisateur1; }
            set
            {
                if (_action.Utilisateur1 != value)
                {
                    _action.Utilisateur1 = value;
                    NotifyPropertyChanged();
                }
            }
        }




    }
}
