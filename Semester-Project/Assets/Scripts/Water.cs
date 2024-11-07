using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Water : MonoBehaviour
{
    private int gameSpeed;
    private float maxHeight;
    [SerializeField] float riseSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameSpeed = GameManager.instance.getGameSpeed();
        float calcRiseSpeed = (float)(riseSpeed + ( (riseSpeed * 0.6) * (gameSpeed - 1) ) );
        maxHeight = GameManager.instance.getMaxHeight();
        if (maxHeight > (transform.position.y + 5))
        {
            calcRiseSpeed *= 2;
        }
        transform.position += (Vector3.up * calcRiseSpeed) * Time.deltaTime;
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
