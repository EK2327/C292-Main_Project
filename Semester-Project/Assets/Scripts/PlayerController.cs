using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform swingHitBox;
    [SerializeField] Sprite leftSprite;
    [SerializeField] Sprite rightSprite;
    [SerializeField] float jumpForce = 2f;
    [SerializeField] float moveSpeed = 1f;
    
    private bool isFacingRight = true;
    private bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //Movement
        if (Input.GetAxis("Horizontal") < 0)
        {
            
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            GetComponent<SpriteRenderer>().sprite = rightSprite;
            isFacingRight = true;
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            GetComponent<SpriteRenderer>().sprite = leftSprite;
            isFacingRight = false;
        }

        if (Input.GetButtonDown("Jump"))
        {
            IsGrounded();
            if (isGrounded)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
                isGrounded = false;
            }
        }

        //Position hitBox for hitting blocks
        if (isFacingRight)
        {
            swingHitBox.position = transform.position + new Vector3(0.2f, 0, 0);
        }
        else
        {
            swingHitBox.position = transform.position - new Vector3(0.2f, 0, 0);
        }

        //Add ability to hit and destroy blocks

    }

    void IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector3.up, 0.3f, LayerMask.GetMask("Blocks"));
        
        Debug.Log("Check for ground");
        if (hit.collider != null)
        {
            Debug.Log("Raycast made contact");
            isGrounded = true;
            //if (hit.collider.gameObject.tag == "Block")
            //{
            //    Debug.Log("Block hit");
            //    isGrounded = true;
            //}
        }
    }
}
