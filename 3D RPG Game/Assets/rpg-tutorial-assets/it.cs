using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class it : MonoBehaviour
{
    public float radius = 3f;
    private bool isFocus = false;
    private bool hasInteracted = false;

    Transform player;
    public Transform interactionTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, interactionTransform.position);

            if(distance < radius)
            {
                hasInteracted = true;
            }
        }
    }

    public virtual void Interact()
    {
        //player.gameObject.GetComponent<Controller>();
    }

    public void onFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }
    public void onDefocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }

    private void OnDrawGizmosSelected()
    {
        if(interactionTransform == null)
        {
            interactionTransform = transform;
        }

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }


}
