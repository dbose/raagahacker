using System;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Text;

namespace RaagaHacker.Playlists
{
    /// <summary>
    /// This class updates the playlists and also updates the 
    /// playlist UI
    /// </summary>
    class PlaylistManager : IDisposable
    {
        private List<Movie> movies;

        public ReadOnlyCollection<Movie> Movies
        {
            get 
            { 
                return movies.AsReadOnly(); 
            }
        }

        public PlaylistManager()
        {
            this.movies = new List<Movie>();
        }

        public PlaylistManager(List<Movie> movies)
        {
            this.movies = new List<Movie>(movies);
        }

        public void AddMovie(Movie movie)
        {
            //Valid movie
            if (movie != null)
            {
                //Movie has some songs
                if (movie.SongCollection.Count != 0)
                {
                    this.movies.Add(movie);
                }
            }
        }


        
        public void Dispose()
        {
            if (this.movies != null)
            {
                movies.Clear();
            }
        }

      
    }

    /// <summary>
    /// Encapsulates a Movie/Album and its Songs
    /// </summary>
    class Movie
    {
        private NameValueCollection songCollection = new NameValueCollection();
        private string movieName;

        public NameValueCollection SongCollection
        {
            get 
            { 
                return new NameValueCollection(songCollection); 
            }
            set
            {
                this.songCollection.Clear();

                if (value != null)
                    this.songCollection.Add(value);  
            }
        }
        

        public string MovieName
        {
            get 
            { 
                return movieName; 
            }
            set 
            { 
                movieName = value; 
            }
        }

        public Movie(string movieName, NameValueCollection songCollection)
        {
            this.movieName = movieName;
            this.songCollection.Clear();
            this.songCollection.Add(songCollection);
        }

        
    }
   
}
