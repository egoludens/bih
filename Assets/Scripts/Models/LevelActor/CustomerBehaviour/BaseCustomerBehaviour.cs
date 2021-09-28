using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCustomerBehaviour {

    protected BaseLevelActor _actor;

    public BaseCustomerBehaviour(BaseLevelActor actor)
    {
        _actor = actor;
    }

    public abstract void PassTime(float timePassedInSeconds, Level level);
}
