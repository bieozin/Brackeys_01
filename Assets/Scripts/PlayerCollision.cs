using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    // public PlayerMovement movement;
    public bool canDie = true;


    void OnCollisionEnter(Collision colInfo)
    {
        if (canDie == true)
        {
            if (colInfo.collider.tag == "Obstacle")
            {
                GetComponent<PlayerMovement>().enabled = false;
                FindObjectOfType<GameManager>().EndGame();
            }
        }
    }

}
