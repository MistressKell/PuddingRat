using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector3 jump;
    public float jumpForce = 100f;

    public bool gravity = false;
    public float g = 1.6f;

    public bool accelerate = false;
    public bool accelerating = false;
    public float speed = 5f;
    public float maxSpeed = 20f;
    public bool isGrounded;
    private Rigidbody rb;

    public bool canMove;
    public AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
        isGrounded = true;
        canMove = true;
        jump = new Vector3(0f, 2f, 0);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && canMove)
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        if (canMove)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * speed;
            rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);

            if (accelerate)
            {
                if (movement != new Vector3(0f, 0f, 0f) && !accelerating)
                {
                    accelerating = true;
                    StartCoroutine(MoveFaster());
                }
            }

            if (accelerate)
            {
                if (movement == new Vector3(0f, 0f, 0f))
                {
                    speed = 2.5f;
                }
            } 

            if (gravity)
            {
                rb.AddForce(new Vector3(0, -1f, 0) * rb.mass * g);
            }
        }
    }

    void Jump()
    {
            rb.AddForce(jump * jumpForce);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
            Debug.Log("Grounded");
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = false;
            Debug.Log("Grounded");
        }
    }

    IEnumerator MoveFaster()
    {
        yield return new WaitForSeconds(.5f);
        if (speed < maxSpeed)
        {
            speed += .25f;
        }
        accelerating = false;
    }

    public void Gravity()
    {
        if (gravity)
        {
            rb.useGravity = false;
        }
        else
        {
            rb.useGravity = true;
        }
    }
}
