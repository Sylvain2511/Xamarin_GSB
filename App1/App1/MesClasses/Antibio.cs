using System;
using System.Collections.Generic;
using System.Text;

namespace App1
{
    public abstract class Antibio
    {
        public String libelle;
        public String unite;
        public int nombreParJour;
        public Categorie laCategorie;
        public Antibio(String pLibelle, String pUnite, int pNombreParJour, Categorie pCategorie)
        {
            this.libelle = pLibelle;
            this.unite = pUnite;
            this.nombreParJour = pNombreParJour;
            this.laCategorie = pCategorie;
        }
        public int getNombreParJour()
        {
            return this.nombreParJour;
        }
        public String getLibelle()
        {
            return this.libelle;
        }
        public String getUnite()
        {
            return this.unite;
        }
        public Categorie getCategorie()
        {
            return this.laCategorie;
        }
        public override String ToString()
        {
            return this.getLibelle();
        }
    }
}
