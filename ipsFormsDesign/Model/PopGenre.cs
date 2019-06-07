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

        public virtual Category CategoryCodeNavigation { get; set; }
        public virtual ObservableListSource<PopGenreTr> PopGenreTr { get; set; }
        public virtual ObservableListSource<RelGenreAdapt> RelGenreAdapt { get; set; }
        public virtual ObservableListSource<RelGenreMovie> RelGenreMovie { get; set; }
        public virtual ObservableListSource<RelGenreSerial> RelGenreSerial { get; set; }
        public virtual ObservableListSource<RelPopGenre> RelPopGenre { get; set; }
    }
}

