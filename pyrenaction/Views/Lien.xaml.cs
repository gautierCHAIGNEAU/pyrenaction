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
    /// Logique d'interaction pour Lien.xaml
    /// </summary>
    public partial class Lien : Grid
    {
  

        public event EventHandler ValiderLien;
        private ViewModels.LienViewModel _lienController;

        public Lien()
        {
            InitializeComponent();
            _lienController = new ViewModels.LienViewModel(new Models.Lien());
            this.DataContext = _lienController;
        }

        //Constructeur pour modifier un lien
        public Lien(Models.Lien lien)
        {
            InitializeComponent();
            _lienController = new ViewModels.LienViewModel(lien);
            this.DataContext = _lienController;
        }

        private void buttonValider_Click(object sender, RoutedEventArgs e)
        {
            ValiderLien(this, EventArgs.Empty);
        }

        public Models.Lien getLien()
        {
            return _lienController.Lien;
        }
    }
}
