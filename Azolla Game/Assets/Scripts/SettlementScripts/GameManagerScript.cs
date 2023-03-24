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
    // science variables
    private const int scienceMax = 100;
    //private int scienceMin;
    //public int ScienceScore { get; set; }
    // morale variables
    private const int moraleMax = 100;
    //private int moraleMin;
    //public int MoraleScore { get; set; }
    // environment variables
    private const int environmentMax = 100;
    //private int environmentMin;
    //public int EnvironmentScore { get; set; }

    // resource bars
    [SerializeField]
    private Slider sciSlider;
    [SerializeField]
    private Slider morSlider;
    [SerializeField]
    private Slider envSlider;


    #endregion


    // players materials cache
    //private int materialsCount;
    // materials prize amount
    private int matPrize = 75;

    [SerializeField]
    public TextMeshProUGUI debugText;

    // Build/Upgrade Panel Menu
    [SerializeField]
    private RectTransform buildPanel;
    [SerializeField]
    private RectTransform upgradePanel;
    [SerializeField]
    private RectTransform campPanel;
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
        TheCloud.scienceConv = 1;
        TheCloud.moraleConv = 1;
        TheCloud.environmentConv = 1;

        // Set Up material Button Click Event
        Button matButt = matButton.GetComponent<Button>();
        matButt.onClick.AddListener(AddMaterials);

        // back button
        Button bckButt = backButton.GetComponent<Button>();
        bckButt.onClick.AddListener(BackToShip);

        // set up sliders 
        sciSlider.GetComponent<Slider>();
        morSlider.GetComponent<Slider>();
        envSlider.GetComponent<Slider>();

        UpdateScoreValues();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateScoreValues()
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
        matDisplayText.GetComponent<TextMeshProUGUI>().text = "" + TheCloud.settOneMaterials;
    }
    
    public void AlterScores(string targetScore, int changeValue, int minValue = 0)
    {
        // change parameters to type/ option/ level
        switch (targetScore)
        {
            case "sec":
                TheCloud.scienceScore += changeValue;
                TheCloud.minScience = minValue;
                break;
            case "mor":
                TheCloud.moraleScore += changeValue;
                TheCloud.minMorale = minValue;
                break;
            case "env":
                TheCloud.environmentScore += changeValue;
                TheCloud.minEnvironment = minValue;
                break;
        }

        

        UpdateScoreValues();
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
            //debugText.text = "" + currPlotSelection;
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
        //ScienceScore += 25;
        //EnvironmentScore += 10;
        //MoraleScore += 15;
        UpdateScoreValues();
    }

    void BackToShip()
    {
        // load ship scene
        SceneManager.LoadScene(0);
    }
}
