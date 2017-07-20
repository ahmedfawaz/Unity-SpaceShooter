using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    Rigidbody rb;
    public float m_speed;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = gameObject.transform.forward * m_speed;
    }
}
