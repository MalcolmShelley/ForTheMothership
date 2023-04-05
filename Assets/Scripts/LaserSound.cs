using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSound : MonoBehaviour
{
    AudioSource laserAudio;
    PlayerEnergy energyBar;

    void Start()
    {
        laserAudio = GetComponent<AudioSource>();
    }
    private void Update()
    {
        {
            if (Input.GetButtonDown("Fire1"))
                laserAudio.Play();
            if (Input.GetButtonUp("Fire1"))
                laserAudio.Stop();
        }
    }
}
