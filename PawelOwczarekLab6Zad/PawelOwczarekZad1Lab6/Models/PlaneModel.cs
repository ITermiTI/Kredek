using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PawelOwczarekZad1Lab6.Models
{
    //Klasa samolotu
    public class PlaneModel
    {
        //Model samolotu
        public string Model { get; set; }
        //Wykonawca samolotu
        public string Manufacturer { get; set; }
        //Firma posiadajaca samolot
        public string Owner { get; set; }
        //Ile samolot pomiesci pasazerow
        public int PassangerCapacity { get; set; }
        //Zasieg w km
        public float Range { get; set; }
        //Ladownosc paliwa w kg
        public float FuelCapacity { get; set; }
        //Zdjecie
        public string Photo { get; set; }

        public PlaneModel()
        {

        }
        public PlaneModel(string Model,string Manufacturer, string Owner, int PassangerCapacity, float Range, float FuelCapacity,string Photo)
        {
            this.Model = Model;
            this.Manufacturer = Manufacturer;
            this.Owner = Owner;
            this.PassangerCapacity = PassangerCapacity;
            this.FuelCapacity = FuelCapacity;
            this.Range = Range;
            this.Photo = Photo;
        }
        public float calculateFuelBurn()
        {
            return Range / FuelCapacity;
        }

        public string getFullName()
        {
            return Model +" " + Manufacturer+" " + Owner;
        }
    }
}
