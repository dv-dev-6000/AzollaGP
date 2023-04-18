using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
using UnityEngine.UI;

public class nftZoneScript : MonoBehaviour
{
    [SerializeField]
    private RectTransform parentPanel;
    [SerializeField]
    private RectTransform menuPanel;

    [SerializeField]
    private Button nftMenuBut;
    [SerializeField]
    private ShipSoundManScript sMan;

    [SerializeField]
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        Button storeButt = nftMenuBut.GetComponent<Button>();
        nftMenuBut.onClick.AddListener(storeButtClick);
    }

    // Update is called once per frame
    void Update()
    {
        if (cam.transform.position.z < -40)
        {
            if (TheCloud.uiMenuOpen && parentPanel.gameObject.activeInHierarchy)
            {
                parentPanel.gameObject.SetActive(false);
            }
            else if (!TheCloud.uiMenuOpen && !parentPanel.gameObject.activeInHierarchy)
            {
                parentPanel.gameObject.SetActive(true);
            }
        }
        else
        {
            parentPanel.gameObject.SetActive(false);
        }

    }

    private void storeButtClick()
    {
        menuPanel.gameObject.SetActive(true);
        TheCloud.uiMenuOpen = true;
        sMan.audioSource.PlayOneShot(sMan.positiveClick, 0.5f);
    }
}
