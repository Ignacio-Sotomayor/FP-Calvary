using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //move parameters
    public float speed = 10f;
    public float stamina = 100f;
    public float horizontalInput;
    public float verticalInput;

    //jump parametrs
    public float jumpForce = 10f;
    private bool isGrounded;

    //player parameters
    private Rigidbody body;
    private Transform transform;

    void Start()
    {
        body = gameObject.GetComponent<Rigidbody>();
        transform = gameObject.GetComponent<Transform>();
    }

    void Update()
    {
        Mover();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            body.AddForce(Vector3.up * (jumpForce * jumpForce * jumpForce / 5));
        }
    }

    void Mover()
    {
        verticalInput = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        horizontalInput = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        if(verticalInput > 0 && Input.GetKey(KeyCode.LeftShift) && stamina > 0)
        {
            speed = 15f;
            stamina --;
        }else
        {
            speed = 10f;
            if(stamina <100)
            {
                stamina++;
            }
        }

        transform.Translate(horizontalInput, 0, verticalInput);

    }

    void FixedUpdate()
    {
        int layerMask = 1 << 8;

        layerMask = ~layerMask;

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up * -1), out hit, 1.5f, layerMask))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}
