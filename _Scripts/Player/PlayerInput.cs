using System;
using System.Collections;
using System.Collections.Generic;
using Character;
using UnityEngine;
using Weapons;

namespace Player
{
    public class PlayerInput : MonoBehaviour
    {
        private Movement movement;
        private Camera main;
        private Weapon wep;

        private bool allowMovement = true;
        // Start is called before the first frame update
        void Start()
        {
            wep = GetComponentInChildren<Weapon>();
            main = Camera.main;
            movement = GetComponent<Movement>();
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 mouse = Input.mousePosition;
            RaycastHit hit;
            if (Physics.Raycast(main.ScreenPointToRay(mouse), out hit)) {
                movement.LookPosition(new Vector3(hit.point.x, transform.position.y, hit.point.z));
            }
            
            if(Input.GetMouseButtonDown(0) && allowMovement) {
                wep.Attack();
            }
            
        }

        private void FixedUpdate()
        {
            if (!allowMovement)
            {
                return;
            }
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                movement.Jump();
                
            }
            movement.Move(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));

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
    }

}