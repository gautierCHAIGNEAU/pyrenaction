using pyrenaction.ViewModels;
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
    /// Interaction logic for Questionnaire.xaml
    /// </summary>
    public partial class Questionnaire : Grid
    {
        private QuestionnaireViewModel _questionnaireController;
        public event EventHandler validerQuest;
        public int actAssoc;
        public int points;
        public Questionnaire(int idAction)
        {
            InitializeComponent();
            actAssoc = idAction;
           
            using (Models.pyrenactionEntities context = new Models.pyrenactionEntities())
            {

                Models.Action action = (from A in context.Actions where A.id == idAction select A).FirstOrDefault();

                if(action != null)
                {
                    _questionnaireController = new QuestionnaireViewModel(action.Questionnaire);
                    this.DataContext = _questionnaireController;

                    var query = from Q in context.Questions where Q.id_Questionnaire == action.Questionnaire.id select Q;
                    List<Models.Question> listeQuestions = query.ToList();

                    //Questions
                    textBlock1.Text = listeQuestions[0].intitule;
                    textBlock2.Text = listeQuestions[1].intitule;
                    textBlock3.Text = listeQuestions[2].intitule;
                    textBlock4.Text = listeQuestions[3].intitule;
                    textBlock5.Text = listeQuestions[4].intitule;

                    //Réponses
                    inputQ1.IsChecked = listeQuestions[0].reponse;
                    inputQ2.IsChecked = listeQuestions[1].reponse;
                    inputQ3.IsChecked = listeQuestions[2].reponse;
                    inputQ4.IsChecked = listeQuestions[3].reponse;
                    inputQ5.IsChecked = listeQuestions[4].reponse;


                }
                
            }

        }

        private void ValiderQuestionnaire(object sender, RoutedEventArgs e)
        {
            points = 0;
            if(inputQ1.IsChecked == true)
            {
                points += 3;
            }
            else
            {
                points += 1;
            }
          
            if (inputQ2.IsChecked == true)
            {
                points += 3;
            }
            else
            {
                points += 1;
            }
           
            if (inputQ3.IsChecked == true)
            {
                points += 3;
            }
            else
            {
                points += 1;
            }
         
            if (inputQ4.IsChecked == true)
            {
                points += 1;
            }
            else
            {
                points += 3;
            }
           
            if (inputQ5.IsChecked == true)
            {
                points += 1;
            }
            else
            {
                points += 3;
            }
        
            _questionnaireController.ValiderQuestionnaire(actAssoc, points);
            validerQuest(this, EventArgs.Empty);
        }

    }
}
