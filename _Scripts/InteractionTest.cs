using System.Collections;
using System.Collections.Generic;
using Events.EventObjects;
using Interactions.Conditions;
using UnityEngine;

public class InteractionTest : MonoBehaviour
{
    public ConditionEventObject conditionEvent;

    public Condition condition;

    public bool raised = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!raised)
        {
            conditionEvent.Raise(condition);
            condition.satasfied = true;
            raised = true;
        }
    }
}
