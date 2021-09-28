using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelActorCustomer : BaseLevelActor
{
    public BaseCustomerBehaviour CurrentBehaviour { get; set; }
    public PortalLevelObject Target { get; set; }
    public List<FormCopy> FormCopies { get; set; }

    public LevelActorCustomer(int x, int y) : base(x, y)
    {
        CurrentBehaviour = new CustomerBehaviourThinking(this);
        FormCopies = new List<FormCopy>();
    }

    public override Sprite GetSprite()
    {
        return MainSceneSpriteListController.Instance.Customer;
    }

    internal bool HasCompletedForm(Form requiredForm)
    {
        var formCopy = FormCopies.Find(x => x.Form == requiredForm);
        if (formCopy == null)
            return false;

        return formCopy.FormCompleted();
    }

    public override void PassTime(float timePassedInSeconds, Level level)
    {
        CurrentBehaviour.PassTime(timePassedInSeconds, level);
    }

}
