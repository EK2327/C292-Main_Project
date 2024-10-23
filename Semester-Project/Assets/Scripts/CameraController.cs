using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform playerPos;
    [SerializeField] Transform waterPos;

    float xPos;
    float yPos;
    float zPos;
    // Start is called before the first frame update
    void Start()
    {
        xPos = transform.position.x;
        yPos = transform.position.y + 3;
        zPos = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        yPos = playerPos.position.y + 3;
        //Make sure y position is above water
        if(yPos < (waterPos.position.y + 5))
        {
            yPos = waterPos.position.y + 5;
        }


        transform.position = new Vector3(xPos, yPos, zPos);
    }
}
