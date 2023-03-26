using UnityEngine;

public class PlatformManager : MonoBehaviour
{

    // Make the player "platforms" child when on it and null when leaving the platform
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.name == "Player")
        {
            collision.transform.parent = transform;
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
