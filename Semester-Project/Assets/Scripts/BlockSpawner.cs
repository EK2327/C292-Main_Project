using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    private float yPos;
    float gameSpeed;
    private bool canSpawn = true;

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
        yPos = GameManager.instance.getMaxHeight() + 10;
        MyEvents.BlockDoneFalling.AddListener(SetCanSpawn);
    }

    // Update is called once per frame
    void Update()
    {
        //Update game speed
        gameSpeed = GameManager.instance.getGameSpeed();
        
        //Check if the last block has landed and a new block can spawn
        if (canSpawn)
        {
            yPos = GameManager.instance.getMaxHeight() + 10;
            SpawnBlock(Random.Range(0, 9));
        }
        
    }

    /**
     * Spawns a block at the indicated column above the screen
     * 
     * Parameter:
     * int placement - the placement location of the block to be spawned (int 0 to 9 to indicate the column the block will fall into)
     */
    void SpawnBlock(int placement)
    {
        int spawnPrefab;
        //Left most column can only spawn block with width of 1
        if (placement == 9)
        {
            spawnPrefab = 0;
        }
        //Can spawn pipes with width up to 2
        else if (placement == 8)
        {
            spawnPrefab = Random.Range(0, 9);
            //All pipes except 1.1, 1.3, 2.1, 2.3, 3.0, 3.2, 5.1, 6.0, 7.0
        }
        //Can spawn pipes with width up to 4
        else if (placement == 7)
        {
           spawnPrefab = Random.Range(0, 18);
            //All pipes except 5.1
        }
        //Can spawn all pipes
        else
        {
            spawnPrefab = Random.Range(0, 19);
            //All pipes possible
        }

        //Calculate spawnpoint for pipe
        float spawnPointX = (float)((placement * 0.5) - 2.25);
        Vector3 spawnPoint = new Vector3(spawnPointX, yPos, transform.position.z);

        //Spawn the correct pipe
        switch (spawnPrefab)
        {
            case 0:
                Instantiate(pipe14prefab, spawnPoint, Quaternion.identity);
                break;
            case 1:
                Instantiate(pipe1prefab, spawnPoint, Quaternion.identity);
                break;
            case 2:
                Instantiate(pipe3prefab, spawnPoint, Quaternion.identity);
                break;
            case 3:
                Instantiate(pipe5prefab, spawnPoint, Quaternion.identity);
                break;
            case 4:
                Instantiate(pipe7prefab, spawnPoint, Quaternion.identity);
                break;
            case 5:
                Instantiate(pipe10prefab, spawnPoint, Quaternion.identity);
                break;
            case 6:
                Instantiate(pipe12prefab, spawnPoint, Quaternion.identity);
                break;
            case 7:
                Instantiate(pipe13prefab, spawnPoint, Quaternion.identity);
                break;
            case 8:
                Instantiate(pipe17prefab, spawnPoint, Quaternion.identity);
                break;
            case 9:
                Instantiate(pipe19prefab, spawnPoint, Quaternion.identity);
                break;
            case 10:
                Instantiate(pipe2prefab, spawnPoint, Quaternion.identity);
                break;
            case 11:
                Instantiate(pipe4prefab, spawnPoint, Quaternion.identity);
                break;
            case 12:
                Instantiate(pipe6prefab, spawnPoint, Quaternion.identity);
                break;
            case 13:
                Instantiate(pipe8prefab, spawnPoint, Quaternion.identity);
                break;
            case 14:
                Instantiate(pipe9prefab, spawnPoint, Quaternion.identity);
                break;
            case 15:
                Instantiate(pipe11prefab, spawnPoint, Quaternion.identity);
                break;
            case 16:
                Instantiate(pipe16prefab, spawnPoint, Quaternion.identity);
                break;
            case 17:
                Instantiate(pipe18prefab, spawnPoint, Quaternion.identity);
                break;
            case 18:
                Instantiate(pipe15prefab, spawnPoint, Quaternion.identity);
                break;
        }
        canSpawn = false;
    }

    private void SetCanSpawn()
    {
        //Debug.Log("Block can spawn again");
        canSpawn = true;
    }

}
