using System.Collections;
using System.Collections.Generic;
using Events.CustomEvents;
using Events.EventObjects;
using Events.Listeners;
using Player;
using UnityEngine;


/**
 * Requires that the game object attatched has a secondary trigger collider,
 * will not interfere with other collision detection
 */
[RequireComponent(typeof(VoidEventListener))]
public class Interactable : MonoBehaviour
{
    private bool canInteract = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartInteraction()
    {
        
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
