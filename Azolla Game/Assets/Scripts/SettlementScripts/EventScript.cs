using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;
using TMPro;

public class EventScript : MonoBehaviour
{
    [SerializeField]
    GameObject gameManager;
    [SerializeField]
    private RectTransform resultPanel;

    GameManagerScript gms;

    private float currEvent;

    [SerializeField]
    private Button op1;
    [SerializeField]
    private Button op2;
    [SerializeField]
    private Button op3;

    [SerializeField]
    private Button accept;

    [SerializeField]
    private TextMeshProUGUI eventTitle;
    [SerializeField]
    private TextMeshProUGUI eventInfo;
    [SerializeField]
    private TextMeshProUGUI eventOpOne;
    [SerializeField]
    private TextMeshProUGUI eventOpTwo;
    [SerializeField]
    private TextMeshProUGUI eventOpThree;

    [SerializeField]
    private TextMeshProUGUI resultInfo;

    // Start is called before the first frame update
    void Start()
    {
        Button option1 = op1.GetComponent<Button>();
        op1.onClick.AddListener(option1Press);

        Button option2 = op2.GetComponent<Button>();
        op2.onClick.AddListener(option2Press);

        Button option3 = op3.GetComponent<Button>();
        op3.onClick.AddListener(option3Press);

        Button acceptResult = accept.GetComponent<Button>();
        accept.onClick.AddListener(acceptResultPress);

        gms = gameManager.GetComponent<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateEvent(float num)
    {

        currEvent = num;

        switch (num)
        {
            case 0:
                eventTitle.text = "Mysterious Stranger";
                eventInfo.text = "A mysterious stranger arrives at the settlement claiming to be a representative of one of the local human tribes, " +
                    "They offer up a gift of crudely made tools and scraps of precious metal. " +
                    "The stranger wishes to establish trade links with the settlement and requests that one of your leading town members return with them " +
                    "to meet their leader for talks…";
                eventOpOne.text = "Send them away, these gifts have little value to us.";
                eventOpTwo.text = "Accept the proposal but send an low ranking envoy, just to play it safe.";
                eventOpThree.text = "Accept the proposal and send our top diplomat to make an impression";
                break;

            case 1:
                eventTitle.text = "Unidentified Object";
                eventInfo.text = "Exploration teams have discovered a strange manmade object buried in the remains of an ancient human city. " +
                    "The spherical object seems to be a container, sealed with a cryptic puzzle lock. " +
                    "A faint ticking noise can be heard from inside the container…";
                eventOpOne.text = "Leave it alone, this seems dangerous.";
                eventOpTwo.text = "Bring the object back to the settlement for further reasearch.";
                eventOpThree.text = "Force open the lock to find out whats inside.";
                break;

            case 2:
                eventTitle.text = "Environmental Hazards";
                eventInfo.text = "A dangerous looking radiation storm is heading for the settlement, storms of this magnitude have been known to last up to 5 days at times. " +
                    "A prolonged storm lockdown will drastically impact the settlements productivity… ";
                eventOpOne.text = "Launch chemicals to dissipate the storm before it reaches the settlement";
                eventOpTwo.text = "Lock down the settlement and let the storm run its course.";
                eventOpThree.text = "Its just a storm, carry on with normal operations.";
                break;

            case 3:
                eventTitle.text = "Attack!";
                eventInfo.text = "A large force of local tribes people have launched an attack on the settlement, " +
                    "security are currently holding them off at the main gate but decisive action will need to be taken soon. ";
                eventOpOne.text = "Commit the full power of the settlement to fight off enemies.";
                eventOpTwo.text = "Take defensive actions only and avoid lethal force where necessary.";
                eventOpThree.text = "Offer resources as a bribe for the attackers to leave immediately.";
                break;

            case 4:
                eventTitle.text = "Beware! Dangerous Machinery";
                eventInfo.text = "Scouts have sent back reports warning of a large group of rogue AI powered bots camped a days ride away from the settlement. " +
                    "Rogue bots are well known to harbour a grudge against the human population of earth and there are growing fears amongst settlers that this" +
                    " could pose a significant threat…";
                eventOpOne.text = "Call back the scouts, lay low and hope they move on peacefully";
                eventOpTwo.text = "Bolster settlement security, restrict settlers from travelling outside settlement bounds.";
                eventOpThree.text = "Send security forces out to neutralise the threat.";
                break;

            default:
                break;
        }
    }

    public void doResult(int option)
    {
        if (currEvent == 0)
        {
            // stranger
            switch (option)
            {
                case 1:
                    // Send them away, these gifts have little value to us.
                    resultInfo.text = "Your guest seems disappointed and departs without any trouble, good riddance to bad rubbish. Everything seems fine…";
                    break;

                case 2:
                    // Accept the proposal but send an low ranking envoy, just to play it safe.
                    resultInfo.text = "Oh no! Seems that your inexperienced envoy had made a mess of things and the offer for friendly relations has been revoked. \n\nSocial score reduced!!";
                    TheCloud.moraleScore -= 15;
                    break;

                case 3:
                    // Accept the proposal and send our top diplomat to make an impression
                    resultInfo.text = "The diplomat returned with great news, new trade relations have been established and a gift of materials has been received. \n\nSocial score improved!!";
                    TheCloud.moraleScore += 15;
                    TheCloud.settOneMaterials += 100;
                    break;

                default:
                    break;
            }
        }
        else if (currEvent == 1)
        {
            // object
            switch (option)
            {
                case 1:
                    // Leave it alone, this seems dangerous.
                    resultInfo.text = "Sometimes, its better not to know. ";
                    break;

                case 2:
                    // bring back
                    resultInfo.text = "Testing revealed the device contained a computer virus set up to harm rogue AI. You safely decommission the device and document the data. \n\nCulture score improved!!";
                    TheCloud.scienceScore += 20;
                    break;

                case 3:
                    // force open
                    resultInfo.text = "The object unleashes a harmful computer virus that wipes a significant portion of your scientific data. \n\nCulture score reduced!!";
                    TheCloud.scienceScore -= 20;
                    break;

                default:
                    break;
            }
        }
        else if (currEvent == 2)
        {
            // storm
            switch (option)
            {
                case 1:
                    // dissapate 
                    resultInfo.text = "The chemical gets to work in the atmosphere, before the day is over the weather dissipates into no more than a light rain. " +
                        "Environmental scientists report that atmospheric toxicity levels have increased in the region as a result. \n\nEnvironment score reduced!!";
                    TheCloud.environmentScore -= 20;
                    break;

                case 2:
                    // lockdown
                    resultInfo.text = "The population are locked down and safely ride out the storm, though morale is low. \n\nCulture score increased!! Social score reduced!!";
                    TheCloud.moraleScore -= 10;
                    TheCloud.scienceScore += 20;
                    break;

                case 3:
                    // carry on
                    resultInfo.text = "The storm rages and the settlements population and infastructure take a beating. \n\nCulture score reduced!! Social score reduced!!";
                    TheCloud.moraleScore -= 20;
                    TheCloud.scienceScore -= 20;
                    break;

                default:
                    break;
            }
        }
        else if (currEvent == 3)
        {
            // attack
            switch (option)
            {
                case 1:
                    // fight 
                    resultInfo.text = "After intense fighting the attacking force is overpowered by your technological advantage, remaining forces retreat. \n\nMaterials gained!!";
                    TheCloud.settOneMaterials += 100;
                    break;

                case 2:
                    // defend 
                    resultInfo.text = "The defensive position holds, but when enemy re-enforcements arrive the settlement is overrun. The attackers loot and vandalise the settlement. \n\nMaterials lost!! Social score reduced!!";
                    TheCloud.settOneMaterials -= 200;
                    TheCloud.moraleScore -= 20;
                    break;

                case 3:
                    // bribe
                    resultInfo.text = "A heavy materials price is paid and the attackers turn back and leave you alone… for now. \n\nMaterials lost!!";
                    TheCloud.settOneMaterials -= 200;
                    break;

                default:
                    break;
            }
        }
        else if (currEvent == 4)
        {
            // robots
            switch (option)
            {
                case 1:
                    // hide 
                    resultInfo.text = "The robot convoy changes direction and bypasses the settlement, that was lucky. \n\nSocial score improved!!";
                    TheCloud.moraleScore += 10;
                    break;

                case 2:
                    // defend 
                    resultInfo.text = "Defences are strengthened, settlers are not happy about the restrictions but accept them. " +
                        "In time the robot convoy moves on without any issues. \n\nSocial score reduced!! ";
                    TheCloud.moraleScore -= 10;
                    break;

                case 3:
                    // attack
                    resultInfo.text = "The robot convoy are overwhelmed and forced out of the area but many of your security forces don’t return. \n\nSocial score reduced!!";
                    TheCloud.moraleScore -= 25;
                    break;

                default:
                    break;
            }
        }

        gms.UpdateScoreValues();
    }

    private void option1Press()
    {
        doResult(1);
        closeMe();
    }

    private void option2Press()
    {
        doResult(2);
        closeMe();
    }

    private void option3Press()
    {
        doResult(3);
        closeMe();
    }

    private void acceptResultPress()
    {
        resultPanel.gameObject.SetActive(false);
        TheCloud.uiMenuOpen = false;
        TheCloud.triggerEvent = false;
        TheCloud.settOneTimeBar = 6;
        gms.UpdateScoreValues();
    }

    private void closeMe()
    {
        // close event window
        this.gameObject.SetActive(false);
        // open event result window
        resultPanel.gameObject.SetActive(true);
    }
}
