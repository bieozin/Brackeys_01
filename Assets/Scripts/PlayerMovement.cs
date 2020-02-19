using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;
    public float fowardForce = 500f;
    public float sidewaysForce = 500f;
    public float jumpForce = 1000f;

    float value = 0f;

    // public void leftMove (){
    // }

    // public void rightMove (){
    // }

    public void jumpMove()
    {
        if (Input.GetKey("joystick button 0"))
        {
            rb.AddForce(0, jumpForce * Time.deltaTime, 0, ForceMode.Impulse);
        }
    }

    // Update is called once per frame
    // usar fixedupdate qudno lidar com física   
    void FixedUpdate()
    {
        // add a foward force
        rb.AddForce(0, 0, fowardForce * Time.deltaTime);

        // get controller value
        value = Input.GetAxis("Horizontal");

        // use value to drive player direction
        rb.AddForce(sidewaysForce * value * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

        jumpMove();

        // Dies if far from center below threshold
        if (
            rb.position.y < -5f |
            rb.position.y > 15f |
            rb.position.x < -7.5f |
            rb.position.x > 7.5f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }

    }

}


