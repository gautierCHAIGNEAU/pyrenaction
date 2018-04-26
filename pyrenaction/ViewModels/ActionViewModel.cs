using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Net.Mail;

namespace pyrenaction.ViewModels
{
    class ActionViewModel : ViewModelBase
    {
        private Models.Action _action;
        private Models.pyrenactionEntities _context;
        private ObservableCollection<Models.Importance> _ListeImportances;
        private  ICollectionView _importanceCollectionView;

        private ObservableCollection<Models.Famille> _ListeFamilles;
        private  ICollectionView _familleCollectionView;

        private ObservableCollection<Models.Site> _ListeSites;
        private  ICollectionView _siteCollectionView;

        private ObservableCollection<Models.Questionnaire> _ListeQuestionnaires;
        private  ICollectionView _questionnaireCollectionView;

        private ObservableCollection<Models.Action> _ListeActions;
        private  ICollectionView _actionCollectionView;

        private ObservableCollection<Models.Utilisateur> _ListeUtilisateurs1;
        private  ICollectionView _utilisateurCollectionView1;

        private ObservableCollection<Models.Utilisateur> _ListeUtilisateurs2;
        private  ICollectionView _utilisateurCollectionView2;

        private ObservableCollection<Models.Tache> _ListeTaches;
        private  ICollectionView _tacheCollectionView;

        private ObservableCollection<Models.Lien> _ListeLiens;
        private ICollectionView _lienCollectionView;

        public void Valider()
        {
            _action.Importance = ImportanceSelected;
            _action.Famille = FamilleSelected;
            _action.Site = SiteSelected;
            _action.Questionnaire = QuestionnaireSelected;
            if(ActionSelected.description == "Aucune")
            {
                _action.Action2 = null;

            }
            else
            {
                _action.Action2 = ActionSelected;

            }
            
            _action.Utilisateur = Resp1Selected;
            _action.Utilisateur1 = Resp2Selected;
            _action.statut = false;
            _action.Taches = (ICollection<Models.Tache>)_ListeTaches;
            int nbreTaches = _action.Taches.Count;
            int nbreTachesFinish = 0;
            foreach(Models.Tache t in _action.Taches)
            {
                if(t.statut == true)
                {
                    nbreTachesFinish++;
                }
            }
            if(nbreTachesFinish == nbreTaches && nbreTaches > 0)
            {
                
                    var queryDest = from U in _context.Utilisateurs where U.id == _action.Utilisateur1.id select U;
                    Models.Utilisateur Dest = queryDest.FirstOrDefault();
                    try
                    {
                        String objet = "PYRENACTION: Action terminée, questionnaire à remplir.";
                        String contenu = "Toutes les tâches de l'action: \n" + _action.description + "\n\n ont étés validées. Merci de vous connecter à l'application pour répondre au questionnaire";
                        MailMessage mail = new MailMessage("pyrenaction@gmail.com", Dest.email, objet, contenu);
                        SmtpClient stpc = new SmtpClient("smtp.gmail.com", 587);
                        stpc.Credentials = new System.Net.NetworkCredential("pyrenaction@gmail.com", "Cesi1234%");
                        stpc.EnableSsl = true;
                        stpc.Send(mail);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("L'email n'a pu être envoyé : {0}.", ex.Message);
                    }
                
            }

            _action.Liens = (ICollection<Models.Lien>)_ListeLiens;
            Models.Action testExist = (from T in _context.Actions where T.id == _action.id select T).FirstOrDefault();

            if(testExist == null)
            {
                _context.Actions.Add(_action);
            }
            
            _context.SaveChanges();
        }

        public ActionViewModel(int id)
        {
            _context = new Models.pyrenactionEntities();
            var query = from U in _context.Actions select U;
            List<Models.Action> listeActions = query.ToList();
            bool find = false;
            foreach (Models.Action act in listeActions)
            {
                if(act.id == id)
                {
                    _action = act;
                    find = true;
                }
            }

            if(find == false)
            {
                _action = new Models.Action();
            }
            loadFields();
        }
        public ActionViewModel(Models.Action action)
        {
            _action = action;
            _action.statut = false;
            _context = new Models.pyrenactionEntities();
            loadFields();
        }

        private void loadFields()
        {
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
            if(_action.Importance != null)
            {
                Models.Importance imp = _action.Importance;
                _importanceCollectionView.MoveCurrentTo(imp);
                NotifyPropertyChanged("Importances");
            }


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
            if (_action.Famille != null)
            {
                Models.Famille fam = _action.Famille;
                _familleCollectionView.MoveCurrentTo(fam);
                NotifyPropertyChanged("Familles");
            }




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
            if (_action.Site != null)
            {
                Models.Site site = _action.Site;
                _siteCollectionView.MoveCurrentTo(site);
                NotifyPropertyChanged("Sites");
            }



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
            if (_action.Questionnaire != null)
            {
                Models.Questionnaire quest = _action.Questionnaire;
                _questionnaireCollectionView.MoveCurrentTo(quest);
                NotifyPropertyChanged("Questionnaires");
            }




            _ListeActions = new ObservableCollection<Models.Action>();
            var queryAct = from U in _context.Actions select U;
            List<Models.Action> listeActions = queryAct.ToList();
            foreach (Models.Action act in listeActions)
            {
                _ListeActions.Add(act);
            }
            Models.Action actNull = new Models.Action();
            actNull.description = "Aucune";
            _ListeActions.Add(actNull);
            
            //définition de la collection view
            _actionCollectionView = CollectionViewSource.GetDefaultView(_ListeActions);

            if (_actionCollectionView == null)
            {
                throw new NullReferenceException("_actionCollectionView");
            }

            //ajout de l'événement à déclencher quand la vue courante change
            _actionCollectionView.CurrentChanged += OnCollectionViewActionCurrentChanged;
            if (_action.Action2 != null)
            {
                Models.Action act = _action.Action2;
                _actionCollectionView.MoveCurrentTo(act);
                NotifyPropertyChanged("Actions");
            }
            else
            {
                _actionCollectionView.MoveCurrentTo(actNull);
                NotifyPropertyChanged("Actions");
            }



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
            if (_action.Utilisateur != null)
            {
                Models.Utilisateur ut1 = _action.Utilisateur;
                _utilisateurCollectionView1.MoveCurrentTo(ut1);
                NotifyPropertyChanged("Resp1");
            }



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
            if (_action.Utilisateur1 != null)
            {
                Models.Utilisateur ut2 = _action.Utilisateur1;
                _utilisateurCollectionView2.MoveCurrentTo(ut2);
                NotifyPropertyChanged("Resp2");
            }



            _ListeTaches = new ObservableCollection<Models.Tache>();
            var queryTach = from U in _context.Taches select U;
            List<Models.Tache> listeTach = queryTach.ToList();
            foreach (Models.Tache t in listeTach)
            {
                if (t.id_Action == _action.id)
                {
                    _ListeTaches.Add(t);
                }

            }

            //définition de la collection view
            _tacheCollectionView = CollectionViewSource.GetDefaultView(_ListeTaches);

            if (_tacheCollectionView == null)
            {
                throw new NullReferenceException("_tacheCollectionView");
            }

            //ajout de l'événement à déclencher quand la vue courante change
            _tacheCollectionView.CurrentChanged += OnCollectionViewTacheCurrentChanged;




            _ListeLiens = new ObservableCollection<Models.Lien>();
            var queryLiens = from U in _context.Liens select U;
            List<Models.Lien> listeLiens = queryLiens.ToList();
            foreach (Models.Lien l in listeLiens)
            {
                if (l.id_Action == _action.id)
                {
                    _ListeLiens.Add(l);
                }

            }

            //définition de la collection view
            _lienCollectionView = CollectionViewSource.GetDefaultView(_ListeLiens);

            if (_lienCollectionView == null)
            {
                throw new NullReferenceException("_lienCollectionView");
            }

            //ajout de l'événement à déclencher quand la vue courante change
            _lienCollectionView.CurrentChanged += OnCollectionViewLienCurrentChanged;
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

        public Models.Tache TacheSelected
        {
            get
            {
                if (_tacheCollectionView == null) return null;
                if (_tacheCollectionView.CurrentItem == null) return null;

                return (Models.Tache)_tacheCollectionView.CurrentItem;

            }
        }


        public Models.Lien LienSelected
        {
            get
            {
                if (_lienCollectionView == null) return null;
                if (_lienCollectionView.CurrentItem == null) return null;

                return (Models.Lien)_lienCollectionView.CurrentItem;

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

        public void OnCollectionViewTacheCurrentChanged(object sender, EventArgs e)
        {
            NotifyPropertyChanged("TacheSelected");
        }

        public void OnCollectionViewLienCurrentChanged(object sender, EventArgs e)
        {
            NotifyPropertyChanged("LienSelected");
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

        public ObservableCollection<Models.Tache> Taches
        {
            get
            {
                return _ListeTaches;
            }


        }

        public ObservableCollection<Models.Lien> Liens
        {
            get
            {
                return _ListeLiens;
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

      
        public void ValiderTache(Models.Tache tache)
        {
            if (_ListeTaches.Contains(tache) == false)
            {
                _ListeTaches.Add(tache);
            }
            else
            {
                _ListeTaches.Remove(tache);
                _ListeTaches.Add(tache);
            }
            
            NotifyPropertyChanged("Taches");
            _tacheCollectionView.MoveCurrentToLast();
        }

        public void SupprimerTache()
        {
            Models.Tache tache = TacheSelected;

            Models.Tache testExist = (from T in _context.Taches where T.id == tache.id select T).FirstOrDefault();

            if(testExist != null)
            {
                _context.Taches.Remove(tache);
                _context.SaveChanges();
            }
            
            _ListeTaches.Remove(tache);
            NotifyPropertyChanged("Taches");
        }



        public void ValiderLien(Models.Lien lien)
        {
            if (_ListeLiens.Contains(lien) == false)
            {
                _ListeLiens.Add(lien);
            }
            else
            {
                _ListeLiens.Remove(lien);
                _ListeLiens.Add(lien);
            }

            NotifyPropertyChanged("Liens");
            _lienCollectionView.MoveCurrentToLast();
        }

        public void SupprimerLien()
        {
            Models.Lien lien = LienSelected;

            Models.Lien testExist = (from T in _context.Liens where T.id == lien.id select T).FirstOrDefault();

            if (testExist != null)
            {
                _context.Liens.Remove(lien);
                _context.SaveChanges();
            }

            _ListeLiens.Remove(lien);
            NotifyPropertyChanged("Liens");
        }



    }
}
