using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlayer : MonoBehaviour
{
    public AudioSource hit;
    public AudioSource explode;
    public AudioSource lightExplode;

    public void playHit() {
        hit.Play();
    }

    public void playExplode() {
        explode.Play();
    }

    public void playLightExplode() {
        lightExplode.Play();
    }
}
