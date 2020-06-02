using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace KredekZad1
{
    /// <summary>
    /// Klasa technologii militarnej dziedzicząca po klasie technologii
    /// </summary>
    public class MilitaryTech : Tech
    {
        //Typ jednostki, którą badamy
        int type;
        //Poziom technologii piechoty z getter-em i setter-em
        private int infantryTechLevel = 0;
        public int InfantryTechLevel { get => infantryTechLevel; set => infantryTechLevel = value; }
        //Poziom technologii kawalerii z getter-em i setter-em
        private int cavalryTechLevel = 0;
        public int CavalryTechLevel { get => cavalryTechLevel; set => cavalryTechLevel = value; }
        //Poziom technologii łuczników z getter-em i setter-em
        private int archerTechLevel = 0;
        public int ArcherTechLevel { get => archerTechLevel; set => archerTechLevel = value; }

        /// <summary>
        /// Metoda wykonywująca się, gdy badanie zostanie zakończone - dodaje poziom technologii i oblicza czas badania następnej
        /// </summary>
        public override void EndResearch()
        {
            switch (type)
            {
                case 0: infantryTechLevel++; break;
                case 1: cavalryTechLevel++; break;
                case 2: archerTechLevel++; break;
            }
            MessageBox.Show("Zbadano technologie militarna!");
            researching = false;
            float temp = TimeToResearch * 1.1f;
            TimeToResearch = (int)temp;
        }
        /// <summary>
        /// Metoda inicjująca badanie - startująca zegar
        /// </summary>
        /// <param name="type"></param>
        public override void Research(int type)
        {
            this.type = type;
            timerTechnology.Elapsed += new System.Timers.ElapsedEventHandler(timerTechnology_Tick);
            timerTechnology.Interval = timeToResearch;
            timerTechnology.Start();
        }
        private void timerTechnology_Tick(object sender, ElapsedEventArgs e)
        {
            timerTechnology.Stop();
            EndResearch();                    
            
        }
    }
}
