using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;

namespace PawelOwczarekLab7Zad.Services
{
    /// <summary>
    /// Serwis dla tabeli Country
    /// </summary>
    public class CountryService : ICountryService
    {
        //Polaczenie z baza
        Lab7Entities DbConnection = new Lab7Entities();
        /// <summary>
        /// Opracja usuniecia rekordu po id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            //Znajdujemy kraj ktory chcemy usunac
            Country countryToDelete = get(id);
            //Jezeli nie ma kraju z takim id to zwracamy falsz
            if (countryToDelete == null) return false;
            //Pobieramy wszystkie miasta ktore naleza do tego kraju aby spelnic wymagania ForeignKeyConstraint
            List<City> citiesInCountry = DbConnection.City.ToList();
            //Usuwamy miasta z tego krau
            foreach(City city in citiesInCountry)
            {
                DbConnection.City.Remove(city);
            }
            //Usuwamy kraj
            DbConnection.Country.Remove(countryToDelete);
            //Zapisujemy zmiany
            DbConnection.SaveChanges();
            return true;
        }
        /// <summary>
        /// Pobranie wsyzstkich krajow z bazy
        /// </summary>
        /// <returns></returns>
        public List<Country> Get()
        {
            return DbConnection.Country.ToList();
        }

        /// <summary>
        /// Pobranie kraju z bazy po ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Country get(int Id)
        {
            return DbConnection.Country.FirstOrDefault(c => c.CountryID==Id);
        }
        /// <summary>
        /// Dodanie nowego kraju do bazy
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        public int Post(Country country)
        {
            Country newCountry = DbConnection.Country.Add(country);
            return newCountry.CountryID;
        }

        /// <summary>
        /// Modyfikacja kraju w bazie
        /// </summary>
        /// <param name="country"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool Put(Country country, int Id)
        {
            //Znalezenie kraju po id
            Country changedCountry = get(Id);
            //Jezeli nie ma takiego kraju to zwracamy falsz
            if (changedCountry == null) return false;
            //Przypisujemy wsyzstkie pola
            changedCountry.CountryName = country.CountryName;
            changedCountry.CountryRating = country.CountryRating;
            changedCountry.Continent = country.Continent;
            //Zapisujemy zmiany
            DbConnection.SaveChanges();
            return true;
        }
    }
}
