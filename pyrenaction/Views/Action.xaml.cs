using pyrenaction.ViewModels;
using pyrenaction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Mail;

namespace pyrenaction.Views
{
    /// <summary>
    /// Interaction logic for Action.xaml
    /// </summary>
    public partial class Action : Grid
    {
        private ActionViewModel _actionController;
        private Views.Tache _tacheView;
        private Views.Lien _lienView;
        public event EventHandler Valider;
        public Action()
        {
            InitializeComponent();
            _actionController = new ActionViewModel(new Models.Action());

            this.DataContext = _actionController;
        }

        public Action(int id)
        {
            InitializeComponent();
            _actionController = new ActionViewModel(id);

            this.DataContext = _actionController;
        }

        private void Submit(object sender, RoutedEventArgs e)
        {
            _actionController.Valider();

            //Envoi de mail au responsable
            Char delimiter = ' ';
            String res = _actionController.Resp1Selected.ToString().Split(delimiter)[0];
            using (Models.pyrenactionEntities context = new Models.pyrenactionEntities())
            {
                var queryDest = from U in context.Utilisateurs where U.nom == res select U;
                Models.Utilisateur Dest = queryDest.FirstOrDefault();
                try
                {
                    String objet = "Nouvelle action N° " + Dest.id.ToString();
                    String contenu = "Une nouvelle action a été créée, merci de bien vouloir la traiter. \n Numéro : " + Dest.id.ToString();
                    MailMessage mail = new MailMessage("pyrenaction@gmail.com", Dest.email, objet, contenu);
                    SmtpClient stpc = new SmtpClient("smtp.gmail.com", 587);
                    stpc.Credentials = new System.Net.NetworkCredential("pyrenaction@gmail.com", "Cesi1234%");
                    stpc.EnableSsl = true;
                    stpc.Send(mail);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("L'email n'a pu être envoyé : {0}.", ex.Message);
                }
            }
            Valider(this, EventArgs.Empty);

        }

        private void AjouterTache(object sender, RoutedEventArgs e)
        {
            _tacheView = new Views.Tache();
            _tacheView.ValiderTache += ValTache;
            tacheControl.Content = _tacheView;
        }

        private void ModifierTache(object sender, RoutedEventArgs e)
        {
            _tacheView = new Views.Tache(_actionController.TacheSelected);
            _tacheView.ValiderTache += ValTache;
            tacheControl.Content = _tacheView;
        }

        private void SupprimerTache(object sender, RoutedEventArgs e)
        {
            _actionController.SupprimerTache();
        }

        private void ValTache(object sender, EventArgs e)
        {
            _actionController.ValiderTache(_tacheView.getTache());
            _tacheView = null;
            tacheControl.Content = null;
        }







        private void AjouterLien(object sender, RoutedEventArgs e)
        {
            _lienView = new Views.Lien();
            _lienView.ValiderLien += ValLien;
            tacheControl.Content = _lienView;
        }

        private void ModifierLien(object sender, RoutedEventArgs e)
        {
            _lienView = new Views.Lien(_actionController.LienSelected);
            _lienView.ValiderLien += ValLien;
            tacheControl.Content = _lienView;
        }

        private void SupprimerLien(object sender, RoutedEventArgs e)
        {
            _actionController.SupprimerLien();
        }

        private void ValLien(object sender, EventArgs e)
        {
            _actionController.ValiderLien(_lienView.getLien());
            _tacheView = null;
            tacheControl.Content = null;
        }


    }
}
