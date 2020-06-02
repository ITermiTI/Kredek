using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;

namespace PawelOwczarekLab7Zad.Services
{
    //Interfejs do obslugi serwisu dla klasy Countries
    interface ICountryService
    {
        //Pobranie calosci
        List<Country> Get();
        //Pobranie po Id
        Country get(int Id);
        //Dodanie nowego kraju
        int Post(Country country);
        //Modyfikacja kraju
        bool Put(Country country, int Id);
        //Usuniecie kraju
        bool Delete(int id);
    }
}
