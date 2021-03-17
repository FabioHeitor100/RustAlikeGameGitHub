using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Inventory_UI_Manager : MonoBehaviour, IPointerDownHandler, IPointerClickHandler
{
    // Start is called before the first frame update

    public GameObject Player;

    public Sprite SpearImage;
    public Sprite BowImage;
    public Sprite ArrowImage;

    public Button spear_Inv_Button;
    public Button bow_Inv_Button;
    public Button arrow_Inv_Button;

    public Player_Inventory_Manager Player_Inventory_Manager;

    public UI_Manager UI_Manager;

    public Player_Inventory_Data player_Inventory_Data;

    public Item_Data_Manager item_Data_Manager;

    private Sprite spriteMemory;
    private int itemIDmemory;
    private int itemAmoutMemory;
    private bool itemEmptMemory;



    public GameObject Spear_Item;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if(Player_Inventory_Manager.woodInv > 2 && Player_Inventory_Manager.stoneInv > 1)
        {
            spear_Inv_Button.GetComponent<Button>().interactable = true;
        }
        else
        {
            spear_Inv_Button.GetComponent<Button>().interactable = false;
        }


        if (Player_Inventory_Manager.woodInv > 9 )
        {
            bow_Inv_Button.GetComponent<Button>().interactable = true;
        }
        else
        {
            bow_Inv_Button.GetComponent<Button>().interactable = false;
        }


        if (Player_Inventory_Manager.woodInv > 0 && Player_Inventory_Manager.stoneInv > 0)
        {
            arrow_Inv_Button.GetComponent<Button>().interactable = true;
        }
        else
        {
            arrow_Inv_Button.GetComponent<Button>().interactable = false;
        }



        if (Input.GetMouseButtonDown(0))
        {


           // Debug.Log("CLICKING");
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
             //RaycastHit hit;
              //  if(Physics.Raycast(ray,out hit))
                // {

                //Debug.Log("CLICKING ON OBJECT");
                //Debug.Log(hit.transform.name);
                //}
        }
       






    }

    public void createSpear()
    {


        spawnSpear();
        for (int i = 0; i < 10; i++)
        {
           if(player_Inventory_Data.playerInvData[i].isEmpty == true)
            {

                Player_Inventory_Manager.woodInv = Player_Inventory_Manager.woodInv - 3;
                Player_Inventory_Manager.stoneInv = Player_Inventory_Manager.stoneInv - 1;


                UI_Manager.woodText.GetComponent<UnityEngine.UI.Text>().text = Player_Inventory_Manager.woodInv.ToString();
                UI_Manager.stoneText.GetComponent<UnityEngine.UI.Text>().text = Player_Inventory_Manager.stoneInv.ToString();

                
                Debug.Log("Slot" + i);

                player_Inventory_Data.playerInvData[i].isEmpty = false;
                player_Inventory_Data.playerInvData[i].itemID = 1;


                Player_Inventory_Manager.slots[i].GetComponent<Image>().sprite = item_Data_Manager.spearSprite;



                // colocar aqui uma função que adiciona um item ao inventario no slot escolhido








                Debug.Log("SLOT VAZIO!! COLOCAR ITEM! ");
                return;
            } else
            {
                Debug.Log("SLOT COMPLETO!! VER OUTRO SLOT ");
            }
            
        }


        Debug.Log("INVENTORY CHEIO!!!! ");




    }



    public void createBow()
    {
        for (int i = 0; i < 10; i++)
        {
            if (player_Inventory_Data.playerInvData[i].isEmpty == true)
            {
                Player_Inventory_Manager.woodInv = Player_Inventory_Manager.woodInv - 10;



                UI_Manager.woodText.GetComponent<UnityEngine.UI.Text>().text = Player_Inventory_Manager.woodInv.ToString();

                Debug.Log("CRiAR BOW");

                player_Inventory_Data.playerInvData[i].isEmpty = false;
                player_Inventory_Data.playerInvData[i].itemID = 2;

                Player_Inventory_Manager.slots[i].GetComponent<Image>().sprite = item_Data_Manager.bowSprite;












                Debug.Log("SLOT VAZIO!! COLOCAR ITEM! ");
                return;
            }
            else
            {
                Debug.Log("SLOT COMPLETO!! VER OUTRO SLOT ");
            }

        }


        Debug.Log("INVENTORY CHEIO!!!! ");



        
       

        Debug.Log("CRiAR Bow");

    }



    public void createArrow()
    {
        for (int i = 0; i < 10; i++)
        {
            if (player_Inventory_Data.playerInvData[i].isEmpty == true)
            {
                Player_Inventory_Manager.woodInv = Player_Inventory_Manager.woodInv - 1;
                Player_Inventory_Manager.stoneInv = Player_Inventory_Manager.stoneInv - 1;


                UI_Manager.woodText.GetComponent<UnityEngine.UI.Text>().text = Player_Inventory_Manager.woodInv.ToString();
                UI_Manager.stoneText.GetComponent<UnityEngine.UI.Text>().text = Player_Inventory_Manager.stoneInv.ToString();

                Debug.Log("CRiAR ARROW");

                player_Inventory_Data.playerInvData[i].isEmpty = false;
                player_Inventory_Data.playerInvData[i].itemID = 3;



                Player_Inventory_Manager.slots[i].GetComponent<Image>().sprite = item_Data_Manager.arrowSprite;














                Debug.Log("SLOT VAZIO!! COLOCAR ITEM! ");
                return;
            }
            else
            {
                Debug.Log("SLOT COMPLETO!! VER OUTRO SLOT ");
            }

        }


        Debug.Log("INVENTORY CHEIO!!!! ");






        Debug.Log("CRiAR Bow");
        

        Debug.Log("CREAR Arrow");

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(eventData); 
        Debug.Log("PRESSIONAR PARA BAIXIO");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("A CLICKAR!!!!!!!!!");
        Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);
        Debug.Log(eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>());
        Debug.Log(eventData);
        Debug.Log(name + " Game Object Clicked!");

        


        if (eventData.pointerCurrentRaycast.gameObject.name == "Slot1_Image")
        {
            Debug.Log("A CLICAR NO SLOT 1 !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Debug.Log(Player_Inventory_Manager.Inv_Basic_Slot1.GetComponent<Image>().sprite);


            

            if(player_Inventory_Data.playerInvData[0].isEmpty == true)
            {
                Debug.Log("ESTA VAZIO E NAO FAZ NADA");
                return;
            }

            Debug.Log("Continuar depois do vazio");

            if (Player_Inventory_Manager.Inv_Basic_Slot_Selected == 1)
            {

                Debug.Log("1 SELECIONADO");

                spriteMemory = eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>().sprite;

                Debug.Log("VER A SPRITE MEMORY");
                Debug.Log(spriteMemory);

              // eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>().sprite = ArrowImage;



                Debug.Log("VER A ARROR IMAGE");
                Debug.Log(ArrowImage);

                Debug.Log("VER A IMAGEM DO INV SLOT 1");
                Debug.Log(eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>().sprite);


                Debug.Log("VER O NOME DO OBJECTO QUE ESTOU A CLICAR");
                Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);
                Debug.Log(eventData.pointerCurrentRaycast.gameObject);
                eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>().sprite = Player_Inventory_Manager.Inv_Basic_Slot1.GetComponentInChildren<Image>().sprite;



                Player_Inventory_Manager.Inv_Basic_Slot1.GetComponentInChildren<Image>().sprite = spriteMemory;

                

                itemIDmemory = player_Inventory_Data.playerBasicInvData[0].itemID;


                 player_Inventory_Data.playerBasicInvData[0].itemID = player_Inventory_Data.playerInvData[0].itemID;
                player_Inventory_Data.playerInvData[0].itemID = itemIDmemory;

                Debug.Log("IS EMPTY NO BASIC SLOT 1");
                Debug.Log(player_Inventory_Data.playerBasicInvData[0].isEmpty);

                itemEmptMemory = player_Inventory_Data.playerBasicInvData[0].isEmpty;
                player_Inventory_Data.playerBasicInvData[0].isEmpty = player_Inventory_Data.playerInvData[0].isEmpty;
                player_Inventory_Data.playerInvData[0].isEmpty = itemEmptMemory;








            }
            if (Player_Inventory_Manager.Inv_Basic_Slot_Selected == 2)
            {
                Player_Inventory_Manager.Inv_Basic_Slot2.GetComponent<Image>().sprite = spriteMemory;
            }
            if (Player_Inventory_Manager.Inv_Basic_Slot_Selected == 3)
            {
                Player_Inventory_Manager.Inv_Basic_Slot3.GetComponent<Image>().sprite = spriteMemory;
            }



           // eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>().sprite = Player_Inventory_Manager.Inv_Basic_Slot1.GetComponent<Image>().sprite;





            


        }
        if (eventData.pointerCurrentRaycast.gameObject.name == "Slot2_Image")
        {
            Debug.Log("A CLICAR NO SLOT 1 !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        }
        if (eventData.pointerCurrentRaycast.gameObject.name == "Slot3_Image")
        {
            Debug.Log("A CLICAR NO SLOT 1 !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        }
        if (eventData.pointerCurrentRaycast.gameObject.name == "Slot4_Image")
        {
            Debug.Log("A CLICAR NO SLOT 1 !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        }
        if (eventData.pointerCurrentRaycast.gameObject.name == "Slot5_Image")
        {
            Debug.Log("A CLICAR NO SLOT 1 !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        }
        if (eventData.pointerCurrentRaycast.gameObject.name == "Slot6_Image")
        {
            Debug.Log("A CLICAR NO SLOT 1 !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        }
        if (eventData.pointerCurrentRaycast.gameObject.name == "Slot7_Image")
        {
            Debug.Log("A CLICAR NO SLOT 1 !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        }
        if (eventData.pointerCurrentRaycast.gameObject.name == "Slot8_Image")
        {
            Debug.Log("A CLICAR NO SLOT 1 !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        }


    }


    public void checkIfSlotEmpty()
    {

    }

    public void spawnSpear()
    {
        var spear = Instantiate(Spear_Item, Player.transform.position, Player.transform.rotation);
        spear.transform.parent = Player.transform;
    }
}

    
       






