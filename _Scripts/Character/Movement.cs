using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float movementSpeed;
        [SerializeField] private float jumpHeight;
        private Rigidbody rBody;
        //private Collider collider;    

        private bool canJump = true;

        // Start is called before the first frame update
        void Start()
        {
            rBody = GetComponent<Rigidbody>(); 
            rBody.velocity = Vector3.zero;

            //collider = GetComponent<Collider>();
        }

        public void Move(float x, float y)
        {
            /*if (x == 0 && y == 0)
            {
                rBody.velocity = Vector3.zero;
            }*/
            rBody.AddForce(movementSpeed * Time.deltaTime * new Vector3(x, 0, y).normalized,ForceMode.Impulse);
        }

        public void LookPosition(Vector3 position) {
            transform.LookAt(position);
        }

        public void LookDirection(Vector3 direction) {
            transform.forward = direction;
        }

        public void Jump()
        {
            //var currentVelocity = rBody.velocity;
            if (canJump)
            {
                rBody.AddForce(new Vector3(0,jumpHeight,0),ForceMode.Impulse);
                canJump = false;
            }
        }

        public void Dash(Vector3 direction)
        {
            //rBody.velocity = movementSpeed * 2 * direction;
            rBody.velocity = (direction * (movementSpeed));
        }
        
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.tag.Equals("Floor") && !canJump)
            {
                canJump = true;
            }
        }
    }

}
