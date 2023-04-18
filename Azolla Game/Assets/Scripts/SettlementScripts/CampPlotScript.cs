using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class CampPlotScript : MonoBehaviour
{
    [SerializeField]
    GameObject gameManager;

    [SerializeField]
    private GameObject hovCir;
    [SerializeField]
    public GameObject upgradeOneSprite;
    [SerializeField]
    SettlementSoundScript soundMan;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        //check if menu closed
        if (TheCloud.uiMenuOpen == false)
        {
            hovCir.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        //check if menu closed
        if (TheCloud.uiMenuOpen == false)
        {
            hovCir.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        if (hovCir.activeInHierarchy == true)
        {
            gameManager.GetComponent<GameManagerScript>().OpenCampMenu();
            soundMan.audioSource.PlayOneShot(soundMan.click1, 0.5f);
            hovCir.SetActive(false);
        }
    }
}
