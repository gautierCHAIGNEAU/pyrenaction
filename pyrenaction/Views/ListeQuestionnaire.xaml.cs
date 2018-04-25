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
        public ListeQuestionnaire()
        {
            InitializeComponent();
            _listeQuestionnaireController = new ListeQuestionnaireViewModel(new Models.Action());

            this.DataContext = _listeQuestionnaireController;
        }
    }
}
