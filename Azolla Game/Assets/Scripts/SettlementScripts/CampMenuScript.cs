using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Assets.Scripts;
using System;

public class CampMenuScript : MonoBehaviour
{
    [SerializeField]
    GameObject gameManager;
    GameManagerScript gms;

    #region Buttons
    [SerializeField]
    private Button close;

    [SerializeField]
    private Button convertSci;
    [SerializeField]
    private Button convertMor;
    [SerializeField]
    private Button convertEnv;
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
    }

    private void ConvertSciPress()
    {
        if (TheCloud.settOneMaterials >= 50)
        {
            TheCloud.scienceScore += (50 * TheCloud.scienceConv) / 10;
            TheCloud.settOneMaterials -= 50;

            gms.UpdateScoreValues();
        }
    }

    private void ConvertMorPress()
    {
        if (TheCloud.settOneMaterials >= 50)
        {
            TheCloud.moraleScore += (50 * TheCloud.moraleConv) / 10;
            TheCloud.settOneMaterials -= 50;

            gms.UpdateScoreValues();
        }
    }

    private void ConvertEnvPress()
    {
        if (TheCloud.settOneMaterials >= 50)
        {
            TheCloud.environmentScore += (50 * TheCloud.environmentConv) / 10;
            TheCloud.settOneMaterials -= 50;

            gms.UpdateScoreValues();
        }
    }

}
