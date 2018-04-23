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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //using (Models.pyrenactionEntities context = new Models.pyrenactionEntities())
            //{
            //    Models.Utilisateur user = new Models.Utilisateur();
            //    user.nom = "Chaigneau";
            //    user.prenom = "Gautier";
            //    user.email = "gautier.chaigneau@gmail.com";
            //    user.qse = true;
            //    user.tel = "0562356879";
            //    user.mdp = "toto";

            //    context.Utilisateur.Add(user);
            //    context.SaveChanges();

            //}

        }
    }
}
