using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pyrenaction.ViewModels
{
    class QuestionViewModel
    {
        private Models.Question _question;
        
        public QuestionViewModel(Models.Question question)
        {
            _question = question;
            _question.reponse = false;
        }

        public Models.Question Question
        {
            get
            {
                return _question;
            }
        }

        public String Commentaire
        {
            get { return _question.commentaire; }
            set
            {
                if (_question.commentaire != value)
                {
                    _question.commentaire = value;
                    //NotifyPropertyChanged();
                }
            }
        }

        public bool? Reponse
        {
            get { return _question.reponse; }
            set
            {
                if (_question.reponse != value)
                {
                    _question.reponse = value;
                    //NotifyPropertyChanged();
                }
            }
        }
    }
}
