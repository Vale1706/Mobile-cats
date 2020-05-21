﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace verde.valeria._5g.Mobilecats
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Aggiorna();
        }

        async void Aggiorna()
        {
            List<Cat> cats = new List<Cat>();
            List<Cat> cats1 = new List<Cat>();
            try
            {
                HttpClient client = new HttpClient();
                
                
                for (int cnt = 0; cnt < 10; cnt++)
                {
                    string response = await client.GetStringAsync(
                                         "https://api.thecatapi.com/v1/images/search");
                    cats = JsonConvert.DeserializeObject<List<Cat>>(response);
                    cats1.Add(cats[0]);

                }
            }
            catch (Exception err)
            {
                await DisplayAlert("Ocio!!", err.Message, "Ok");
            }
            lvDati.ItemsSource = cats1;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Aggiorna();
        }
    }

    public class Weight
    {
        public string imperial { get; set; }
        public string metric { get; set; }
    }

    public class Breed
    {
        public Weight weight { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string vetstreet_url { get; set; }
        public string temperament { get; set; }
        public string origin { get; set; }
        public string country_codes { get; set; }
        public string country_code { get; set; }
        public string description { get; set; }
        public string life_span { get; set; }
        public int indoor { get; set; }
        public int lap { get; set; }
        public string alt_names { get; set; }
        public int adaptability { get; set; }
        public int affection_level { get; set; }
        public int child_friendly { get; set; }
        public int dog_friendly { get; set; }
        public int energy_level { get; set; }
        public int grooming { get; set; }
        public int health_issues { get; set; }
        public int intelligence { get; set; }
        public int shedding_level { get; set; }
        public int social_needs { get; set; }
        public int stranger_friendly { get; set; }
        public int vocalisation { get; set; }
        public int experimental { get; set; }
        public int hairless { get; set; }
        public int natural { get; set; }
        public int rare { get; set; }
        public int rex { get; set; }
        public int suppressed_tail { get; set; }
        public int short_legs { get; set; }
        public string wikipedia_url { get; set; }
        public int hypoallergenic { get; set; }
    }

    public class Cat
    {
        public List<Breed> breeds { get; set; }
        public string id { get; set; }
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }

        public string Stato { get; set; }
    }
}
