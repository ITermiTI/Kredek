using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KredekZad1
{
    /// <summary>
    /// Klasa cegielni dziedzicząca po klasie budynek
    /// </summary>
    public class Ironsmith : Building
    {
        /// <summary>
        /// Konstruktor klasy przypisuje koszta budowy, poziom rozbudowy, przychód surowca na minutę i przelicznik
        /// "drożenia" budynku
        /// </summary>
        /// <param name="wood"></param>
        /// <param name="clay"></param>
        /// <param name="iron"></param>
        /// <param name="gold"></param>
        /// <param name="level"></param>
        /// <param name="income"></param>
        /// <param name="buildingFactor"></param>
        public Ironsmith(int wood, int clay, int iron, int gold, int level, int income, float buildingFactor)
        {
            woodCost = wood;
            clayCost = clay;
            ironCost = iron;
            goldCost = gold;
            this.level = level;
            this.income = income;
            factor = buildingFactor;
        }
    }
}
