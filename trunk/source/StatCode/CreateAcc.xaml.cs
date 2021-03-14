using System;
using Data;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ClasseManager;
using Microsoft.Win32;
using ProjectClasses;
using System.IO;

namespace StatCode
{
    /// <summary>
    /// Logique d'interaction pour CreateAcc.xaml
    /// </summary>
    public partial class CreateAcc : Window
    {
        /// <summary>
        /// Instancie un utilisateur pour pouvoir lui assigné des valeur et ensuite l'ajouter a la base de donnée 
        /// </summary>
        Utilisateur Ucreation = new Utilisateur(null,null,new DateTime(0),null);
        /// <summary>
        /// Chemin par défaut avec le nom et l'extension de l'image
        /// </summary>
        private string DefaultImageDirectory;
        /// <summary>
        /// Nom de l'image
        /// </summary>
        private string filename;
        /// <summary>
        /// Avoir le manager commun aux autres classes 
        /// </summary>
        public Manager mng = (App.Current as App).Mng;
        /// <summary>
        /// Initialise la fenetre CreateAcc.xaml
        /// </summary>
        public CreateAcc()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Permet d'ajouter un utilisateur a la base de donnée en controlant si l'utilisateur a bien saisie les informations
        /// Ajoute une image par défaut a un utilisateur qui n'aurait pas de photo de profil
        /// Regarde si l'utilisateur n'est pas déjà dans la base de donnée
        /// Copie l'image que l'utilisateur a choisi dans le répertoir par défaut des images pour pouvoir l'avoir sur n'importe quelle PC 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreeCompteBTN_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(TxtMdp.Password + "==" + TxtMdpConfirme.Password);
            if (TxtMdp.Password == TxtMdpConfirme.Password)
            {
                if (mng.RechercherSiUtilisateurExiste(new Utilisateur(TxtNom.Text,"", new DateTime(1), ""))==false)
                {
                    if(filename != String.Empty)
                    {
                        System.IO.File.Copy(filename, DefaultImageDirectory); //Copie de la photo de l'ordinateur vers le répertoire par défaut
                    }
                    else
                    {
                        DefaultImageDirectory = "../../../img/pp/UnknownUser.png";
                    }
                    Ucreation = new Utilisateur(TxtNom.Text, TxtMdp.Password, TxtDateInscription.DisplayDate, DefaultImageDirectory);
                    mng.AjouterUtilisateur(Ucreation);
                    mng.UtilisateurEnCours = Ucreation;
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.ShowDialog();
                    Close();
                }
                else
                {
                    MessageBox.Show("L'utilisateur est déjà existant.");
                }
            }
            else
            {
                MessageBox.Show("Votre mot de passe n'est pas identique.");
            }
        }
        /// <summary>
        /// Permet de choisir une photo de profile du format .png, .jpeg, .jpg  ou .gif
        /// Fait attention si l'utilisateur a bien choisi une image
        /// Affiche un prévisualisation de l'immage choisi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void testbtn(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = ".png | .jpeg | .jpg | .gif";
            ofd.ShowDialog();
            filename = ofd.FileName;
            if (ofd.FileName == String.Empty)
            {
                DefaultImageDirectory = null;
            }
            else
            {
                DefaultImageDirectory = "../../../img/pp/" + System.IO.Path.GetFileName(filename);
                //Ucreation.ProfilPicture = DefaultImageDirectory;
                if(filename != String.Empty)
                {
                    PrevImage.ImageSource = new BitmapImage(new Uri(filename));
                }
            }
            

        }

    }
}
