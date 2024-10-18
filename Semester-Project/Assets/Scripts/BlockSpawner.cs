using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    private float yPos;
    private float timer = 0;
    float gameSpeed;

    //Pipe prefabs
    [SerializeField] GameObject pipe1prefab;
    [SerializeField] GameObject pipe2prefab;
    [SerializeField] GameObject pipe3prefab;
    [SerializeField] GameObject pipe4prefab;
    [SerializeField] GameObject pipe5prefab;
    [SerializeField] GameObject pipe6prefab;
    [SerializeField] GameObject pipe7prefab;
    [SerializeField] GameObject pipe8prefab;
    [SerializeField] GameObject pipe9prefab;
    [SerializeField] GameObject pipe10prefab;
    [SerializeField] GameObject pipe11prefab;
    [SerializeField] GameObject pipe12prefab;
    [SerializeField] GameObject pipe13prefab;
    [SerializeField] GameObject pipe14prefab;
    [SerializeField] GameObject pipe15prefab;
    [SerializeField] GameObject pipe16prefab;
    [SerializeField] GameObject pipe17prefab;
    [SerializeField] GameObject pipe18prefab;
    [SerializeField] GameObject pipe19prefab;

    // Start is called before the first frame update
    void Start()
    {
        yPos = Camera.main.ViewportToWorldPoint(new Vector3(0, 1.25f, 0)).y;
    }

    // Update is called once per frame
    void Update()
    {
        gameSpeed = GameManager.instance.getGameSpeed();
        timer += Time.deltaTime;
        if (timer > 2 / gameSpeed)
        {
            //Debug.Log("Spawning a block");
            yPos = Camera.main.ViewportToWorldPoint(new Vector3(0, 1.25f, 0)).y;
            SpawnBlock(Random.Range(0, 9));
            timer = 0;
        }
        
    }

    void SpawnBlock(int placement)
    {
        if (placement == 9)
        {
            //Only pipe 5.0
        }
        else if (placement == 8)
        {
            //All pipes except 1.1, 1.3, 2.1, 2.3, 3.0, 3.2, 5.1, 6.0, 7.0
        }
        else if (placement == 7)
        {
            //All pipes except 5.1
        }
        else
        {
            //All pipes possible
        }
    }

}
