using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Antibiotiques : ContentPage
    {
        Categorie Categorie; // déclare la propriété de la classe
        public Antibiotiques(Categorie categ)
        {
            InitializeComponent();
            Categorie = categ;
        }

        private void lvAntibiotiques_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (lvAntibiotiques.SelectedItem != null)
            {
                entPoids.Text = "";
                txtPrescription.Text = "";
                Antibio antibio = lvAntibiotiques.SelectedItem as Antibio;
                if (antibio is AntibioParKilo)
                {
                    txtEntPoids.IsVisible = true;
                    entPoids.IsVisible = true;
                    txtPrescription.IsVisible = true;
                    btnPoids.IsVisible = true;
                }
                else
                {
                    txtPrescription.IsVisible = true;
                    btnPoids.IsVisible = true;
                    //txtNbAntibioParPrise.IsVisible = true;
                }
            }
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            lvAntibiotiques.ItemsSource = DataAntibio.getAntibiotiquesUneCateg(Categorie.getLibelle()).ToList();
        }

        private void btnPoids_Clicked(object sender, EventArgs e)
        {
            //string nbAntibioParPrise = "";
            string message = "";
            if (lvAntibiotiques.SelectedItem != null)
            {
                bool kilosSaisi = false;
                Antibio antibio = lvAntibiotiques.SelectedItem as Antibio;

                if (antibio is AntibioParKilo)
                {
                    if (entPoids.Text != null)
                    {
                        kilosSaisi = true;
                    }
                }
                else
                {
                    kilosSaisi = true;
                }
                if (kilosSaisi)
                {
                    int nombreParJour = antibio.getNombreParJour();

                    if (antibio is AntibioParKilo)
                    {
                        AntibioParKilo d = (AntibioParKilo)antibio;
                        message = "Il faut la quantité de : " + (d.getDoseKilo() * Convert.ToInt32(entPoids.Text)).ToString() + " " + d.getUnite() + " " + nombreParJour.ToString() + " fois par jour";

                    }
                    else
                    {
                        AntibioParPrise d = (AntibioParPrise)antibio;
                        message = "Il faut la quantité de : " + (d.getDosePrise()).ToString() + " " + d.getUnite() + " " + nombreParJour.ToString() + " fois par jour";
                        //nbAntibioParPrise = "Il y a " +  " antibiotiques par prise.";
                    }
                }
                else
                {
                    message = "Veuillez saisir le nombre de kilos";
                }
            }
            else
            {
                message = "Veuillez choisir un antibiotique";
            }
            txtPrescription.Text = message;
            //txtNbAntibioParPrise.Text = nbAntibioParPrise;
        }
    }
}