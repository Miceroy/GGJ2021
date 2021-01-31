using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Audio;



public class DuckCtrl : GameComponent
{
    [SerializeField] AudioSource sound;
    [SerializeField] ParticleSystem ParticleEffect;
    [SerializeField] GameObject ankka;
    void die()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            sound.Play();
            Debug.Log("Duck dies");
            ankka.SetActive(false);
            Invoke("die", 3.0f);
            ParticleEffect.gameObject.SetActive(true);
            getGameController().decreaseTime();
        }

        if (other.gameObject.tag == "Distract")
        {

        }
    }

}
