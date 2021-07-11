using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Rigidbody playerRB;

    public float forwardForce;
    public float sidewaysForce;
    public float jumpingForce;
    public float fallingForce;
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
        playerRB.rotation = Quaternion.identity;
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
            playerRB.AddForce(0, jumpingForce, 0, ForceMode.Impulse);
            inTheAir = true;
            isJumpPressed = false;
        }

        if(playerRB.velocity.y < 0)
        {
            // Increase gravity when we start falling,
            // This makes our player fall faster
            playerRB.velocity += fallingForce*Physics.gravity*Time.deltaTime;
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
