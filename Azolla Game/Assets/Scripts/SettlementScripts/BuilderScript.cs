using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Assets.Scripts.SettlementScripts;
using Assets.Scripts;

public class BuilderScript : MonoBehaviour
{
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
    Building watchtower = new Building(1);
    Building park = new Building(2);
    Building airPurifier = new Building(3);
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        gameManager.GetComponent<GameObject>();

        // Set Up Building Button Click Events
        Button sOne = secOne.GetComponent<Button>();
        sOne.onClick.AddListener(sOnePress);

        Button mOne = morOne.GetComponent<Button>();
        mOne.onClick.AddListener(mOnePress);

        Button eOne = envOne.GetComponent<Button>();
        eOne.onClick.AddListener(eOnePress);

        Button closeMe = close.GetComponent<Button>();
        closeMe.onClick.AddListener(closeMePress);
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
    }

    void closeMePress()
    {
        this.gameObject.SetActive(false);
        TheCloud.uiMenuOpen = false; // update to use global var
    }
}
