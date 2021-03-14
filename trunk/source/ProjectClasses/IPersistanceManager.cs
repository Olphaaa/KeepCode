using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ProjectClasses
{
    public interface IPersistanceManager
    {
        BD_Utilisateur ChargDonnées();
        void SauvegardeDonnées(BD_Utilisateur bdUser);
    }
}
