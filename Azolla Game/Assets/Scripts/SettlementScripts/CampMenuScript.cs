using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Assets.Scripts;
using System;
using UnityEngine.SceneManagement;

public class CampMenuScript : MonoBehaviour
{
    private int sceneToLoad;

    [SerializeField]
    GameObject gameManager;
    GameManagerScript gms;

    [SerializeField]
    SettlementSoundScript soundMan;

    [SerializeField]
    private RectTransform embarkPanel;

    #region Buttons
    [SerializeField]
    private Button close;

    [SerializeField]
    private Button convertSci;
    [SerializeField]
    private Button convertMor;
    [SerializeField]
    private Button convertEnv;

    [SerializeField]
    private Button embarkOne;
    [SerializeField]
    private Button embarkTwo;

    [SerializeField]
    private Button withTimer;
    [SerializeField]
    private Button noTimer;
    [SerializeField]
    private Button embarkClose;

    #endregion


    // Start is called before the first frame update
    void Start()
    {
        Button closeMe = close.GetComponent<Button>();
        closeMe.onClick.AddListener(closeMePress);

        Button convSci = convertSci.GetComponent<Button>();
        convSci.onClick.AddListener(ConvertSciPress);

        Button convMor = convertMor.GetComponent<Button>();
        convMor.onClick.AddListener(ConvertMorPress);

        Button convEnv = convertEnv.GetComponent<Button>();
        convEnv.onClick.AddListener(ConvertEnvPress);

        Button levelOne = embarkOne.GetComponent<Button>();
        embarkOne.onClick.AddListener(EmbarkOnePress);

        Button levelTwo = embarkTwo.GetComponent<Button>();
        embarkTwo.onClick.AddListener(EmbarkTwoPress);

        Button timerBut = withTimer.GetComponent<Button>();
        withTimer.onClick.AddListener(timerButPress);

        Button noTimerBut = noTimer.GetComponent<Button>();
        noTimer.onClick.AddListener(noTimerButPress);

        Button closeEmbark = embarkClose.GetComponent<Button>();
        embarkClose.onClick.AddListener(embarkClosePress);

        gms = gameManager.GetComponent<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void closeMePress()
    {
        this.gameObject.SetActive(false);
        TheCloud.uiMenuOpen = false;
        soundMan.audioSource.PlayOneShot(soundMan.click2, 0.5f);
    }

    private void ConvertSciPress()
    {
        if (TheCloud.settOneMaterials >= 50)
        {
            TheCloud.scienceScore += (50 * TheCloud.scienceConv) / 10;
            TheCloud.settOneMaterials -= 50;
            soundMan.audioSource.PlayOneShot(soundMan.click1, 0.5f);
            gms.UpdateScoreValues();
            TheCloud.credits += 20;
        }
    }

    private void ConvertMorPress()
    {
        if (TheCloud.settOneMaterials >= 50)
        {
            TheCloud.moraleScore += (50 * TheCloud.moraleConv) / 10;
            TheCloud.settOneMaterials -= 50;
            soundMan.audioSource.PlayOneShot(soundMan.click1, 0.5f);
            gms.UpdateScoreValues();
            TheCloud.credits += 20;
        }
    }

    private void ConvertEnvPress()
    {
        if (TheCloud.settOneMaterials >= 50)
        {
            TheCloud.environmentScore += (50 * TheCloud.environmentConv) / 10;
            TheCloud.settOneMaterials -= 50;
            soundMan.audioSource.PlayOneShot(soundMan.click1, 0.5f);
            gms.UpdateScoreValues();
            TheCloud.credits += 20;
        }
    }

    private void EmbarkOnePress()
    {
        // if more than one level add level flag to cloud

        // update prize in cloud
        TheCloud.levelPrize = 100;
        // close menu
        this.gameObject.SetActive(false);
        // open embark menu
        embarkPanel.gameObject.SetActive(true);
        soundMan.audioSource.PlayOneShot(soundMan.click1, 0.5f);
        sceneToLoad = 3;
    }

    private void EmbarkTwoPress()
    {
        // if more than one level add level flag to cloud

        // update prize in cloud
        TheCloud.levelPrize = 200;
        // close menu
        this.gameObject.SetActive(false);
        // open embark menu
        embarkPanel.gameObject.SetActive(true);
        soundMan.audioSource.PlayOneShot(soundMan.click1, 0.5f);
        sceneToLoad = 3;
    }

    private void timerButPress()
    {
        // set timer bool in cloud
        TheCloud.playTimed = true;

        // load level 
        embarkPanel.gameObject.SetActive(false); // ** replace line with level load
        TheCloud.uiMenuOpen = false;

        SceneManager.LoadScene(sceneToLoad);
    }

    private void noTimerButPress()
    {
        // set timer boolk in cloud
        TheCloud.playTimed = false;

        // load level
        embarkPanel.gameObject.SetActive(false); // ** replace line with level load
        TheCloud.uiMenuOpen = false;

        SceneManager.LoadScene(sceneToLoad);
    }

    private void embarkClosePress()
    {
        embarkPanel.gameObject.SetActive(false);
        TheCloud.uiMenuOpen = false;
        soundMan.audioSource.PlayOneShot(soundMan.click2, 0.5f);
    }
}
