using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planetPhysics : MonoBehaviour
{
    public float pullRadius = 20;
    public float pullForce = 400;



    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(transform.position);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 10f);
        Collider collider = colliders[0];
        Vector3 forceDirection = transform.position - collider.transform.position;
        collider.GetComponent<Rigidbody>().AddForce(forceDirection.normalized * pullForce * Time.fixedDeltaTime);   
    }
}
