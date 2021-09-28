using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerBehaviourMovingToDesk : BaseCustomerBehaviour
{
    public DeskLevelObject TargetDesk { get; set; }
    public LevelRoute Route { get; set; }
    
    public CustomerBehaviourMovingToDesk(LevelActorCustomer actor, DeskLevelObject desk) : base(actor)
    {
        TargetDesk = desk;
        Route = null;
    }

    public override void PassTime(float timePassedInSeconds, Level level)
    {
        if (Route == null)
        {
            Route = LevelRouter.BuildRoute(_actor.Position, TargetDesk.Position);
        }




    }
}
