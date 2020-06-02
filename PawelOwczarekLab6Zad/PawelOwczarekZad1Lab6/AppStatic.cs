using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PawelOwczarekZad1Lab6.Models;

namespace PawelOwczarekZad1Lab6
{
    /// <summary>
    /// Klasa statyczna przetrzymujaca obiekt autora i samolotow w celu zapobiegnieciu wielokrotnemu dodawania elementow - kontroler jest
    /// tworzony za kazdym razem kiedy pobierzemy nowy widok - jego zaleznosc nie jest wstrzykiwana
    /// </summary>
    public static class AppStatic
    {
        public static AuthorViewModel author = new AuthorViewModel("Pawel","Owczarek","ITermiTI");
        public static List<PlaneModel> planes = new List<PlaneModel>{
            new PlaneModel("Boeing 747 400", "Boeing", "Ryanair", 568, 13450, 216840, "~/boeing747400.jpg"),
             new PlaneModel("A-10 Thunderbolt", "Fairchild-Aircraft", "USAF", 1, 4148, 4853, "~/A10Thunderbolt.jpg"),
            new PlaneModel("Airbus A380 900", "Airbus", "Lufthansa", 900, 15200, 259200, "~/AirbusA380900.jpg"),
            new PlaneModel("Boeing 737 MAX", "Boeing", "Wizzair", 200, 5925, 29680, "~/boeing737MAX.jpg"),
            new PlaneModel("McDonnellDouglas DC-9", "McDonnell", "KLM", 106, 3815, 13381, "~/McDonnellDouglasDC-9.jpg"),
            new PlaneModel("Mig 29", "Sokol", "SPRP", 1, 1750, 2140, "~/mig29.jpg")
        };
    }
}
