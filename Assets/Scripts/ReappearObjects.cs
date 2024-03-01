using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ReappearObjects : MonoBehaviour
{
    [SerializeField] private GameObject objectToReappear;
    private Vector3 objectPositionToReappear;

    // Start is called before the first frame update
    void Start()
    {
        objectPositionToReappear = objectToReappear.transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == objectToReappear.name)
        {
            objectToReappear.transform.position = objectPositionToReappear;
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
}
