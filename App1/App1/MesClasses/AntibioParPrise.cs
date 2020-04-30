using System;
using System.Collections.Generic;
using System.Text;

namespace App1
{
    public class AntibioParPrise : Antibio
    {
        public int dosePrise;

        public AntibioParPrise(String pLibelle, String pUnite, int pNombre,Categorie pCategorie, int pDosePrise) : base(pLibelle, pUnite, pNombre, pCategorie)
        {            
            this.dosePrise = pDosePrise;
        }
        public int getDosePrise()
        {
            return this.dosePrise;
        }
        

    }
}
