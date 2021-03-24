using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCircle : MonoBehaviour
{
    public GameObject littleCircle;
    GameObject GameAdmin;

    void Start()
    {
        GameAdmin = GameObject.FindGameObjectWithTag("gameadmin");
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            littleCircleCreate();
        }
    }

    void littleCircleCreate()
    {
        Instantiate(littleCircle, transform.position, transform.rotation);
        GameAdmin.GetComponent<GameAdmin>().insivibleText();
    }
}
