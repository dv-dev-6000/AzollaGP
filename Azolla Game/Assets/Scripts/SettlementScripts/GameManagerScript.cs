using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Assets.Scripts;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public int currPlotSelection { get; set; }

    // back to ship Button
    [SerializeField]
    private Button backButton;

    #region Resource Values
    // science variable
    private const int scienceMax = 100;
    // morale variable
    private const int moraleMax = 100;
    // environment variable
    private const int environmentMax = 100;

    // resource bars
    [SerializeField]
    private Slider sciSlider;
    [SerializeField]
    private Slider morSlider;
    [SerializeField]
    private Slider envSlider;

    [SerializeField]
    private Slider timeSlider;


    #endregion

    // materials prize amount
    private int matPrize = 250;

    [SerializeField]
    public TextMeshProUGUI debugText;

    // conversion rations text
    [SerializeField]
    private TextMeshProUGUI sciRatio;
    [SerializeField]
    private TextMeshProUGUI morRatio;
    [SerializeField]
    private TextMeshProUGUI envRatio;

    // Build/Upgrade Panel Menu
    [SerializeField]
    private RectTransform buildPanel;
    [SerializeField]
    private RectTransform upgradePanel;
    [SerializeField]
    private RectTransform campPanel;
    [SerializeField]
    private RectTransform embarkPanel;
    [SerializeField]
    private RectTransform eventPanel;
    // Materials Button
    [SerializeField]
    private Button matButton;

    // Materials UI text
    [SerializeField]
    private TextMeshProUGUI matDisplayText;

    // Start is called before the first frame update
    void Start()
    {
        // Set Cursor Visibility
        Cursor.visible = true;

        // set initial cloud values
        if (!TheCloud.varsInitialised)
        {
            TheCloud.scienceConv = 1;
            TheCloud.moraleConv = 1;
            TheCloud.environmentConv = 1;

            TheCloud.goldValue = 1;
            TheCloud.ironValue = 1;
            TheCloud.copperValue = 1;

            TheCloud.levelPrize = 0;
            TheCloud.matsCollected = 0;
            TheCloud.playTimed = false;
            TheCloud.returnedFromPlatformer = false;

            TheCloud.settOneTimeBar = (int)timeSlider.maxValue;

            TheCloud.varsInitialised = true;
        }
        
        // Set Up material Button Click Event
        Button matButt = matButton.GetComponent<Button>();
        matButt.onClick.AddListener(AddMaterials);

        // back button
        Button bckButt = backButton.GetComponent<Button>();
        bckButt.onClick.AddListener(BackToShip);

        UpdateScoreValues();
        updateConvValueText();
    }

    // Update is called once per frame
    void Update()
    {
        if (!TheCloud.uiMenuOpen && TheCloud.triggerEvent)
        {
            eventPanel.gameObject.SetActive(true);
            TheCloud.uiMenuOpen = true;
        }
    }

    private void checkForEvent()
    {
        if (timeSlider.value <= 0)
        {
            TheCloud.triggerEvent = true;
            eventPanel.GetComponent<EventScript>().updateEvent(Random.Range(0, 5));
        }
    }

    private void updateConvValueText()
    {
        if (TheCloud.scienceConv == 2)
        {
            sciRatio.text = "1 material = 2 points";
        }
        else if(TheCloud.scienceConv == 3)
        {
            sciRatio.text = "1 material = 3 points";
        }

        if (TheCloud.moraleConv == 2)
        {
            morRatio.text = "1 material = 2 points";
        }
        else if (TheCloud.moraleConv == 3)
        {
            morRatio.text = "1 material = 3 points";
        }

        if (TheCloud.environmentConv == 2)
        {
            envRatio.text = "1 material = 2 points";
        }
        else if (TheCloud.environmentConv == 3)
        {
            envRatio.text = "1 material = 3 points";
        }
    }

    public void UpdateScoreValues()
    {
        // update security bar
        if (TheCloud.scienceScore < TheCloud.minScience)
        {
            TheCloud.scienceScore = TheCloud.minScience;
        }
        else if (TheCloud.scienceScore > scienceMax)
        {
            TheCloud.scienceScore = scienceMax;
        }
        sciSlider.value = TheCloud.scienceScore;

        // update morale bar
        if (TheCloud.moraleScore < TheCloud.minMorale)
        {
            TheCloud.moraleScore = TheCloud.minMorale;
        }
        else if (TheCloud.moraleScore > moraleMax)
        {
            TheCloud.moraleScore = moraleMax;
        }
        morSlider.value = TheCloud.moraleScore;

        // update security bar
        if (TheCloud.environmentScore < TheCloud.minEnvironment)
        {
            TheCloud.environmentScore = TheCloud.minEnvironment;
        }
        else if (TheCloud.environmentScore > environmentMax)
        {
            TheCloud.environmentScore = environmentMax;
        }
        envSlider.value = TheCloud.environmentScore;

        // update matrerials
        if (TheCloud.settOneMaterials < 0)
        {
            TheCloud.settOneMaterials = 0;
        }
        matDisplayText.GetComponent<TextMeshProUGUI>().text = "" + TheCloud.settOneMaterials;

        timeSlider.value = TheCloud.settOneTimeBar;
    }
    
    public void AlterScores(string type, int option, int level, int matcost, int timecost)
    {
        // change parameters to type/ option/ level
        switch (type)
        {
            case "sec":
                if (option == 1)        // if option one, increase score and set new min
                {
                    if (level == 1) 
                    {
                        TheCloud.scienceScore += 25;
                        TheCloud.minScience = 25;
                    }
                    else if (level == 2)
                    {
                        TheCloud.scienceScore += 25;
                        TheCloud.minScience = 50;
                    }
                }
                else if (option == 2)   // if option two, increase conversion ratio
                {
                    if (level == 1)
                    {
                        TheCloud.scienceConv = 2;
                    }
                    else if (level == 2)
                    {
                        TheCloud.scienceConv = 3;
                    }
                }
                else if (option == 3)   // if option three, increse collectible value
                {
                    if (level == 1)
                    {
                        TheCloud.ironValue = 2;
                    }
                    else if (level == 2)
                    {
                        TheCloud.ironValue = 3;
                    }
                }
                break;

            case "mor":
                if (option == 1)        // if option one, increase score and set new min
                {
                    if (level == 1)
                    {
                        TheCloud.moraleScore += 25;
                        TheCloud.minMorale = 25;
                    }
                    else if (level == 2)
                    {
                        TheCloud.moraleScore += 25;
                        TheCloud.minMorale = 50;
                    }
                }
                else if (option == 2)   // if option two, increase conversion ratio
                {
                    if (level == 1)
                    {
                        TheCloud.moraleConv = 2;
                    }
                    else if (level == 2)
                    {
                        TheCloud.moraleConv = 3;
                    }
                }
                else if (option == 3)   // if option three, increse collectible value
                {
                    if (level == 1)
                    {
                        TheCloud.copperValue = 2;
                    }
                    else if (level == 2)
                    {
                        TheCloud.copperValue = 3;
                    }
                }
                break;

            case "env":
                if (option == 1)        // if option one, increase score and set new min
                {
                    if (level == 1)
                    {
                        TheCloud.environmentScore += 25;
                        TheCloud.minEnvironment = 25;
                    }
                    else if (level == 2)
                    {
                        TheCloud.environmentScore += 25;
                        TheCloud.minEnvironment = 50;
                    }
                }
                else if (option == 2)   // if option two, increase conversion ratio
                {
                    if (level == 1)
                    {
                        TheCloud.environmentConv = 2;
                    }
                    else if (level == 2)
                    {
                        TheCloud.environmentConv = 3;
                    }
                }
                else if (option == 3)   // if option three, increse collectible value
                {
                    if (level == 1)
                    {
                        TheCloud.goldValue = 2;
                    }
                    else if (level == 2)
                    {
                        TheCloud.goldValue = 3;
                    }
                }
                break;
        }

        // reduce materials
        TheCloud.settOneMaterials -= matcost;

        // reduce time
        TheCloud.settOneTimeBar -= timecost;

        // debug text
        debugText.text = "sciMin=" + TheCloud.minScience + " sciCon=" + TheCloud.scienceConv +
                         " morMin=" + TheCloud.minMorale + " morCon=" + TheCloud.moraleConv +
                         " envMin=" + TheCloud.minEnvironment + " envCon=" + TheCloud.environmentConv +
                         " iron="+ TheCloud.ironValue + " copper=" + TheCloud.copperValue + " gold=" + TheCloud.goldValue;

        UpdateScoreValues();
        updateConvValueText();
        checkForEvent();
    }

    /// <summary>
    /// on click event logic for build button 
    /// </summary>
    public void OpenBuildMenu()
    {
        if (buildPanel.gameObject.activeInHierarchy == false)
        {
            buildPanel.gameObject.SetActive(true);
            TheCloud.uiMenuOpen = true;
        }
        else
        {
            buildPanel.gameObject.SetActive(false);
            TheCloud.uiMenuOpen = false;
        }
    }
    public void OpenUpgradeMenu()
    {
        if (upgradePanel.gameObject.activeInHierarchy == false)
        {
            upgradePanel.gameObject.SetActive(true);
            upgradePanel.GetComponent<UpgradeScript>().GetPlotInfo();
            TheCloud.uiMenuOpen = true;
        }
        else
        {
            upgradePanel.gameObject.SetActive(false);
            TheCloud.uiMenuOpen = false;
        }
    }

    public void OpenCampMenu()
    {
        if (campPanel.gameObject.activeInHierarchy == false)
        {
            campPanel.gameObject.SetActive(true);
            TheCloud.uiMenuOpen = true;
        }
    }

    void AddMaterials()
    {
        TheCloud.settOneMaterials += matPrize;
        UpdateScoreValues();

        //TESTING 
        TheCloud.triggerEvent = true;
        eventPanel.GetComponent<EventScript>().updateEvent(Random.Range(0, 5));
    }

    void BackToShip()
    {
        // load ship scene
        SceneManager.LoadScene(0);
    }
}
