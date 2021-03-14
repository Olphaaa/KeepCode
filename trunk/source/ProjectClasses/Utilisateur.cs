using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ProjectClasses
{
    [Serializable()]
    /// <summary>
    /// Classe Utilisateur
    /// </summary>
    public class Utilisateur
    {
        /// <summary>
        /// Propriété et attribut de l'id Utilisateur
        /// </summary>
        private string idUtilisateur;
        public string IdUtilisateur
        {
            get
            {
                return idUtilisateur;
            }
            set
            {
                idUtilisateur = value;
            }
        }

        /// <summary>
        /// Propriété et attribut du mot de passe de l'utilisateur
        /// </summary>
        private string passwd;
        public string Passwd
        {
            get
            {
                return passwd;
            }
            set
            {
                passwd = value;
            }
        }

        /// <summary>
        /// Propriété et attribut de la date d'inscription de l'utilisateur
        /// </summary>
        private DateTime dateInscription;
        public DateTime DateInscription
        {
            get
            {
                return dateInscription;
            }
            set
            {
                if (value >= DateTime.Now)
                {
                    throw new Exception($"Erreur: {value.ToShortDateString()} doit être avant la date d'aujourd'hui ({DateTime.Now.ToShortDateString()})");
                }
                else dateInscription = value;
            }
        }

        /// <summary>
        /// Propriété et attribut de la date d'examen de l'utilisateur
        /// </summary>
        private DateTime dateExam;
        public DateTime DateExam
        {
            get
            {
                return dateExam;
            }
            set
            {
                /*if (value < DateTime.Now)
                {
                    throw new Exception($"Erreur: {value.ToShortDateString()} doit être plus au plus tard que la date d'aujourd'hui ({DateTime.Now.ToShortDateString()})");
                }
                else*/ dateExam = value;
            }
        }

        /// <summary>
        /// Propriété et attribut de l'image de profil de l'utilisateur
        /// </summary>
        private string profilPicture;
        public string ProfilPicture
        {
            get
            {
                return profilPicture;
            }
            set
            {
                profilPicture = value;
            }
        }

        /// <summary>
        /// Propriété et attribut de la liste de Session
        /// </summary>
        private ObservableCollection<Session> listSession;
        public ObservableCollection<Session> ListSession {
            get
            {
                return listSession;
            }
            set
            {
                listSession = value;
            }
        }

        /// <summary>
        /// Constructeur d'un utilisateur
        /// </summary>
        /// <param name="idUser">ID Utilisateur</param>
        /// <param name="passwd">Mot de passe de l'utilisateur</param>
        /// <param name="dateInscription">Date d'inscription de l'utilisateur</param>
        /// <param name="dateExam">Date d'examen de l'utilisateur</param>
        /// <param name="urlProfilPicture">Chemin de la photo de profil de l'utilisateur</param>
        public Utilisateur(string idUser,string passwd,DateTime dateInscription, DateTime dateExam, string urlProfilPicture)
        {
            IdUtilisateur = idUser;
            Passwd = passwd;
            DateInscription = dateInscription;
            DateExam = dateExam;
            listSession = new ObservableCollection<Session>();
            if(urlProfilPicture == null ||  urlProfilPicture == String.Empty)
            {
                ProfilPicture = "../../../img/pp/UnknownUser.png";
            }
            else
            {
                ProfilPicture = urlProfilPicture;
            }
        }

        /// <summary>
        /// Constructeur d'un utilisateur
        /// </summary>
        /// <param name="idUser">Id Utilisateur</param>
        /// <param name="passwd">Mot de passe utilisateur</param>
        /// <param name="dateInscription">Date d'inscription de l'utilisateur</param>
        /// <param name="urlProfilPicture">Chemin de la photo de profil de l'utilisateur</param>
        public Utilisateur(string idUser, string passwd, DateTime dateInscription, string urlProfilPicture)
        {
            IdUtilisateur = idUser;
            Passwd = passwd;
            DateInscription = dateInscription;
            ProfilPicture = urlProfilPicture;
            listSession = new ObservableCollection<Session>();
        }

        /// <summary>
        /// Methode ToString de l'utilisateur
        /// </summary>
        /// <returns>Retourne les sessions de l'utilisateur</returns>
        public override string ToString()
        {
            string str = $"{idUtilisateur} a pour sessions:\n";
            foreach (Session s in listSession)
            {
                str += $"\t{s.Note}/40 à {s.Date.ToShortDateString()}\n";
            }
            return str;
        }

        /// <summary>
        /// Methode Equals de l'utilisateur
        /// </summary>
        /// <param name="obj">Parametre a comparer </param>
        /// <returns>Retourne true si les deux objets sont egaux, false sinon</returns>
        public override bool Equals(Object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Utilisateur u = (Utilisateur)obj;
                return (idUtilisateur == u.idUtilisateur) && (passwd == u.passwd);
            }
        }
    }
}
