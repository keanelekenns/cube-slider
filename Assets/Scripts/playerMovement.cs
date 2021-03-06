using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Rigidbody playerRB;

    public float forwardForce = 1000f;
    public float sidewaysForce = 100f;
    public float jumpingForce = 300000f;
    public const int LOWER_BOUNDARY = -1;

    bool inTheAir = false;

    // Called at consistent intervals (meant for physics)
    void FixedUpdate()
    {
        playerRB.AddForce(0, 0, forwardForce*Time.deltaTime);

        if(!inTheAir && Input.GetKey("d"))
        {
            playerRB.AddForce(sidewaysForce*Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        
        if(!inTheAir && Input.GetKey("a"))
        {
            playerRB.AddForce(-sidewaysForce*Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if(!inTheAir && Input.GetKey(KeyCode.Space))
        {
            inTheAir = true;
            playerRB.AddForce(0, jumpingForce, 0, ForceMode.Force);
        }

        if(playerRB.position.y < LOWER_BOUNDARY)
        {
            this.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if(collisionInfo.collider.tag == "Obstacle")
        {
            this.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }
        else if(collisionInfo.collider.tag == "Ground")
        {
            inTheAir = false;
        }
    }
}
