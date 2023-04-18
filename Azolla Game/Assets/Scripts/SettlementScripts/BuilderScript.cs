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
    [SerializeField]
    GameObject spriteManager;
    [SerializeField]
    SettlementSoundScript soundMan;

    #region Button Fields
    [SerializeField]
    private Button sciOne;
    [SerializeField]
    private Button morOne;
    [SerializeField]
    private Button envOne;
    [SerializeField]
    private Button sciTwo;
    [SerializeField]
    private Button morTwo;
    [SerializeField]
    private Button envTwo;
    [SerializeField]
    private Button sciThree;
    [SerializeField]
    private Button morThree;
    [SerializeField]
    private Button envThree;
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
        // Set Up Building Button Click Events
        Button sOne = sciOne.GetComponent<Button>();
        sOne.onClick.AddListener(sOnePress);

        Button mOne = morOne.GetComponent<Button>();
        mOne.onClick.AddListener(mOnePress);

        Button eOne = envOne.GetComponent<Button>();
        eOne.onClick.AddListener(eOnePress);

        Button sTwo = sciTwo.GetComponent<Button>();
        sTwo.onClick.AddListener(sTwoPress);

        Button mTwo = morTwo.GetComponent<Button>();
        mTwo.onClick.AddListener(mTwoPress);

        Button eTwo = envTwo.GetComponent<Button>();
        eTwo.onClick.AddListener(eTwoPress);

        Button sThree = sciThree.GetComponent<Button>();
        sThree.onClick.AddListener(sThreePress);

        Button mThree = morThree.GetComponent<Button>();
        mThree.onClick.AddListener(mThreePress);

        Button eThree = envThree.GetComponent<Button>();
        eThree.onClick.AddListener(eThreePress);


        Button closeMe = close.GetComponent<Button>();
        closeMe.onClick.AddListener(closeMePress);

        Button buildMe = buildIt.GetComponent<Button>();
        buildMe.onClick.AddListener(buildMePress);

        selectedType = "";

        sOnePress();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region Security Building Button Press Actions ** CHANGED TO SCIENCE **
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
        // set image
        image.GetComponent<Image>().sprite = spriteManager.GetComponent<SpriteManScript>().Sec_1_1;

        selectedType = "sec_1_1";
    }

    void sTwoPress()
    {
        // Set Building Name
        buildType.GetComponent<TextMeshProUGUI>().text = university.Name;
        // Set Benefits
        benOne.GetComponent<TextMeshProUGUI>().text = university.BenOne;
        benTwo.GetComponent<TextMeshProUGUI>().text = university.BenTwo;
        // Set Descriptor
        buildInfo.GetComponent<TextMeshProUGUI>().text = university.Info;
        // Set Costs
        matCost.GetComponent<TextMeshProUGUI>().text = "" + university.MatCost;
        timeCost.GetComponent<TextMeshProUGUI>().text = "" + university.TimeCost;
        // set image
        image.GetComponent<Image>().sprite = spriteManager.GetComponent<SpriteManScript>().Sec_2_1; //**

        selectedType = "sec_2_1";
    }

    void sThreePress()
    {
        // Set Building Name
        buildType.GetComponent<TextMeshProUGUI>().text = observatory.Name;
        // Set Benefits
        benOne.GetComponent<TextMeshProUGUI>().text = observatory.BenOne;
        benTwo.GetComponent<TextMeshProUGUI>().text = observatory.BenTwo;
        // Set Descriptor
        buildInfo.GetComponent<TextMeshProUGUI>().text = observatory.Info;
        // Set Costs
        matCost.GetComponent<TextMeshProUGUI>().text = "" + observatory.MatCost;
        timeCost.GetComponent<TextMeshProUGUI>().text = "" + observatory.TimeCost;
        // set image
        image.GetComponent<Image>().sprite = spriteManager.GetComponent<SpriteManScript>().Sec_3_1; //**

        selectedType = "sec_3_1";
    }

    #endregion

    #region Morale Building Button Press Actions
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
        // set image
        image.GetComponent<Image>().sprite = spriteManager.GetComponent<SpriteManScript>().Mor_1_1;

        selectedType = "mor_1_1";
    }

    void mTwoPress()
    {
        // Set Building Name
        buildType.GetComponent<TextMeshProUGUI>().text = recreationCentre.Name;
        // Set Benefits
        benOne.GetComponent<TextMeshProUGUI>().text = recreationCentre.BenOne;
        benTwo.GetComponent<TextMeshProUGUI>().text = recreationCentre.BenTwo;
        // Set Descriptor
        buildInfo.GetComponent<TextMeshProUGUI>().text = recreationCentre.Info;
        // Set Costs
        matCost.GetComponent<TextMeshProUGUI>().text = "" + recreationCentre.MatCost;
        timeCost.GetComponent<TextMeshProUGUI>().text = "" + recreationCentre.TimeCost;
        // set image
        image.GetComponent<Image>().sprite = spriteManager.GetComponent<SpriteManScript>().Mor_2_1; //**

        selectedType = "mor_2_1";
    }

    void mThreePress()
    {
        // Set Building Name
        buildType.GetComponent<TextMeshProUGUI>().text = gym.Name;
        // Set Benefits
        benOne.GetComponent<TextMeshProUGUI>().text = gym.BenOne;
        benTwo.GetComponent<TextMeshProUGUI>().text = gym.BenTwo;
        // Set Descriptor
        buildInfo.GetComponent<TextMeshProUGUI>().text = gym.Info;
        // Set Costs
        matCost.GetComponent<TextMeshProUGUI>().text = "" + gym.MatCost;
        timeCost.GetComponent<TextMeshProUGUI>().text = "" + gym.TimeCost;
        // set image
        image.GetComponent<Image>().sprite = spriteManager.GetComponent<SpriteManScript>().Mor_3_1; //**

        selectedType = "mor_3_1";
    }

    #endregion

    #region Environment Building Button Press Actions
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
        // set image
        image.GetComponent<Image>().sprite = spriteManager.GetComponent<SpriteManScript>().Env_1_1;

        selectedType = "env_1_1";
    }

    void eTwoPress()
    {
        // Set Building Name
        buildType.GetComponent<TextMeshProUGUI>().text = windTurbine.Name;
        // Set Benefits
        benOne.GetComponent<TextMeshProUGUI>().text = windTurbine.BenOne;
        benTwo.GetComponent<TextMeshProUGUI>().text = windTurbine.BenTwo;
        // Set Descriptor
        buildInfo.GetComponent<TextMeshProUGUI>().text = windTurbine.Info;
        // Set Costs
        matCost.GetComponent<TextMeshProUGUI>().text = "" + windTurbine.MatCost;
        timeCost.GetComponent<TextMeshProUGUI>().text = "" + windTurbine.TimeCost;
        // set image
        image.GetComponent<Image>().sprite = spriteManager.GetComponent<SpriteManScript>().Env_2_1; //**

        selectedType = "env_2_1";
    }

    void eThreePress()
    {
        // Set Building Name
        buildType.GetComponent<TextMeshProUGUI>().text = recyclingFacility.Name;
        // Set Benefits
        benOne.GetComponent<TextMeshProUGUI>().text = recyclingFacility.BenOne;
        benTwo.GetComponent<TextMeshProUGUI>().text = recyclingFacility.BenTwo;
        // Set Descriptor
        buildInfo.GetComponent<TextMeshProUGUI>().text = recyclingFacility.Info;
        // Set Costs
        matCost.GetComponent<TextMeshProUGUI>().text = "" + recyclingFacility.MatCost;
        timeCost.GetComponent<TextMeshProUGUI>().text = "" + recyclingFacility.TimeCost;
        // set image
        image.GetComponent<Image>().sprite = spriteManager.GetComponent<SpriteManScript>().Env_3_1; //**

        selectedType = "env_3_1";
    }

    #endregion

    void closeMePress()
    {
        this.gameObject.SetActive(false);
        TheCloud.uiMenuOpen = false; 
        soundMan.audioSource.PlayOneShot(soundMan.click2, 0.5f);
    }

    void buildMePress()
    {
        GameManagerScript gms = gameManager.GetComponent<GameManagerScript>();
        // get ID
        int id = gms.currPlotSelection;

        // check funds
        if (TheCloud.settOneMaterials >= int.Parse(matCost.text))
        {
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

            gms.AlterScores(TheCloud.Plots[id].Type, TheCloud.Plots[id].Option, TheCloud.Plots[id].Level, int.Parse(matCost.text), int.Parse(timeCost.text));
            soundMan.audioSource.PlayOneShot(soundMan.build, 0.5f);
        }

        closeMePress();
    }
}
