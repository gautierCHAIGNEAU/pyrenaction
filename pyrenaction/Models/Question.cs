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
    
    public partial class Question
    {
        public int id { get; set; }
        public string intitule { get; set; }
        public Nullable<bool> reponse { get; set; }
        public string commentaire { get; set; }
        public int id_Questionnaire { get; set; }
    
        public virtual Questionnaire Questionnaire { get; set; }
    }
}
