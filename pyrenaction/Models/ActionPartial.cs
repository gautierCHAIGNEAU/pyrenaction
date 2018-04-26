using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace pyrenaction.Models
{
    public partial class Action
    {

        public override string ToString()
        {
            return description;
        }

        //Couleur du nombre de points à l'issu du questionnaire
        public SolidColorBrush color
        {
            get
            {
                if (this.nb_points < 7)
                {
                    return new SolidColorBrush(Colors.Red);
                }
                else
                {
                    return new SolidColorBrush(Colors.Green);
                }
            }

        }
    }
}
