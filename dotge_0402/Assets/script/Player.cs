using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private float speed = 10;
    private int hp = 3;

    public int GetHp()
    {
        return hp;
    }

    public void SetHP (int hp)
    {
        this.hp = hp;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(hp > 0) MoveKey();
    }

    private void MoveKey()
    {
        float posX, posY;
        posX = posY = 0;
        //if (Input.GetKey(KeyCode.A))
        //{
        //    posX -= 1;
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    posX += 1;
        //}
        //if (Input.GetKey(KeyCode.W))
        //{
        //    posY += 1;
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    posY -= 1;
        //}

        posX = Input.GetAxis("Horizontal");
        posY = Input.GetAxis("Vertical");

        Vector3 pos = this.transform.position;
        pos.x += posX * Time.deltaTime * speed;
        pos.y += posY * Time.deltaTime * speed;

        if (pos.x < -9.4f) pos.x = -9.4f;
        if (pos.y > 4.38f) pos.y = 4.38f;
        if (pos.x > 9.4f) pos.x = 9.4f;
        if (pos.y < -4.38f) pos.y = -4.38f;


        transform.position = pos;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Enemy"))
        {
            hp -= 1;
            Debug.Log(hp);
            print("À¸¾Ç");
        }
    }
}
