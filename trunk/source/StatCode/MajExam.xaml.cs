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
using ClasseManager;
using ProjectClasses;

namespace StatCode
{
    /// <summary>
    /// Logique d'interaction pour MajExam.xaml
    /// </summary>
    public partial class MajExam : Window
    {
        /// <summary>
        /// Instancie le manager commun
        /// </summary>
        public Manager mng = (App.Current as App).Mng;
        /// <summary>
        /// Initialisation de la page MajExam.xaml
        /// </summary>
        public MajExam()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Permet de modifier la date de l'éxam pour avoir des statistiques supplémentaires
        /// Controle a ce que la date ne soit pas inferrieur a celle d'ajourd'hui
        /// Appel a la fonciotn de sauvegarde dans le fichier 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnConfirm(object sender, RoutedEventArgs e)
        {
            if(TxtDateExam.SelectedDate <= DateTime.Now){ MessageBox.Show("Vous devez saisir une date correcte"); }
            else
            {
                if(TxtDateExam.SelectedDate == null) {MessageBox.Show("Veuillez saisir une date");}
                else{ 
                    mng.UtilisateurEnCours.DateExam = (DateTime)TxtDateExam.SelectedDate;
                    mng.SaveBduser();
                    Close();
                }
            }
            
        }
    }
}
