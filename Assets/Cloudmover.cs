using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloudmover : MonoBehaviour
{
    public GameObject CloudThingy;
    public float Cloudspeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CloudThingy.transform.position += new Vector3(0, 0, Cloudspeed * Time.deltaTime);
    }
}
