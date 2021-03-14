using System;
using System.Diagnostics;
using ClasseManager;
using ProjectClasses;
using Data;
using System.Linq;

namespace Test
{
    /// <summary>
    /// Permet de faire des test du modele
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                /*Utilisateur u = new Utilisateur("Patrick", "mdp", new DateTime(1), "");
                
                Manager mng = new Manager(Stub.CreerUtilisateurAvecSessions());
                mng.UtilisateurEnCours = mng.BdUser.ListeUtilisateur.First();
                Console.WriteLine("triage de la liste :");

                //Console.WriteLine(mng.bdUtilisateur.listeSessionsPourLUtilisateur);
                foreach (Session s in mng.listeSession)
                {
                    Console.WriteLine($"{u.IdUtilisateur}: {s.Note}");
                }
                Console.WriteLine("Coucou");


                Session s1 = new Session(38, new DateTime(2020, 01, 14), "assez facile", 3);
                Session s2 = new Session(10, new DateTime(2020, 02, 11), "trop difficile", 5);
                Session s3 = new Session(36, new DateTime(2020, 02, 12), "ez", 5);
                Session s4 = new Session(35, new DateTime(2020, 03, 06), "j'en ai ch***", 5);
                Session s5 = new Session(10, new DateTime(2020, 03, 09), "pas ouf ", 5);
                Session s6 = new Session(28, new DateTime(2020, 04, 10), "je sais pas ce que j'ai fiat mais cela me semblait cool", 5);
                Session s7 = new Session(33, new DateTime(2020, 04, 21), "Ca va en vrai", 5);

                Utilisateur u1 = new Utilisateur("Archibald", "motdepasse", new DateTime(2020, 01, 13), new DateTime(2020, 06, 25), "img/pp/uer1.png");

                Debug.WriteLine($"Valeur de la note de la première session {s1.Note} ");
                Console.WriteLine(s1.Note);
                Console.WriteLine($"{s2}");
                Console.WriteLine(u1.ToString());
                Console.WriteLine("**********************************************************");
                //BD_Session b1 = new BD_Session();
                mng.AjouterSession(s1, u1);
                mng.AjouterSession(s2, u1);
                mng.AjouterSession(s3, u1);
                mng.AjouterSession(s4, u1);
                mng.AjouterSession(s5, u1);
                mng.AjouterSession(s6, u1);
                mng.AjouterSession(s7, u1);
                Console.WriteLine("**********************************************************");
                Console.WriteLine($"Liste des sessions pour un utilisateur: {mng.AfficherListeSession(Stub.)}";
                Console.WriteLine("**********************************************************");
                Console.WriteLine($"Moyenne générale: {mng.MoyenneGenerale(u1)}");
                Console.WriteLine("**********************************************************");
                Console.WriteLine($"Pourcentage de réussite: {mng.PourcentageReussite(u1)}");
                Console.WriteLine("**********************************************************");
                Console.WriteLine($"Moyenne 5 dernières sessions: {mng.MoyenneDes5Dernieres(u1)}");
                Console.WriteLine("**********************************************************");
                Console.WriteLine($"Date de l'exam: {u1.dateExam.ToShortDateString()}");
                Console.WriteLine("**********************************************************");
                Console.WriteLine($"Temps écoulé en nombre de jour: {mng.NombreJourRestant(u1)}");
                Console.WriteLine("**********************************************************");
                Console.WriteLine($"Temps écoulé en nombre de jour: {mng.NombreJourRestant(u1)}");
                Console.WriteLine("**********************************************************");
*/

            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }

            //Console.WriteLine($"la valeur est: {s1.Valeur()}");

           
  		}
 	}
}
