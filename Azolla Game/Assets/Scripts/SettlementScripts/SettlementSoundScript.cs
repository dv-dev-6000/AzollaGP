using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettlementSoundScript : MonoBehaviour
{
    public AudioSource audioSource;

    [Header("Audio clips")]
    [SerializeField] public AudioClip negativeClick;
    [SerializeField] public AudioClip positiveClick;
    [SerializeField] public AudioClip click1;
    [SerializeField] public AudioClip click2;
    [SerializeField] public AudioClip build;
    [SerializeField] public AudioClip buildMetal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
