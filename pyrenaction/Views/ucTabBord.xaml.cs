using System;
using System.Collections.Generic;
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

                    // Présence id1
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

                    // Utilisateur 1
                    var utilisateur1 = context.Utilisateurs.Find(lAction.id_Utilisateur);
                    String responsable = utilisateur1.nom;

                    // Utilisateur 2
                    var utilisateur2 = context.Utilisateurs.Find(lAction.id_Utilisateur_2);
                    String executant = "";
                    try
                    {
                        executant = utilisateur2.nom;
                    }
                    catch (System.NullReferenceException)
                    {
                        executant = "N/A";
                    };

                    var date_Action = lAction.date_a;
                    var delais = lAction.delais;
                    String description = lAction.description;
                    String source = lAction.source;
                    String analyse = lAction.analyse;
                    var statut = lAction.statut;
                    int id_Action = lAction.id;


                    ligneTab maLigne = new ligneTab();
                    maLigne.id = id_Action;

                    if (date_Action != null)
                        maLigne.date1 = ((DateTime)date_Action).ToShortDateString().ToString(System.Globalization.CultureInfo.CreateSpecificCulture("fr-FR"));
                    else
                        maLigne.date1 = "N/A";

                    if (delais != null)
                        maLigne.date2 = ((DateTime) delais).ToShortDateString().ToString(System.Globalization.CultureInfo.CreateSpecificCulture("fr-FR"));
                    else
                        maLigne.date2 = "N/A";

                    maLigne.source = source;
                    maLigne.analyse = analyse;
                    maLigne.description = description;
                    maLigne.statut = (Boolean)statut;
                    maLigne.importance = type_Importance;
                    maLigne.famille = type_Famille;
                    maLigne.site = nom_Site;
                    maLigne.questionnaire = _questionnaire;
                    maLigne.parente = presence_id1;
                    maLigne.utilisateur1 = responsable;
                    maLigne.utilisateur2 = executant;
                    maLigne.pourcentage = 0;

                    listeLigne.Add(maLigne);

                }

                myDashboard.ItemsSource = listeLigne;


            }


        }

        public class ligneTab
        {
            public int id { get; set; }

            public String date1 { get; set; }
            public String date2 { get; set; }

            public String source { get; set; }
            public String analyse { get; set; }
            public String description { get; set; }
            public Boolean statut { get; set; }
            public String importance { get; set; }
            public String famille { get; set; }
            public String site { get; set; }
            public String questionnaire { get; set; }
            public String parente { get; set; }
            public String utilisateur1 { get; set; }
            public String utilisateur2 { get; set; }
            public int pourcentage { get; set; }

        }

    }
}