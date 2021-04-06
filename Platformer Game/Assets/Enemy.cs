using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator anim;
    float dieTimer = 0f;
    bool isDie = false;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDie)
        {
            dieTimer += Time.deltaTime;
            if (dieTimer >= 1f)
            {
                SoundManager.instance.PlayHitSound();
                Destroy(gameObject);
            }
        }
    }

    public void Die()
    {
        isDie = true;
        anim.SetBool("isDie", true);
    }
}
