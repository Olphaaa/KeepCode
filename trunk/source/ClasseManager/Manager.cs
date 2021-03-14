using Data;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ProjectClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;

namespace ClasseManager
{
    /// <summary>
    /// Construction d'une classe Manager
    /// </summary>
    public partial class Manager : INotifyPropertyChanged
    {
        /// <summary>
        /// Dépendance vers le gestionnaire de la persistance
        /// </summary>
        public IPersistanceManager Persistance { get; private set; }

        /// <summary>
        /// Declaration et instanciation  
        /// </summary>
        public SauvegardeChargement saveLoad = new SauvegardeChargement();

        /// <summary>
        /// Methode qui appelle la methode de sauvegarde de la base de Données
        /// </summary>
        public void SaveBduser()
        {
            saveLoad.SauvegardeDonnées(BdUser);
        }

        /// <summary>
        ///  Methode qui appelle la methode de chargement de la base de Données
        /// </summary>
        /// <returns></returns>
        public BD_Utilisateur LoadBdUser()
        {
            return saveLoad.ChargDonnées();
        }

        /// <summary>
        /// Declaration de PropertyChanged pour mettre a jour automatiquement le contenu d'une liste
        /// </summary>
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        //private BindingSource binding1;

        /// <summary>
        /// Declaration d'une base de données d'utilisateur 
        /// </summary>
        public BD_Utilisateur BdUser { get; set; }

        /// <summary>
        /// Declaration d'une collection de Session, qui sera remplie par une collection de Session d'un utilisateur specifique
        /// </summary>
        public ObservableCollection<Session> ListeSessionsPourLUtilisateur { get; set; }

        /// <summary>
        /// Declaration d'un Utilisateur, qui représente l'utilisateur connecté
        /// </summary>
        public Utilisateur UtilisateurEnCours { get; set; }

        //ObservableCollection<Session> ListeSessionDeUtilisateur = new ObservableCollection<Session>();
        
        //public BD_Utilisateur bdUser = new BD_Utilisateur();
        
        public Manager()
        {
            BdUser = LoadBdUser();
        }
        /// <summary>
        /// Constructeur de Manager avec une Base de données en parametre
        /// </summary>
        /// <param name="bdUser">Base de données d'utilisateur</param>
        public Manager(BD_Utilisateur bdUser)
        {
            //Essayer d'appeler ce manager a chaque instanciation
            BdUser = bdUser;
            //BdUser.ListeSessionsPourLUtilisateur = UtilisateurEnCours.ListSession;
        }
        
        /// <summary>
        /// Méthode qui permet d'ajouter un utilisateur a la base de données d'utilisateur
        /// </summary>
        /// <param name="u">Utilisateur a ajouter dans la base de données</param>
        public void AjouterUtilisateur(Utilisateur u)
        {
            BdUser.AddUser(u);
            SaveBduser();
        }

        /// <summary>
        /// Méthode qui permet d'ajouter une session a la liste de sessions d'un utilisateur passé en parametre
        /// </summary>
        /// <param name="s">Session a ajouter a la liste de sessions</param>
        /// <param name="u"></param>
        public void AjouterSession(Session s, Utilisateur u)
        {
            u.ListSession.Add(s);
            SaveBduser();
        }

        /// <summary>
        /// Methode qui permet de supprimer une session passée en parametre de la liste de session d'un utilisateur passé en parametre
        /// </summary>
        /// <param name="sASuppr">Session a supprimer</param>
        /// <param name="u">Session a suppriùer dans la liste de session de cet utilisateur</param>
        public void SupprimerSession(Session sASuppr, Utilisateur u)
        {
            u.ListSession.Remove(sASuppr);
            SaveBduser();
        }

        /// <summary>
        /// Methode qui permet d'afficher une liste de session pour un utilisateur passé en parametre, elle a été seulement utilisé dans la class program.cs
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public string AfficherListeSession(Utilisateur u)
        {
            string str="";
            foreach (Session s in u.ListSession)
            {
                str+=$"{s.Note}/40 le {s.Date.ToShortDateString()} \n\tdescription: {s.Description} \n\tnivDif {s.NiveauDif}/5";
            }
            return str;
        }

        /// <summary>
        /// Methode qui calcule le pourcentage de session ayant des notes superieures ou egales a 35
        /// </summary>
        /// <param name="u">Utilisateur connecté</param>
        /// <returns>Retourne le pourcentage de note superieures ou egales a 35 d'un utilisateur</returns>
        public float PourcentageReussite(Utilisateur u)
        {
            int i = 0;
            foreach (Session s in u.ListSession)
            {
                if (s.Note >= 35) { i++; }
            }
            return (float)Math.Round((float)i / u.ListSession.Count()*100);
        }

        /// <summary>
        /// Methode qui permet de calculer la moyenne generale de toutes les sessions d'un utilisateur
        /// </summary>
        /// <param name="u">Utilisateur connecté</param>
        /// <returns>Retourne la moyenne des notes des sessions de l'utilisateur</returns>
        public float MoyenneGenerale(Utilisateur u)
        {
            int nombreSession = u.ListSession.Count();
            int sommeSession = 0;
            foreach (Session s in u.ListSession)
            {
                sommeSession += s.Note;
            }
            return (float)Math.Round((float)sommeSession / nombreSession,2);
        }

        /// <summary>
        /// Methode qui calcule la moyenne des 5 dernieres sessions de l'utilisateur 
        /// </summary>
        /// <param name="u">Utilisateur connecté</param>
        /// <returns>Retourne la moyenne des 5 dernieres sessions si l'utilisateur a 5 sessions, sinon retourne null/returns>
        public float? MoyenneDes5Dernieres(Utilisateur u)
        {
            int somme = 0;
            if (UtilisateurEnCours.ListSession.Count() > 5)
            {
                List<Session> liste5dernieres = new List<Session>
                {
                    u.ListSession.OrderByDescending(s => s.Date).Take(5).First(),
                    u.ListSession.OrderByDescending(s => s.Date).Take(5).Skip(1).First(),
                    u.ListSession.OrderByDescending(s => s.Date).Take(5).Skip(2).First(),
                    u.ListSession.OrderByDescending(s => s.Date).Take(5).Skip(3).First(),
                    u.ListSession.OrderByDescending(s => s.Date).Take(5).Skip(4).First()
                };
                foreach (Session s in liste5dernieres)
                {
                    somme += s.Note;
                }
                return (float)somme / liste5dernieres.Count();
            }
            return null;
        }

        /// <summary>
        /// Methode qui calcule le nombre de jours restants entre aujourd'hui et la date d'examen
        /// </summary>
        /// <param name="u">Utilisateur connecté</param>
        /// <returns>Retourne le nombre de jours restants avant l'examen</returns>
        public double NombreJourRestant(Utilisateur u)
        {
            TimeSpan ts = u.DateExam - DateTime.Now;
            return Math.Round(ts.TotalDays);
        }

        /// <summary>
        /// Methode qui calcule le nombre de jours écoules entre la date d'inscription et aujourd'hui
        /// </summary>
        /// <param name="u">Utilisateur connecté</param>
        /// <returns>Retourne le nombre de jours écoules entre la date d'inscription et aujourd'hui</returns>
        public double TempsEcoule(Utilisateur u)
        {
            TimeSpan ts = DateTime.Now - u.DateInscription;
            return Math.Round(ts.TotalDays);
        }
        
        /// <summary>
        /// Methode qui permet d'afficher en orange les notes entre 20 et 35
        /// </summary>
        /// <param name="u">Utilisateur connecté</param>
        /// <returns>Le nombre de notes inferieures a 35</returns>
        public double ProgressBarOrange(Utilisateur u)
        {
            double i = 0;
            foreach(Session s in u.ListSession)
            {
                if (s.Note < 35)
                {
                    i++;
                }
            }
            return i;
        }
        /// <summary>
        /// Methode qui permet d'afficher en rouge le nombre de notes entre 0 et 20
        /// </summary>
        /// <param name="u">Utilisateur connecté</param>
        /// <returns>Le nombre de notes inferieures a 35</returns>
        public double ProgressBarRouge(Utilisateur u)
        {
            double i = 0;
            foreach (Session s in u.ListSession)
            {
                if (s.Note < 20)
                {
                    i++;
                }
            }
            return i;
        }

        /// <summary>
        /// Methode qui permet de rechercher si l'utilisateur passé en parametre est dans la liste des utilisateurs 
        /// </summary>
        /// <param name="uTest">Utilisateur a comparer pour savoir si il est deja present dans la liste des utilisateurs</param>
        /// <returns>True si l'utilisateur passé en parametre est present dans la liste des utilisateurs, false sinon</returns>
        public bool RechercherSiUtilisateurExiste(Utilisateur uTest)
        {
            foreach (Utilisateur u in BdUser.ListeUtilisateur)
            {
                if (u.IdUtilisateur == uTest.IdUtilisateur)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
