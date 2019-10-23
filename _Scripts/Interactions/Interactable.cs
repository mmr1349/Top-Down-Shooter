using System;
using System.Collections;
using System.Collections.Generic;
using Events.EventObjects;
using Events.Listeners;
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
    //[SerializeField] private Dictionary<Condition,string> conditions;
    [SerializeField] private Condition condition;
    [SerializeField] private Reaction reaction;
    [SerializeField] private ReactionEventObject reactionEventObject;
    
    
    // Start is called before the first frame update
    void Start()
    {
        reaction.Init();
        
        //TODO replace string with reaction type
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckInteraction(Condition conditionInput)
    {
        if (conditionInput.satasfied)
        {
            
            Debug.Log($"Heard Condition {condition.description}");
        }
    }
    public void StartInteraction()
    {
        //Look Through conditions to see what has been satisfied and and then look to see if reaction has been played
        //Then play the reaction and send it to a text manager
        reactionEventObject.Raise(reaction);
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
