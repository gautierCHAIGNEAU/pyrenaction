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

        public Questionnaire()
        {
            InitializeComponent();
            Models.Questionnaire quest = new Models.Questionnaire();
            var idQuestionnaire = 1;
            using (Models.pyrenactionEntities context = new Models.pyrenactionEntities())
            {
                var queryQuest = from Q in context.Questionnaires where Q.id == idQuestionnaire select Q;
                Models.Questionnaire Quest = queryQuest.FirstOrDefault();
                quest.nom = Quest.nom;

            }
            _questionnaireController = new QuestionnaireViewModel(quest);
            this.DataContext = _questionnaireController;
            using (Models.pyrenactionEntities context = new Models.pyrenactionEntities())
            {
                var query = from Q in context.Questions where Q.id_Questionnaire == idQuestionnaire select Q;
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

                //Commentaires
                inputComm1.Text = listeQuestions[0].commentaire;
                inputComm2.Text = listeQuestions[1].commentaire;
                inputComm3.Text = listeQuestions[2].commentaire;
                inputComm4.Text = listeQuestions[3].commentaire;
                inputComm5.Text = listeQuestions[4].commentaire;
            }

        }

        private void ValiderQuestionnaire(object sender, RoutedEventArgs e)
        {
            
        }

    }
}
