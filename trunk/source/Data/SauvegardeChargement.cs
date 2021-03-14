using ProjectClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class SauvegardeChargement : IPersistanceManager
    {
        public BD_Utilisateur ChargDonnées()
        {
            BD_Utilisateur BdUser = new BD_Utilisateur();
            using (Stream OpenSaveFileStream = File.Open("../../../../save/SavedBdUtilisateur", FileMode.Open))
            {
                try
                {
                    BinaryFormatter lire = new BinaryFormatter();
                    BdUser = (BD_Utilisateur)lire.Deserialize(OpenSaveFileStream);
                    OpenSaveFileStream.Close();
                    return BdUser;
                }
                catch
                {
                    return BdUser;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bdUser"></param>
        public void SauvegardeDonnées(BD_Utilisateur bdUser)
        {
            using (Stream SaveFileStream = File.Create("../../../../save/SavedBdUtilisateur"))
            {
                BinaryFormatter charger = new BinaryFormatter();
                charger.Serialize(SaveFileStream, bdUser);
                SaveFileStream.Close();
            }
        }
    }
}
