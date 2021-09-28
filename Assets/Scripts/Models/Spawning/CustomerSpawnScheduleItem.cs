using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawnScheduleItem {

    public float InitialDelayInSeconds { get; set; }
    public float RemainingInitialDelayInSeconds { get; set; }

    public int SpawnLimit { get; set; }
    public int RemainingSpawnLimit { get; set; }

    public float IntervalInSeconds { get; set; }
    public float RemainingIntervalInSeconds { get; set; }

    public PortalLevelObject CustomerTarget { get; set; }

    public CustomerSpawnScheduleItem(float initialDelayInSeconds, int spawnLimit, float intervalInSeconds, PortalLevelObject customerTarget)
    {
        InitialDelayInSeconds = initialDelayInSeconds;
        RemainingInitialDelayInSeconds = InitialDelayInSeconds;

        SpawnLimit = spawnLimit;
        RemainingSpawnLimit = SpawnLimit;

        IntervalInSeconds = intervalInSeconds;
        RemainingIntervalInSeconds = 0;

        CustomerTarget = customerTarget;
    }

}
