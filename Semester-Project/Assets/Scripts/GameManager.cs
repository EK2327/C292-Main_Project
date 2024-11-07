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
    private int height;
    private float maxHeight = -3;
    private int tempSpeed = 0;
    private float timer;
    private float tempSpeedTimer;
    private int score;
    private int maxScore;

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
        maxScore = 0;
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
        //Calculate Score
        score = 
            //Height points - 25/block
            (int)((maxHeight + 3) * 50)
            //Speed points 50/speed
            + ((permSpeed + tempSpeed)) * 50 
            //Time survived points - 100/s
            + (int)(timer * 100);
        if (score > maxScore)
        {
            maxScore = score;
        }
        UIManager.instance.setScoreText(maxScore);
    }

    //End the game
    private void EndGame()
    {
        //Calculate height
        height = (int)(maxHeight + 3) * 10;

        //Store score and height for main menu scene
        PlayerPrefs.SetInt("Score", maxScore);
        PlayerPrefs.SetInt("Height", height);

        //Open main menu scene
        SceneManager.LoadScene("Scene1");
    }

    //Add a permanent speed increase
    private void AddSpeed()
    {
        permSpeed++;
    }

    //Add a temporary speed increase
    private void AddTempSpeed()
    {
        tempSpeed++;
    }

    //Get the current speed of the game
    public int getGameSpeed()
    {
        return permSpeed + tempSpeed;
    }

    //Get the max height of the blocks
    public float getMaxHeight()
    {
        return maxHeight;
    }

    //Check if a new max height has been reached
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
