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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StatCode
{
    /// <summary>
    /// Logique d'interaction pour BlockRougeTextBlanc.xaml
    /// </summary>
    public partial class BlockRougeTextBlanc : UserControl
    {
        /// <summary>
        /// Contructeur de l'UserControl
        /// </summary>
        public BlockRougeTextBlanc()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Permet de definire un nouvelle propriété appellée Message
        /// </summary>
        public string Message
        {
            set
            {
                leText.Text = value;
            }
        }
        /// <summary>
        /// Permet de definire un nouvelle propriété appellée Information
        /// </summary>
        public string Information
        {
            set
            {
                lInformation.Text = value;
            }
        }
    }
}
