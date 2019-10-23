using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;

public class PlayerInput : MonoBehaviour
{
    private Movement movement;
    private Camera main;
    private Plane raycastPlane;
    private EquippedItemManager itemManager;
    // Start is called before the first frame update
    void Start() {
        main = Camera.main;
        movement = GetComponent<Movement>();
        raycastPlane = new Plane(Vector3.up, 0f);
        itemManager = GetComponent<EquippedItemManager>();
    }

    // Update is called once per frame
    void Update() {
        movement.Move(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        RaycastHit hit;
        Ray mouseRay = main.ScreenPointToRay(Input.mousePosition);
        float enter;
        //For plane casting
        if (raycastPlane.Raycast(mouseRay, out enter)) {
            Vector3 hitPoint = mouseRay.GetPoint(enter);
            movement.LookPosition(new Vector3(hitPoint.x, transform.position.y, hitPoint.z));
        }

        //For raycasting
        /*if (Physics.Raycast(mouseRay, out hit, 100f, mask)) {
            Debug.Log("Collided with " + hit.transform.name + " at position " + hit.point);
            movement.LookPosition(new Vector3(hit.point.x, transform.position.y, hit.point.z));
            mousePosition.transform.position = hit.point;
        }*/

        if(Input.GetMouseButtonDown(0)) {
            itemManager.currentyEquipped().Use();
        } if (Input.GetAxis("Mouse ScrollWheel") > 0f) {
            itemManager.EnableUsableUp();
        } else if (Input.GetAxis("Mouse ScrollWheel") < 0f) {
            itemManager.EnableUsableDown();
        }
    }
}
