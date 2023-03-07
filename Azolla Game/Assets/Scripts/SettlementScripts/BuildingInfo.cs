using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.SettlementScripts
{
    class BuildingInfo
    {
        // class vars
        public string Name { get; set; }
        public string BenOne { get; set; }
        public string BenTwo { get; set; }
        public string Info { get; set; }
        public int MatCost { get; set; }
        public int TimeCost { get; set; }

        public string BenOneUP { get; set; }
        public string BenTwoUP { get; set; }
        public int MatCostUP { get; set; }
        public int TimeCostUP { get; set; }

        public bool IsAvailable { get; set; }
        public int Level { get; set; }

        /// <summary>
        /// Constructor for building class
        /// </summary>
        /// <param name="type">1=Watchtower, 2=Park, 3=AirPurifier</param>
        public BuildingInfo(int type)
        {
            switch (type)
            {
                case 1:
                    makeScienceLab();
                    break;
                case 2:
                    makeTreePlantingZone();
                    break;
                case 3:
                    makeSolarArray();
                    break;
            }
        }

        private void makeScienceLab()
        {
            Name = "Science Lab";
            BenOne = "Provides a boost to the settlements Science score.";
            BenTwo = "Science score can't be reduced below 25%";
            Info = "The Science Lab allows settlers to research new technologies for the advancement of the settlement.";
            MatCost = 250;
            TimeCost = 2;
            IsAvailable = true;
            Level = 0;

            BenOneUP = "Provides a further boost to Science score.";
            BenTwoUP = "Science score can't be reduced below 50%";
            MatCostUP = 450;
            TimeCostUP = 3;
        }

        private void makeTreePlantingZone()
        {
            Name = "Tree Planting Zone";
            BenOne = "Provides a boost to the settlements Morale score.";
            BenTwo = "Morale score can't be reduced below 25%";
            Info = "The Tree Planting Zone provides a recreational area for settlers to unwind and relax, happy settlers are productive settlers.";
            MatCost = 150;
            TimeCost = 2;
            IsAvailable = true;
            Level = 0;

            BenOneUP = "Provides a further boost to Morale score.";
            BenTwoUP = "Morale score can't be reduced below 50%";
            MatCostUP = 350;
            TimeCostUP = 2;
        }

        private void makeSolarArray()
        {
            Name = "Solar Array";
            BenOne = "Provides a boost to the settlements environment score.";
            BenTwo = "Environment score can't be reduced below 25%";
            Info = "Solar Arrays help settlements generate clean energy, they are an essential first step in the mission to resettle earth. ";
            MatCost = 200;
            TimeCost = 2;
            IsAvailable = true;
            Level = 0;

            BenOneUP = "Provides a further boost to Environment score.";
            BenTwoUP = "Environment score can't be reduced below 50%";
            MatCostUP = 400;
            TimeCostUP = 3;
        }
    }
}
