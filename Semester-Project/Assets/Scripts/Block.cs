using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("Made contact with block");
        if (collision.gameObject.tag == "SwingArea" && Input.GetButton("Fire1"))
        {
            //Debug.Log("Block broken");
            Destroy(gameObject);
        }
    }

}
