using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.EventSystems.EventTrigger;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform swingHitBox;
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

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
                GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            
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

        //Debug Lines
        Debug.DrawRay(transform.position, Vector3.up * 0.2f, Color.white);
        Debug.DrawRay(transform.position, Vector3.down * 0.2f, Color.black);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("PLayer touched something");
        RaycastHit2D hit1 = Physics2D.Raycast(transform.position + new Vector3(0.15f, 0, 0), Vector3.up, 0.2f, LayerMask.GetMask("Blocks"));
        RaycastHit2D hit2 = Physics2D.Raycast(transform.position - new Vector3(0.15f, 0, 0), Vector3.up, 0.2f, LayerMask.GetMask("Blocks"));
        if (hit1.collider != null && IsGrounded())
        {
            Debug.Log("Player crushed");
            MyEvents.PlayerDied.Invoke();
        }
    }

    bool IsGrounded()
    {
        RaycastHit2D hit1 = Physics2D.Raycast(transform.position + new Vector3(0.15f, 0, 0), -Vector3.up, 0.2f, LayerMask.GetMask("Blocks"));
        RaycastHit2D hit2 = Physics2D.Raycast(transform.position - new Vector3(0.15f, 0, 0), -Vector3.up, 0.2f, LayerMask.GetMask("Blocks"));

        Debug.Log("Check for ground");
        if (hit1.collider != null || hit2.collider != null)
        {
            Debug.Log("Raycast made contact");
            return true;
        }
        else
        {
            return false;
        }
    }
}
