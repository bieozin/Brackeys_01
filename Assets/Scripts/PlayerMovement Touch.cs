using UnityEngine;

public class PlayerMovementTouch : MonoBehaviour
{

    public Rigidbody rb;
    public float fowardForce = 500f;
    public float sidewaysForce = 500f;
    public float jumpForce = 1000f;

    float value = 0f;
    
    
    // Update is called once per frame
    // usar fixedupdate qudno lidar com física   
    void FixedUpdate()
    {
        // add a foward force
        rb.AddForce(0, 0, fowardForce * Time.deltaTime);

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (touch.position.x < Screen.width / 2)
                    rb.AddForce(- sidewaysForce * value * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
                    
                    if (touch.position.x > Screen.width / 2)
                    rb.AddForce( sidewaysForce * value * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
                    
                    if (touch.position.x > Screen.height / 2)
                    rb.AddForce(0, jumpForce * Time.deltaTime, 0, ForceMode.Impulse);
                    
                    break;
            }
            
        }






        // // get controller value
        // value = Input.GetAxis ("Horizontal"); 

        // use value to drive plauer direction
        rb.AddForce(sidewaysForce * value * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

        // if (Input.GetKey ("joystick button 0"))
        // {
        //     rb.AddForce(0, jumpForce * Time.deltaTime, 0, ForceMode.Impulse);
        // }

        if (rb.position.y < -5f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }

    }

}


