using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pyrenaction.Views
{
    /// <summary>
    /// Logique d'interaction pour ucTabBord.xaml
    /// </summary>
    public partial class ucTabBord : Grid
    {
        public event EventHandler DoubleClick;
        public ucTabBord()
        {
            InitializeComponent();

            using (Models.pyrenactionEntities context = new Models.pyrenactionEntities())
            {


                var query = from U in context.Actions select U;
                List<Models.Action> listeActions = query.ToList();
                List<ligneTab> listeLigne = new List<ligneTab>();

                foreach (Models.Action lAction in listeActions)
                {
                    // Nom du site 
                    var site = context.Sites.Find(lAction.id_Site);
                    String nom_Site = site.nom;

                    // Niveau d'importance
                    var importance = context.Importances.Find(lAction.id_Importance);
                    String type_Importance = importance.nom;

                    // Famille
                    var famille = context.Familles.Find(lAction.id_Famille);
                    String type_Famille = famille.nom;

                    // Questionnaire
                    var questionnaire = context.Questionnaires.Find(lAction.id_Questionnaire);
                    String _questionnaire = "";
                    try
                    {
                        _questionnaire = questionnaire.nom;
                    }
                    catch (System.NullReferenceException)
                    {
                        _questionnaire = "N/A";
                    };

                    // Présence d'une tache rattachée
                    var id1 = context.Actions.Find(lAction.id_1);
                    String presence_id1 = "";
                    try
                    {
                        presence_id1 = id1.description;
                    }
                    catch (System.NullReferenceException)
                    {
                        presence_id1 = "N/A";
                    };

                    // Utilisateur 1 : Responsable
                    var utilisateur1 = context.Utilisateurs.Find(lAction.id_Utilisateur);
                    String responsable = utilisateur1.nom;

                    // Utilisateur 2 : Exécutant
                    var utilisateur2 = context.Utilisateurs.Find(lAction.id_Utilisateur_2);
                    String executant = "";
                    try // Si présence d'un Utilisateur 2, on recherche son nom
                    {
                        executant = utilisateur2.nom;
                    }
                    catch (System.NullReferenceException)  //Sinon on le met en "N/A"
                    {
                        executant = "N/A";
                    };

					// Date de création de la tache
                    var date_Action = lAction.date_a;
					// Date de deadline
                    var delais = lAction.delais;
					// Description de la tâche
                    String description = lAction.description;
					// Source de la création de la tâche
                    String source = lAction.source;
					// Analyse de la tache
                    String analyse = lAction.analyse;
					// Statut de la tâche (vrai/faux -> terminée/en cours)
                    var statut = lAction.statut;
					// ID de l'action
                    int id_Action = lAction.id;

					// Création de la ligne du tableau (visuellement parlant)
                    ligneTab maLigne = new ligneTab();
                    maLigne.id = id_Action;
					
					// Affichage de la date de création au format français "jj/mm/aaaa" ou "N/A" si pas de date
                    if (date_Action != null)
                        maLigne.date1 = ((DateTime)date_Action).ToShortDateString().ToString(System.Globalization.CultureInfo.CreateSpecificCulture("fr-FR"));
                    else
                        maLigne.date1 = "N/A";

					// Affichage de la date dead-line au format français "jj/mm/aaaa" ou "N/A" si pas de date
                    if (delais != null)
                        maLigne.date2 = ((DateTime) delais).ToShortDateString().ToString(System.Globalization.CultureInfo.CreateSpecificCulture("fr-FR"));
                    else
                        maLigne.date2 = "N/A";

					
                    maLigne.source = source;
                    maLigne.analyse = analyse;
                    maLigne.description = description;
					
					// Formatage du statut : true/false -> terminée/en cours
                    if (statut != null)
                        maLigne.statut = ((Boolean)statut ? "Terminée" : "En cours");
                    else
                        maLigne.statut = "";

                    maLigne.importance = type_Importance;
                    maLigne.famille = type_Famille;
                    maLigne.site = nom_Site;
                    maLigne.questionnaire = _questionnaire;
                    maLigne.parente = presence_id1;
                    maLigne.utilisateur1 = responsable;
                    maLigne.utilisateur2 = executant;
                    maLigne.pourcentage = 0;

					// Liste de tâches rattachées
                    ObservableCollection<Models.Tache> theListe = new ObservableCollection<Models.Tache>();


                    int nbTaches = lAction.Taches.Count;
                    int nbTachesFinies = 0;

                    foreach (Models.Tache _tch in lAction.Taches)
                    {
                        if (_tch.statut == true) // Incrément du nb de taches soldées
                            nbTachesFinies++;
                    }

					
					// Calcul du pourcentage d'avancement de la tache
                    if (nbTachesFinies > 0 && nbTaches > 0)
                        maLigne.pourcentage = (nbTachesFinies * 100) / nbTaches;
                    else
                        maLigne.pourcentage = 0;



                    foreach (Models.Tache _tch in lAction.Taches) // Ajout des tâches dans la liste destinée à remplir le tableau
                    {
                        theListe.Add(_tch);
                    }
                    
                    maLigne.taches = theListe;


                    ObservableCollection<Models.Lien> theListeLien = new ObservableCollection<Models.Lien>(); // Liste des liens rattachés à l'action

                    foreach (Models.Lien _tch in lAction.Liens)
                    {
                        theListeLien.Add(_tch);
                    }

                    maLigne.liens = theListeLien;

                    listeLigne.Add(maLigne);

                }

                myDashboard.ItemsSource = listeLigne; // Remplissage du tableau via binding de listeLigne


            }


        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)  // Méthode permettant l'ouverture d'un navigateur lors d'un "clic-lien"
        {
            System.Diagnostics.Process.Start(e.Uri.ToString());
        }

        public class ligneTab  // Classe "binding" dédiée à l'affichage des données dans le tableau 
        {
            public int id { get; set; }

            public String date1 { get; set; }
            public String date2 { get; set; }

            public String source { get; set; }
            public String analyse { get; set; }
            public String description { get; set; }
            public String statut { get; set; }
            public String importance { get; set; }
            public String famille { get; set; }
            public String site { get; set; }
            public String questionnaire { get; set; }
            public String parente { get; set; }
            public String utilisateur1 { get; set; }
            public String utilisateur2 { get; set; }
            public float pourcentage { get; set; }
           public ObservableCollection<Models.Tache> taches { get; set; }
            public ObservableCollection<Models.Lien> liens { get; set; }

        }

        private void myDashboard_MouseDoubleClick(object sender, MouseButtonEventArgs e) // Méthode permettant l'ouverture de la page d'édition lors d'un "doubleclick-tache"
        {
            
            DoubleClick(this, EventArgs.Empty);
        }

        
    }
}