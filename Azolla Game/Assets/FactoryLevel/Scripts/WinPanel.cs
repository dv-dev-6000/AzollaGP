using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;

public class WinPanel : MonoBehaviour
{
    [Header ("Resources Txt")]
    [SerializeField] private Text woodCount;
    [SerializeField] private Text ironCount;
    [SerializeField] private Text goldCount;
    [SerializeField] private Text copperCount;

    [Header ("Player Controller")]
    public PlayerController playerController;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    public void Win()
    {
        woodCount.text = "Wood: " + playerController.woodCount;
        ironCount.text = "Iron: " + playerController.ironCount;
        goldCount.text = "Gold: " + playerController.goldCount;
        copperCount.text = "Copper: " + playerController.copperCount;

        TheCloud.matsCollected = playerController.woodCount + playerController.ironCount + playerController.goldCount + playerController.copperCount;
        TheCloud.returnedFromPlatformer = true;
    }
}
