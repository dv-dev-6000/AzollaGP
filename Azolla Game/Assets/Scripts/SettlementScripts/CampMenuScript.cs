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
            
        }
    }

    private void ConvertMorPress()
    {
        
    }

    private void ConvertEnvPress()
    {
        
    }

}
