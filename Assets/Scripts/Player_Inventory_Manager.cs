using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Inventory_Manager : MonoBehaviour
{

    public int woodInv;
    public int stoneInv;

    public GameObject Inventory;

    public Image Inv_Basic_Slot1;
    public Image Inv_Basic_Slot2;
    public Image Inv_Basic_Slot3;

    private Inventory inventory;

    public List<GameObject> slots = new List<GameObject>();


    public float Inv_Basic_Slot_Selected = 0;



    // Start is called before the first frame update
    void Start()
    {
        woodInv = 0;
        stoneInv = 0;
        Inventory.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetKeyDown(KeyCode.Tab)) {
                Inventory.SetActive(!Inventory.activeSelf);
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
             {
            Debug.Log("Tecla 1");
            Inv_Basic_Slot1.GetComponent<Image>().color = Color.yellow;
            Inv_Basic_Slot2.GetComponent<Image>().color = Color.white;
            Inv_Basic_Slot3.GetComponent<Image>().color = Color.white;

            Inv_Basic_Slot_Selected = 1;


        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("Tecla 1");
            Inv_Basic_Slot1.GetComponent<Image>().color = Color.white;
            Inv_Basic_Slot2.GetComponent<Image>().color = Color.yellow;
            Inv_Basic_Slot3.GetComponent<Image>().color = Color.white;

            Inv_Basic_Slot_Selected = 2;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("Tecla 1");
            Inv_Basic_Slot1.GetComponent<Image>().color = Color.white;
            Inv_Basic_Slot2.GetComponent<Image>().color = Color.white;
            Inv_Basic_Slot3.GetComponent<Image>().color = Color.yellow;

            Inv_Basic_Slot_Selected = 3;
        }







    }


    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
    }










}
