using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class Plot
    {
        //vars
        public string Type { get; set; }
        public int Option { get; set; }
        public int Level { get; set; }

        public Plot(string t = "empty", int o = 0, int l = 0)
        {
            Type = t;
            Option = o;
            Level = l;
        }
    }

    public static class TheCloud
    {
        // check var init
        public static bool varsInitialised { get; set; }
        // trigger the event menu
        public static bool triggerEvent { get; set; }

        // Static Variables
        public static bool uiMenuOpen { get; set; }             // is a UI menu currently open
        public static int credits { get; set; }                 // total credits

        public static int minScience { get; set; }
        public static int scienceScore { get; set; }
        public static int scienceConv { get; set; }
        public static int minMorale { get; set; }
        public static int moraleScore { get; set; }
        public static int moraleConv { get; set; }
        public static int minEnvironment { get; set; }
        public static int environmentScore { get; set; }
        public static int environmentConv { get; set; }

        public static int settOneMaterials { get; set; }
        public static int settOneTimeBar { get; set; }

        public static int goldValue { get; set; }
        public static int ironValue { get; set; }
        public static int copperValue { get; set; }

        // play against timer
        public static bool playTimed { get; set; }
        // the prize in materials for completing a level
        public static int levelPrize { get; set; }
        // the total materials to collected in a level
        public static int matsCollected { get; set; }
        // marks when player has just returned from platforming
        public static bool returnedFromPlatformer { get; set; }

        public static Plot[] Plots { get; set; } = {new Plot(), new Plot(), new Plot(), new Plot(), new Plot(), new Plot() };

    }
}
