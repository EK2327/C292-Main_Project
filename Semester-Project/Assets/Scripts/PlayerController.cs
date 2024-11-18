using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.EventSystems.EventTrigger;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform swingHitBox;
    [SerializeField] Transform cameraPos;
    [SerializeField] Sprite leftSprite;
    [SerializeField] Sprite rightSprite;
    [SerializeField] float jumpForce = 2f;
    [SerializeField] float moveSpeed = 1f;
    
    private bool isFacingRight = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            GetComponent<SpriteRenderer>().sprite = rightSprite;
            isFacingRight = true;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            GetComponent<SpriteRenderer>().sprite = leftSprite;
            isFacingRight = false;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded())
        {
            GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }

        //Position hitBox for hitting blocks
        if (isFacingRight)
        {
            swingHitBox.position = transform.position - new Vector3(0.125f, -0.03f, 0);
        }
        else
        {
            swingHitBox.position = transform.position + new Vector3(0.125f, 0.03f, 0);
        }


    }

    //Check if player is in Water
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Water")
        {
            MyEvents.PlayerDied.Invoke();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Check if collider is directly above player
        RaycastHit2D hit1 = Physics2D.Raycast(transform.position + new Vector3(0.15f, 0, 0), Vector3.up, 0.2f, LayerMask.GetMask("Blocks"));
        RaycastHit2D hit2 = Physics2D.Raycast(transform.position - new Vector3(0.15f, 0, 0), Vector3.up, 0.2f, LayerMask.GetMask("Blocks"));
        if (hit1.collider != null && IsGrounded())
        {
            MyEvents.PlayerDied.Invoke();
        }
    }

    //Return if the player is touching the top of a block
    private bool IsGrounded()
    {
        RaycastHit2D hit1 = Physics2D.Raycast(transform.position + new Vector3(0.15f, 0, 0), -Vector3.up, 0.2f, LayerMask.GetMask("Blocks"));
        RaycastHit2D hit2 = Physics2D.Raycast(transform.position - new Vector3(0.15f, 0, 0), -Vector3.up, 0.2f, LayerMask.GetMask("Blocks"));

        if (hit1.collider != null || hit2.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
