using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    private bool isFalling = true;
    [SerializeField] float fallSpeed = 2.5f;
    private int gameSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Get game speed
        gameSpeed = GameManager.instance.getGameSpeed();
        //Check if pipe is falling
        if (isFalling)
        {
            //Move pipe down at proper speed, taking into account game speed
            transform.position += Vector3.down * fallSpeed * gameSpeed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If this pipe collided with another pipe, it should stop falling
        if (collision.gameObject.tag == "Block" && !(collision.transform.IsChildOf(transform)))
        {
            isFalling = false;
            MyEvents.BlockDoneFalling.Invoke();
        }
    }
}
