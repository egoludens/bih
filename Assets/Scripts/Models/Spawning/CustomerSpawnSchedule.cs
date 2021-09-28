using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawnSchedule {

    public List<CustomerSpawnScheduleItem> Items { get; set; }

    public CustomerSpawnSchedule()
    {
        Items = new List<CustomerSpawnScheduleItem>();
    }

}
