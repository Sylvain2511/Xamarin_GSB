using System;
using System.Collections.Generic;
using System.Text;

namespace App1
{
    public class AntibioParKilo : Antibio
    {
        public int doseKilo;
        public AntibioParKilo(String pLibelle, String pUnite, int pNombre, Categorie pCategorie, int pDoseKilo) : base(pLibelle, pUnite, pNombre, pCategorie)
        {            
            this.doseKilo = pDoseKilo;
        }
        public int getDoseKilo()
        {
            return this.doseKilo;
        }

    }
}
