using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cam
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private GameObject objectToFollow;

        //private Camera camera; //This Camera
        [SerializeField] private Vector3 offset;
<<<<<<< HEAD
    
        // Start is called before the first frame update
        void Start()
        {
=======

        // Start is called before the first frame update
        void Start() {
>>>>>>> Marcus's-Branch
            //camera = GetComponent<Camera>();
        }

        // Update is called once per frame
<<<<<<< HEAD
        void Update()
        {
=======
        void Update() {
>>>>>>> Marcus's-Branch
            transform.position = objectToFollow.transform.position + offset;
        }
    }

<<<<<<< HEAD
}
=======
}
>>>>>>> Marcus's-Branch
