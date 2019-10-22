using System;
using System.Collections;
using System.Collections.Generic;
using Events.Listeners;
using Interactions.Conditions;
using Player;
using UnityEditorInternal.VersionControl;
using UnityEngine;


/**
 * Requires that the game object attatched has a secondary trigger collider,
 * will not interfere with other collision detection
 */
[RequireComponent(typeof(VoidEventListener))]
public class Interactable : MonoBehaviour
{
    private bool canInteract = false;
    //[SerializeField] private Dictionary<Condition,string> conditions;
    
    
    // Start is called before the first frame update
    void Start()
    {
        //conditions = new Dictionary<Condition, string>();//TODO replace string with reaction type
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckInteraction(Condition condition)
    {
        if (true)
        {
            
            Debug.Log($"Running Condition {condition.description}");
        }
    }
    public void StartInteraction()
    {
        //Look Through conditions to see what has been satisfied and and then look to see if reaction has been played
        //Then play the reaction and send it to a text manager
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
}
