using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public Vector3 originalPos;
    bool moveBack = false;

    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.position;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.name == "Player" || collision.transform.name == "PushableGear")
        {
                // Move pressure plate down
                transform.Translate(0, -0.01f, 0);
                moveBack = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.name == "Player" || collision.transform.name == "PushableGear")
        {
            collision.transform.parent = transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.name == "Player" || collision.transform.name == "PushableGear")
        {
            collision.transform.parent = null;
            moveBack = true;
        }
    }

    private void Update()
    {
        if (moveBack)
        {
            if (transform.position.y < originalPos.y)
            {
                transform.Translate(0, 0.01f, 0);
            }
            else
            {
                moveBack = false;
            }
        }
    }
}
