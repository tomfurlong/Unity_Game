using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody my_Rigidbody;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("left") || Input.GetKey("right"))
        {
            Vector3 my_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            my_Rigidbody.MovePosition(transform.position + my_Input * Time.deltaTime * 5f);
        }
        if (Input.GetKey("space"))
        {
            Vector3 my_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            my_Rigidbody.MovePosition(transform.position + my_Input * Time.deltaTime * 5f);
        }
    }
}
