using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Audio;

public class DuckCtrl : GameComponent
{
    [SerializeField] AudioSource sound;
    [SerializeField] ParticleSystem ParticleEffect;
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
            Invoke("die", 1.0f);
            ParticleEffect.gameObject.SetActive(true);
        }

        if (other.gameObject.tag == "Distract")
        {

        }
    }

}
