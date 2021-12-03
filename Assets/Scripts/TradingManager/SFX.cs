using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    AudioSource source;
    [SerializeField] AudioClip tooExpensive;
    [SerializeField] AudioClip niceShirt;
    [SerializeField] AudioClip nicePants;
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    internal void Expensive()
    {
        source.clip = tooExpensive;
        source.Play();
    }
    internal void NiceShirt()
    {
        source.clip = niceShirt;
        source.Play();

    }
    internal void NicePants()
    {
        source.clip = nicePants;
        source.Play();
    }
}
