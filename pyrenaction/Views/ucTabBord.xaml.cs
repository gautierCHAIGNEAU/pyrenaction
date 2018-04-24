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

<<<<<<< HEAD
                dataGrid.ItemsSource = listeActions;
=======
                foreach (Models.Action lAction in listeActions)
                {
                    // Nom du site 
                    var site = context.Sites.Find(lAction.id_Site);
                    String nom_Site = site.nom;

                    // Niveau d'importance
                    var importance = context.Importances.Find(lAction.id_Importance);
                    String type_Importance = importance.nom;

                    // Niveau d'importance
                    var famille = context.Familles.Find(lAction.id_Famille);
                    String type_Famille = famille.nom;

                    // Niveau d'importance
                    var questionnaire = context.Familles.Find(lAction.id_Questionnaire);
                    String presence_Questionnaire = "";
                    try
                    {
                        presence_Questionnaire = questionnaire.nom;
                    }
                    catch (System.NullReferenceException)
                    {
                        presence_Questionnaire = "N/A";
                    };
                       



                    //lAction.id_Site
                }
                //dataGrid.ItemsSource = listeActions;




>>>>>>> 58ca2b6935a037f1f39188e9b6a6b19a6f1390b1
            }

        }

    }
}
