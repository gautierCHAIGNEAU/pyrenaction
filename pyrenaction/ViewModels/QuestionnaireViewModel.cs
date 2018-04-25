using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pyrenaction.ViewModels
{
    class QuestionnaireViewModel
    {
        private Models.Questionnaire _questionnaire;
        private Models.Action _action;
        private Models.pyrenactionEntities _context;

        public void Valider()
        {
            _context.SaveChanges();
        }

        public QuestionnaireViewModel(Models.Questionnaire questionnaire)//, Models.Action action
        {
            _questionnaire = questionnaire;
            //_action = action;
            _context = new Models.pyrenactionEntities();

        }

        public Models.Questionnaire Questionnaire
        {
            get
            {
                return _questionnaire;
            }
        }

        public String Nom
        {
            get { return _questionnaire.nom; }
            set
            {
                if (_questionnaire.nom != value)
                {
                    _questionnaire.nom = value;
                   
                }
            }
        }
    }
}
