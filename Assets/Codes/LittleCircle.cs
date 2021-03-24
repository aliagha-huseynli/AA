using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleCircle : MonoBehaviour
{
    Rigidbody2D physics;
    public float velocity;
    bool moveControl;
    GameObject gameAdmin;

    void Start()
    {
        physics = GetComponent<Rigidbody2D>();
        gameAdmin = GameObject.FindGameObjectWithTag("gameadmin");
    }

    void FixedUpdate()
    {
        if (!moveControl)
        {
            physics.MovePosition(physics.position + Vector2.up * velocity * Time.deltaTime);
        }        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "circle")
        {
            transform.SetParent(col.transform);
            moveControl = true;
            //Debug.Log("boom");
        }
        if (col.tag == "littlecircle")
        {
            gameAdmin.GetComponent<GameAdmin>().GameOver();
            //Debug.Log("Contact");
        }
    }
}
