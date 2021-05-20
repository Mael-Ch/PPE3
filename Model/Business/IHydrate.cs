using System.Collections.Generic;
using System.Data;

namespace Model.Business
{
    public interface IHydrate
    {
        public void Hydrate(DataRow row);
        
        /// <returns>
        /// Retourne un dictionnaire avec comme mot clé le nom de la colone de la table
        /// (L'id est omis si il est en auto_increment)
        /// (Les clés étrangère prennent comme valeur l'id de la class)
        /// </returns>
        public Dictionary<string, dynamic> ToArray();
    }
}