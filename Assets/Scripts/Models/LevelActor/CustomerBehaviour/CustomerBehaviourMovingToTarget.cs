using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerBehaviourMovingToTarget : BaseCustomerBehaviour
{
    public CustomerBehaviourMovingToTarget(LevelActorCustomer actor) : base(actor) { }

    public override void PassTime(float timePassedInSeconds, Level level)
    {
    }
}
