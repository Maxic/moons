using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class planetPhysics : MonoBehaviour
{
    public float pullRadius = 20;
    public float pullForce = 400;



    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Collider[] colliders = Physics.OverlapSphere(transform.position, 10f);
        Array.ForEach(colliders, c =>
        {
            // TODO: Change to tag
            if (c.name == "Player")
            {
                Vector3 forceDirection = transform.position - c.transform.position;
                c.GetComponent<Rigidbody>().AddForce(forceDirection.normalized * pullForce * Time.fixedDeltaTime);
            }
        });       
    }
}
