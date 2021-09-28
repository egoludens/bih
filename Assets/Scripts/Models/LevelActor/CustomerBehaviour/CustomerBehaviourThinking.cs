using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerBehaviourThinking : BaseCustomerBehaviour
{
    public CustomerBehaviourThinking(LevelActorCustomer actor) : base(actor) {}

    public override void PassTime(float timePassedInSeconds, Level level)
    {
        var customer = (LevelActorCustomer)_actor;
        var target = customer.Target;

        Form formToComplete = null;
        foreach(var requiredForm in target.RequiredForms)
        {
            if(!customer.HasCompletedForm(requiredForm))
            {
                formToComplete = requiredForm;
                break;
            }
        }

        if (formToComplete == null)
        {
            customer.CurrentBehaviour = new CustomerBehaviourMovingToTarget(customer);
        } else
        {
            var desk = level.FindDeskForTheForm(formToComplete);
            customer.CurrentBehaviour = new CustomerBehaviourMovingToDesk(customer, desk);
        }

    }
}
