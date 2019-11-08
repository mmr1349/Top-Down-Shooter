using System;
using System.Collections;
using System.Collections.Generic;
using Character;
using Events.EventObjects;
using UnityEngine;
using Weapons;

namespace Player
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private Vector3EventObject startInteraction;

        private Movement movement;
        private Camera main;
        private Plane raycastPlane;
        private EquippedItemManager itemManager;
        private InventoryVisual inventoryVisual;

        private bool allowMovement = true;

        private bool canInteract = false;

        // Start is called before the first frame update
        void Start() {
            inventoryVisual = GameObject.FindObjectOfType<InventoryVisual>();
            main = Camera.main;
            movement = GetComponent<Movement>();
            raycastPlane = new Plane(Vector3.up, 0f);
            itemManager = GetComponent<EquippedItemManager>();
        }

        // Update is called once per frame
        void Update()
        {
            RaycastHit hit;
            Ray mouseRay = main.ScreenPointToRay(Input.mousePosition);
            float enter;
            //For plane casting
            if (raycastPlane.Raycast(mouseRay, out enter))
            {
                Vector3 hitPoint = mouseRay.GetPoint(enter);
                movement.LookPosition(new Vector3(hitPoint.x, transform.position.y, hitPoint.z));
            }

            //For raycasting
            /*if (Physics.Raycast(mouseRay, out hit, 100f, mask)) {
                Debug.Log("Collided with " + hit.transform.name + " at position " + hit.point);
                movement.LookPosition(new Vector3(hit.point.x, transform.position.y, hit.point.z));
                mousePosition.transform.position = hit.point;
            }*/


            if (Input.GetMouseButtonDown(0))
            {
                itemManager.currentyEquipped().Use();
            }

            if (Input.GetAxis("Mouse ScrollWheel") > 0f) {
                itemManager.EnableEquippableUp();
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0f) {
                itemManager.EnableEquippableDown();
            }

            if (Input.GetKeyDown(KeyCode.F) && canInteract)
            {
                allowMovement = !allowMovement;
                if (!allowMovement)
                {
                    startInteraction.Raise(transform.position);
                }

            }

            if (Input.GetKeyDown(KeyCode.I)) {
                inventoryVisual.gameObject.SetActive(!inventoryVisual.gameObject.activeSelf);
            }

        }

        private void FixedUpdate()
        {
            if (!allowMovement) return;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                movement.Jump();

            }

            movement.Move(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            if (Input.GetKeyDown(KeyCode.Q))
            {
                movement.Dash(Vector3.left);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                movement.Dash(Vector3.right);
            }
        }

        public void ToggleMovement()
        {
            allowMovement = !allowMovement;
        }

        public void SetCanInteract(bool val) {
            canInteract = val;
        }
    }
}