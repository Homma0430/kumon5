using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; 
    public float jumpForce = 10f; 
    public float gravity = 9.81f; 
    private bool isJumping = false; 
    private float verticalSpeed = 0f; 

    void Update()
    {
        float move = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        transform.Translate(move, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            verticalSpeed = jumpForce;
        }

        if (isJumping)
        {
            verticalSpeed -= gravity * Time.deltaTime;
            transform.Translate(0, verticalSpeed * Time.deltaTime, 0);

            
            if (transform.position.y <= 0)
            {
                transform.position = new Vector3(transform.position.x, 0, transform.position.z);
                isJumping = false;
                verticalSpeed = 0;
            }
        }
    }
}
