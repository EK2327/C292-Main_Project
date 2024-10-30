using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] Transform playerPos;

    private int permSpeed = 1;
    private float maxHeight = -3;
    private int tempSpeed = 0;
    private float timer;
    float tempSpeedTimer;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        MyEvents.PlayerDied.AddListener(EndGame);
        MyEvents.BlockDoneFalling.AddListener(CheckMaxHeight);
        timer = 0;
        tempSpeedTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        //Every 30 seconds add one to speed
        if (timer >= 20)
        {
            AddSpeed();
            timer -= 30;
            tempSpeed = 0;
        }
        if (playerPos.position.y > maxHeight)
        {
            tempSpeedTimer += Time.deltaTime;
        }
        if (tempSpeedTimer >= 5)
        {
            AddTempSpeed();
            tempSpeedTimer = 0;
        }
        //Debug.DrawRay(new Vector3(-2.9f, maxHeight + 1.9f, 0f), Vector3.right * 6f, Color.white);
        //Debug.DrawRay(new Vector3(-2.9f, maxHeight + 1.4f, 0f), Vector3.right * 6f, Color.white);
        //Debug.DrawRay(new Vector3(-2.9f, maxHeight + 0.9f, 0f), Vector3.right * 6f, Color.white);
        //Debug.DrawRay(new Vector3(-2.9f, maxHeight + 0.4f, 0f), Vector3.right * 6f, Color.white);
    }

    void EndGame()
    {
        Debug.Log("Player died and game is over");
        SceneManager.LoadScene("Scene1");
    }

    void AddSpeed()
    {
        permSpeed++;
        Debug.Log("Permanent Speed increased to " + permSpeed);
    }

    void AddTempSpeed()
    {
        tempSpeed++;
        Debug.Log("Temporary speed increased");
    }

    public int getGameSpeed()
    {
        return permSpeed + tempSpeed;
    }

    public float getMaxHeight()
    {
        return maxHeight;
    }

    private void CheckMaxHeight()
    {
        RaycastHit2D hit1 = Physics2D.Raycast(new Vector3(-2.9f, maxHeight + 1.9f, 0f), Vector3.right, 5.75f, LayerMask.GetMask("Blocks"));
        RaycastHit2D hit2 = Physics2D.Raycast(new Vector3(-2.9f, maxHeight + 1.4f, 0f), Vector3.right, 5.75f, LayerMask.GetMask("Blocks"));
        RaycastHit2D hit3 = Physics2D.Raycast(new Vector3(-2.9f, maxHeight + 0.9f, 0f), Vector3.right, 5.75f, LayerMask.GetMask("Blocks"));
        RaycastHit2D hit4 = Physics2D.Raycast(new Vector3(-2.9f, maxHeight + 0.4f, 0f), Vector3.right, 5.75f, LayerMask.GetMask("Blocks"));
        if (hit1.collider != null)
        {
            maxHeight += 2;
        }
        else if (hit2.collider != null)
        {
            maxHeight += 1.5f;
        }
        else if (hit3.collider != null)
        {
            maxHeight += 1;
        }
        else if (hit4.collider != null)
        {
            maxHeight += 0.5f;
        }
    }
}
