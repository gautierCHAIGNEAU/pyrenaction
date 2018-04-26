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

        //Attribut bindé pour que les checkbox de la vue questionnaire soient à False à l'ouverture de la vue
        private bool checkedFalse { get; set; }
        public void Valider()
        {
            _context.SaveChanges();
        }

        //On Valide le questionnaire en attribuant le nombre de points qu'il à calculer à l'action associée
        public void ValiderQuestionnaire(int idAction, int points)
        {
            Models.Action act = (from T in _context.Actions where T.id == idAction select T).FirstOrDefault();
            if(act != null)
            {
                act.nb_points = points;
                act.statut = true;
                _context.SaveChanges();
            }
        }
        public QuestionnaireViewModel(Models.Questionnaire questionnaire)
        {
            _questionnaire = questionnaire;
     
            _context = new Models.pyrenactionEntities();
            checkedFalse = false;
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
