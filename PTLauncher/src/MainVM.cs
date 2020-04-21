using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Diagnostics;

using PTLauncher.News;

namespace PTLauncher
{
    public class MainVM
    {
        public static Place selectedPlace;

        private IList<Place> places = new List<Place>();
        public IList<Place> Places { get { return places; } set { places = value; } }

        private IList<GameNews> gameNews = new List<GameNews>();
        public IList<GameNews> GameNews { get { return gameNews; } set { gameNews = value; } }

        public Place SelectedPlace
        {
            get { return selectedPlace; }
            set
            {
                selectedPlace = value;
                Debug.WriteLine(value);
            }
        }

        private int cityID;
        public int CityID { get { return cityID; } set { cityID = value; } }
        //private string selectedValuePath = "ID";

        //public static string language = Place;

        public string SelectedValuePath
        {
            get
            {
                return "ID";
            }
        }

        public string Name { get; set; }


        public MainVM()
        {
            PopulateComoboBoxes();
            ObtainGameNews();
        }

        /// <summary>
        /// The function can be used to populate all the collection properties from any datasource
        /// </summary>
        private void PopulateComoboBoxes()
        {
            Places = new List<Place>() { new Place(){ID =1, City = "English", Country = "lang=en"},
            new Place(){ID= 2, City = "German", Country = "lang=de"},
            new Place(){ID = 3 ,City = "French", Country = "lang=fr"},
            new Place(){ID = 4, City = "Russian", Country = "lang=ru"}};
            //  new Place(){ID =5, City = "Paris", Country = "France"}};


            //This is the case for SelectedValue and selectedValuePath

        }

        private void ObtainGameNews()
        {
            GameNews.Obtainer obtainer = new GameNews.Obtainer();
            GameNews = obtainer.GameNews;
        }

    }

    public class Place
    {
        public int ID { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public override string ToString()
        {
            return Country;   
        }
    }

}
