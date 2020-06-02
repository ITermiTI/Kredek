using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KredekZad1
{
    /// <summary>
    /// Klasa jednostki łucznika dziedzicząca po klasie jednostka
    /// </summary>
    public class Infantry : Unit
    {
        /// <summary>
        /// Konstruktor, który przypisuje siłę jednostki
        /// </summary>
        /// <param name="infStr"></param>
        /// <param name="cavStr"></param>
        /// <param name="arcStr"></param>
        public Infantry(int infStr, int cavStr, int arcStr)
        {
            VsInfantryStrength = infStr;
            VsCavalryStrength = cavStr;
            vsArcherStrength = arcStr;
        }

        /// <summary>
        /// Rekrutacja jednostek - zwracana jest lista jednostek o określonej sile, oraz odejmowane są koszta surowców
        /// jeżeli gracza stać na rekrutację wybranej liczby jednostek
        /// </summary>
        /// <param name="wood"></param>
        /// <param name="clay"></param>
        /// <param name="iron"></param>
        /// <param name="gold"></param>
        /// <param name="amount"></param>
        /// <param name="infStr"></param>
        /// <param name="cavStr"></param>
        /// <param name="arcStr"></param>
        /// <returns></returns>
        public override List<Unit> Recruit(ref int wood,ref int clay,ref int iron,ref int gold, int amount,
                                                int infStr, int cavStr, int arcStr)
        {
            if (wood >= woodCost * amount && clay >= clayCost * amount &&
                     iron >= ironCost * amount && gold >= goldCost * amount)
            {
                wood -= woodCost * amount;
                clay -= clayCost * amount;
                iron -= ironCost * amount;
                gold -= goldCost * amount;                
                List<Unit> recruited = new List<Unit>();
                for(int i=0;i<amount;i++)
                {
                    recruited.Add(new Infantry(infStr,cavStr,arcStr));
                }
                return recruited;
            }
            else
            {
                MessageBox.Show("Brak surowców na zrekrutowanie podanej ilości jednostek!",
                    "Niestety", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
                return null;
            }
        }
    }
}
