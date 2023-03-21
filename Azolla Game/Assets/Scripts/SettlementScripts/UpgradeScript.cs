using Assets.Scripts;
using Assets.Scripts.SettlementScripts;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeScript : MonoBehaviour
{
    [SerializeField]
    GameObject gameManager;
    [SerializeField]
    GameObject spriteManager;

    #region Buttons
    [SerializeField]
    private Button close;
    [SerializeField]
    private Button upgradeIt;
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

    [SerializeField]
    private Image image;
    #endregion

    #region Building Objects
    BuildingInfo watchtower = new BuildingInfo(1);
    BuildingInfo park = new BuildingInfo(2);
    BuildingInfo airPurifier = new BuildingInfo(3);
    BuildingInfo university = new BuildingInfo(4);
    BuildingInfo recreationCentre = new BuildingInfo(5);
    BuildingInfo windTurbine = new BuildingInfo(6);
    BuildingInfo observatory = new BuildingInfo(7);
    BuildingInfo gym = new BuildingInfo(8);
    BuildingInfo recyclingFacility = new BuildingInfo(9);
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
        Button closeMe = close.GetComponent<Button>();
        closeMe.onClick.AddListener(closeMePress);

        Button upgradeMe = upgradeIt.GetComponent<Button>();
        upgradeMe.onClick.AddListener(upgradeMePress);

        GetPlotInfo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void closeMePress()
    {
        this.gameObject.SetActive(false);
        TheCloud.uiMenuOpen = false;
    }

    void upgradeMePress()
    {
        int id = gameManager.GetComponent<GameManagerScript>().currPlotSelection;

        // check for price

        switch (id)
        {
            case 0:
                plot0.GetComponent<BuildPlotScript>().upgradeSprite.SetActive(true);
                break;
            case 1:
                plot1.GetComponent<BuildPlotScript>().upgradeSprite.SetActive(true);
                break;
            case 2:
                plot2.GetComponent<BuildPlotScript>().upgradeSprite.SetActive(true);
                break;
            case 3:
                plot3.GetComponent<BuildPlotScript>().upgradeSprite.SetActive(true);
                break;
            case 4:
                plot4.GetComponent<BuildPlotScript>().upgradeSprite.SetActive(true);
                break;
            case 5:
                plot5.GetComponent<BuildPlotScript>().upgradeSprite.SetActive(true);
                break;
        }
        closeMePress();
    }

    public void GetPlotInfo()
    {
        int id = gameManager.GetComponent<GameManagerScript>().currPlotSelection;
        string currBuilding = TheCloud.Plots[id].Type + "_" + TheCloud.Plots[id].Option;
        BuildingInfo currBuildType;

        switch (currBuilding)
        {
            case "sec_1":
                currBuildType = watchtower;
                image.GetComponent<Image>().sprite = spriteManager.GetComponent<SpriteManScript>().Sec_1_1;
                break;
            case "mor_1":
                currBuildType = park;
                image.GetComponent<Image>().sprite = spriteManager.GetComponent<SpriteManScript>().Mor_1_1;
                break;
            case "env_1":
                currBuildType = airPurifier;
                image.GetComponent<Image>().sprite = spriteManager.GetComponent<SpriteManScript>().Env_1_1;
                break;
            case "sec_2":
                currBuildType = university;
                image.GetComponent<Image>().sprite = spriteManager.GetComponent<SpriteManScript>().Sec_2_1;
                break;
            case "mor_2":
                currBuildType = recreationCentre;
                image.GetComponent<Image>().sprite = spriteManager.GetComponent<SpriteManScript>().Mor_2_1;
                break;
            case "env_2":
                currBuildType = windTurbine;
                image.GetComponent<Image>().sprite = spriteManager.GetComponent<SpriteManScript>().Env_2_1;
                break;
            case "sec_3":
                currBuildType = observatory;
                image.GetComponent<Image>().sprite = spriteManager.GetComponent<SpriteManScript>().Sec_3_1;
                break;
            case "mor_3":
                currBuildType = gym;
                image.GetComponent<Image>().sprite = spriteManager.GetComponent<SpriteManScript>().Mor_3_1;
                break;
            case "env_3":
                currBuildType = recyclingFacility;
                image.GetComponent<Image>().sprite = spriteManager.GetComponent<SpriteManScript>().Env_3_1;
                break;
            default:
                currBuildType = watchtower;
                break;
        }

        // Set Building Name
        buildType.GetComponent<TextMeshProUGUI>().text = currBuildType.Name;
        // Set Benefits
        benOne.GetComponent<TextMeshProUGUI>().text = currBuildType.BenOneUP;
        benTwo.GetComponent<TextMeshProUGUI>().text = currBuildType.BenTwoUP;
        // Set Descriptor
        buildInfo.GetComponent<TextMeshProUGUI>().text = currBuildType.Info;
        // Set Costs
        matCost.GetComponent<TextMeshProUGUI>().text = "" + currBuildType.MatCostUP;
        timeCost.GetComponent<TextMeshProUGUI>().text = "" + currBuildType.TimeCostUP;

    }
}
