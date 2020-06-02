using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KredekZad1
{
    /// <summary>
    /// Klasa wydarzeń odpowiadająca za losowe wydarzenie w grze
    /// </summary>
    public class Event
    {
        /// <summary>
        /// Wydarzenie plotki odejmujące poparcie
        /// </summary>
        /// <param name="support"></param>
        public void EventGossip(ref int support)
        {
            MessageBox.Show("Ktoś puścił o tobie nieprzyjemną plotkę...\n Tracisz 15 poparcia");
            support -= 15;
        }

        /// <summary>
        /// Wydarzenie kradzieży odejmujące część surowców
        /// </summary>
        /// <param name="wood"></param>
        /// <param name="clay"></param>
        /// <param name="iron"></param>
        /// <param name="gold"></param>
        public void EventTheft(ref int wood, ref int clay, ref int iron, ref int gold)
        {
            MessageBox.Show("Częśc twoich surowców została skradziona!");
            float temp;
            temp = (float)wood * 0.2f;
            wood -= (int)temp;
            temp = (float)clay * 0.2f;
            clay -= (int)temp;
            temp = (float)iron * 0.2f;
            iron -= (int)temp;
            temp = (float)gold * 0.2f;
            gold -= (int)temp;
        }

        /// <summary>
        /// Wydarzenie polityczne odejmujące poparcie
        /// </summary>
        /// <param name="support"></param>
        public void EventPoliticalAffair(ref int support)
        {
            MessageBox.Show("Przez przypadek obrażasz swoich rodaków co oznacza katastrofę polityczną...\nTracisz 40 poparcia");
            support -= 40;
        }

        /// <summary>
        /// Wydarzenie plagii zabijającej część żołnierzy
        /// </summary>
        /// <param name="infantry"></param>
        /// <param name="cavalry"></param>
        /// <param name="archers"></param>
        public void EventPlague(ref List<Unit> infantry, ref List<Unit> cavalry, ref List<Unit> archers)
        {
            MessageBox.Show("Plaga!! Umiera częśc twoich żołnierzy!");
            float temp;
            temp = (float)infantry.Count * 0.12f;
            if(temp != 0)
                infantry.RemoveRange(infantry.Count - (int)temp - 1, (int)temp);
            temp = (float)cavalry.Count * 0.12f;
            if (temp != 0)
                cavalry.RemoveRange(cavalry.Count - (int)temp - 1, (int)temp);
            temp = (float)archers.Count * 0.12f;
            if (temp != 0)
                archers.RemoveRange(cavalry.Count - (int)temp - 1, (int)temp);
        }

        /// <summary>
        /// Wydarzenie zyskania popularności
        /// </summary>
        /// <param name="support"></param>
        public void EventPopularityGain(ref int support)
        {
            MessageBox.Show("Lud się raduje twoimi dokonaniami! Twoje poparcie wzrasta!");
            support += 10;
        }


    }
}
