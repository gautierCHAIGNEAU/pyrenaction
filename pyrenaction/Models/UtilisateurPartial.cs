﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pyrenaction.Models
{
    public partial class Utilisateur
    {
        public override string ToString()
        {
            return nom + " " + prenom;
        }
    }
}
