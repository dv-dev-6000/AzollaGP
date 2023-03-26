using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PcScript : MonoBehaviour
{
    public GameObject PC;
    public Sprite OFF;
    public SpriteRenderer ON;

    [SerializeField] private AudioSource powerOFF;

    bool collide = false;

    private void Start()
    {
        ON = gameObject.GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player entered collider");

            collide = true;
        }
    }

    private void Update()
    {
        if(collide)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Button E pressed");
                powerOFF.Play();
                SwapSprite();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collide = false;
        Debug.Log("Player left the collider");
    }

    void SwapSprite()
    {
        ON.sprite = OFF;
    }
}
