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
        
        public Action()
        {
            InitializeComponent();
            _actionController = new ActionViewModel(new Models.Action());

            this.DataContext = _actionController;
        }

        private void Submit(object sender, RoutedEventArgs e)
        {
            _actionController.Valider();
        }

        private void AjouterTache(object sender, RoutedEventArgs e)
        {
            Views.Tache tacheView = new Views.Tache();
            tacheControl.Content = tacheView;
        }

        private void SupprimerTache(object sender, RoutedEventArgs e)
        {
            
        }

    }
}
