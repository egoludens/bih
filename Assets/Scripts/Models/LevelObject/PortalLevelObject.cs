using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalLevelObject : BaseLevelObject
{
    public PortalType PortalType { get; set; }
    public List<Form> RequiredForms { get; set; }
    public CustomerSpawnSchedule SpawnSchedule { get; set; }
    public event EventHandler<CustomerSpawnedEventArgs> CustomerSpawned;

    public PortalLevelObject(int x, int y, PortalType portalType) : base(x, y)
    {
        Placement = ObjectPlacementEnum.Floor;
        PortalType = portalType;
        RequiredForms = new List<Form>();
        SpawnSchedule = new CustomerSpawnSchedule();
    }

    public override Sprite GetSprite()
    {
        if (PortalType == PortalType.Inbound)
            return MainSceneSpriteListController.Instance.PortalInbound;
        else if (PortalType == PortalType.Outbound)
            return MainSceneSpriteListController.Instance.PortalOutbound;
        else
            throw new System.NotImplementedException();
    }

    public override void PassTime(float timePassedInSeconds)
    {
        CustomerSpawnScheduleItem activeScheduleItem = null;
        foreach(var scheduleItem in SpawnSchedule.Items)
        {
            if (scheduleItem.RemainingInitialDelayInSeconds > 0f || scheduleItem.RemainingSpawnLimit > 0)
            {
                activeScheduleItem = scheduleItem;
                break;
            }
        }

        if (activeScheduleItem != null)
        {
            var spawnIsNeeded = false;
            if (activeScheduleItem.RemainingInitialDelayInSeconds > 0f)
            {
                activeScheduleItem.RemainingInitialDelayInSeconds = activeScheduleItem.RemainingInitialDelayInSeconds <= timePassedInSeconds 
                    ? 0f
                    : activeScheduleItem.RemainingInitialDelayInSeconds - timePassedInSeconds;

                if (activeScheduleItem.RemainingInitialDelayInSeconds == 0f)
                    spawnIsNeeded = true;
            }
            else
            {
                activeScheduleItem.RemainingIntervalInSeconds = activeScheduleItem.RemainingIntervalInSeconds <= timePassedInSeconds ? 0f : activeScheduleItem.RemainingIntervalInSeconds - timePassedInSeconds;
                if (activeScheduleItem.RemainingIntervalInSeconds == 0f)
                    spawnIsNeeded = true;
            }

            if (spawnIsNeeded)
            {
                SpawnNewCustomer(activeScheduleItem.CustomerTarget);
                activeScheduleItem.RemainingSpawnLimit--;
                activeScheduleItem.RemainingIntervalInSeconds = activeScheduleItem.IntervalInSeconds;
            }
        }
    }

    private void SpawnNewCustomer(PortalLevelObject customerTarget)
    {
        var newActor = new LevelActorCustomer(Position.X, Position.Y)
        {
            Target = customerTarget
        };
        CustomerSpawned.Invoke(this, new CustomerSpawnedEventArgs(newActor));
    }

    public class CustomerSpawnedEventArgs : EventArgs
    {
        public BaseLevelActor Actor { get; private set; }

        public CustomerSpawnedEventArgs(BaseLevelActor actor)
        {
            Actor = actor;
        }
    }
}
