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
    // security variables
    private const int securityMax = 100;
    private int securityMin;
    public int SecurityScore { get; set; }
    // morale variables
    private const int moraleMax = 100;
    private int moraleMin;
    public int MoraleScore { get; set; }
    // environment variables
    private const int environmentMax = 100;
    private int environmentMin;
    public int EnvironmentScore { get; set; }

    // resource bars
    [SerializeField]
    private Slider secSlider;
    [SerializeField]
    private Slider morSlider;
    [SerializeField]
    private Slider envSlider;


    #endregion


    // players materials cache
    private int materialsCount;
    // materials prize amount
    private int matPrize = 75;

    [SerializeField]
    public TextMeshProUGUI debugText;

    // Build/Upgrade Panel Menu
    [SerializeField]
    private RectTransform buildPanel;
    [SerializeField]
    private RectTransform upgradePanel;
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

        // set initial min values for main scores
        securityMin = TheCloud.minSecurity;
        SecurityScore = TheCloud.securityScore;
        moraleMin = TheCloud.minMorale;
        MoraleScore = TheCloud.moraleScore;
        environmentMin = TheCloud.minEnvironment;
        EnvironmentScore = TheCloud.environmentScore;


        // Set initial material amount
        materialsCount = TheCloud.settOneMaterials;

        // Set Up material Button Click Event
        Button matButt = matButton.GetComponent<Button>();
        matButt.onClick.AddListener(AddMaterials);

        // back button
        Button bckButt = backButton.GetComponent<Button>();
        bckButt.onClick.AddListener(BackToShip);

        debugText.GetComponent<TextMeshProUGUI>();

        // set up sliders 
        secSlider.GetComponent<Slider>();
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
        if (SecurityScore < securityMin)
        {
            SecurityScore = securityMin;
        }
        else if (SecurityScore > securityMax)
        {
            SecurityScore = securityMax;
        }
        secSlider.value = SecurityScore;

        // update morale bar
        if (MoraleScore < moraleMin)
        {
            MoraleScore = moraleMin;
        }
        else if (MoraleScore > moraleMax)
        {
            MoraleScore = moraleMax;
        }
        morSlider.value = MoraleScore;

        // update security bar
        if (EnvironmentScore < environmentMin)
        {
            EnvironmentScore = environmentMin;
        }
        else if (EnvironmentScore > environmentMax)
        {
            EnvironmentScore = environmentMax;
        }
        envSlider.value = EnvironmentScore;

        // update matrerials
        matDisplayText.GetComponent<TextMeshProUGUI>().text = "" + materialsCount;
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

    void AddMaterials()
    {
        materialsCount = materialsCount + matPrize;
        SecurityScore += 25;
        EnvironmentScore += 10;
        MoraleScore += 15;
        UpdateScoreValues();
    }

    void BackToShip()
    {
        // store level info in cloud
        TheCloud.minSecurity = securityMin;
        TheCloud.securityScore = SecurityScore;
        TheCloud.minMorale = moraleMin;
        TheCloud.moraleScore = MoraleScore;
        TheCloud.minEnvironment = environmentMin;
        TheCloud.environmentScore = EnvironmentScore;

        TheCloud.settOneMaterials = materialsCount;

        // load ship scene
        SceneManager.LoadScene(0);
    }
}
