using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KredekZad1
{
    /// <summary>
    /// Formularz technologii służacy do badania i wyswietlania obecnego statusu badań
    /// </summary>
    public partial class FormTechnologies : Form
    {
        //Technologia, która będzie przyjmowała jedną z postaci - może być badana tylko jedna na raz
        Tech technology;
        //Typ badanej technologii
        int type;
        //Technologia militarna - tutaj znajduje się nasz obecny rozwój technologii militarnej
        MilitaryTech military;
        //Technologia ekonomiczna - tutaj znajduje się nasz obecny rozwój technologii ekonomicznej
        CommercialTech commercial;        

        /// <summary>
        /// Konstruktor, który inicjalizuje okno, "przypomina" nasz rozwój a następnie wstawia obdpowiednie wartości w label-ach
        /// </summary>
        /// <param name="milTech"></param>
        /// <param name="comTech"></param>
        public FormTechnologies(ref MilitaryTech milTech,ref CommercialTech comTech)
        {
            InitializeComponent();
            military = milTech;
            commercial = comTech;
            SetLabels();
        }

        /// <summary>
        /// Funkcja wpisująca wartości w label-e
        /// </summary>
        public void SetLabels()
        {
            labelInfantryLevel.Text = military.InfantryTechLevel.ToString();
            labelCavalryLevel.Text = military.CavalryTechLevel.ToString();
            labelArcherLevel.Text = military.ArcherTechLevel.ToString();

            labelCarpenterLevel.Text = commercial.CarpenterTechLevel.ToString();
            labelBrickYardLevel.Text = commercial.BrickyardTechLevel.ToString();
            labelIronSmithLevel.Text = commercial.IronsmithTechLevel.ToString();
            labelCoinmakerLevel.Text = commercial.CoinmakerTechLevel.ToString();
        }

        /// <summary>
        /// Naciśnięcie przycisku badaj technologię militarną
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonMilitaryTech_Click(object sender, EventArgs e)
        {
            //Jeżeli technologia jest już technologią militarną to oznacza, że obecnie badamy już tą technologię
            if(!(technology is MilitaryTech))
            {
                //Jeżeli technologia jest już technologią ekonomiczną to oznacza, że obecnie badamy już tą technologię
                if (!(technology is CommercialTech))
                {
                    if (radioButtonInfantry.Checked) type = 0;
                    if (radioButtonCavalry.Checked) type = 1;
                    if (radioButtonArcher.Checked) type = 2;                    
                    technology = military;
                    technology.Research(type);
                }
                else
                {
                    MessageBox.Show("Obecnie badasz technologie ekonomiczną!");
                }
            }
            else
            {
                MessageBox.Show("Obecnie badasz już technologie militarną!");
                
            }
        }
        /// <summary>
        /// Naciśnięcie przycisku badaj technologię ekonomiczną
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCommercial_Click(object sender, EventArgs e)
        {
            //Jeżeli technologia jest już technologią ekonomiczną to oznacza, że obecnie badamy już tą technologię
            if (!(technology is CommercialTech))
            {
                //Jeżeli technologia jest już technologią militarną to oznacza, że obecnie badamy już tą technologię
                if (!(technology is MilitaryTech))
                {
                    if (radioButtonCarpenter.Checked) type = 0;
                    if (radioButtonBrickyard.Checked) type = 1;
                    if (radioButtonIronsmith.Checked) type = 2;
                    if (radioButtonCoinmaker.Checked) type = 3;                    
                    technology = commercial;
                    technology.Research(type);
                }
                else
                {
                    MessageBox.Show("Obecnie badasz technologie militarną!");
                    
                }
            }
            else
            {
                MessageBox.Show("Obecnie badasz już technologie ekonomiczną!");
            }
        }
        
    }
}
