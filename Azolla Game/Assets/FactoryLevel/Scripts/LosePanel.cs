using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LosePanel : MonoBehaviour
{
    [Header ("Player Controller")]
    public PlayerController playerController;

    [Header ("Resources")]
    [SerializeField] private Text woodCount;
    [SerializeField] private Text ironCount;
    [SerializeField] private Text goldCount;
    [SerializeField] private Text copperCount;

    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    public void Lose()
    {
        woodCount.text = "Wood: " + playerController.woodCount / 2;
        ironCount.text = "Iron: " + playerController.ironCount / 2;
        goldCount.text = "Gold: " + playerController.goldCount / 2;
        copperCount.text = "Copper: " + playerController.copperCount / 2;
    }
}
