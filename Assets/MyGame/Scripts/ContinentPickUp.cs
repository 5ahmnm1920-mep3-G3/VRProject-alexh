using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinentPickUp : MonoBehaviour
{
    private Transform tf;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        tf = GetComponent<Transform>();
    }

    public void OnPickUp()
    {
        tf.SetParent(null);
    }

    public void OnRelease()
    {
        rb.isKinematic = false;
    }
}
