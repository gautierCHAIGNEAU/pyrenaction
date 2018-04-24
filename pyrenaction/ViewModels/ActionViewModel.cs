using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace pyrenaction.ViewModels
{
    class ActionViewModel : ViewModelBase
    {
        private Models.Action _action;
        private Models.pyrenactionEntities _context;
        private ObservableCollection<Models.Importance> _ListeImportances;
        private readonly ICollectionView _importanceCollectionView;

        private ObservableCollection<Models.Famille> _ListeFamilles;
        private readonly ICollectionView _familleCollectionView;

        private ObservableCollection<Models.Site> _ListeSites;
        private readonly ICollectionView _siteCollectionView;

        private ObservableCollection<Models.Questionnaire> _ListeQuestionnaires;
        private readonly ICollectionView _questionnaireCollectionView;

        private ObservableCollection<Models.Action> _ListeActions;
        private readonly ICollectionView _actionCollectionView;

        private ObservableCollection<Models.Utilisateur> _ListeUtilisateurs1;
        private readonly ICollectionView _utilisateurCollectionView1;

        private ObservableCollection<Models.Utilisateur> _ListeUtilisateurs2;
        private readonly ICollectionView _utilisateurCollectionView2;

        public void Valider()
        {
            _action.Importance = ImportanceSelected;
            _action.Famille = FamilleSelected;
            _action.Site = SiteSelected;
            _action.Questionnaire = QuestionnaireSelected;
            _action.Action2 = ActionSelected;
            _action.Utilisateur = Resp1Selected;
            _action.Utilisateur1 = Resp2Selected;

            _context.Actions.Add(_action);
            _context.SaveChanges();
        }
        public ActionViewModel(Models.Action action)
        {
            _action = action;
            _context = new Models.pyrenactionEntities();

            _ListeImportances = new ObservableCollection<Models.Importance>();
            var query = from U in _context.Importances select U;
            List<Models.Importance> listeImportances = query.ToList();
            foreach (Models.Importance imp in listeImportances)
            {
                _ListeImportances.Add(imp);
            }

            //définition de la collection view
            _importanceCollectionView = CollectionViewSource.GetDefaultView(_ListeImportances);
            
            if (_importanceCollectionView == null)
            {
                throw new NullReferenceException("_importanceCollectionView");
            }

            //ajout de l'événement à déclencher quand la vue courante change
            _importanceCollectionView.CurrentChanged += OnCollectionViewImportanceCurrentChanged;



            _ListeFamilles = new ObservableCollection<Models.Famille>();
            var queryFam = from U in _context.Familles select U;
            List<Models.Famille> listeFamilles = queryFam.ToList();
            foreach (Models.Famille fam in listeFamilles)
            {
                _ListeFamilles.Add(fam);
            }

            //définition de la collection view
            _familleCollectionView = CollectionViewSource.GetDefaultView(_ListeFamilles);

            if (_familleCollectionView == null)
            {
                throw new NullReferenceException("_familleCollectionView");
            }

            //ajout de l'événement à déclencher quand la vue courante change
            _familleCollectionView.CurrentChanged += OnCollectionViewFamilleCurrentChanged;


            _ListeSites = new ObservableCollection<Models.Site>();
            var querySite = from U in _context.Sites select U;
            List<Models.Site> listeSites = querySite.ToList();
            foreach (Models.Site site in listeSites)
            {
                _ListeSites.Add(site);
            }

            //définition de la collection view
            _siteCollectionView = CollectionViewSource.GetDefaultView(_ListeSites);

            if (_siteCollectionView == null)
            {
                throw new NullReferenceException("_siteCollectionView");
            }

            //ajout de l'événement à déclencher quand la vue courante change
            _siteCollectionView.CurrentChanged += OnCollectionViewSiteCurrentChanged;


            _ListeQuestionnaires = new ObservableCollection<Models.Questionnaire>();
            var queryQuest = from U in _context.Questionnaires select U;
            List<Models.Questionnaire> listeQuestionnaires = queryQuest.ToList();
            foreach (Models.Questionnaire quest in listeQuestionnaires)
            {
                _ListeQuestionnaires.Add(quest);
            }

            //définition de la collection view
            _questionnaireCollectionView = CollectionViewSource.GetDefaultView(_ListeQuestionnaires);

            if (_questionnaireCollectionView == null)
            {
                throw new NullReferenceException("_questionnaireCollectionView");
            }

            //ajout de l'événement à déclencher quand la vue courante change
            _questionnaireCollectionView.CurrentChanged += OnCollectionViewQuestionnaireCurrentChanged;


            _ListeActions = new ObservableCollection<Models.Action>();
            var queryAct = from U in _context.Actions select U;
            List<Models.Action> listeActions = queryAct.ToList();
            foreach (Models.Action act in listeActions)
            {
                _ListeActions.Add(act);
            }

            //définition de la collection view
            _actionCollectionView = CollectionViewSource.GetDefaultView(_ListeActions);

            if (_actionCollectionView == null)
            {
                throw new NullReferenceException("_actionCollectionView");
            }

            //ajout de l'événement à déclencher quand la vue courante change
            _actionCollectionView.CurrentChanged += OnCollectionViewActionCurrentChanged;




            _ListeUtilisateurs1 = new ObservableCollection<Models.Utilisateur>();
            var queryUt1 = from U in _context.Utilisateurs select U;
            List<Models.Utilisateur> listeUt1 = queryUt1.ToList();
            foreach (Models.Utilisateur ut in listeUt1)
            {
                _ListeUtilisateurs1.Add(ut);
            }

            //définition de la collection view
            _utilisateurCollectionView1 = CollectionViewSource.GetDefaultView(_ListeUtilisateurs1);

            if (_utilisateurCollectionView1 == null)
            {
                throw new NullReferenceException("_utilisateurCollectionView1");
            }

            //ajout de l'événement à déclencher quand la vue courante change
            _utilisateurCollectionView1.CurrentChanged += OnCollectionViewResp1CurrentChanged;


            _ListeUtilisateurs2 = new ObservableCollection<Models.Utilisateur>();
            var queryUt2 = from U in _context.Utilisateurs select U;
            List<Models.Utilisateur> listeUt2 = queryUt2.ToList();
            foreach (Models.Utilisateur ut in listeUt2)
            {
                _ListeUtilisateurs2.Add(ut);
            }

            //définition de la collection view
            _utilisateurCollectionView2 = CollectionViewSource.GetDefaultView(_ListeUtilisateurs2);

            if (_utilisateurCollectionView2 == null)
            {
                throw new NullReferenceException("_utilisateurCollectionView2");
            }

            //ajout de l'événement à déclencher quand la vue courante change
            _utilisateurCollectionView2.CurrentChanged += OnCollectionViewResp2CurrentChanged;
        }

        public Models.Importance ImportanceSelected
        {
            get
            {
                if (_importanceCollectionView == null) return null;
                if (_importanceCollectionView.CurrentItem == null) return null;
    
                return (Models.Importance)_importanceCollectionView.CurrentItem;
                
            }
        }

        public Models.Famille FamilleSelected
        {
            get
            {
                if (_familleCollectionView == null) return null;
                if (_familleCollectionView.CurrentItem == null) return null;

                return (Models.Famille)_familleCollectionView.CurrentItem;

            }
        }

        public Models.Site SiteSelected
        {
            get
            {
                if (_siteCollectionView == null) return null;
                if (_siteCollectionView.CurrentItem == null) return null;

                return (Models.Site)_siteCollectionView.CurrentItem;

            }
        }

        public Models.Questionnaire QuestionnaireSelected
        {
            get
            {
                if (_questionnaireCollectionView == null) return null;
                if (_questionnaireCollectionView.CurrentItem == null) return null;

                return (Models.Questionnaire)_questionnaireCollectionView.CurrentItem;

            }
        }

        public Models.Action ActionSelected
        {
            get
            {
                if (_actionCollectionView == null) return null;
                if (_actionCollectionView.CurrentItem == null) return null;

                return (Models.Action)_actionCollectionView.CurrentItem;

            }
        }

        public Models.Utilisateur Resp1Selected
        {
            get
            {
                if (_utilisateurCollectionView1 == null) return null;
                if (_utilisateurCollectionView1.CurrentItem == null) return null;

                return (Models.Utilisateur)_utilisateurCollectionView1.CurrentItem;

            }
        }

        public Models.Utilisateur Resp2Selected
        {
            get
            {
                if (_utilisateurCollectionView2 == null) return null;
                if (_utilisateurCollectionView2.CurrentItem == null) return null;

                return (Models.Utilisateur)_utilisateurCollectionView2.CurrentItem;

            }
        }



        public void OnCollectionViewImportanceCurrentChanged(object sender, EventArgs e)
        {
            NotifyPropertyChanged("ImportanceSelected");
        }

        public void OnCollectionViewFamilleCurrentChanged(object sender, EventArgs e)
        {
            NotifyPropertyChanged("FamilleSelected");
        }

        public void OnCollectionViewSiteCurrentChanged(object sender, EventArgs e)
        {
            NotifyPropertyChanged("SiteSelected");
        }

        public void OnCollectionViewQuestionnaireCurrentChanged(object sender, EventArgs e)
        {
            NotifyPropertyChanged("QuestionnaireSelected");
        }

        public void OnCollectionViewActionCurrentChanged(object sender, EventArgs e)
        {
            NotifyPropertyChanged("ActionSelected");
        }

        public void OnCollectionViewResp1CurrentChanged(object sender, EventArgs e)
        {
            NotifyPropertyChanged("Resp1Selected");
        }

        public void OnCollectionViewResp2CurrentChanged(object sender, EventArgs e)
        {
            NotifyPropertyChanged("Resp2Selected");
        }

        public Models.Action Action
        {
            get
            {
                return _action;
            }
        }

        

        public ObservableCollection<Models.Importance> Importances
        {
            get
            {
                return _ListeImportances;
            }
            
            
        }

        public ObservableCollection<Models.Famille> Familles
        {
            get
            {
                return _ListeFamilles;
            }


        }

        public ObservableCollection<Models.Site> Sites
        {
            get
            {
                return _ListeSites;
            }


        }


        public ObservableCollection<Models.Questionnaire> Questionnaires
        {
            get
            {
                return _ListeQuestionnaires;
            }


        }

        public ObservableCollection<Models.Action> Actions
        {
            get
            {
                return _ListeActions;
            }


        }


        public ObservableCollection<Models.Utilisateur> Resp1
        {
            get
            {
                return _ListeUtilisateurs1;
            }


        }

        public ObservableCollection<Models.Utilisateur> Resp2
        {
            get
            {
                return _ListeUtilisateurs2;
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

      




    }
}
