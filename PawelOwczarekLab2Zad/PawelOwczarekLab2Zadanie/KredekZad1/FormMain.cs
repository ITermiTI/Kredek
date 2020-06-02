using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace KredekZad1
{
    /// <summary>
    /// Klasa okna głownego
    /// </summary>
    public partial class FormMain : Form
    {
        //Zmienna przetrzymująca ilość posiadanego drewna
        int wood=30;
        //Zmienna przetrzymująca ilość posiadanej gliny
        int clay=30;
        //Zmienna przetrzymująca ilość posiadanego żelaza
        int iron=30;
        //Zmienna przetrzymująca ilość posiadanego złota
        int gold=30;
        //Lista przetrzymująca jednostki piechoty
        List<Unit> infantry= new List<Unit>();
        //Lista przetrzymująca jednostki kawalerii
        List<Unit> cavalry = new List<Unit>();
        //Lista przetrzymująca jednostki łuczników
        List<Unit> archers = new List<Unit>();
        //Lista przetrzymująca jednostki piechoty wroga
        List<Unit> enemyInfantry = new List<Unit>();
        //Lista przetrzymująca jednostki kawalerii wroga
        List<Unit> enemyCavalry = new List<Unit>();
        //Lista przetrzymująca jednostki łuczników wroga
        List<Unit> enemyArchers = new List<Unit>();
        //Obiekt przetrzymujący postęp technologiczny militarny
        MilitaryTech militaryTechnology = new MilitaryTech();
        //Obiekt przetrzymujący postęp technologiczny ekonomiczny
        CommercialTech commercialTech = new CommercialTech();
        //Obiekt tartaku
        Building carpenter;
        //Obiekt cegielni
        Building brickyard;
        //Obiekt huty
        Building ironsmith;
        //Obiekt mennicy
        Building coinmaker;
        //Obiekt piechoty
        Unit infantryUnit;
        //Obiekt kawalerii
        Unit cavalryUnit;
        //Obiekt łucznika
        Unit archerUnit;
        //Obiekt wydarzeń
        Event happening = new Event();

        //Zmienna przetrzymująca wysokość poparcia
        int support = 100;
        //Konstruktor formularza, ustawiamy wszystkie wartości w label-ach, oraz tworzymy obiekty budynków, następnie ustalamy częstotliwość
        //timerów i je startujemy
        public FormMain()
        {
            InitializeComponent();
            LoadBuildingsSetUp(1, 1, 1, 1);
            
            labelArcherAmount.Text = archers.Count.ToString();
            labelInfantryAmount.Text = infantry.Count.ToString();
            labelCavalryAmount.Text = cavalry.Count.ToString();
            refreshStorage();           

            infantryUnit = new Infantry(10, 18, 2);
            infantryUnit.SetCosts(5, 7, 2, 5 );
            cavalryUnit = new Cavalry(11, 14, 50);
            cavalryUnit.SetCosts(8, 6, 20, 20);
            archerUnit = new Archer(20, 2, 10);
            archerUnit.SetCosts(11, 3, 5, 6 );            
            
            labelArcWoodCost.Text = archerUnit.WoodCost.ToString();
            labelArcClayCost.Text = archerUnit.ClayCost.ToString();
            labelArcIronCost.Text = archerUnit.IronCost.ToString();
            labelArcGoldCost.Text = archerUnit.GoldCost.ToString();

            labelInfWoodCost.Text = infantryUnit.WoodCost.ToString();
            labelInfClayCost.Text = infantryUnit.ClayCost.ToString();
            labelInfIronCost.Text = infantryUnit.IronCost.ToString();
            labelInfGoldCost.Text = infantryUnit.GoldCost.ToString();

            labelCavWoodCost.Text = cavalryUnit.WoodCost.ToString();
            labelCavClayCost.Text = cavalryUnit.ClayCost.ToString();
            labelCavIronCost.Text = cavalryUnit.IronCost.ToString();
            labelCavGoldCost.Text = cavalryUnit.GoldCost.ToString();

            for (int i = 0; i < 8; i++)
                enemyInfantry.Add(new Infantry(infantryUnit.VsInfantryStrength, infantryUnit.VsCavalryStrength,
                                    infantryUnit.VsArcherStrength));
            for (int i = 0; i < 4; i++)
                enemyCavalry.Add(new Cavalry(cavalryUnit.VsInfantryStrength, cavalryUnit.VsCavalryStrength,
                                    cavalryUnit.VsArcherStrength));
            for (int i = 0; i < 6; i++)
                enemyArchers.Add(new Archer(archerUnit.VsInfantryStrength, archerUnit.VsCavalryStrength,
                                    archerUnit.VsArcherStrength));

            string[] items = { "Tartak", "Cegielnia", "Huta", "Mennica" };
            comboBoxBuild.Items.AddRange(items);
            comboBoxBuild.SelectedIndex = 0;         

            timerRaid.Interval = 160000;
            timerSupport.Interval = 55000;
            timerEvent.Interval = 45000;            
            timerRaid.Start();
            timerSupport.Start();
            timerEvent.Start();
        }

        /// <summary>
        /// Funkcja pomagająca ustawić opis w label-ach dotyczący budynków, oraz wystartować timer-y - przy wczytaniu i otwarciu gry
        /// </summary>
        /// <param name="carpenterLevel"></param>
        /// <param name="brickyardLevel"></param>
        /// <param name="ironsmithLevel"></param>
        /// <param name="coinmakerLevel"></param>
        private void LoadBuildingsSetUp(int carpenterLevel, int brickyardLevel, int ironsmithLevel, int coinmakerLevel)
        {
            carpenter = new Carpenter(14, 25, 11, 17, 1, 30, 1.32f);
            brickyard = new Brickyard(20, 16, 9, 11, 1, 30, 1.36f);
            ironsmith = new Ironsmith(19, 18, 7, 22, 1, 30, 1.45f);
            coinmaker = new Coinmaker(14, 16, 16, 14, 1, 30, 1.41f);

            for(int i=0;i<carpenterLevel - 1;i++)
            {
                carpenter.CalcalateNewCosts();
                carpenter.Level++;
                float calculate = 1.2f * (float)carpenter.Income;
                carpenter.Income = (int)calculate;
            }
            for (int i = 0; i < brickyardLevel - 1; i++)
            {
                brickyard.CalcalateNewCosts();
                brickyard.Level++;
                float calculate = 1.2f * (float)brickyard.Income;
                brickyard.Income = (int)calculate;
            }
            for (int i = 0; i < ironsmithLevel - 1; i++)
            {
                ironsmith.CalcalateNewCosts();
                ironsmith.Level++;
                float calculate = 1.2f * (float)ironsmith.Income;
                ironsmith.Income = (int)calculate;
            }
            for (int i = 0; i < coinmakerLevel - 1; i++)
            {
                coinmaker.CalcalateNewCosts();
                coinmaker.Level++;
                float calculate = 1.2f * (float)coinmaker.Income;
                coinmaker.Income = (int)calculate;
            }

            labelCarpenterLevel.Text = carpenter.Level.ToString();
            labelBrickYardLevel.Text = brickyard.Level.ToString();
            labelIronSmithLevel.Text = ironsmith.Level.ToString();
            labelCoinmakerLevel.Text = coinmaker.Level.ToString();

            setBuildingCostLabels(carpenter);

            labelWoodPerMinute.Text = carpenter.Income.ToString();
            labelClayPerMinute.Text = brickyard.Income.ToString();
            labelIronPerMinute.Text = ironsmith.Income.ToString();
            labelGoldPerMinute.Text = coinmaker.Income.ToString();

            float countInterval = (60 / (float)carpenter.Income) * 1000;
            timerWood.Interval = (int)countInterval;

            countInterval = (60 / (float)brickyard.Income) * 1000;
            timerClay.Interval = (int)countInterval;

            countInterval = (60 / (float)ironsmith.Income) * 1000;
            timerIron.Interval = (int)countInterval;

            countInterval = (60 / (float)coinmaker.Income) * 1000;
            timerGold.Interval = (int)countInterval;

            timerWood.Start();
            timerClay.Start();
            timerIron.Start();
            timerGold.Start();
        }
        /// <summary>
        /// Funkcja odświeżająca ilość posiadanych surowców
        /// </summary>
        private void refreshStorage()
        {
            labelWoodAmount.Text = wood.ToString();
            labelClayAmount.Text = clay.ToString();
            labelIronAmount.Text = iron.ToString();
            labelGoldAmount.Text = gold.ToString();
        }
        /// <summary>
        /// Funkcja ustawiająca etykiety kosztów rozbudowy budynków
        /// </summary>
        private void setBuildingCostLabels(Building building)
        {
            labelCarWoodCost.Text = building.WoodCost.ToString();
            labelCarClayCost.Text = building.ClayCost.ToString();
            labelCarIronCost.Text = building.IronCost.ToString();
            labelCarGoldCost.Text = building.GoldCost.ToString();
        }

        

        /// <summary>
        /// Tykanie zegara odpowiadającego za wydobycie drewna
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerWood_Tick(object sender, EventArgs e)
        {
            wood++;
            labelWoodAmount.Text = wood.ToString();
        }

        /// <summary>
        /// Tykanie zegara odpowiadającego za wydobycie gliny
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerClay_Tick(object sender, EventArgs e)
        {
            clay++;
            labelClayAmount.Text = clay.ToString();
        }

        /// <summary>
        /// Tykanie zegara odpowiadającego za wydobycie żelaza
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerIron_Tick(object sender, EventArgs e)
        {
            iron++;
            labelIronAmount.Text = iron.ToString();
        }

        /// <summary>
        /// Tykanie zegara odpowiadającego za wydobycie złota
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerGold_Tick(object sender, EventArgs e)
        {
            gold++;
            labelGoldAmount.Text = gold.ToString();
        }

        /// <summary>
        /// Tykanie zegara odpowiadającego za atak zbójów na naszą wioskę
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerRaid_Tick(object sender, EventArgs e)
        {
            MessageBox.Show("Zbóje zaatakowali! \nPiechota: " + enemyInfantry.Count.ToString() + "\nKawaleria: " + enemyCavalry.Count.ToString() +
                "\nŁucznicy: " + enemyArchers.Count.ToString(), "BITWA!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //Bitwa pomiędzy zbójami, a naszymi wojskami
            battle(enemyInfantry, enemyCavalry, enemyArchers);

            enemyInfantry.Clear();
            enemyCavalry.Clear();
            enemyArchers.Clear();
            //Zmienna pomocnicza w obliczeniu rozmiaru następnego ataku
            float count = 1;
            //Obliczamy rozmiar następnego ataku
            count = 1.4f * (float)enemyInfantry.Count;
            for (int i = 0; i < (int)count; i++)
                enemyInfantry.Add(new Infantry(infantryUnit.VsInfantryStrength, infantryUnit.VsCavalryStrength,
                                    infantryUnit.VsArcherStrength));
            count = 1.25f * (float)enemyCavalry.Count;
            for (int i = 0; i < (int)count; i++)
                enemyCavalry.Add(new Cavalry(cavalryUnit.VsInfantryStrength, cavalryUnit.VsCavalryStrength,
                                    cavalryUnit.VsArcherStrength));
            count = 1.35f * (float)enemyArchers.Count;
            for (int i = 0; i < (int)count; i++)
                enemyArchers.Add(new Archer(archerUnit.VsInfantryStrength, archerUnit.VsCavalryStrength,
                                    archerUnit.VsArcherStrength));
        }


        /// <summary>
        /// Tykanie zegara odpowiadającego za wzrost poparcia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerSupport_Tick(object sender, EventArgs e)
        {
            support++;
            if (support > 100) support = 100;
            labelSupportAmount.Text = support.ToString();
        }


        /// <summary>
        /// Tykanie zegara odpowiadającego za losowe zdarzenia 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerEvent_Tick(object sender, EventArgs e)
        {
            //Wygenerowanie losowej liczby typu double w zakresie od 0 do 1
            Random random = new Random();
            double eventCode = random.NextDouble();
            //W zależności od wylosowanej liczby dopasowujemy do niej zdarzenie
            //Zdarzenie utraty popularności
            if(eventCode<0.125)
            {
                happening.EventGossip(ref support);
                labelSupportAmount.Text = support.ToString();
                ifLost();
            }
            //Zdarzenie kradzieży surowców
            if(eventCode>=0.125&&eventCode<0.225)
            {
                happening.EventTheft(ref wood, ref clay, ref iron, ref gold);
                refreshStorage();
            }
            //Zdarzenie ogromnej utraty popularności
            if(eventCode>=0.225&&eventCode<0.26)
            {
                happening.EventPoliticalAffair(ref support);
                labelSupportAmount.Text = support.ToString();
                ifLost();
            }
            //Zdarzenie utraty 10% żołnierzy
            if(eventCode>=0.4&&eventCode<0.5)
            {
                happening.EventPlague(ref infantry,ref cavalry,ref archers);
                labelInfantryAmount.Text = infantry.Count.ToString();
                labelCavalryAmount.Text = cavalry.Count.ToString();
                labelArcherAmount.Text = archers.Count.ToString();
            }
            //Zdarzenie zyskania popularności
            if(eventCode>=0.6&&eventCode<0.785)
            {
                happening.EventPopularityGain(ref support);
                if (support > 100) support = 100;
                labelSupportAmount.Text = support.ToString();
            }
        }
       
        /// <summary>
        /// Funkcja obliczająca wynik bitwy, oraz starty w tej bitwie przyjmująca jako argument ilość wrogich żołnierzy danego typu
        /// </summary>
        /// <param name="enemyInfantry"></param>
        /// <param name="enemyCavalry"></param>
        /// <param name="enemyArchers"></param>
        /// <returns>Zwraca czy gracz wygrał bitwę</returns>
        private void battle(List<Unit> enemyInfantry,List<Unit> enemyCavalry, List<Unit> enemyArchers)
        {
            //Zmienna pomocnicza w obliczaniu strat
            float countLoses = 1;
            //Zmienne przetrzymujące zsumowaną siłę wojsk gracza przeciwko konkretnemu rodzajowi wojsk
            int playerVsInfStrength = 0, playerVsCavStrength = 0, playerVsArcStrength = 0;
            //Zmienne przetrzymujące zsumowaną siłę wojsk wroga przeciwko konkretnemu rodzajowi wojsk
            int enemyVsInfStrength = 0, enemyVsCavStrength = 0, enemyVsArcStrength = 0;
            //Walczymy tak długo dopóki przeciwnik zostaje na polu walki - nie ma odwrotu
            //Za kązdym przebiegiem pętli obliczamy zwycięzce i straty w bitwie danego typu żołnierza
            //przegrany typ wojsk umiera w całości, następnie całość powtarzamy, aż gdy po którejś ze stron nie pozostał żaden żołnierz
            while (!(infantry.Count == 0 && cavalry.Count == 0 && archers.Count == 0) && !(enemyInfantry.Count == 0 && enemyCavalry.Count == 0 && enemyArchers.Count == 0))
            {
                //Obliczamy siłę kazdej z armii przeciwko konkretnym typom jednostek
                for(int i=0;i<infantry.Count;i++)
                {
                    playerVsInfStrength += infantry[i].VsInfantryStrength;
                    playerVsCavStrength += infantry[i].VsCavalryStrength;
                    playerVsArcStrength += infantry[i].VsArcherStrength;
                }
                for(int i=0;i<cavalry.Count;i++)
                {
                    playerVsInfStrength += cavalry[i].VsInfantryStrength;
                    playerVsCavStrength += cavalry[i].VsCavalryStrength;
                    playerVsArcStrength += cavalry[i].VsArcherStrength;
                }
                for (int i = 0; i < archers.Count; i++)
                {
                    playerVsInfStrength += archers[i].VsInfantryStrength;
                    playerVsCavStrength += archers[i].VsCavalryStrength;
                    playerVsArcStrength += archers[i].VsArcherStrength;
                }
                for (int i = 0; i < enemyInfantry.Count; i++)
                {
                    enemyVsInfStrength += enemyInfantry[i].VsInfantryStrength;
                    enemyVsCavStrength += enemyInfantry[i].VsCavalryStrength;
                    enemyVsArcStrength += enemyInfantry[i].VsArcherStrength;
                }
                for (int i = 0; i < enemyCavalry.Count; i++)
                {
                    enemyVsInfStrength += enemyCavalry[i].VsInfantryStrength;
                    enemyVsCavStrength += enemyCavalry[i].VsCavalryStrength;
                    enemyVsArcStrength += enemyCavalry[i].VsArcherStrength;
                }
                for (int i = 0; i < enemyArchers.Count; i++)
                {
                    enemyVsInfStrength += enemyArchers[i].VsInfantryStrength;
                    enemyVsCavStrength += enemyArchers[i].VsCavalryStrength;
                    enemyVsArcStrength += enemyArchers[i].VsArcherStrength;
                }



                //Następnie sprawdzamy kto ma większą siłę przeciwko danemu typu jednostek, u przegranego typ jednostek umiera w całości
                //u zwycięzcy liczymy straty
                if (playerVsInfStrength > enemyVsInfStrength)
                {
                    countLoses = ((float)enemyVsInfStrength / (float)playerVsInfStrength) * (float)infantry.Count;
                    infantry.RemoveRange(infantry.Count - (int)Math.Ceiling(countLoses) - 1, (int)Math.Ceiling(countLoses));
                    enemyInfantry.Clear();
                }
                else
                {
                    countLoses = ((float)playerVsInfStrength / (float)enemyVsInfStrength) * (float)enemyInfantry.Count;
                    enemyInfantry.RemoveRange(enemyInfantry.Count - (int)Math.Ceiling(countLoses) - 1, (int)Math.Ceiling(countLoses));
                    infantry.Clear();
                }
                if (playerVsCavStrength > enemyVsCavStrength)
                {
                    countLoses = ((float)enemyVsCavStrength / (float)playerVsCavStrength) * (float)cavalry.Count;
                    cavalry.RemoveRange(cavalry.Count - (int)Math.Ceiling(countLoses) - 1, (int)Math.Ceiling(countLoses));
                    enemyCavalry.Clear();
                }
                else
                {
                    countLoses = ((float)playerVsCavStrength / (float)enemyVsCavStrength) * (float)enemyCavalry.Count;
                    enemyCavalry.RemoveRange(enemyCavalry.Count - (int)Math.Ceiling(countLoses) - 1, (int)Math.Ceiling(countLoses));
                    cavalry.Clear();
                }
                if (playerVsArcStrength > enemyVsArcStrength)
                {
                    countLoses = ((float)enemyVsArcStrength / (float)playerVsArcStrength) * (float)archers.Count;
                    archers.RemoveRange(archers.Count - (int)Math.Ceiling(countLoses) - 1, (int)Math.Ceiling(countLoses));
                    enemyArchers.Clear();
                }
                else
                {
                    countLoses = ((float)playerVsArcStrength / (float)enemyVsArcStrength) * (float)enemyArchers.Count;
                    enemyArchers.RemoveRange(enemyArchers.Count - (int)Math.Ceiling(countLoses) - 1, (int)Math.Ceiling(countLoses));
                    archers.Clear();
                }
            } 
            //Wyświetlamy informacje o zwycięstwie lub porażce
            if(infantry.Count == 0 && cavalry.Count == 0 && archers.Count == 0)
            {
                //Jeżeli przegrana to tracimy poparcię i część surowców
                MessageBox.Show("Twoi dzielni żołnierze zostali pokanani...\nTracisz ich wszystkich, trochę surowców, oraz część poparcia",
                    "PORAŻKA",MessageBoxButtons.OK,MessageBoxIcon.Information);
                support -= 15;
                float temp;
                temp = (float)wood * 0.3f;
                wood -= (int)temp;
                temp = (float)clay * 0.3f;
                clay -= (int)temp;
                temp = (float)iron * 0.3f;
                iron -= (int)temp;
                temp = (float)gold * 0.3f;
                gold -= (int)temp;
                refreshStorage();
                labelSupportAmount.Text = support.ToString();
                //Aktualizacja informacji na interfejsie
                labelInfantryAmount.Text = infantry.Count.ToString();
                labelCavalryAmount.Text = cavalry.Count.ToString();
                labelArcherAmount.Text = archers.Count.ToString();
                ifLost();
                return;
            }
            else
            {
                MessageBox.Show("Twoi niezłomni żołnierze zwyciężyli i pobili wroga...\nCzęść z nich niestety poległa, ale twoja osada jest bezpieczna",
                    "ZWYCIĘSTWO", MessageBoxButtons.OK, MessageBoxIcon.Information);                
                return;
            }
            
        }

        

        /// <summary>
        /// Funkcja sprawdzenia czy poparcie spadło poniżej 0 i gracz przegrał
        /// </summary>
        private void ifLost()
        {
            if(support<=0)
            {
                MessageBox.Show("Poparcia spadło do 0 - przegrywasz!", "O nie!");
                FormLose loseWindow = new FormLose();
                timerWood.Stop();
                timerClay.Stop();
                timerIron.Stop();
                timerGold.Stop();
                timerEvent.Stop();
                timerGold.Stop();
                timerSupport.Stop();
                loseWindow.Show();
            }
        }
        /// <summary>
        /// Obsługa zdarzenia zmiany wyboru budynku w comboBox - zmiana kosztów surowców w label-ach
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxBuild_SelectedIndexChanged(object sender, EventArgs e)
        {
                string buildingName = (string)comboBoxBuild.SelectedItem;
                switch (buildingName)
                {
                    case "Tartak": setBuildingCostLabels(carpenter); break;
                    case "Cegielnia": setBuildingCostLabels(brickyard); break;
                    case "Huta": setBuildingCostLabels(ironsmith); break;
                    case "Mennica": setBuildingCostLabels(coinmaker); break;
                }
            
        }
        /// <summary>
        /// Funkcja rozbudowywująca dany budynek o jeden poziom
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBuild_Click(object sender, EventArgs e)
        {
            int techInfluence=0;
            string buildingName = (string)comboBoxBuild.SelectedItem;
            Building building;
            switch (buildingName)
            {
                case "Tartak": building = carpenter;techInfluence = commercialTech.CarpenterTechLevel; break;
                case "Cegielnia": building = brickyard; techInfluence = commercialTech.BrickyardTechLevel; break;
                case "Huta": building = ironsmith; techInfluence = commercialTech.IronsmithTechLevel; break;
                case "Mennica": building = coinmaker; techInfluence = commercialTech.CoinmakerTechLevel; break;
                default: return;
            }
            building.Build(ref wood, ref clay, ref iron, ref gold,techInfluence);
            float countInterval = (60 / (float)building.Income) * 1000;
            switch (buildingName)
            {
                case "Tartak": timerWood.Interval = (int)countInterval; break;
                case "Cegielnia": timerClay.Interval = (int)countInterval; break;
                case "Huta": timerIron.Interval = (int)countInterval; break;
                case "Mennica": timerGold.Interval = (int)countInterval; break;
                default: return;
            }
            //Odświeżamy stan surowców, przychód surowca, poziom budynku i nowe koszta budowy budynku na interfejsie
            refreshStorage();
            setBuildingCostLabels(building);
            labelCarpenterLevel.Text = carpenter.Level.ToString();
            labelWoodPerMinute.Text = carpenter.Income.ToString();
            labelBrickYardLevel.Text = brickyard.Level.ToString();
            labelClayPerMinute.Text = brickyard.Income.ToString();
            labelIronSmithLevel.Text = ironsmith.Level.ToString();
            labelIronPerMinute.Text = ironsmith.Income.ToString();
            labelCoinmakerLevel.Text = coinmaker.Level.ToString();
            labelGoldPerMinute.Text = coinmaker.Income.ToString();
        }
        /// <summary>
        /// Obsługa przycisku buttonAttack - zaatakowanie obozu zbójów i bitwa z nimi, w wypadku zwycięstwa - wygrana w grze
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAttack_Click(object sender, EventArgs e)
        {
            
            
                List<Unit> enemyBaseInfantry = new List<Unit>();
                List<Unit> enemyBaseCavalry = new List<Unit>();
                List<Unit> enemyBaseArchers = new List<Unit>();
                for (int i = 0; i < 120; i++)
                    enemyBaseInfantry.Add(new Infantry(10, 16, 2));
                for (int i = 0; i < 70; i++)
                    enemyBaseCavalry.Add(new Cavalry(11, 14, 30));
                for (int i = 0; i < 100; i++)
                    enemyBaseArchers.Add(new Archer(20, 2, 10));
                battle(enemyBaseInfantry, enemyBaseCavalry, enemyBaseArchers);
                if (!(infantry.Count == 0 && cavalry.Count == 0 && archers.Count == 0))
                {
                    FormWin winWindow = new FormWin();
                    timerWood.Stop();
                    timerClay.Stop();
                    timerIron.Stop();
                    timerGold.Stop();
                    timerEvent.Stop();
                    timerGold.Stop();
                    timerSupport.Stop();
                    winWindow.Show();
                }
            
        }
        /// <summary>
        /// Funkcja szkoląca jednostki piechoty
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRecruitInfantry_Click(object sender, EventArgs e)
        {
            int techInfluence = militaryTechnology.InfantryTechLevel;
            //Pobieramy z textBoxInfantryAmount ilość jednostek do zrekrutowania, sprawdzamy popraność wprowadzonego tekstu, oraz
            //czy mamy na to surowce, jeżeli tak odejmujemy surowce i dodajemy ilość jednostek
            try
            {
                int amount = Int32.Parse(textBoxInfantryAmount.Text);
                infantry.AddRange(infantryUnit.Recruit(ref wood, ref clay, ref iron, ref gold, amount,
                                    infantryUnit.VsInfantryStrength*(int)(1+(techInfluence*0.05f)),
                                    infantryUnit.VsCavalryStrength* (int)(1 + (techInfluence * 0.05f)),
                                    infantryUnit.VsArcherStrength* (int)(1 + (techInfluence * 0.05f))));
                labelInfantryAmount.Text = infantry.Count.ToString();
                refreshStorage();
            }
            //Jeżeli tekst w textBox nie został poprawnie wprowadzony - nie liczba, lub brak jakiegokolwiek znaku to wyświetlamy komunikat
            catch (ArgumentNullException)
            {
                MessageBox.Show("Błędnie wprowadzone dane ilości rekrutacji",
                    "Niestety", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (FormatException)
            {
                MessageBox.Show("Błędnie wprowadzone dane ilości rekrutacji",
                   "Niestety", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            textBoxInfantryAmount.Text = "";
        }
        /// <summary>
        /// Funkcja szkoląca jednostki kawalerii
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRecruitCavalry_Click(object sender, EventArgs e)
        {
            int techInfluence = militaryTechnology.CavalryTechLevel;
            //Pobieramy z textBoxCavalryAmount ilość jednostek do zrekrutowania, sprawdzamy popraność wprowadzonego tekstu, oraz
            //czy mamy na to surowce, jeżeli tak odejmujemy surowce i dodajemy ilość jednostek
            try
            {
                int amount = Int32.Parse(textBoxCavalryAmount.Text);
                cavalry.AddRange(cavalryUnit.Recruit(ref wood, ref clay, ref iron, ref gold, amount,
                                    cavalryUnit.VsInfantryStrength* (int)(1 + (techInfluence * 0.05f)),
                                    cavalryUnit.VsCavalryStrength* (int)(1 + (techInfluence * 0.05f)),
                                    cavalryUnit.VsArcherStrength* (int)(1 + (techInfluence * 0.05f))));
                labelCavalryAmount.Text = cavalry.Count.ToString();
                refreshStorage();
            }
            //Jeżeli tekst w textBox nie został poprawnie wprowadzony - nie liczba, lub brak jakiegokolwiek znaku to wyświetlamy komunikat
            catch (ArgumentNullException)
            {
                MessageBox.Show("Błędnie wprowadzone dane ilości rekrutacji",
                    "Niestety", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (FormatException)
            {
                MessageBox.Show("Błędnie wprowadzone dane ilości rekrutacji",
                   "Niestety", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            textBoxCavalryAmount.Text = "";
        }
        /// <summary>
        /// Funkcja szkoląca jednostki luczników
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRecruitArcher_Click(object sender, EventArgs e)
        {
            int techInfluence = militaryTechnology.ArcherTechLevel;
            //Pobieramy z textBoxArcherAmount ilość jednostek do zrekrutowania, sprawdzamy popraność wprowadzonego tekstu, oraz
            //czy mamy na to surowce, jeżeli tak odejmujemy surowce i dodajemy ilość jednostek
            try
            {
                int amount = Int32.Parse(textBoxArcherAmount.Text);
                archers.AddRange(archerUnit.Recruit(ref wood, ref clay, ref iron, ref gold, amount,
                                    archerUnit.VsInfantryStrength*(int)(1 + (techInfluence * 0.05f)),
                                    archerUnit.VsCavalryStrength* (int)(1 + (techInfluence * 0.05f)),
                                    archerUnit.VsArcherStrength* (int)(1 + (techInfluence * 0.05f))));
                labelArcherAmount.Text = archers.Count.ToString();
                refreshStorage();
            }
            //Jeżeli tekst w textBox nie został poprawnie wprowadzony - nie liczba, lub brak jakiegokolwiek znaku to wyświetlamy komunikat
            catch (ArgumentNullException)
            {
                MessageBox.Show("Błędnie wprowadzone dane ilości rekrutacji",
                    "Niestety", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (FormatException)
            {
                MessageBox.Show("Błędnie wprowadzone dane ilości rekrutacji",
                   "Niestety", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            textBoxArcherAmount.Text = "";
        }
        /// <summary>
        /// Funkcja zapisująca stan gry - zapisujemy po kolei - surowce, jednostki, poparcie, poziomy budynków, technologie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            fileDialog.FilterIndex = 2;
            fileDialog.ShowDialog();
            try
            {
                StreamWriter writer = new StreamWriter(fileDialog.FileName);
                writer.Write(wood.ToString() + "\n" + clay.ToString() + "\n" + iron.ToString() + "\n" + gold.ToString() + "\n");
                writer.Write(militaryTechnology.InfantryTechLevel + "\n" + militaryTechnology.CavalryTechLevel + "\n" + militaryTechnology.ArcherTechLevel + "\n");

                writer.Write(commercialTech.CarpenterTechLevel + "\n" + commercialTech.BrickyardTechLevel +
                    "\n" + commercialTech.IronsmithTechLevel + "\n" + commercialTech.CoinmakerTechLevel + "\n");

                writer.Write(infantry.Count.ToString() + "\n" + cavalry.Count.ToString() + "\n" + archers.Count.ToString() + "\n");

                writer.WriteLine(support.ToString());

                writer.Write(carpenter.Level.ToString() + "\n" + brickyard.Level.ToString() + "\n" +
                    ironsmith.Level.ToString() + "\n" + coinmaker.Level.ToString() + "\n");

                writer.Close();
            }
            catch(IOException)
            {
                MessageBox.Show("Błąd zapisu do pliku",
                    "Niestety", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch(ArgumentException)
            {
                MessageBox.Show("Błąd zapisu do pliku",
                    "Niestety", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        /// <summary>
        /// Funkcja wczytująca dane z pliku w tej samej kolejności co zapisaliśmy, oraz ustawiająca dane gry
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "txt files (*.txt)|*.txt";
            fileDialog.FilterIndex = 1;
            fileDialog.ShowDialog();
            try
            {
                StreamReader reader = new StreamReader(fileDialog.FileName);
                wood = Int32.Parse(reader.ReadLine());
                clay = Int32.Parse(reader.ReadLine());
                iron = Int32.Parse(reader.ReadLine());
                gold = Int32.Parse(reader.ReadLine());

                militaryTechnology.InfantryTechLevel= Int32.Parse(reader.ReadLine());
                militaryTechnology.CavalryTechLevel= Int32.Parse(reader.ReadLine());
                militaryTechnology.ArcherTechLevel= Int32.Parse(reader.ReadLine());

                commercialTech.CarpenterTechLevel= Int32.Parse(reader.ReadLine());
                commercialTech.BrickyardTechLevel= Int32.Parse(reader.ReadLine());
                commercialTech.IronsmithTechLevel= Int32.Parse(reader.ReadLine());
                commercialTech.CarpenterTechLevel= Int32.Parse(reader.ReadLine());

                infantry.Clear();
                cavalry.Clear();
                archers.Clear();
                int amount = Int32.Parse(reader.ReadLine());
                for (int i = 0; i < amount; i++)
                    infantry.Add(new Infantry(10, 16, 2));
                amount = Int32.Parse(reader.ReadLine());
                for (int i = 0; i < amount; i++)
                    cavalry.Add(new Cavalry(11, 14, 30));
                amount = Int32.Parse(reader.ReadLine());
                for (int i = 0; i < amount; i++)
                    archers.Add(new Archer(20, 2, 10));

                labelArcherAmount.Text = archers.Count.ToString();
                labelInfantryAmount.Text = infantry.Count.ToString();
                labelCavalryAmount.Text = cavalry.Count.ToString();
                refreshStorage();

                support = Int32.Parse(reader.ReadLine());
                labelSupportAmount.Text = support.ToString();

                int loadCarpenterLevel = Int32.Parse(reader.ReadLine());
                int loadBrickyardLevel = Int32.Parse(reader.ReadLine());
                int loadIronsmithLevel = Int32.Parse(reader.ReadLine());
                int loadCoinmakerLevel = Int32.Parse(reader.ReadLine());

                LoadBuildingsSetUp(loadCarpenterLevel, loadBrickyardLevel, loadIronsmithLevel, loadCoinmakerLevel);

                timerRaid.Stop();
                timerSupport.Stop();
                timerEvent.Stop();
                timerRaid.Start();
                timerSupport.Start();
                timerEvent.Start();
                reader.Close();
            }
            catch (IOException)
            {
                MessageBox.Show("Błąd wczytania z pliku",
                    "Niestety", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Błąd wczytania z pliku",
                    "Niestety", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch(FormatException)
            {
                MessageBox.Show("Błąd wczytania z pliku",
                    "Niestety", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        /// <summary>
        /// Funkcja otwierająca okno technologii
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonTechs_Click(object sender, EventArgs e)
        {
            FormTechnologies technologies = new FormTechnologies(ref militaryTechnology,ref commercialTech);
            technologies.Show();
        }

    }
}
