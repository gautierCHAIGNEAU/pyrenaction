//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace pyrenaction.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tache
    {
        public int id { get; set; }
        public Nullable<bool> statut { get; set; }
        public string nom { get; set; }
        
        public int id_Action { get; set; }
    
        public virtual Action Action { get; set; }
    }
}
