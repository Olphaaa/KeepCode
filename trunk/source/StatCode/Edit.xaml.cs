using ClasseManager;
using ProjectClasses;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Printing;
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
    /// Logique d'interaction pour Edit.xaml
    /// </summary>
    public partial class Edit : Window
    {
        /// <summary>
        /// Initialise la fenetre Edit.xaml
        /// donne le contexte des donnée à traiter 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="bdUser"></param>
        public Edit(Session s, BD_Utilisateur bdUser)
        {
            InitializeComponent();
            DataContext = s;
        }
        /// <summary>
        /// Ferme la page des que le bouton Modifier est cliqué 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void modifierBTN_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        /// <summary>
        /// Ferme la page des que le bouton Annuler est cliqué 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void annulerBTN_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        /// <summary>
        /// Permet de savoir si la note saisie est bien un entier compris entre 0 et 40
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NoteModif_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s = string.Empty;
            char[] tabChar = NoteModif.Text.ToCharArray();
            foreach (char c in tabChar)
            {
                if (char.IsDigit(c)) s = s + c;
                else
                {
                    MessageBox.Show(c + " n'est pas un nombre!", "Erreur avec la note", MessageBoxButton.OK, MessageBoxImage.Warning);
                    NoteModif.Text = "0";
                    s.Trim();
                }
            }
            if (String.Compare(NoteModif.Text, "") != 0)
            {
                if (Convert.ToInt32(NoteModif.Text) >= 0 && Convert.ToInt32(NoteModif.Text) <= 40)
                {
                    NoteModif.Text = s;
                }
                else
                {
                    MessageBox.Show("Veuillez saisir une note correcte!", "Erreur avec la note", MessageBoxButton.OK, MessageBoxImage.Warning);
                    NoteModif.Clear();
                }
            }
        }
        /// <summary>
        /// Permet de controler que la date ne soit par supperieur a celle d'aujorud'hui
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModifDateTxt_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ModifDateTxt.SelectedDate > DateTime.Now)
            {
                MessageBox.Show($"La date ne doit pas être supperieur à celle d'aujourd'hui ({DateTime.Now.ToShortDateString()})", "Erreur avec la date", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
