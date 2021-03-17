using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colider_Manager : MonoBehaviour
{
    // Start is called before the first frame update


    public Player_Inventory_Manager Player_Inventory_Manager;
    public UI_Manager UI_Manager;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

 
    private void OnCollisionEnter2D( Collision2D collision)
    {
        Debug.Log("TOCOU em colider!");
       

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("TOCOU!", collision);
        Debug.Log(collision.gameObject.name);

        if (collision.gameObject.name == ("Wood(Clone)"))
        {
            Debug.Log("TOCOU EM MADEIRA");
            Destroy(collision.gameObject);
            Player_Inventory_Manager.woodInv = Player_Inventory_Manager.woodInv + 1;
            UI_Manager.woodText.GetComponent<UnityEngine.UI.Text>().text = Player_Inventory_Manager.woodInv.ToString();

        }
        if (collision.gameObject.name == ("Stone(Clone)"))
        {
            Debug.Log("TOCOU EM PEDRA");
            Destroy(collision.gameObject);
            Player_Inventory_Manager.stoneInv = Player_Inventory_Manager.stoneInv + 1;
            UI_Manager.stoneText.GetComponent<UnityEngine.UI.Text>().text = Player_Inventory_Manager.stoneInv.ToString();
        }

        
    }

}
