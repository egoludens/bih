using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseLevelObject {

    public ObjectPosition Position { get; set; }
    public ObjectPlacementEnum Placement { get; set; }

    public BaseLevelObject(int x, int y)
    {
        Position = new ObjectPosition { X = x, Y = y };
    }

    public abstract Sprite GetSprite();

    public virtual void PassTime(float timePassedInSeconds) { }
}
