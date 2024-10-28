using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    private int gameSpeed;
    private float maxHeight;
    private float riseSpeed;
    [SerializeField] float riseMult;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameSpeed = GameManager.instance.getGameSpeed();
        maxHeight = GameManager.instance.getMaxHeight();
        if (maxHeight > (transform.position.y + 5))
        {
            gameSpeed *= 2;
        }
        riseSpeed = gameSpeed * riseMult;
        transform.position += (Vector3.up * riseSpeed) * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            if (collision.gameObject.GetComponent<Block>().IsWaterlogged())
            {
                Destroy(collision.gameObject);
            }
            else
            {
                collision.gameObject.GetComponent<Block>().Waterlog();
            }
        }
    }
}
