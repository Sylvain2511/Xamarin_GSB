using System;
using System.Collections.Generic;
using System.Text;

namespace App1
{
    public class Categorie
    {
        public String libelle;
        public Categorie(String pLibelle)
        {
            this.libelle = pLibelle;
        }
        public String getLibelle()
        {
            return this.libelle;
        }    
        
        public override String ToString()
        {
            return this.getLibelle();
        }
    }

}
