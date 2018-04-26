using pyrenaction.ViewModels;
using pyrenaction.Models;
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
    /// Interaction logic for Action.xaml
    /// </summary>
    public partial class Action : Grid
    {
        private ActionViewModel _actionController;
        private Views.Tache _tacheView;
        private Views.Lien _lienView;
        public event EventHandler Valider;
        public Action()
        {
            InitializeComponent();
            _actionController = new ActionViewModel(new Models.Action());

            this.DataContext = _actionController;
        }

        //Constructeur quand on a double cliquer sur le tablea de bord, on récupère l'id de l'action associée pour la modifier
        public Action(int id)
        {
            InitializeComponent();
            _actionController = new ActionViewModel(id);

            this.DataContext = _actionController;
        }


        //Valider l'action (ajouter/modifier)
        private void Submit(object sender, RoutedEventArgs e)
        {
            _actionController.Valider();
            Valider(this, EventArgs.Empty);

        }

        //Affichage de la vue Gestion de tâche dans la fenetre Action
        private void AjouterTache(object sender, RoutedEventArgs e)
        {
            _tacheView = new Views.Tache();
            _tacheView.ValiderTache += ValTache;
            tacheControl.Content = _tacheView;
        }

        //Affichage de la vue Gestion de tâche dans la fenetre Action
        private void ModifierTache(object sender, RoutedEventArgs e)
        {
            _tacheView = new Views.Tache(_actionController.TacheSelected);
            _tacheView.ValiderTache += ValTache;
            tacheControl.Content = _tacheView;
        }

        private void SupprimerTache(object sender, RoutedEventArgs e)
        {
            _actionController.SupprimerTache();
        }

        //Valider une tache (ajouter/modifier)
        private void ValTache(object sender, EventArgs e)
        {
            _actionController.ValiderTache(_tacheView.getTache());
            _tacheView = null;
            tacheControl.Content = null;
        }






        //Affichage de la vue Gestion de lien dans la fenetre Action
        private void AjouterLien(object sender, RoutedEventArgs e)
        {
            _lienView = new Views.Lien();
            _lienView.ValiderLien += ValLien;
            tacheControl.Content = _lienView;
        }

        //Affichage de la vue Gestion de lien dans la fenetre Action
        private void ModifierLien(object sender, RoutedEventArgs e)
        {
            _lienView = new Views.Lien(_actionController.LienSelected);
            _lienView.ValiderLien += ValLien;
            tacheControl.Content = _lienView;
        }

        private void SupprimerLien(object sender, RoutedEventArgs e)
        {
            _actionController.SupprimerLien();
        }


        //Valider un lien (ajouter/modifier)
        private void ValLien(object sender, EventArgs e)
        {
            _actionController.ValiderLien(_lienView.getLien());
            _tacheView = null;
            tacheControl.Content = null;
        }


    }
}
