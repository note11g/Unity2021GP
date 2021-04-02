using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int directionVector = 1;
    private int speed = 7;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += directionVector * speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -9.4f || pos.x > 9.4f)
            gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            gameObject.SetActive(false);
        }
    }
    //enemySpawner
    //public Enemy enemy;
    //public GameObject emenyGroup;
    //private bool isPlaying = true;

}
