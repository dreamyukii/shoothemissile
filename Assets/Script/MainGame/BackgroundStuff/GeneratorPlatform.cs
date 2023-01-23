using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorPlatform : MonoBehaviour
{
    public GameObject platformIni;
    public Transform poinGenerasi;
    public float jarakAntara;
    private float platformLebar;
    void Start()
    {
        platformLebar = platformIni.GetComponent<BoxCollider2D>().size.x;
    }
    void Update()
    {
        if (transform.position.x < poinGenerasi.position.x)
        {
            transform.position = new Vector3(transform.position.x + platformLebar + jarakAntara, transform.position.y, transform.position.z);
            Instantiate(platformIni, transform.position, transform.rotation);
        }
    }
}
