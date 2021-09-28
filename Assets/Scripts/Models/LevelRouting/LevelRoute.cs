using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelRoute {

    public List<ObjectPosition> Waypoints { get; set; }

    public LevelRoute()
    {
        Waypoints = new List<ObjectPosition>();
    }

}
