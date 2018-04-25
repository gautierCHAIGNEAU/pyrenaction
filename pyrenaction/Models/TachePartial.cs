using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace pyrenaction.Models
{
    public partial class Tache
    {
        public SolidColorBrush color {
            get
            {
                if(this.statut == false)
                {
                    return new SolidColorBrush(Colors.Red);
                }
                else
                {
                    return new SolidColorBrush(Colors.Green);
                }
            }

        }


        public override string ToString()
        {
            return nom;
        }




    }
}
