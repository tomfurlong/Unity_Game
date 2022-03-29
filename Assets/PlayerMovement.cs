using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float gravityScale = 20;
    public float jumpHeight = 1;
    public new Rigidbody rigidbody;
    public float buttonTime = 0.3f;
    public float jumpAmount = 20;
    float jumpTime;
    bool jumping;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float jumpForce = Mathf.Sqrt(jumpHeight * -2 * (Physics2D.gravity.y * gravityScale));
        if (Input.GetKey("left") || Input.GetKey("right"))
        {
            Vector3 my_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            rigidbody.MovePosition(transform.position + my_Input * Time.deltaTime * 5f);
        }
        if (Input.GetKey("space"))
        {
            jumping = true;
            jumpTime = 0;
        }
        if (jumping)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpAmount);
            jumpTime += Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.Space) | jumpTime > buttonTime)
        {
            jumping = false;
        }
    }
}

