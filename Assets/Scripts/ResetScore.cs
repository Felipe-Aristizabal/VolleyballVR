using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScore : MonoBehaviour
{
    [SerializeField] private VolleyballManager _VolleyballManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hand"))
        {
            _VolleyballManager.ResetScore();
        }
    }
}
