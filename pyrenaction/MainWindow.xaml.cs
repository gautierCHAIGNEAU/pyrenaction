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
                //Models.Utilisateur user = new Models.Utilisateur();
                //user.nom = "Chaigneau";
                //user.prenom = "Gautier";
                //user.email = "gautier.chaigneau@gmail.com";
                //user.qse = true;
                //user.tel = "0562356879";
                //user.mdp = "toto";

                //context.Utilisateur.Add(user);
                //context.SaveChanges();

                //var query = from U in context.Utilisateur select U;
                //List<Models.Utilisateur> listeUsers = query.ToList();

                //context.Utilisateur.Remove(listeUsers.Last());
                //context.SaveChanges();

            }

            

        }

        public void NouvelleAction(object sender, RoutedEventArgs e)
        {
            _actionView = new Views.Action();
            _actionView.Valider += ValiderAction;
            textControl.Content = _actionView;
        }

        private void ValiderAction(object sender, EventArgs e)
        {
            _actionView = null;
            _tabBordView = new Views.ucTabBord();

            textControl.Content = _tabBordView;
        }

        private void TabDoubleClick(object sender, EventArgs e)
        {
            Views.ucTabBord tabBord = (Views.ucTabBord)sender;
            DataGrid myDashboard = tabBord.myDashboard;
            TextBlock tb = myDashboard.Columns[0].GetCellContent(myDashboard.Items[myDashboard.SelectedIndex]) as TextBlock;
            String id = tb.Text;


            _actionView = new Views.Action(Int32.Parse(id));
            _actionView.Valider += ValiderAction;
            textControl.Content = _actionView;
        }
    }
}
