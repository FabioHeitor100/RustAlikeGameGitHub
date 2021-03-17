using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear_Weapon_Manager : MonoBehaviour
{
    public float spearSpeed = 10f;
    public Rigidbody2D spearRigidBody;

    public GameObject TrowPoint;


    private Camera cam;

    public GameObject SpearBullet;

    
    Vector2 target;

    private GameObject Player;




    void Start()
    {
        Debug.Log("ENTROU A SPEAR");
        cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
       // Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        target = cam.ScreenToWorldPoint(Input.mousePosition);

        Debug.Log("PLAYER ROTATION;");
        Debug.Log(gameObject.transform.rotation);


        if (Input.GetButtonDown("Fire1"))
        {
            ShootSpear();
        }
    }

    public void ShootSpear()
    {
        Debug.Log("DISPARAR SPEAR");
        GameObject bulletSpawned = Instantiate(SpearBullet) as GameObject;
        bulletSpawned.transform.position = TrowPoint.transform.position;
        bulletSpawned.transform.rotation = gameObject.transform.rotation;
        //bulletSpawned.GetComponent<Rigidbody2D>().velocity = dire
        bulletSpawned.GetComponent<Rigidbody2D>().AddForce(TrowPoint.transform.up * spearSpeed, ForceMode2D.Impulse);


        //rb.rotation

        //spearRigidBody.AddForce(spearRigidBody.transform.forward * 1000);
    }

}
