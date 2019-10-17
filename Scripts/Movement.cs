using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    private Rigidbody rBody;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody>(); 
        rBody.velocity = Vector3.zero;
    }

    public void Move(float x, float y) {
        rBody.velocity = new Vector3(x, 0, y) * movementSpeed;
    }

    public void LookPosition(Vector3 position) {
        transform.LookAt(position);
    }

    public void LookDirection(Vector3 direction) {
        transform.forward = direction;
    }
}
