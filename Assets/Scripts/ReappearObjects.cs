using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ReappearObjects : MonoBehaviour
{
    [SerializeField] private GameObject objectToReappear;
    [SerializeField] private GameObject[] positionsToReappear;
    private Quaternion objectRotationToReappear;

    // Start is called before the first frame update
    void Start()
    {
        objectRotationToReappear = objectToReappear.transform.rotation;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == objectToReappear.name)
        {
            objectToReappear.transform.position = KnowWhereReappear();
            objectToReappear.transform.rotation = objectRotationToReappear;
            Rigidbody rb = objectToReappear.GetComponent<Rigidbody>();
            rb.velocity = new Vector3(0f, 0f, 0f);
            rb.angularVelocity = new Vector3(0f, 0f, 0f);
            rb.useGravity = false;

            if (this.gameObject.name == "Point")
            {
                // Agregar punto
            }
            else if (this.gameObject.name == "No Point")
            {
                // Restar punto
            }
        }
    }

    private Vector3 KnowWhereReappear()
    {
        int randomIndex = Random.Range(0, positionsToReappear.Length);
        return positionsToReappear[randomIndex].gameObject.transform.position;
    }
}
