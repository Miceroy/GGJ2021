using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    public GameObject Blood;

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("Player"))
        {
            Explode();
        }
    }
    void Explode()
    {
        GameObject bloodSplatter = Instantiate(Blood, x,y,z , Quaternion.identity);
        bloodSplatter.GetComponent<ParticleSystem>().Play();
    }
}
