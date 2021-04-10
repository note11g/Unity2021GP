using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public it focus;

    public LayerMask movementMask;
    Camera cam;
    Motor motor;

    

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<Motor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                motor.MoveToPoint(hit.point);

                RemoveFocus();
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 100))
            {
                it interactable = hit.collider.gameObject.GetComponent<it>();
                if(interactable != null)
                {
                    SetFocus(interactable);
                }
            }
        }
    }

    void SetFocus(it newFocus)
    {
        if(newFocus != focus)
        {
            if(focus != null)
            {
                focus.onDefocused();
            }
            focus = newFocus;
            motor.FollowTarget(newFocus);
        }
        newFocus.onFocused(transform);
    }

    void RemoveFocus()
    {
        if(focus != null)
        {
            focus.onDefocused();
            focus = null;
            motor.StopFollowing();
        }
    }
   
}
