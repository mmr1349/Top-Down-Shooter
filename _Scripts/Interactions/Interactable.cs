using System;
using System.Collections;
using System.Collections.Generic;
using Events.EventObjects;
using Events.Listeners;
using Interactions;
using Interactions.Conditions;
using Interactions.Reactions;
using Player;
using UnityEditorInternal.VersionControl;
using UnityEngine;


/**
 * Requires that the game object attached has a secondary trigger collider,
 * will not interfere with other collision detection
 */
[RequireComponent(typeof(VoidEventListener))]
public class Interactable : MonoBehaviour
{
    private bool canInteract = false;
    [SerializeField] private ConditionCollection[] conditionCollections;
    [SerializeField] private ReactionEventObject reactionEventObject;
    [SerializeField] private ReactionCollection defaultReaction;
    private int currentConditionIndex = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (var conditionCollection in conditionCollections)
        {
            conditionCollection.Init();
        }
        
        //TODO replace string with reaction type
    }

    // Update is called once per frame
    void Update()
    {
        
    }

//    public void CheckInteraction(Condition conditionInput)
//    {
//        if (conditionInput.satasfied)
//        {
//            
//            Debug.Log($"Heard Condition {condition.description}");
//        }
//    }
    public void StartInteraction()
    {
        if (currentConditionIndex >= conditionCollections.Length)
        {
            reactionEventObject.Raise(defaultReaction);
        }
        else
        {
            if (conditionCollections[currentConditionIndex].CheckSatisfied())
            {
                reactionEventObject.Raise(conditionCollections[currentConditionIndex].GetReactionCollection());
            }
            else
            {
                reactionEventObject.Raise(defaultReaction);
            }
        }
        
        Debug.Log("Looking for interaction text");
        
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerInput>())
        {
            other.gameObject.GetComponent<PlayerInput>().SetCanInteract(true);
            canInteract = true;
            Debug.Log("Can interact");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerInput>())
        {
            other.gameObject.GetComponent<PlayerInput>().SetCanInteract(false);
            canInteract = false;
            Debug.Log("Can no longer interact");
        }
    }

    //public abstract Reaction startReaction();

}
