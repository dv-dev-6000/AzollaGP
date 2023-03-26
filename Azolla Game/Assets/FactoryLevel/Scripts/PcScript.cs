using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PcScript : MonoBehaviour
{
    public GameObject PC;
    public Sprite OFF;
    public SpriteRenderer ON;

    private void Start()
    {
        ON = gameObject.GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SwapSprite();
        }
    }

    void SwapSprite()
    {
        ON.sprite = OFF;
    }
}
