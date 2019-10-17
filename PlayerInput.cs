using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Movement movement;
    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.Move(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector3 mouse = Input.mousePosition;
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(mouse), out hit)) {
            movement.LookPosition(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        }
    }
}
