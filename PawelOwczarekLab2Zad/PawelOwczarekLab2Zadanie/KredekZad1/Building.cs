using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KredekZad1
{
    /// <summary>
    /// Klasa budynek - podstawa pod tworzenie nowych budynków
    /// </summary>
    public abstract class Building
    {
        //Zmienna opisująca koszt drewna za rozbudowę budynku wraz z getter-em i setter-em
        protected int woodCost;
        public int WoodCost { get => woodCost; set => woodCost = value; }
        //Zmienna opisująca koszt gliny za rozbudowę budynku wraz z getter-em i setter-em
        protected int clayCost;
        public int ClayCost { get => clayCost; set => clayCost = value; }
        //Zmienna opisująca koszt żelaza za rozbudowę budynku wraz z getter-em i setter-em
        protected int ironCost;
        public int IronCost { get => ironCost; set => ironCost = value; }
        //Zmienna opisująca koszt złota za rozbudowę budynku wraz z getter-em i setter-em
        protected int goldCost;
        public int GoldCost { get => goldCost; set => goldCost = value; }
        //Zmienna opisująca przychód surowca po rozbudowie budynku wraz z getter-em i setter-em
        protected int income;
        public int Income { get => income; set => income = value; }
        //Zmienna opisująca poziom rozbudowania budynku wraz z getter-em i setter-em
        protected int level;
        public int Level { get => level; set => level = value; }
        //Zmienna opisująca przelicznik kosztów za kolejną rozbudowę budynku wraz z getter-em i setter-em
        protected float factor;
        public float Factor { get => factor; set => factor = value; }
        /// <summary>
        /// Metoda obliczająca interwał do zegara danego surowca
        /// </summary>
        /// <param name="currentInterval"></param>
        /// <returns></returns>
        virtual public int CountInterval(float currentInterval)
        {
            float countInterval = (60 / (float)income) * 1000;
            return (int)countInterval;
        }
        /// <summary>
        /// Metoda obliczająca kolejny koszt rozbudowy
        /// </summary>
        virtual public void CalcalateNewCosts()
        {
            float calculate = 1;
            calculate = factor * (float)woodCost;
            woodCost = (int)calculate;
            calculate = factor * (float)clayCost;
            clayCost = (int)calculate;
            calculate = factor * (float)ironCost;
            ironCost = (int)calculate;
            calculate = factor * (float)goldCost;
            goldCost = (int)calculate;
        }
        /// <summary>
        /// Metoda rozbudowywująca budynek
        /// </summary>
        /// <param name="wood"></param>
        /// <param name="clay"></param>
        /// <param name="iron"></param>
        /// <param name="gold"></param>
        /// <param name="techInfluence"></param>
        virtual public void Build(ref int wood,ref int clay,ref int iron,ref int gold, int techInfluence)
        {
            //Jeżeli gracza stać na rozbudowę to ją wykonujemy - obliczamy nowy przychód surowca,
            //odejmujemy koszty surowców i generujemy nastepne koszy
            if (wood >= woodCost && clay >= clayCost && iron >= ironCost && gold >= goldCost)
            {
                this.level++;
                wood -= woodCost;
                clay -= clayCost;
                iron -= ironCost;
                gold -= goldCost;
                float calculate = (1.2f+(0.035f * techInfluence)) * (float)income;
                income = (int)calculate;
                this.CalcalateNewCosts();
            }
            else
            {
                MessageBox.Show("Brak surowców na wybudowanie tego budynku!",
                        "Niestety", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
