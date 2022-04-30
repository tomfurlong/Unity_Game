using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstPersonPlayerMovement : MonoBehaviour
{
    public int maxHealth = 100;
    public int minHealth = 0;
    public int health = 0;
    public HealthBar healthBar;
    public CharacterController controller;
    public float speed = 9f;
    public float gravity = -9.81f;
    Vector3 velocity;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    public float jumpHeight = 5f;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    //this movemtn works with keyboards and controllers
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move*speed*Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            print("jumped");
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }

    }

    void OnCollisionEnter(Collision targetObj)
    {
        Debug.Log("Finish");
        if (targetObj.gameObject.tag == "Finish")
        {
            print("Finish");
            SceneManager.LoadScene("Ending_mcq");
        }
        if (targetObj.gameObject.tag == "Fire")
        {
            foreach (ContactPoint contact in targetObj.contacts)
            {
                print("Walked into fire");
                Debug.DrawRay(contact.point, contact.normal, Color.white);
            }
            if (targetObj.relativeVelocity.magnitude > 2)
                audioSource.Play();
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.SetHealth(health);
    }

}
