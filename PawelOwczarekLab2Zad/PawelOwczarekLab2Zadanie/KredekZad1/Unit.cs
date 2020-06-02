using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KredekZad1
{
    //Klasa jednostki, która pozwala łatwo rozszerzyć grę o nowe typy jednostek
    public abstract class Unit
    {
        //Zmienna opisująca koszt drewna za jedną jednostkę wraz z getter-em i setter-em
        protected int woodCost;
        public int WoodCost{ get => woodCost; set => woodCost=value; }
        //Zmienna opisująca koszt gliny za jedną jednostkę wraz z getter-em i setter-em
        protected int clayCost;
        public int ClayCost { get => clayCost; set => clayCost = value; }
        //Zmienna opisująca koszt żelaza za jedną jednostkę wraz z getter-em i setter-em
        protected int ironCost;
        public int IronCost { get => ironCost; set => ironCost = value; }
        //Zmienna opisująca koszt złota za jedną jednostkę wraz z getter-em i setter-em
        protected int goldCost;
        public int GoldCost { get => goldCost; set => goldCost = value; }
        //Zmienna opisująca siłe przeciw piechocie jednostki wraz z getter-em i setter-em
        protected int vsInfantryStrength;
        public int VsInfantryStrength { get => vsInfantryStrength; set => vsInfantryStrength = value; }
        //Zmienna opisująca siłe przeciw kawalerii jednostki wraz z getter-em i setter-em
        protected int vsCavalryStrength;
        public int VsCavalryStrength { get => vsCavalryStrength; set => vsCavalryStrength = value; }
        //Zmienna opisująca siłe przeciw łucznikom jednostki wraz z getter-em i setter-em
        protected int vsArcherStrength;
        public int VsArcherStrength { get => vsArcherStrength; set => vsArcherStrength = value; }
        //Metoda rekrutacji zwracająca liste zrekrutowanych jednostek
        abstract public List<Unit> Recruit(ref int wood,ref int clay,ref int iron,ref int gold,
                    int amount, int infStr, int cavStr, int arcStr);
        //Metoda ustawiająca koszt produkcji jednostki
        virtual public void SetCosts(int wood, int clay, int iron, int gold)
        {
            this.woodCost = wood;
            this.clayCost = clay;
            this.ironCost = iron;
            this.goldCost = gold;
        }
        
    }
}
