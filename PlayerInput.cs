using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Movement movement;
    private Camera main;
    private Weapon wep;
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
        movement.Move(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector3 mousePosition = Input.mousePosition;
        RaycastHit hit;
        if (Physics.Raycast(main.ScreenPointToRay(mousePosition), out hit)) {
            movement.LookPosition(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        }

        if(Input.GetMouseButtonDown(0)) {
            wep.Attack();
        }
    }
}
