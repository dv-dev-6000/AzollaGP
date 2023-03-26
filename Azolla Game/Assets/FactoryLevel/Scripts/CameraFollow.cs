using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 0f, -10f);
    private Vector3 velocity = Vector3.zero;
    private float smoothTime = 0.25f;

    [SerializeField]

    private Transform target;

    // Update is called once per frame
    void Update()
    {
        // Make camera follow the player in a smooth way
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        
    }
}
