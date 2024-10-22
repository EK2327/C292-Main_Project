using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Block : MonoBehaviour
{
    private bool canBreak = true;
    private bool hasLanded = false;
    private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        MyEvents.BlockBroken.AddListener(PipeBroken);
        MyEvents.BlockDoneFalling.AddListener(PipeLanded);
    }

    // Update is called once per frame
    void Update()
    {
        if (!canBreak)
        {
            timer += Time.deltaTime;
            if (timer > 0.5f)
            {
                Debug.Log("A new block can be broken");
                canBreak = true;
                timer = 0f;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Check if block is colliding with players swinging hitbox, the proper input is down, and the block can break
        if (hasLanded && collision.gameObject.tag == "SwingArea" && Input.GetButton("Fire1") && canBreak)
        {
            //Destroy this block
            Destroy(gameObject);
            MyEvents.BlockBroken.Invoke();
        }
    }

    //Called when a pipe block has been broken
    void PipeBroken()
    {
        Debug.Log("A block was broken");
        canBreak = false;
    }

    //Called when the pipe has landed
    void PipeLanded()
    {
        Debug.Log("Block has landed");
        hasLanded = true;
    }

}
