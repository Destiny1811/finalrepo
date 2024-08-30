
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float speed = 1;
    public Rigidbody rb;

    float horizontalInput;
    public float horizontalMultiplier = 2;
    
    // Start is called before the first frame update
    private void FixedUpdate()
    {
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
    }
}



