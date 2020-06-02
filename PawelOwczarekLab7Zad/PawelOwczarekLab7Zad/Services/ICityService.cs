using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;

namespace PawelOwczarekLab7Zad.Services
{
    //Interfejs do obslugi serwisu dla tabeli City
    interface ICityService
    {
        //Pobranie wszystkich
        List<City> Get();
        //Pobranie po Id
        City get(int Id);
        //Dodanie nowego miasta
        int Post(City city);
        //Modyfikacja miasta
        bool Put(City city, int Id);
        //Usuniecie miasta
        bool Delete(int id);
    }
}
