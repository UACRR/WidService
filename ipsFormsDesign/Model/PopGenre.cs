using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class PopGenre : IPopGenre
    {
        public PopGenre()
        {
            PopGenreTr = new ObservableListSource<PopGenreTr>();
            RelGenreAdapt = new ObservableListSource<RelGenreAdapt>();
            RelGenreMovie = new ObservableListSource<RelGenreMovie>();
            RelGenreSerial = new ObservableListSource<RelGenreSerial>();
            RelPopGenre = new ObservableListSource<RelPopGenre>();
        }

        public int CategoryCode { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }

        public Category CategoryCodeNavigation { get; set; }
        public ObservableListSource<PopGenreTr> PopGenreTr { get; set; }
        public ObservableListSource<RelGenreAdapt> RelGenreAdapt { get; set; }
        public ObservableListSource<RelGenreMovie> RelGenreMovie { get; set; }
        public ObservableListSource<RelGenreSerial> RelGenreSerial { get; set; }
        public ObservableListSource<RelPopGenre> RelPopGenre { get; set; }
    }
}

