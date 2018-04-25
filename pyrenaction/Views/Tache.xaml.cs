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
    /// Interaction logic for Tache.xaml
    /// </summary>
    public partial class Tache : Grid
    {
        public event EventHandler ValiderTache;
        private ViewModels.TacheViewModel _tacheController;
        public Tache()
        {
            InitializeComponent();
            _tacheController = new ViewModels.TacheViewModel(new Models.Tache());
            this.DataContext = _tacheController;
        }

        public Tache(Models.Tache tache)
        {
            InitializeComponent();
            _tacheController = new ViewModels.TacheViewModel(tache);
            this.DataContext = _tacheController;
        }

        private void buttonValider_Click(object sender, RoutedEventArgs e)
        {
            ValiderTache(this, EventArgs.Empty);
        }

        public Models.Tache getTache()
        {
            return _tacheController.Tache;
        }
    }
}
