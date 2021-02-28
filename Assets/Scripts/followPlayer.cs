using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public playerMovement playerMovement;
    public Transform player;
    public Vector3 cameraOffset;

    // Update is called once per frame
    void Update()
    {
        if(player.position.y >= playerMovement.LOWER_BOUNDARY)
        {
            transform.position = player.position + cameraOffset;
        }
    }
}
