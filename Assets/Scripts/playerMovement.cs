using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Rigidbody playerRB;

    public float forwardForce;
    public float sidewaysForce;
    public float jumpingForce;
    public const int LOWER_BOUNDARY = -1;

    private bool inTheAir = false;
     private bool isJumpPressed = false;

    void Update()
    {
        isJumpPressed = Input.GetButtonDown("Jump") && !inTheAir;
    }

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

        if(isJumpPressed)
        {
            playerRB.velocity += new Vector3(0, jumpingForce, 0);
            inTheAir = true;
        }

        if(playerRB.velocity.y < 0)
        {
            playerRB.velocity -= Physics.gravity*Time.deltaTime;
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
