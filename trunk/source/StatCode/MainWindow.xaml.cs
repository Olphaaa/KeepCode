using ClasseManager;
using Data;
using Microsoft.Win32;
using ProjectClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StatCode
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window 
    {
        /// <summary>
        /// Instanciation d'un manager
        /// </summary>
        public Manager mng;
        /// <summary>
        /// Permet d'initialiser la fenêtre MainWindow.xaml
        /// Assigne au manager le manager commun
        /// Donne le dataContexe pour savoir ou prendre les informations
        /// Affiche le nom, la date d'inscription, la photo de profil de l'utilisateur en cours 
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            mng=(App.Current as App).Mng;
            mng.UtilisateurEnCours= mng.UtilisateurEnCours;
            
            mng.BdUser.ListeSessionsPourLUtilisateur = mng.UtilisateurEnCours.ListSession;
            
            afficheurSessions.DataContext = (App.Current as App).Mng.BdUser;
            
            MiseAJourStats();
            ObservableCollection<Session> list = mng.UtilisateurEnCours.ListSession;
            

            TxtDateInscription.Information = mng.UtilisateurEnCours.DateInscription.ToShortDateString().ToString();
            TxtNomUtilisateur.Information = mng.UtilisateurEnCours.IdUtilisateur;

            string filename = mng.UtilisateurEnCours.ProfilPicture;
            pp.ImageSource = new BitmapImage(new Uri(mng.UtilisateurEnCours.ProfilPicture, UriKind.Relative));
        }
        /// <summary>
        /// Permet de mettre a jour toutes les information/statistique en fonction de l'ajout ou de la modification de sessions
        /// </summary>
        private void MiseAJourStats()
        {

            if (mng.UtilisateurEnCours.DateExam.Year == new DateTime(0001, 01, 01).Year)
            {
                TxtDateExam.Information = "Non renseigné";
                TxtNbJourRestant.Information = "Date de l'exam non renseigné";

            }
            else
            {
                TxtDateExam.Information = mng.UtilisateurEnCours.DateExam.ToShortDateString();
                TxtNbJourRestant.Information = mng.NombreJourRestant(mng.UtilisateurEnCours).ToString()+" jours";

            }
            if(mng.UtilisateurEnCours.ListSession.Count < 5)
            {
                TxtMoyenne5.Information = "Il manque des notes";
            }
            else
            {
                TxtMoyenne5.Information = mng.MoyenneDes5Dernieres(mng.UtilisateurEnCours).ToString();
            }
            TxtNbSession.Information = mng.UtilisateurEnCours.ListSession.Count().ToString();
            TxtMoyenneGenerale.Information = mng.MoyenneGenerale(mng.UtilisateurEnCours).ToString();
            TxtPourcentage.Information = mng.PourcentageReussite(mng.UtilisateurEnCours).ToString()+"%";
            TxtTempsEcoule.Information = mng.TempsEcoule(mng.UtilisateurEnCours).ToString()+" jours";
            if(mng.UtilisateurEnCours.ListSession.Count != 0)
            {
                TxtMeilleureNote.Information = mng.UtilisateurEnCours.ListSession.Max().Note.ToString()+"/40\nle "+ mng.UtilisateurEnCours.ListSession.Max().Date.ToShortDateString();
            }
            else
            {
                TxtMeilleureNote.Information = "Il manque des notes";
            }
            PBorange.Value = mng.ProgressBarOrange(mng.UtilisateurEnCours);
            PBrouge.Value = mng.ProgressBarRouge(mng.UtilisateurEnCours);
            TxtNoteBonne.Text = "Notes superieures à 35\t→\t (" + mng.UtilisateurEnCours.ListSession.Where(s => s.Note >= 35).Count()+ " sessions)";
            TxtNoteMoyenne.Text = "Note entre 20 et 35\t→\t (" + mng.UtilisateurEnCours.ListSession.Where(s => s.Note < 35 && s.Note >= 25).Count() + " sessions)";
            TxtNoteMauvaise.Text = "Notes inferieures à 20\t→\t (" + mng.UtilisateurEnCours.ListSession.Where(s => s.Note < 25).Count() + " sessions)";

            Pregression5DernieresNotes();
        }
        /// <summary>
        /// Permet d'avoir une prévisualisation des 5 dernières note pour savoir si l'utilisateur pourrais etre pret a passer le code 
        /// Affichage d'un message dans ce cas 
        /// Affiche la couleur et la note des cinqs dernière note inscrites 
        /// </summary>
        private void Pregression5DernieresNotes()
        {
            if (mng.UtilisateurEnCours.ListSession.Count() >= 5)
            {
                List<Session> cinqDer = new List<Session>();
                int bad = 0;
                foreach(Session s in mng.UtilisateurEnCours.ListSession.OrderByDescending(s => s.Date).Take(5)){
                    if (s.Note < 35) { bad = 1; }
                }
                if (bad == 0)
                {
                    MessageBox.Show("Vous etes prêt a passer le code, vous pouvez vous y inscrir\n vous avez une succession de 5 bonnes notes");
                }


                Color color1 = (Color)ColorConverter.ConvertFromString(mng.UtilisateurEnCours.ListSession.OrderByDescending(s => s.Date).Take(5).First().Fill.ToString());
                Color color2 = (Color)ColorConverter.ConvertFromString(mng.UtilisateurEnCours.ListSession.OrderByDescending(s => s.Date).Take(5).Skip(1).First().Fill.ToString());
                Color color3 = (Color)ColorConverter.ConvertFromString(mng.UtilisateurEnCours.ListSession.OrderByDescending(s => s.Date).Take(5).Skip(2).First().Fill.ToString());
                Color color4 = (Color)ColorConverter.ConvertFromString(mng.UtilisateurEnCours.ListSession.OrderByDescending(s => s.Date).Take(5).Skip(3).First().Fill.ToString());
                Color color5 = (Color)ColorConverter.ConvertFromString(mng.UtilisateurEnCours.ListSession.OrderByDescending(s => s.Date).Take(5).Skip(4).First().Fill.ToString());
                SolidColorBrush brush1 = new SolidColorBrush(color1);
                SolidColorBrush brush2 = new SolidColorBrush(color2);
                SolidColorBrush brush3 = new SolidColorBrush(color3);
                SolidColorBrush brush4 = new SolidColorBrush(color4);
                SolidColorBrush brush5 = new SolidColorBrush(color5);
                Fillprem.Fill = brush1;
                Fillsec.Fill = brush2;
                Filltro.Fill = brush3;
                Fillqua.Fill = brush4;
                Fillcin.Fill = brush5;

                Noteprem.Text = mng.UtilisateurEnCours.ListSession.OrderByDescending(s => s.Date).Take(5).First().Note.ToString();
                Notesec.Text = mng.UtilisateurEnCours.ListSession.OrderByDescending(s => s.Date).Take(5).Skip(1).First().Note.ToString();
                Notetro.Text = mng.UtilisateurEnCours.ListSession.OrderByDescending(s => s.Date).Take(5).Skip(2).First().Note.ToString();
                Notequa.Text = mng.UtilisateurEnCours.ListSession.OrderByDescending(s => s.Date).Take(5).Skip(3).First().Note.ToString();
                Notecin.Text = mng.UtilisateurEnCours.ListSession.OrderByDescending(s => s.Date).Take(5).Skip(4).First().Note.ToString();
            }
        }
        /// <summary>
        /// Permet d'apepler la fenetre Add pour ajouter une session 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Add ajouterWindows = new Add();
            ajouterWindows.ShowDialog();
            MiseAJourStats();
        }
        /// <summary>
        /// Permet de supprimer la session séléctionnée avec confirmation de suppression 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Suppr_Click(object sender, RoutedEventArgs e)
        {
            string message_supp = "Voulez-vous vraiment supprimer cette session?";
            string titre = "Supprimer";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            MessageBoxResult result = MessageBox.Show(message_supp, titre, buttons);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    mng.SupprimerSession((Session)afficheurSessions.SelectedItem, mng.UtilisateurEnCours);
                    MiseAJourStats();
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }
        /// <summary>
        /// Permet d'appeler la fenetre Edit pour modifier la session séléctionné 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Edit modifierWindow = new Edit((Session)afficheurSessions.SelectedItem, mng.BdUser);
            modifierWindow.ShowDialog();
        }
        /// <summary>
        /// Appelle la fenetre poru modifier la date d'inscription
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnUpdateExam(object sender, RoutedEventArgs e)
        {
            MajExam miseAJourDateExam = new MajExam();
            miseAJourDateExam.ShowDialog();
            MiseAJourStats();
        }
        /// <summary>
        /// Permet de trier les sessions par date
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnTrierParDate(object sender, RoutedEventArgs e)
        {
            afficheurSessions.Items.SortDescriptions.Clear();
            afficheurSessions.Items.SortDescriptions.Add(new SortDescription("Date", ListSortDirection.Descending));
        }
        /// <summary>
        /// Permet de trier les sessions par note 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnTrierParNote(object sender, RoutedEventArgs e)
        {
            afficheurSessions.Items.SortDescriptions.Clear();
            afficheurSessions.Items.SortDescriptions.Add(new SortDescription("Note", ListSortDirection.Descending));
        }
    }
}
