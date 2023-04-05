using UnityEngine.UI;
using UnityEngine;

public class PcScript : MonoBehaviour
{
    PlayerController playerController;

    public GameObject PC;
    public Sprite OFF;
    public SpriteRenderer ON;

    [SerializeField] private AudioSource powerOFF;
    [SerializeField] private Text PCcounter;

    bool collide = false;
    int wasPressed = 0;
    int pcCountLvl1 = 1;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        ON = gameObject.GetComponent<SpriteRenderer>();

        PCcounter.text = "- " + pcCountLvl1;
    }

    // Enable trigger so it could be used in the update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collide = true;
        }
    }

    // Swap sprites when a player presses E
    private void Update()
    {
        if(collide)
        {
            if (Input.GetKeyDown(KeyCode.E) && wasPressed < 1)
            {
                    powerOFF.Play();
                    SwapSprite();
                pcCountLvl1--;

                    PCcounter.text = "- " + pcCountLvl1.ToString();
                    collide = false;
                    wasPressed++;
            }
        }
    }

    // Make trigger false after player leaves trigger box
    private void OnTriggerExit2D(Collider2D collision)
    {
        collide = false;
    }

    // Swap computer sprites
    void SwapSprite()
    {
        ON.sprite = OFF;
    }
}
