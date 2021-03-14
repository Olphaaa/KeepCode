using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime;
using System.Text;

namespace ProjectClasses 
{
    [Serializable()]
    /// <summary>
    /// Classe qui permet d'avoir des utilisateurs et des sessions
    /// </summary>
    public class BD_Utilisateur : INotifyPropertyChanged
    {
        /// <summary>
        /// Declaration de PropertyChanged pour mettre a jour automatiquement le contenu d'une liste 
        /// </summary>
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Methode qui si elle est appelée, dit que une propriété a changée
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void OnpropertyChanged(string propertyName)
                        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        /// <summary>
        /// Liste d'utilisateurs
        /// </summary>
        public ObservableCollection<Utilisateur> ListeUtilisateur { get; set; }
        
        /// <summary>
        /// Liste de Sessions pour un utilisateur
        /// </summary>
        public ObservableCollection<Session> ListeSessionsPourLUtilisateur { get; set; }
        
        /// <summary>
        /// Constructeur qui permet d'initialiser la liste d'utilisateurs et la liste de sessions d'un utilisateur
        /// </summary>
        /// <param name="u">Utilisateur connecté</param>
        public BD_Utilisateur(Utilisateur u)
        {
            ListeUtilisateur = new ObservableCollection<Utilisateur>();
            ListeSessionsPourLUtilisateur = u.ListSession;
        }

        /// <summary>
        /// Constructeur par defaut qui permet d'initialiser une liste d'utilisateurs
        /// </summary>
        public BD_Utilisateur()
        {
            ListeUtilisateur = new ObservableCollection<Utilisateur>();
        }

        /// <summary>
        /// Methode qui permet d'ajouter un utilisateur à la liste d'utilisateur
        /// </summary>
        /// <param name="u">Utilisateur a ajouter a la liste</param>
        public void AddUser(Utilisateur u)
        {
            ListeUtilisateur.Add(u);
        }

        /// <summary>
        /// Methode qui permet d'ajouer une session a la liste de sessions
        /// </summary>
        /// <param name="s">Session a ajouter</param>
        /// <param name="u">Utilisateur concerné </param>
        public void AjouterSession(Session s, Utilisateur u)
        {
            u.ListSession.Add(s);
        }

        /// <summary>
        /// Methode qui permet de savoir si l'utilisateur qui veut se connecter est deja dans la ListeUtilisateur
        /// </summary>
        /// <param name="id">Id de connexion de la personne qui veut se connecter</param>
        /// <param name="passwd">Mot de passe de connexion de la personne qui veut se connecter</param>
        /// <returns>Retourne true si la personne qui se connecte a deja un compte, false sinon</returns>
        public bool UtilisateurConnu(string id, string passwd)
        {
            foreach(Utilisateur u in ListeUtilisateur)
            {
                if(string.Equals(u.IdUtilisateur,id) && string.Equals(u.Passwd, passwd))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Methode qui renvoie les infos de l'utilisateur qui vient de se connecter
        /// </summary>
        /// <param name="id">Id de connexion de la personne qui veut se connecter</param>
        /// <param name="passwd">Mot de passe de connexion de la personne qui veut se connecter</param>
        /// <returns>Renvoie l'utilisateur qui vient de se connecter avec ses infos</returns>
        public Utilisateur RechercherInfosUtilisateur(string id, string passwd)
        {
            foreach(Utilisateur u in ListeUtilisateur)
            {
                if (u.Equals(new Utilisateur(id, passwd, new DateTime(0), "")))
                {
                    return u;
                }
            }
            return null;
        }

        /// <summary>
        /// Methode qui retourne la liste de session d'un utilisateur passé en parametre
        /// </summary>
        /// <param name="u">Utilisateur connecté</param>
        /// <returns>La liste de session de l'utilisateur connecté</returns>
        public ObservableCollection<Session> SessionsPourUnUtilisateur(Utilisateur u)
        {
            foreach (Utilisateur user in ListeUtilisateur)
            {
                if (user.Equals(u))
                {
                    return user.ListSession;
                }
            }
            return null;
        }
    }
}
