using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public Rigidbody ballRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        ballRigidbody.AddForce(-transform.forward * 1000f);
    }
}
