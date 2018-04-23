using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.ObjectModel;

namespace pyrenaction.Views.TableauDeBord
{
    public partial class ucTableauDeBord : UserControl
    {
        public ucTableauDeBord()
        {
            InitializeComponent();
            ObservableCollection<Actions> actions = new ObservableCollection<Actions>();
            actions.Add(new Actions
            {
                actionNum = 1,
                actionAnnee = 2018,
                actionMois = "Avril",
                actionSite = "Tous",
                actionFamille = "RH",
                actionName = "Vérifier les arrêts maladies",
                actionDeadLine = new DateTime(2008, 5, 1, 8, 30, 52),
                actionResponsable = "DUPONT, Nicolas",
                actionAvancement = 100,
                actionTermine = false,
                actionTracabilite = "A chaque nouveau projet",
                actionSuivi = "",
                actionDateBouclage = new DateTime(2008, 5, 1, 8, 30, 52),
            });

            actions.Add(new Actions
            {
                actionNum = 1,
                actionAnnee = 2018,
                actionMois = "Avril",
                actionSite = "Tous",
                actionFamille = "RH",
                actionName = "Vérifier les arrêts maladies",
                actionDeadLine = new DateTime(2008, 5, 1, 8, 30, 52),
                actionResponsable = "DUPONT, Nicolas",
                actionAvancement = 100,
                actionTermine = false,
                actionTracabilite = "A chaque nouveau projet",
                actionSuivi = "",
                actionDateBouclage = new DateTime(2008, 5, 1, 8, 30, 52),
            });

            actions.Add(new Actions
            {
                actionNum = 1,
                actionAnnee = 2018,
                actionMois = "Avril",
                actionSite = "Tous",
                actionFamille = "RH",
                actionName = "Vérifier les arrêts maladies",
                actionDeadLine = new DateTime(2008, 5, 1, 8, 30, 52),
                actionResponsable = "DUPONT, Nicolas",
                actionAvancement = 100,
                actionTermine = false,
                actionTracabilite = "A chaque nouveau projet",
                actionSuivi = "",
                actionDateBouclage = new DateTime(2008, 5, 1, 8, 30, 52),
            });

            actions.Add(new Actions
            {
                actionNum = 1,
                actionAnnee = 2018,
                actionMois = "Avril",
                actionSite = "Tous",
                actionFamille = "RH",
                actionName = "Vérifier les arrêts maladies",
                actionDeadLine = new DateTime(2008, 5, 1, 8, 30, 52),
                actionResponsable = "DUPONT, Nicolas",
                actionAvancement = 100,
                actionTermine = false,
                actionTracabilite = "A chaque nouveau projet",
                actionSuivi = "",
                actionDateBouclage = new DateTime(2008, 5, 1, 8, 30, 52),
            });

            actions.Add(new Actions
            {
                actionNum = 1,
                actionAnnee = 2018,
                actionMois = "Avril",
                actionSite = "Tous",
                actionFamille = "RH",
                actionName = "Vérifier les arrêts maladies",
                actionDeadLine = new DateTime(2008, 5, 1, 8, 30, 52),
                actionResponsable = "DUPONT, Nicolas",
                actionAvancement = 100,
                actionTermine = false,
                actionTracabilite = "A chaque nouveau projet",
                actionSuivi = "",
                actionDateBouclage = new DateTime(2008, 5, 1, 8, 30, 52),
            });
            dataGridView1.DataSource = actions;


        }


    }
}
