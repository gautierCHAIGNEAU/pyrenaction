using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pyrenaction.ViewModels
{
    class ActionViewModel : ViewModelBase
    {
        private Models.Action _action;
        

        public ActionViewModel(Models.Action action)
        {
            _action = action;

        }

        public Models.Action Action
        {
            get
            {
                return _action;
            }
        }

        public String Source
        {
            get { return _action.source; }
            set
            {
                if (_action.source != value)
                {
                    _action.source = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public DateTime? Date_a
        {
            get { return _action.date_a; }
            set
            {
                if (_action.date_a != value)
                {
                    _action.date_a = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}
