using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class MyEvents
{
    //Add listener for event using MyEvents.<event name>.AddListener(<method to be called when event is triggered>)
    //Add listener in Start method for object script
    public static UnityEvent PlayerDied = new UnityEvent();
}
