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
    /// Interaction logic for ListeQuestionnaire.xaml
    /// </summary>
    public partial class ListeQuestionnaire : Grid
    {
        public event EventHandler afficherQuest;
        private ViewModels.ListeQuestionnaireViewModel _listeQuestController;
        public int idActionAssociee;
        public ListeQuestionnaire()
        {
            InitializeComponent();
            _listeQuestController = new ViewModels.ListeQuestionnaireViewModel();
            dataGrid.ItemsSource = _listeQuestController.ListeActions;
        }

        private void AfficherQuestionnaire(object sender, RoutedEventArgs e)
        {

            TextBlock tb = dataGrid.Columns[0].GetCellContent(dataGrid.Items[dataGrid.SelectedIndex]) as TextBlock;
            String id = tb.Text;
            idActionAssociee = Int32.Parse(id);
            afficherQuest(this, EventArgs.Empty);
        }
    }
}
