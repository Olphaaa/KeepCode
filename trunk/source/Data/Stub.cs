using ProjectClasses;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    /// <summary>
    /// Classe Stub, qui permet d'avoir des données préremplies pour pouvoir tester l'application
    /// </summary>
    public class Stub : IPersistanceManager
    {
        /// <summary>
        /// Methode qui permet de Creer des utilisateurs avec des sessions preremplies
        /// </summary>
        public static BD_Utilisateur CreerUtilisateurAvecSessions()
        {
            //creerListeSession();
            //creerUtilisateurs();

            BD_Utilisateur bD_Utilisateur = new BD_Utilisateur(new Utilisateur("", "", new DateTime(1), ""));

            Session s1 = new Session(38, new DateTime(2020, 01, 14), "assez facile", 3);
            Session s2 = new Session(10, new DateTime(2020, 02, 11), "trop difficile", 4);
            Session s3 = new Session(36, new DateTime(2020, 02, 12), "ez", 2);
            Session s4 = new Session(35, new DateTime(2020, 03, 06), "j'en ai ch***", 5);
            Session s5 = new Session(10, new DateTime(2020, 03, 09), "pas ouf ", 1);
            Session s6 = new Session(28, new DateTime(2020, 04, 10), "je sais pas ce que j'ai fait mais cela me semblait cool", 5);
            Session s7 = new Session(33, new DateTime(2020, 04, 21), "Ca va en vrai", 5);

            Utilisateur u1 = new Utilisateur("Kevin", "mdp", new DateTime(2020, 04, 24), "../../../img/pp/User1.png");
            Utilisateur u2 = new Utilisateur("Patrick", "mdp", new DateTime(2020, 03, 21), new DateTime(2021, 03, 22), "../../../img/pp/User2.png");
            Utilisateur testUser = new Utilisateur("", "", new DateTime(2020, 05, 27), new DateTime(2020, 07, 25), null);

            bD_Utilisateur.AddUser(u1);
            bD_Utilisateur.AddUser(u2);
            bD_Utilisateur.AddUser(testUser);

            bD_Utilisateur.AjouterSession(s1, u1);
            bD_Utilisateur.AjouterSession(s2, u1);
            bD_Utilisateur.AjouterSession(s3, u1);

            bD_Utilisateur.AjouterSession(s4, u2);
            bD_Utilisateur.AjouterSession(s5, u2);
            bD_Utilisateur.AjouterSession(s6, u2);
            bD_Utilisateur.AjouterSession(s7, u2);

            bD_Utilisateur.AjouterSession(s1, testUser);
            bD_Utilisateur.AjouterSession(s2, testUser);
            bD_Utilisateur.AjouterSession(s3, testUser);
            bD_Utilisateur.AjouterSession(s4, testUser);
            bD_Utilisateur.AjouterSession(s5, testUser);
            bD_Utilisateur.AjouterSession(s6, testUser);
            bD_Utilisateur.AjouterSession(s7, testUser);

            return bD_Utilisateur;
            //Console.WriteLine($"Liste des sessions pour un utilisateur: {mng.AfficherListeSession(u1)}");
        }

        public BD_Utilisateur ChargDonnées()
        {
            return CreerUtilisateurAvecSessions();
        }

        public void SauvegardeDonnées(BD_Utilisateur bdUser)
        {
            Debug.WriteLine("Sauvegarde demandée");
        }
        
    }
}
