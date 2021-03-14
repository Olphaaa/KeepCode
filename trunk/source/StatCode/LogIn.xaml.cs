using ClasseManager;
using Data;
using ProjectClasses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StatCode
{
    /// <summary>
    /// Logique d'interaction pour LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        /// <summary>
        /// Avoir le manager commun
        /// </summary>
        Manager mng = (App.Current as App).Mng;
        public LogIn()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Permet de voir si l'utilisateur est déjà connu grace a la méthode UtilisateurConnu dans la class BD_Utilisateur
        /// si il existe alors l'utilisateur se connecte en reseignant au manager quelle est l'utilisateur en cours 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConnectBTN_Click(object sender, RoutedEventArgs e)
        {
            if (mng.BdUser.UtilisateurConnu(IdentifiantSaisi.Text, MotDePasseSaisi.Password))
            {
                Utilisateur send = mng.BdUser.RechercherInfosUtilisateur(IdentifiantSaisi.Text,MotDePasseSaisi.Password);
                mng.UtilisateurEnCours = send;
                MainWindow mainWindow = new MainWindow();
                mainWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Login introuvable, il faut créer un compte!");
            }
            
        }
        /// <summary>
        /// Bouton qui permet d'appeler la fenetre CreateAcc pour pouvoir ajouter un utilisateur si il n'est pas existant dans la base de donnée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CreateAcc CreerWindow = new CreateAcc();
            CreerWindow.ShowDialog();
        }

    }
}
