using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class MyEvents
{
    //Add listener for event using MyEvents.<event name>.AddListener(<method to be called when event is triggered>)
    //Add listener in Start method for object script

    //Event for player death
    public static UnityEvent PlayerDied = new UnityEvent();
    //Event for pipe being done falling, so a new pipe can spawn
    public static UnityEvent BlockDoneFalling = new UnityEvent();
    //Event for a pipe being broken
    public static UnityEvent BlockBroken = new UnityEvent();
}
