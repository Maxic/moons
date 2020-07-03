using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float jumpHeight;
    private Vector3 moveDirection = Vector3.zero;
    private float distanceToGround;
    private Vector3 groundNormal;
    private bool onGround = false;

    private Rigidbody rb; 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

    }

    // Update is called once per frame
    void Update()
    {

        // Movement
        float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float vertical = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        transform.Translate(horizontal, 0, vertical);

        // Jump
        if(Input.GetKey(KeyCode.Space) && onGround){
            rb.AddForce(transform.up * 1000 * jumpHeight * Time.deltaTime);
        }

        // On ground determination
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(transform.position, -transform.up, out hit, 10)) {
            distanceToGround = hit.distance;
            groundNormal = hit.normal;

            if (distanceToGround < 0.8f){
                onGround = true;
                Debug.Log("On Ground");
            } else {
                onGround = false;
                Debug.Log("Off Ground");
            }
        }

        // Rotation towards surface
        Quaternion toRotation  = Quaternion.FromToRotation(transform.up, groundNormal) * transform.rotation;
        transform.rotation = toRotation;
    }
}
