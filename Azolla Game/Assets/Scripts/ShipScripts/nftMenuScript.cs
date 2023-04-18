using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class nftMenuScript : MonoBehaviour
{
    [SerializeField]
    private Button op1;
    [SerializeField]
    private Button op2;
    [SerializeField]
    private Button op3;
    [SerializeField]
    private Button op4;
    [SerializeField]
    private Button op5;

    [SerializeField]
    public TextMeshProUGUI heading;
    [SerializeField]
    public TextMeshProUGUI body;

    // Start is called before the first frame update
    void Start()
    {
        Button opt1 = op1.GetComponent<Button>();
        op1.onClick.AddListener(optOneClick);

        Button opt2 = op2.GetComponent<Button>();
        op2.onClick.AddListener(optTwoClick);

        Button opt3 = op3.GetComponent<Button>();
        op3.onClick.AddListener(optThreeClick);

        Button opt4 = op4.GetComponent<Button>();
        op4.onClick.AddListener(optFourClick);

        Button opt5 = op5.GetComponent<Button>();
        op5.onClick.AddListener(optFiveClick);

        heading.text = "NFT Store";
        body.text = "Select an option to get more info.";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void optOneClick()
    {
        heading.text = "VR Experience";
        body.text = "Spend your hard earned credits on a unique VR experience. " +
            "Visit Luxor Egypt and tour the ruins of the ancient city of thebes, " +
            "learn about life in ancient egypt then flash forward for a taste of modern life in the region.";
    }

    void optTwoClick()
    {
        heading.text = "Art Collectable";
        body.text = "Get a unique NFT pixel art collectable from our limited 'Wild West' collection, " +
            "featuring legendary characters and scenes from the American west.";
    }

    void optThreeClick()
    {
        heading.text = "Crypto";
        body.text = "Trade up your credits for real crypto currency with an opportunity to buy Azolla Coin";
    }

    void optFourClick()
    {
        heading.text = "VR Experience";
        body.text = "Take a whirlwind virtual tour of the beautiful Scottish highlands, see and experience the " +
            "wildlife and wonder of this location all from the warmth of your home. ";
    }

    void optFiveClick()
    {
        heading.text = "Special Offer";
        body.text = "Get a 10% discount valid across the whole Azolla Marketplace.";
    }
}
