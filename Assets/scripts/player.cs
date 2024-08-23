using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class player : MonoBehaviour

{
    [SerializeField] private cameraFollowing camera;
    [SerializeField] private float playerSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float secondJumpForce;
    [SerializeField] private float orientationChangeDelay;
    [NonSerialized] public playerHorizontalOrientation currentPlayerHorizontalOrientation = playerHorizontalOrientation.Right;

    public enum playerHorizontalOrientation { Left = 1, Right = 2 }
    private int maxJumps = 1;
    private int amountOfJumps;
    private bool OnGround;
    private Rigidbody2D rb;
    private float sprint;
    private playerHorizontalOrientation lastOrientation = playerHorizontalOrientation.Right;

    private void Start()
    {
        StartCoroutine(ChangeOrientation());
    }
    IEnumerator ChangeOrientation()
    {
        float stableOrientationTime = 0;
        while (true)
        {
            if (currentPlayerHorizontalOrientation == lastOrientation)
            {
                stableOrientationTime += 0.1f;
                if (stableOrientationTime > orientationChangeDelay)
                {
                    camera.SetHorizontalOrientation(currentPlayerHorizontalOrientation);
                }
            }
            else
            {
                stableOrientationTime = 0;
            }
            lastOrientation = currentPlayerHorizontalOrientation;
            yield return new WaitForSeconds(0.1f);

        }

    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {


//horizontal moving and orientation
        
        
        if (Input.GetKey(KeyCode.LeftShift)) { sprint = 1.5f; } else { sprint = 1f; }


        if (Input.GetKey("d") || Input.GetKey("a"))
        {
            float xSpeed = (Input.GetKey("d")) ? playerSpeed * sprint : -playerSpeed * sprint ;
            currentPlayerHorizontalOrientation = (Input.GetKey("d")) ? playerHorizontalOrientation.Right : playerHorizontalOrientation.Left;
            this.transform.position = new Vector3(this.transform.position.x + xSpeed*Time.deltaTime, this.transform.position.y, this.transform.position.z);
        }
        
        
//Jump mechanic

        
        if (Input.GetKeyDown("space") && OnGround == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown("space") && OnGround == false && amountOfJumps > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(new Vector3(0, secondJumpForce, 0), ForceMode2D.Impulse);
            amountOfJumps -= 1;
        }
        
    }

//Grounded status
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            OnGround = true;
            amountOfJumps = maxJumps;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            OnGround = false;
        }
    }
}

