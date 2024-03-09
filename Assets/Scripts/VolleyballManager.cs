using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class VolleyballManager : MonoBehaviour
{
    private Rigidbody rb;
    private float velocityMax = 100f;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hand"))
        {
            Debug.Log("Im in Hand");
            //rb.velocity = Vector3.zero;

            rb.AddRelativeForce(Vector3.forward * velocityMax, ForceMode.Impulse);

            //Physics.IgnoreCollision(collision.gameObject.GetComponent<BoxCollider>(), gameObject.GetComponent<SphereCollider>());

            //float forceMultiplier = GetHandForce(collision.gameObject.GetComponent<Rigidbody>());
            //Debug.Log($"Hand Velocity: {forceMultiplier}");
            //Vector3 direction = collision.gameObject.GetComponent<Rigidbody>().velocity.normalized;
            //rb.AddForce(direction * forceMultiplier*2, ForceMode.Impulse);
            rb.useGravity = true;
        }    
    }


    private float GetHandForce(Rigidbody handRB)
    {
        return handRB.velocity.magnitude;
    }    
}
