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
    
    public partial class Action
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Action()
        {
            this.Action1 = new HashSet<Action>();
            this.Liens = new HashSet<Lien>();
            this.Mails = new HashSet<Mail>();
            this.Taches = new HashSet<Tache>();
        }
    
        public int id { get; set; }
        public Nullable<System.DateTime> date_a { get; set; }
        public Nullable<System.DateTime> delais { get; set; }
        public string source { get; set; }
        public string analyse { get; set; }
        public string description { get; set; }
        public Nullable<bool> statut { get; set; }
        public int id_Importance { get; set; }
        public int id_Famille { get; set; }
        public int id_Site { get; set; }
        public Nullable<int> id_Questionnaire { get; set; }
        public Nullable<int> id_1 { get; set; }
        public int id_Utilisateur { get; set; }
        public Nullable<int> id_Utilisateur_2 { get; set; }
        public Nullable<int> nb_points { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Action> Action1 { get; set; }
        public virtual Action Action2 { get; set; }
        public virtual Famille Famille { get; set; }
        public virtual Importance Importance { get; set; }
        public virtual Questionnaire Questionnaire { get; set; }
        public virtual Site Site { get; set; }
        public virtual Utilisateur Utilisateur { get; set; }
        public virtual Utilisateur Utilisateur1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lien> Liens { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mail> Mails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tache> Taches { get; set; }
    }
}
