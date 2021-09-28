using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseLevelActor {

    public Vector2 Position { get; set; }

    public BaseLevelActor(int x, int y)
    {
        Position = new Vector2(Convert.ToSingle(x), Convert.ToSingle(y));
    }

    public abstract Sprite GetSprite();

    public virtual void PassTime(float timePassedInSeconds, Level level)
    {
    }

}
