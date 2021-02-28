using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Rigidbody playerRB;

    public float forwardForce = 1000f;
    public float sidewaysForce = 100f;

    public const int LOWER_BOUNDARY = -1;

    void Update()
    {
        
    }
    // Called at consistent intervals (meant for physics)
    void FixedUpdate()
    {
        playerRB.AddForce(0, 0, forwardForce*Time.deltaTime);

        if( Input.GetKey("d"))
        {
            playerRB.AddForce(sidewaysForce*Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        
        if( Input.GetKey("a"))
        {
            playerRB.AddForce(-sidewaysForce*Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if( Input.GetKey(KeyCode.Space))
        {
            playerRB.AddForce(0, sidewaysForce*Time.deltaTime, 0, ForceMode.VelocityChange);
        }

        if(playerRB.position.y < LOWER_BOUNDARY)
        {
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
    }
}
