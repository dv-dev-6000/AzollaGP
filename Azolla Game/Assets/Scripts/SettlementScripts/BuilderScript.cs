using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Assets.Scripts.SettlementScripts;
using Assets.Scripts;

public class BuilderScript : MonoBehaviour
{
    private string selectedType;

    [SerializeField]
    GameObject gameManager;

    #region Button Fields
    [SerializeField]
    private Button secOne;
    [SerializeField]
    private Button morOne;
    [SerializeField]
    private Button envOne;
    [SerializeField]
    private Button close;
    [SerializeField]
    private Button buildIt;


    #endregion

    #region Info Fields
    [SerializeField]
    private TextMeshProUGUI buildType;
    [SerializeField]
    private TextMeshProUGUI benOne;
    [SerializeField]
    private TextMeshProUGUI benTwo;

    [SerializeField]
    private TextMeshProUGUI buildInfo;

    [SerializeField]
    private TextMeshProUGUI matCost;
    [SerializeField]
    private TextMeshProUGUI timeCost;

    #endregion

    #region Building Objects
    BuildingInfo watchtower = new BuildingInfo(1);
    BuildingInfo park = new BuildingInfo(2);
    BuildingInfo airPurifier = new BuildingInfo(3);
    #endregion

    [SerializeField]
    private GameObject plot0;
    [SerializeField]
    private GameObject plot1;
    [SerializeField]
    private GameObject plot2;
    [SerializeField]
    private GameObject plot3;
    [SerializeField]
    private GameObject plot4;
    [SerializeField]
    private GameObject plot5;


    // Start is called before the first frame update
    void Start()
    {
        //gameManager.GetComponent<GameObject>();

        // Set Up Building Button Click Events
        Button sOne = secOne.GetComponent<Button>();
        sOne.onClick.AddListener(sOnePress);

        Button mOne = morOne.GetComponent<Button>();
        mOne.onClick.AddListener(mOnePress);

        Button eOne = envOne.GetComponent<Button>();
        eOne.onClick.AddListener(eOnePress);

        Button closeMe = close.GetComponent<Button>();
        closeMe.onClick.AddListener(closeMePress);

        Button buildMe = buildIt.GetComponent<Button>();
        buildMe.onClick.AddListener(buildMePress);

        selectedType = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void sOnePress()
    {
        // Set Building Name
        buildType.GetComponent<TextMeshProUGUI>().text = watchtower.Name;
        // Set Benefits
        benOne.GetComponent<TextMeshProUGUI>().text = watchtower.BenOne;
        benTwo.GetComponent<TextMeshProUGUI>().text = watchtower.BenTwo;
        // Set Descriptor
        buildInfo.GetComponent<TextMeshProUGUI>().text = watchtower.Info;
        // Set Costs
        matCost.GetComponent<TextMeshProUGUI>().text = "" + watchtower.MatCost;
        timeCost.GetComponent<TextMeshProUGUI>().text = "" + watchtower.TimeCost;

        selectedType = "sec_1_1";
    }

    void mOnePress()
    {
        // Set Building Name
        buildType.GetComponent<TextMeshProUGUI>().text = park.Name;
        // Set Benefits
        benOne.GetComponent<TextMeshProUGUI>().text = park.BenOne;
        benTwo.GetComponent<TextMeshProUGUI>().text = park.BenTwo;
        // Set Descriptor
        buildInfo.GetComponent<TextMeshProUGUI>().text = park.Info;
        // Set Costs
        matCost.GetComponent<TextMeshProUGUI>().text = ""+park.MatCost;
        timeCost.GetComponent<TextMeshProUGUI>().text = ""+park.TimeCost;

        selectedType = "mor_1_1";
    }

    void eOnePress()
    {
        // Set Building Name
        buildType.GetComponent<TextMeshProUGUI>().text = airPurifier.Name;
        // Set Benefits
        benOne.GetComponent<TextMeshProUGUI>().text = airPurifier.BenOne;
        benTwo.GetComponent<TextMeshProUGUI>().text = airPurifier.BenTwo;
        // Set Descriptor
        buildInfo.GetComponent<TextMeshProUGUI>().text = airPurifier.Info;
        // Set Costs
        matCost.GetComponent<TextMeshProUGUI>().text = "" + airPurifier.MatCost;
        timeCost.GetComponent<TextMeshProUGUI>().text = "" + airPurifier.TimeCost;

        selectedType = "env_1_1";
    }

    void closeMePress()
    {
        this.gameObject.SetActive(false);
        TheCloud.uiMenuOpen = false; // update to use global var
    }

    void buildMePress()
    {
        GameManagerScript gms = gameManager.GetComponent<GameManagerScript>();
        // get ID
        int id = gms.currPlotSelection;

        // set plot to building type
        TheCloud.Plots[id].Type = selectedType.Substring(0, 3);
        TheCloud.Plots[id].Option = int.Parse(selectedType[4].ToString());
        TheCloud.Plots[id].Level = int.Parse(selectedType[6].ToString());

        switch (id) 
        {
            case 0:
                plot0.GetComponent<BuildPlotScript>().UpdatePlot();
                break;
            case 1:
                plot1.GetComponent<BuildPlotScript>().UpdatePlot();
                break;
            case 2:
                plot2.GetComponent<BuildPlotScript>().UpdatePlot();
                break;
            case 3:
                plot3.GetComponent<BuildPlotScript>().UpdatePlot();
                break;
            case 4:
                plot4.GetComponent<BuildPlotScript>().UpdatePlot();
                break;
            case 5:
                plot5.GetComponent<BuildPlotScript>().UpdatePlot();
                break;
        }

        closeMePress();
    }
}
