using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectCentral.Areas.OlympicGames.Models.Session
{
    public class FavoritesSessionModel
    {
        private readonly ISession session;
        //assigns session
        public FavoritesSessionModel(ISession session)
        {
            this.session = session;
        }
        //sets the favorites in session
        public void SetFavorites(List<Country> countries)
        {
            session.SetString("Favorites", JsonConvert.SerializeObject(countries));
        }
        //gets favorites from session. if favorites does not exist in session, return null
        public List<Country> GetFavorites()
        {
            List<Country> Favorites;
            if (session.Keys.Contains("Favorites"))
            {
                Favorites = JsonConvert.DeserializeObject<List<Country>>(session.GetString("Favorites"));
            }
            else
            {
                Favorites = null;
            }
            return Favorites;
        }
        //if favorites is not null, and country exists inside favorites, return true. otherwise false
        public bool IsFavorite(Country country)
        {
            bool? value = GetFavorites()?.Find(c => c.CountryName == country.CountryName)
                == null? false : true;
            return value != null? value.Value : false;
        }
    }
}
