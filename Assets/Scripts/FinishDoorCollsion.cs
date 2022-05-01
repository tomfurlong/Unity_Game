using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishDoorCollsion : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("ENterED Dpopwdw");
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("The player has collided with the wall!");
        }
    }
}
