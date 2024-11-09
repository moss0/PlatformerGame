using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundsScript : MonoBehaviour
{
    public Rigidbody _rb;
    public Transform OutOfBoundsDest;

    //public void Start()
    //{
    //    _rb = GetComponent<Rigidbody>();
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _rb.velocity = Vector3.zero;
            _rb.transform.position = OutOfBoundsDest.position;
        }
    }

}
