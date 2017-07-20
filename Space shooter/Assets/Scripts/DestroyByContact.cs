using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject explodeAudio;


    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Boundary")
        {
            return;
        }

        if (other.gameObject.tag == "bolt")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Instantiate(explodeAudio, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
