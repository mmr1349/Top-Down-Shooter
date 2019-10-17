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
    }

    public void Move(float x, float y) {
        rBody.velocity = new Vector3(x, 0, y) * movementSpeed;
    }

    public void LookDirection(Vector3 direction) {
        transform.LookAt(direction);
    }

    public void LookPosition(Vector3 position) {
        Vector3 direction = Vector3.Normalize(transform.position - position);
        //transform.rotation = Quaternion.Euler(0, Mathf.Atan2(), 0);
        transform.rotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.y), Vector3.up);
    }
}
