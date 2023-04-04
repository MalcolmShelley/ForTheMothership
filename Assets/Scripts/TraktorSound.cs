using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraktorSound : MonoBehaviour
{
    AudioSource traktorAudio;

    void Start()
    {
        traktorAudio = GetComponent<AudioSource>();
    }
    private void Update()
    {
        {
            if (Input.GetButtonDown("Jump"))
                traktorAudio.Play();
            if (Input.GetButtonUp("Jump"))
                traktorAudio.Stop();
        }
    }
}
