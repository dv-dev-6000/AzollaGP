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
                    makeWatchtower();
                    break;
                case 2:
                    makePark();
                    break;
                case 3:
                    makeAirPurifier();
                    break;
            }
        }

        private void makeWatchtower()
        {
            Name = "Watch Tower";
            BenOne = "Provides a boost to the settlements Security score.";
            BenTwo = "Security score can't be reduced below 25%";
            Info = "The watchtower allows settlers to gain a high vantage point and keep a close watch on the lands around the settlement.";
            MatCost = 250;
            TimeCost = 2;
            IsAvailable = true;
            Level = 0;

            BenOneUP = "Provides a further boost to Security score.";
            BenTwoUP = "Security score can't be reduced below 50%";
            MatCostUP = 450;
            TimeCostUP = 3;
        }

        private void makePark()
        {
            Name = "Park";
            BenOne = "Provides a boost to the settlements Morale score.";
            BenTwo = "Morale score can't be reduced below 25%";
            Info = "The park provides a recreational area for settlers to unwind and relax, happy settlers are productive settlers.";
            MatCost = 150;
            TimeCost = 2;
            IsAvailable = true;
            Level = 0;

            BenOneUP = "Provides a further boost to Morale score.";
            BenTwoUP = "Morale score can't be reduced below 50%";
            MatCostUP = 350;
            TimeCostUP = 2;
        }

        private void makeAirPurifier()
        {
            Name = "Air Purifier";
            BenOne = "Provides a boost to the settlements environment score.";
            BenTwo = "Environment score can't be reduced below 25%";
            Info = "Air purifiers help clear the atmosphere of toxic fumes, they are an essential first step in the mission to resettle earth. ";
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
