using System;
using System.ComponentModel;
using System.Dynamic;

namespace ProjectClasses
{
    [Serializable()]
    /// <summary>
    /// Classe session
    /// </summary>
    public class Session : IComparable, INotifyPropertyChanged
    {
        /// <summary>
        /// Declaration de PropertyChanged pour mettre a jour automatiquement le contenu d'une liste 
        /// </summary>
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;
        
        /// <summary>
        /// Methode qui si elle est appelée, dit que une propriété se met a jour
        /// </summary>
        /// <param name="propertyName">Nom de la propriété qui se met a jour</param>
        protected virtual void OnpropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        /// <summary>
        /// Constructeur d'une session 
        /// </summary>
        /// <param name="note">Note de la session</param>
        /// <param name="date">Date de la session</param>
        /// <param name="description">Description de la session</param>
        /// <param name="niveauDif">Niveau de difficulté de la session</param>
        public Session(int note, DateTime date, string description, int niveauDif)
        {
            Note = note;
            Date = date;
            Description = description;
            NiveauDif = niveauDif;
        }

        /// <summary>
        /// Propriété permettant d'assigner des couleurs en fonction des notes
        /// </summary>
        private string fill;
        public string Fill
        {
            get
            {
                if (note > 40 || note < 0)
                {
                    throw new Exception("La valeur n'est pas correcte!");
                }
                else if (note < 25)
                {
                    return "#bf2525";
                }
                else if (note >= 25 && note <= 34)
                {
                    return "Orange";
                }
                else if (note > 34)
                {
                    return "#FF0CB900";
                }
                return "White";
            }
            set
            {
                fill = value;
                OnpropertyChanged(nameof(Fill));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Fill"));
            }
        }

        /// <summary>
        /// Propriété qui indique la note de la session 
        /// </summary>
        private int note;
        public int Note 
        {
            get
            {
                return note;
            }
            set
            {
                note = value;
                Reste=40-value;
                Fill = value.ToString();
                OnpropertyChanged(nameof(Note));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Note"));
            }
        }

        /// <summary>
        /// Propriété qui indique le nombre de fautes d'une session 
        /// </summary>
        private int reste;
        public int Reste
        {
            get
            {
                return 40-note;
            }
            set
            {
                reste = value;
                OnpropertyChanged(nameof(Reste));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Reste"));
            }
        }

        /// <summary>
        /// Propriété qui indique la date de la session 
        /// </summary>
        private DateTime date;
        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
                OnpropertyChanged(nameof(Date));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Date"));
            }
        }

        /// <summary>
        /// Propriété qui indique la description de la session
        /// </summary>
        private string description;
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
                OnpropertyChanged(nameof(Description));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Description"));
            }
        }

        /// <summary>
        /// Propriété qui indique le niveau de difficulté de la session
        /// </summary>
        private int niveauDif;
        public int NiveauDif
        {
            get
            {
                return niveauDif;
            }
            set
            {
                niveauDif = value;
                OnpropertyChanged(nameof(NiveauDif));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NiveauDif"));
            }
        }

        /// <summary>
        /// Methode ToString d'une session
        /// </summary>
        /// <returns>Retourne un string avec la note, date, description et niveau de difficulté d'une session</returns>
        public override string ToString()
        {
            return $"{note}/40 le {date.ToShortDateString()} \n description: {description} \n nivDif {niveauDif}/5";
        }

        /// <summary>
        /// Methode CompareTo qui compare deux notes ensemble
        /// </summary>
        /// <param name="obj">Objet a comparer</param>
        /// <returns>Retourne true si les deux notes sont égales, false sinon</returns>
        public int CompareTo(object obj)
        {
            Session s = (Session)obj;
            if (s == null)
                return -1;
            else
                return Note.CompareTo(s.Note);
        }
    }
}
