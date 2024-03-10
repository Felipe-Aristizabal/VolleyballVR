using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class VolleyballManager : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private AudioSource hitTheBall;
    [SerializeField] private ReappearObjects _ReappearObjectsScript;
    
    private float velocityMax = 100f;
    private int numberMaxOfIterations;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        numberMaxOfIterations = 0;
        rb = gameObject.GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hand"))
        {
            if (numberMaxOfIterations < 5)
            {
                numberMaxOfIterations++;
                Debug.Log("Im in Hand");
                hitTheBall.Play();
                float forceMultiplier = GetHandForce(collision.gameObject.GetComponent<Rigidbody>());
                Debug.Log($"This is the hand Force: {forceMultiplier}");
                rb.AddRelativeForce(Vector3.forward * velocityMax, ForceMode.Impulse);
                rb.useGravity = true;
            }
            else
            {
                _ReappearObjectsScript.EndGame($"Your final score was: {score}");
            }
        }    
    }

    private float GetHandForce(Rigidbody handRB)
    {
        return handRB.velocity.magnitude;
    }

    private float CalculateImpulse(float handForce)
    {
        if (handForce < 1)
        {
            handForce = velocityMax;
        }
        else if (handForce > 1)
        {
            handForce = handForce * velocityMax;
        }

        return 0f;
    }

    public void ResetScore()
    {
        score = 0;
        _ReappearObjectsScript.ResetScore();
        _ReappearObjectsScript.ReappearBall();
    }
}
