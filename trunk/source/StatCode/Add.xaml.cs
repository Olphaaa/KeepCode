using ClasseManager;
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
    /// Logique d'interaction pour Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        /// <summary>
        /// Déclaration de la classe manager pour avoir accès a la base de donnée des utilisateurs
        /// </summary>
        public Manager mng = (App.Current as App).Mng;
        /// <summary>
        /// Contructeur qui initialise les composants
        /// </summary>
        public Add()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Méthode qui permet d'ajouter une session a un utilisateur précis a condition que les informations soient saisient et correcte
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AjouterBTN_Click(object sender, RoutedEventArgs e)
        {
            if(TxtAddNote.Text == String.Empty || TxtAddDate.SelectedDate.ToString() == String.Empty || TxtAddDescription.Text == String.Empty)
            {
                MessageBox.Show("Vous devez saisir les informations demandées");
            }
            else
            {
                mng.AjouterSession(new Session(Int32.Parse(TxtAddNote.Text), (DateTime)TxtAddDate.SelectedDate, TxtAddDescription.Text, (int)slValue.Value),mng.UtilisateurEnCours);
                Close();
            }
        }
        /// <summary>
        /// Méthode qui annule l'ajout 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnnulerBTN_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        /// <summary>
        /// Permet de faire le controle, en regardant si ce que l'on saisie n'est ni une chaine de caractère ni infèrieur à 0 et supperrieur à 40
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtAddNote_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s = string.Empty;
            char[] tabChar = TxtAddNote.Text.ToCharArray();
            foreach (char c in tabChar)
            {
                if (char.IsDigit(c)) s = s + c;
                else
                {
                    //MessageBox.Show(c + " n'est pas un nombre!");
                    MessageBox.Show(c + " n'est pas un nombre!", "Erreur avec la note", MessageBoxButton.OK, MessageBoxImage.Warning);
                    TxtAddNote.Text ="0";
                    s.Trim();
                }
            }
            if(String.Compare(TxtAddNote.Text,"")!=0)
            {
                if(Convert.ToInt32(TxtAddNote.Text) >= 0 && Convert.ToInt32(TxtAddNote.Text) <= 40)
                {
                        TxtAddNote.Text = s;
                }
                else
                {
                    MessageBox.Show("Veuillez saisir une note correcte!","Erreur avec la note",MessageBoxButton.OK,MessageBoxImage.Warning);
                    TxtAddNote.Clear();
                }

            }
        }
        /// <summary>
        /// Permet dire a l'utilisateur de resaisir la date si celle ci est suppérieur à celle d'aujourd'hui car cela est impossible
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtAddDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if(TxtAddDate.SelectedDate > DateTime.Now)
            {
                MessageBox.Show($"La date ne doit pas être supperieur à celle d'aujourd'hui ({DateTime.Now.ToShortDateString()})","Erreur avec la date",MessageBoxButton.OK,MessageBoxImage.Warning);
            }
        }
    }
}
