using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int gameSpeed = 1;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        MyEvents.PlayerDied.AddListener(EndGame);
        MyEvents.SpeedIncreased.AddListener(AddSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EndGame()
    {
        Debug.Log("Player died and game is over");
    }

    void AddSpeed()
    {
        gameSpeed++;
    }

    public int getGameSpeed()
    {
        return gameSpeed;
    }
}
