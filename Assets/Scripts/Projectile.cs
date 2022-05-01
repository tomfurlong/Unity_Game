using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private bool collide;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Shootable" && collision.gameObject.tag != "Player")
        {
            //collide = true;
            //Destroy(gameObject);
        }
        if(collision.gameObject.tag == "Fire")
        {
            Debug.Log("Hit Fire");
            Destroy(gameObject);
        }
    }
}
    