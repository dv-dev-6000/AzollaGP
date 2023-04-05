using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinPanel : MonoBehaviour
{
    [SerializeField] private Text woodCount;
    [SerializeField] private Text ironCount;
    [SerializeField] private Text goldCount;
    [SerializeField] private Text copperCount;

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
    }
}
