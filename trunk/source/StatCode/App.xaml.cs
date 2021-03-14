using ClasseManager;
using Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace StatCode
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// Cette classe principale permet d'instancier la classe manager qui peut etre accessible par toutes les autres classes
    /// </summary>

    public partial class App : Application
    {
       // public Manager Mng = new Manager(new Stub().ChargDonnées()); //Pour charger les valeurs par défaut du stub
        public Manager Mng = new Manager(); //Pour lire le fichier de sauvegarde
    }
}
