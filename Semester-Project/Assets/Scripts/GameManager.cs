using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MyEvents.PlayerDied.AddListener(EndGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EndGame()
    {

    }
}
