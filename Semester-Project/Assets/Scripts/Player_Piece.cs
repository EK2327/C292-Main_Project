using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Piece : MonoBehaviour
{
    private bool isFalling = true;
    [SerializeField] float fallSpeed = 3f;
    private int gameSpeed;

    private bool canMove = false;
    [SerializeField] float moveDelay;
    private float moveTimer;
    [SerializeField] int pipeHeight;
    [SerializeField] int pipeWidth;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Increment move timer
        moveTimer += Time.deltaTime;
        //If sufficient delay since last move allow for movement
        if ( moveTimer > moveDelay)
        {
            canMove = true;
        }

        if (canMove && Input.GetKey(KeyCode.A))
        {
            moveTimer = 0;
            AttmeptMoveLeft();
        }
        else if (canMove && Input.GetKey (KeyCode.D))
        {
            moveTimer = 0;
            AttmeptMoveRight();
        }

        //Get game speed
        gameSpeed = GameManager.instance.getGameSpeed();
        float calcFallSpeed = (float)(fallSpeed + ((fallSpeed * 0.5) * (gameSpeed - 1)));
        //Check if pipe is falling
        if (isFalling)
        {
            //Move pipe down at proper speed, taking into account game speed
            transform.position += Vector3.down * calcFallSpeed * Time.deltaTime;
        }
    }

    private void AttmeptMoveLeft()
    {
        bool willMove = true;
        RaycastHit2D hit;
        for (int i = 0; i <= pipeHeight; i++)
        {
            hit = Physics2D.Raycast(transform.position + new Vector3(0, 0.25f + (0.5f * i), 0), Vector3.left, 0.5f);
            if (hit.collider != null)
            {
                willMove = false;
            }
        }
        if (willMove)
        {
            MoveLeft();
        }
    }

    private void MoveLeft()
    {
        transform.position += new Vector3(-0.5f, 0, 0);
    }

    private void AttmeptMoveRight()
    {
        bool willMove = true;
        RaycastHit2D hit;
        for (int i = 0; i <= pipeHeight; i++)
        {
            hit = Physics2D.Raycast(transform.position + new Vector3(pipeWidth / 2, 0.25f + (0.5f * i), 0), Vector3.right, 0.5f);
            if (hit.collider != null)
            {
                willMove = false;
            }
        }
        if (willMove)
        {
            MoveRight();
        }
    }

    private void MoveRight()
    {
        transform.position += new Vector3(0.5f, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If this pipe collided with another pipe, it should stop falling
        if ((collision.gameObject.tag == "Block" || collision.gameObject.tag == "GroundLevel") && !(collision.transform.IsChildOf(transform)))
        {
            isFalling = false;
            MyEvents.BlockDoneFalling.Invoke();
        }
    }
}
