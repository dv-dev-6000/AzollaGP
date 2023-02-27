using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    public bool isMenuOpen { get; set; }
    public int currPlotSelection { get; set; }

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
    private TextMeshProUGUI debugText;

    // Build/Upgrade Panel Menu
    [SerializeField]
    private RectTransform buildPanel;
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
        securityMin = 0;
        SecurityScore = securityMin;
        moraleMin = 0;
        MoraleScore = moraleMin;
        environmentMin = 0;
        EnvironmentScore = environmentMin;


        // set menuopen bool
        isMenuOpen = false;

        // Set initial material amount
        materialsCount = 0;

        // Set Up material Button Click Event
        Button matButt = matButton.GetComponent<Button>();
        matButt.onClick.AddListener(AddMaterials);

        debugText.GetComponent<TextMeshProUGUI>();

        // set up sliders 
        secSlider.GetComponent<Slider>();
        morSlider.GetComponent<Slider>();
        envSlider.GetComponent<Slider>();
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
    }
    
    /// <summary>
    /// on click event logic for build button 
    /// </summary>
    public void OpenBuildMenu()
    {
        if (buildPanel.gameObject.activeInHierarchy == false)
        {
            buildPanel.gameObject.SetActive(true);
            isMenuOpen = true;
            debugText.text = "" + currPlotSelection;
        }
        else
        {
            buildPanel.gameObject.SetActive(false);
            isMenuOpen = false;
        }
    }

    void AddMaterials()
    {
        materialsCount = materialsCount + matPrize;
        matDisplayText.GetComponent<TextMeshProUGUI>().text = ""+materialsCount;
        SecurityScore += 25;
        EnvironmentScore += 10;
        MoraleScore += 15;
        UpdateScoreValues();
    }
}
