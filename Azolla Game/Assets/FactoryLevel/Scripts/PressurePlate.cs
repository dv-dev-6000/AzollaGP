using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{

    public GameObject doorVertical;
    public GameObject doorHorizontal;

    [SerializeField] private AudioSource doorEffect;



    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.name == "Player")
        {
                // Move pressure plate down
                transform.Translate(0, -0.0060f, 0);
                
            doorVertical.transform.Translate(0,0.05f,0);
            doorHorizontal.transform.Translate(0.05f,0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.name == "Player")
        {
            collision.transform.parent = transform;
            doorEffect.Play();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.name == "Player")
        {
            collision.transform.parent = null;
        }
    }
}
