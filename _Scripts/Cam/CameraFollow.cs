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

        // Start is called before the first frame update
        void Start() {
            //camera = GetComponent<Camera>();
        }

        // Update is called once per frame
        void Update() {
            transform.position = objectToFollow.transform.position + offset;
        }
    }

}