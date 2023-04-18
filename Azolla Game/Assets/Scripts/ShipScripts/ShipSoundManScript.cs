using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSoundManScript : MonoBehaviour
{
    public AudioSource audioSource;

    [Header("Audio clips")]
    [SerializeField] public AudioClip negativeClick;
    [SerializeField] public AudioClip positiveClick;
    [SerializeField] public AudioClip click1;
    [SerializeField] public AudioClip click2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
