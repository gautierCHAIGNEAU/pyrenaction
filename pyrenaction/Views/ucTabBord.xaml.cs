using System;
using System.Collections.Generic;
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
                    String presence_Questionnaire = "";
                    try
                    {
                        presence_Questionnaire = questionnaire.ToString();
                    }
                    catch (System.NullReferenceException)
                    {
                        presence_Questionnaire = "N/A";
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
                    var etat = lAction.statut;
                    int id_Action = lAction.id;




<<<<<<< HEAD
                    
=======
>>>>>>> 969dabadf76f412e83733f120d6e475e76fb521d
                }
                




            }

        }

    }
}
