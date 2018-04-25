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

namespace pyrenaction
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IndexViewModel _indexController;
        private Views.Action _actionView;
        private Views.ucTabBord _tabBordView;
        private Views.ListeQuestionnaire _listeQuestView;
        private Views.Questionnaire _questView;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _indexController = new IndexViewModel();

            using (Models.pyrenactionEntities context = new Models.pyrenactionEntities())
            {
                _tabBordView = new Views.ucTabBord();
                _tabBordView.DoubleClick += TabDoubleClick;
                textControl.Content = _tabBordView;


            }

            

        }

        public void NouvelleAction(object sender, RoutedEventArgs e)
        {
            _actionView = new Views.Action();
            _actionView.Valider += ValiderAction;
            textControl.Content = _actionView;
            _listeQuestView = null;
            _tabBordView = null;
        }

        public void Questionnaires(object sender, RoutedEventArgs e)
        {
            _listeQuestView = new Views.ListeQuestionnaire();
            _listeQuestView.afficherQuest += AfficherQuest;
            textControl.Content = _listeQuestView;
            _actionView = null;
            _tabBordView = null;
        }

        public void Index(object sender, RoutedEventArgs e)
        {
            _tabBordView = new Views.ucTabBord();
            _tabBordView.DoubleClick += TabDoubleClick;
            textControl.Content = _tabBordView;
        }

        private void ValiderAction(object sender, EventArgs e)
        {
            _actionView = null;
            _tabBordView = new Views.ucTabBord();
            _tabBordView.DoubleClick += TabDoubleClick;
            textControl.Content = _tabBordView;
        }

        private void AfficherQuest(object sender, EventArgs e)
        {
            Views.ListeQuestionnaire listeQuest = (Views.ListeQuestionnaire)sender;

            _questView = new Views.Questionnaire(listeQuest.idActionAssociee);
            _questView.validerQuest += ValiderQuestionnaire;
            textControl.Content = _questView;
            _listeQuestView = null;
        }

        private void ValiderQuestionnaire(object sender, EventArgs e)
        {
            _questView = null;
            _tabBordView = new Views.ucTabBord();
            _tabBordView.DoubleClick += TabDoubleClick;
            textControl.Content = _tabBordView;
        }

        private void TabDoubleClick(object sender, EventArgs e)
        {
            Views.ucTabBord tabBord = (Views.ucTabBord)sender;
            DataGrid myDashboard = tabBord.myDashboard;
            if(myDashboard.SelectedIndex > -1)
            {
                TextBlock tb = myDashboard.Columns[0].GetCellContent(myDashboard.Items[myDashboard.SelectedIndex]) as TextBlock;
                String id = tb.Text;


                _actionView = new Views.Action(Int32.Parse(id));
                _actionView.Valider += ValiderAction;
                textControl.Content = _actionView;

                _tabBordView = null;
            }
            
        }
    }
}
