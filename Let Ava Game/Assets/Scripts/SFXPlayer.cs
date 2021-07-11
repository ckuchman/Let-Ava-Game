using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlayer : MonoBehaviour
{
    public AudioSource basicEnemyDestroy;
    public AudioSource lightEnemyDestroy;
    public AudioSource indestructableHit;
    public AudioSource buttonClick;
    public AudioSource playerHit;
    public AudioSource playerShot;
    public AudioSource playerJump;
    public AudioSource coinCollect;
    public AudioSource heartCollect;
    public AudioSource collectDestroy;

    public void playBasicEnemyDestroy() {
        basicEnemyDestroy.Play();
    }

    public void playLightEnemyDestroy() {
        lightEnemyDestroy.Play();
    }

    public void playIndestructableHit() {
        indestructableHit.Play();
    }
    
    public void playButtonClick() {
        buttonClick.Play();
    }

    public void playPlayerHit() {
        playerHit.Play();
    }

    public void playPlayerShot() {
        playerShot.Play();
    }
    public void playPlayerJump() {
        playerJump.Play();
    }
    public void playCoinCollect() {
        coinCollect.Play();
    }
    public void playHeartCollect() {
        heartCollect.Play();
    }
    public void playCollectDestroy() {
        collectDestroy.Play();
    }
}
