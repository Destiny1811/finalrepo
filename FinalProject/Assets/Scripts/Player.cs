using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SphereController2D : MonoBehaviour
{
    public float moveSpeed = 5f;    // Speed of left/right movement
    public float jumpForce = 10f;   // Force applied for jumping
    private bool isGrounded;        // Checks if the player is on the ground
    private int keyCount = 0;       // Keeps track of number of collected keys

    public TextMeshProUGUI keysText;          // shows text of how many keys have been collected

    public Rigidbody rb;
    public AudioSource audioSource;         // used to play sound when player collects key
    public GameObject Door;                 // Door that opens when we collect 3 keys


    void Update()
    {
        Movement();
        ShowKeysText();

        PlayerDie();

        if (keyCount == 3)
        {
            Destroy(Door);      // Remove door when player collects 3 keys
        }

    }

    void Movement()
    {
        // Left/right movement
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector3(move * moveSpeed, rb.velocity.y, 0f);

        // Jumping
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector3(0f, jumpForce, 0f), ForceMode.Impulse);
        }
    }

    void PlayerDie()
    {
        if (transform.position.y <= -4f)
        {
            SceneManager.LoadScene("Lose Scene");       // If players falls down then load the lose scene
        }
    }

    void ShowKeysText()
    {
        keysText.text = "Keys Collected: " + keyCount.ToString();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the sphere is on the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // Sphere is no longer on the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        // Collect key
        if (collision.gameObject.CompareTag("Key"))
        {
            keyCount++;
            audioSource.Play();
            Destroy(collision.gameObject);
        }

        // if we reach finish line then we move to the next level
        if (collision.gameObject.CompareTag("Finish"))    
        {
            SceneManager.LoadScene("Level 2");
        }

        // if player touches gameobject with tag "Finish2" which is in the level 2 scene, then we go to the Win scene
        if (collision.gameObject.CompareTag("Finish2"))
        {
            SceneManager.LoadScene("Win Scene");
        }
    }

    

}
