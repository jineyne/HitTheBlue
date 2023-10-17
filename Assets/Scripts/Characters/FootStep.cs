using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class FootStep : MonoBehaviour
{
    public AudioSource audioSource;
    public List<AudioClip> footsteps;

    public void Footstep() {
        if (footsteps.Count <= 0) {
            return;
        }

        if(audioSource != null)
        {
            audioSource.clip = footsteps[Random.Range(0, footsteps.Count)];
            audioSource.Play();
        }
    }

    public void Start() {
        audioSource = GetComponent<AudioSource>();
    }
}
