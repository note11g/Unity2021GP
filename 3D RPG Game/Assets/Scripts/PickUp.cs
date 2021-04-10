using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : it
{
    public RpgItem item;

    // Start is called before the first frame update
    
    public override void Interact()
    {
        base.Interact();

        Pick();
    }

    void Pick()
    {
        Debug.Log("use item: " + item.name);

        Destroy(gameObject);

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
