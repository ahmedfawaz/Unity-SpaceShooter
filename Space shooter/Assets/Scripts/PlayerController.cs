using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{

    public Boundary boundary;
    Rigidbody rb;
    public float m_moveSpeed = 10.0f;
    public float tilt;
    public GameObject bolt;
    public Transform shotSpawn;
    public float fireRate = 1.0f;

    float nextFire = 0.0f;

    void Update()
    {
        if(Time.time >nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject clone = Instantiate(bolt, shotSpawn.position, shotSpawn.rotation) as GameObject;
            

        }

    }

	void FixedUpdate()
    {
        float m_moveHorizontal = Input.GetAxis("Horizontal");
        float m_moveVertical = Input.GetAxis("Vertical");

        rb = GetComponent<Rigidbody>();
        Vector3 movement = new Vector3 (m_moveHorizontal, 0.0f, m_moveVertical);
        rb.velocity = movement * m_moveSpeed;

        rb.transform.position = new Vector3
            (
            Mathf.Clamp(rb.transform.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rb.transform.position.z, boundary.zMin, boundary.zMax)
            );

        rb.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);


    }


}
