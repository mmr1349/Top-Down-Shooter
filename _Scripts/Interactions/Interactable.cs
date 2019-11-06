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
 * In order for interactions to work, the game object must have a void event listener that listens for a start interaction call
 * When an interaction attempt is made, it will check the current ConditionCollection. If that passes, then it will send the attached reactioncollection
 * to the proper listeners.
 *
 * The conditions are scriptalbe objects that can have their satisfied value set by any action. Just need to make sure that they are notified by it.
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
            Debug.Log("Playing Default Reaction");
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
                Debug.Log("Playing Default Reaction");
            }
        }
        
        
        
        
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
