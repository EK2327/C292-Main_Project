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
    private float timer = 0;
    private float totalTime = 0;
    private float tempSpeedTimer = 0;
    private float scoreUpdateTimer = 0;
    private int maxScore = 0;
    private int score;
    private int height;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        MyEvents.PlayerDied.AddListener(EndGame);
        MyEvents.BlockDoneFalling.AddListener(CheckMaxHeight);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        totalTime += Time.deltaTime;
        //Every 30 seconds add one to speed
        if (timer >= 20)
        {
            AddSpeed();
            timer -= 20;
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
        
        //Calculate and update score
        scoreUpdateTimer += Time.deltaTime;
        if (scoreUpdateTimer >= 0.2)
        {
            //Calculate Score
            score =
                //Height points : 60/block
                (int)((maxHeight + 3) * 120)
                //Speed points : 125/permanent speed + 50/temporary speed
                + (permSpeed * 125) + (tempSpeed * 50)
                //Time survived points : 150/s
                + (int)(totalTime * 150);
            //Check if score increased
            if (score > maxScore)
            {
                maxScore = score;
            }
            //Update UI
            UIManager.instance.setScoreText(maxScore);
            scoreUpdateTimer = 0;
        }
        
    }

    //End the game
    private void EndGame()
    {
        //Calculate height
        height = (int)(maxHeight + 3) * 5;

        //Store score and height for main menu scene
        PlayerPrefs.SetInt("Score", maxScore);
        PlayerPrefs.SetInt("Height", height);

        //Open main menu scene
        SceneManager.LoadScene(0);
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
