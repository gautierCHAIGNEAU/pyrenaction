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
        private IndexViewModel indexController;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            indexController = new IndexViewModel();


            using (Models.pyrenactionEntities context = new Models.pyrenactionEntities())
            {
                Views.ucTabBord tabBordView = new Views.ucTabBord();
                textControl.Content = tabBordView;
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
            Views.Action actionView = new Views.Action();
            textControl.Content = actionView;
        }
    }
}
