using System;
using System.Collections.Generic;
using System.Text;

namespace TPModule5.Services
{
    /**
     * Permet de récupérer le chemin de la base de données sur chaque device.
     * A implémenter dans tous les projets natifs
     */
    public interface IFileHelper
    {
        string GetLocalFilePath(string filename);
    }
}
