using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;

namespace PawelOwczarekLab7Zad.Services
{
    /// <summary>
    /// Klasa serwisu dla tabeli City
    /// </summary>
    public class CityService : ICityService
    {
        //Polaczenie z baza
        Lab7Entities DbConnection = new Lab7Entities();
        /// <summary>
        /// Usuwanie rekordu po ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            //Pobranie miasta po ID
            City cityToDelete = get(id);
            //Jezeli nie ma takiego maista to zwracamy falsz
            if (cityToDelete == null) return false;
            //Usuwamy miasto
            DbConnection.City.Remove(cityToDelete);
            //Zapisujemy zmiany
            DbConnection.SaveChanges();
            return true;
        }

        /// <summary>
        /// Pobranie wszystkich miast z bazy
        /// </summary>
        /// <returns></returns>
        public List<City> Get()
        {
            return DbConnection.City.ToList();
        }

        /// <summary>
        /// Pobranie miasta z bazy po ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public City get(int Id)
        {
            return DbConnection.City.FirstOrDefault(c =>c.CityId==Id);
        }

        /// <summary>
        /// Dodanie nowego miasta do bazy
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        public int Post(City city)
        {
           City newCity = DbConnection.City.Add(city);
            return newCity.CityId;
        }

        /// <summary>
        /// Modyfikacja miasta w bazie
        /// </summary>
        /// <param name="city"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool Put(City city, int Id)
        {
            //Znajdujemy miasto do zmiany
            City changedCity = get(Id);
            //Jezeli takiego nie ma to zwracamy falsz
            if (changedCity == null) return false;
            //Przypisujemy wszystkie pola
            changedCity.CityName = city.CityName;
            changedCity.CityRating = city.CityRating;
            changedCity.Country = city.Country;
            changedCity.CountryID = city.CountryID;
            //Zapisujemy zmiany
            DbConnection.SaveChanges();
            return true;
        }
    }
}
