using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Inventory_Data : MonoBehaviour
{
    // Start is called before the first frame update

    public class myClass
    {
        public bool isEmpty;
        public int itemID;
        public string myString;
        public int amount;
    }

    public myClass[] playerInvData = new myClass[8];
    public myClass[] playerBasicInvData = new myClass[3];


    // ------------//

    private Inventory inventory;



    void Start()
    {
        

        inventory = new Inventory();

        for (int i = 0; i < 8; i++)
        {
            playerInvData[i] = new myClass();
            playerInvData[i].isEmpty = true;
           

            Debug.Log(playerInvData[i]);
            Debug.Log(playerInvData[i].isEmpty);
        }

        for (int i = 0; i < 3; i++)
        {
            playerBasicInvData[i] = new myClass();
            playerBasicInvData[i].isEmpty = true;


            Debug.Log(playerBasicInvData[i]);
            Debug.Log(playerBasicInvData[i].isEmpty);
        }



        Debug.Log(playerInvData);
        Debug.Log(JsonUtility.ToJson(playerInvData));
        Debug.Log(playerInvData.Length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
