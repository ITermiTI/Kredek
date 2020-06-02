using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace KredekZad1
{
    /// <summary>
    /// Klasa technologii, która pozwala rozszerzać grę o wiele różnych rodzajów technologii
    /// </summary>
    abstract public class Tech
    {
        //Timer do liczenia czasu badań
        protected Timer timerTechnology = new Timer();
        //Flaga sprwadzająca czy już coś odkrywamy z getter-em i setter-em
        protected bool researching;
        public bool Researching { get => researching; set => researching = value; }
        //Czas odkrywania technologii z getter-em i setter-em
        protected int timeToResearch = 40000;
        public int TimeToResearch { get => timeToResearch; set => timeToResearch = value; }
        //Metoda rozpoczynająca odkrywanie technologii
        abstract public void Research(int type);
        //Metoda kończąca odkrywanie technologii
        abstract public void EndResearch();
    }
}
