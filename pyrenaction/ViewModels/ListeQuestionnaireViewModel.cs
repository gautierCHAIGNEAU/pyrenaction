using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pyrenaction.ViewModels
{
    class ListeQuestionnaireViewModel : ViewModelBase
    {
        private List<Models.Action> _listeActions;
        private Models.pyrenactionEntities _context;

        public ListeQuestionnaireViewModel()
        {
            _context = new Models.pyrenactionEntities();
            _listeActions = new List<Models.Action>();
            var query = from U in _context.Actions select U;
            _listeActions = query.ToList();

        }

        public List<Models.Action> ListeActions
        {
            get
            {
                return _listeActions;
            }
        }
    }
}
