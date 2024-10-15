using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject player;
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
            player.transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            player.GetComponent<SpriteRenderer>().sprite = rightSprite;
            isFacingRight = true;
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            player.transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            player.GetComponent<SpriteRenderer>().sprite = leftSprite;
            isFacingRight = false;
        }

        if (Input.GetButtonDown("Jump"))
        {
            player.GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }

        //Position hitBox for hitting blocks
        if (isFacingRight)
        {
            swingHitBox.position = player.transform.position + new Vector3(0.2f, 0, 0);
        }
        else
        {
            swingHitBox.position = player.transform.position - new Vector3(0.2f, 0, 0);
        }
        Debug.Log(player.transform.position + "   " + swingHitBox.position);

        //Add ability to hit and destroy blocks

    }
}
