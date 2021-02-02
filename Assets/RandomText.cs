using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RandomText : MonoBehaviour
{
    public Camera Playercamera;
    public GameObject Textbox;
    // Start is called before the first frame update
    void Start()
    {
        Textbox.SetActive(false);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 v = Playercamera.transform.position - Textbox.transform.position;
        v.x = v.z = 0.0f;
        Textbox.transform.LookAt(Playercamera.transform.position - v);
        Textbox.transform.Rotate(0, 0, 0);
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Textbox.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Textbox.SetActive(false);
        }
    }
}



