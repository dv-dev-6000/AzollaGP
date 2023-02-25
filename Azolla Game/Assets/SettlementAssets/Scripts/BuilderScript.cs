using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuilderScript : MonoBehaviour
{
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

    [SerializeField]
    private Image image;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
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
        buildType.GetComponent<TextMeshProUGUI>().text = "Watch Tower";
        // Set Benefits
        benOne.GetComponent<TextMeshProUGUI>().text = "Provides a boost to the settlements Security score.";
        benTwo.GetComponent<TextMeshProUGUI>().text = "Security score can't be reduced below 25%";
        // Set Descriptor
        buildInfo.GetComponent<TextMeshProUGUI>().text = "The watchtower allows settlers to gain a high vantage point and keep a close watch on the lands around the settlement.";
        // Set Costs
        matCost.GetComponent<TextMeshProUGUI>().text = "250";
        timeCost.GetComponent<TextMeshProUGUI>().text = "2";
    }

    void mOnePress()
    {
        // Set Building Name
        buildType.GetComponent<TextMeshProUGUI>().text = "Park";
        // Set Benefits
        benOne.GetComponent<TextMeshProUGUI>().text = "Provides a boost to the settlements Morale score.";
        benTwo.GetComponent<TextMeshProUGUI>().text = "Morale score can't be reduced below 25%";
        // Set Descriptor
        buildInfo.GetComponent<TextMeshProUGUI>().text = "The park provides a recreational area for settlers to unwind and relax, happy settlers are productive settlers.";
        // Set Costs
        matCost.GetComponent<TextMeshProUGUI>().text = "150";
        timeCost.GetComponent<TextMeshProUGUI>().text = "2";
    }

    void eOnePress()
    {
        // Set Building Name
        buildType.GetComponent<TextMeshProUGUI>().text = "Air Purifier";
        // Set Benefits
        benOne.GetComponent<TextMeshProUGUI>().text = "Provides a boost to the settlements Environment score.";
        benTwo.GetComponent<TextMeshProUGUI>().text = "Environment score can't be reduced below 25%";
        // Set Descriptor
        buildInfo.GetComponent<TextMeshProUGUI>().text = "Air purifiers help clear the atmosphere of toxic fumes, they are an essential first step in the mission to resettle earth. ";
        // Set Costs
        matCost.GetComponent<TextMeshProUGUI>().text = "200";
        timeCost.GetComponent<TextMeshProUGUI>().text = "2";
    }

    void closeMePress()
    {
        this.gameObject.SetActive(false);
    }
}
