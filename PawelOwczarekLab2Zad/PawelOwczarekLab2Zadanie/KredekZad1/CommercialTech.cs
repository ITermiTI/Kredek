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
    /// Klasa technologii ekonomicznej dziedzicząca po klasie technologii
    /// </summary>
    public class CommercialTech : Tech
    {
        //Typ budynku, którego badamy
        int type;
        //Poziom technologii tartaku z getter-em i setter-em
        private int carpenterTechLevel = 0;
        public int CarpenterTechLevel { get => carpenterTechLevel; set => carpenterTechLevel = value; }
        //Poziom technologii cegielni z getter-em i setter-em
        private int brickyardTechLevel = 0;
        public int BrickyardTechLevel { get => brickyardTechLevel; set => brickyardTechLevel = value; }
        //Poziom technologii huty z getter-em i setter-em
        private int ironsmithTechLevel = 0;
        public int IronsmithTechLevel { get => ironsmithTechLevel; set => ironsmithTechLevel = value; }
        //Poziom technologii mennicy z getter-em i setter-em
        private int coinmakerTechLevel = 0;
        public int CoinmakerTechLevel { get => coinmakerTechLevel; set => coinmakerTechLevel = value; }

        /// <summary>
        /// Metoda wykonywująca się, gdy badanie zostanie zakończone - dodaje poziom technologii i oblicza czas badania następnej
        /// </summary>
        public override void EndResearch()
        {
            switch(type)
            {
                case 0: carpenterTechLevel++;break;
                case 1: brickyardTechLevel++;break;
                case 2: ironsmithTechLevel++;break;
                case 3: coinmakerTechLevel++;break;
            }
            float temp = TimeToResearch * 1.1f;
            TimeToResearch = (int) temp;
            MessageBox.Show("Zbadano technologie ekonomiczną!");
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

        /// <summary>
        /// Funkcja opisująca tyknięcie zegara technologii - jej odkrycie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerTechnology_Tick(object sender, ElapsedEventArgs e)
        {
            timerTechnology.Stop();
            EndResearch();


        }
    }
}
