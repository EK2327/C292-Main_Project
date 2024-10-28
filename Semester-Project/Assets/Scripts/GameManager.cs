using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int gameSpeed = 1;
    private float maxHeight = -3;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        MyEvents.PlayerDied.AddListener(EndGame);
        MyEvents.SpeedIncreased.AddListener(AddSpeed);
        MyEvents.BlockDoneFalling.AddListener(CheckMaxHeight);
    }

    // Update is called once per frame
    void Update()
    {
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
        gameSpeed++;
    }

    public int getGameSpeed()
    {
        return gameSpeed;
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
