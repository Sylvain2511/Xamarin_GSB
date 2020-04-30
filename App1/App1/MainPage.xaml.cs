using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            recuperation();
        }

        private void lvCategories_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (lvCategories.SelectedItem != null)
            {
                Categorie c = lvCategories.SelectedItem as Categorie;
                Navigation.PushAsync(new Antibiotiques(c));
            }
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            
        }

        public async void recuperation()

        {
            HttpClient wc = new HttpClient();
            HttpResponseMessage reponse = await wc.GetAsync(new Uri("https://mobilegsb.000webhostapp.com/api/categories.php", UriKind.Absolute));
            string json = reponse.Content.ReadAsStringAsync().Result;
            List<Categorie> unelisteCategorie = null;
            unelisteCategorie = JsonConvert.DeserializeObject<List<Categorie>>(json);
            DataAntibio.setLesCategories(unelisteCategorie);
            lvCategories.ItemsSource = unelisteCategorie.ToList();


            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Auto
            };
           
            HttpResponseMessage antibioResponse = await wc.GetAsync(new Uri("https://mobilegsb.000webhostapp.com/api/antibiotiques.php", UriKind.Absolute));
            string antibioJson = antibioResponse.Content.ReadAsStringAsync().Result;
            List<Antibio> uneListeAntibio = null;
            uneListeAntibio = JsonConvert.DeserializeObject<List<Antibio>>(antibioJson, settings).ToList();
            DataAntibio.setLesAntibiotiques(uneListeAntibio);
            // sert à récuperer les antibio et la catégories, et les mets dans les listes views
        }
    }
}
