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
        [SerializeField] private VoidEventObject startInteraction;

        private Movement movement;
        private Camera main;
        private Plane raycastPlane;
        private EquippedItemManager itemManager;

        private bool allowMovement = true;

        private bool canInteract = false;

        // Start is called before the first frame update
        void Start()
        {
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


            if (Input.GetMouseButtonDown(0))
            {
                itemManager.currentyEquipped().Use();
            }

            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                itemManager.EnableUsableUp();
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                itemManager.EnableUsableDown();
            }

            if (Input.GetKeyDown(KeyCode.F) && canInteract)
            {
                allowMovement = !allowMovement;
                if (!allowMovement)
                {
                    startInteraction.Raise();
                }

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

        public void SetCanInteract(bool val)
        {
            canInteract = val;
        }
    }
}