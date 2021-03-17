using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class RoomButton : MonoBehaviour
{
    [SerializeField]
    private Text nameText;

    [SerializeField]
    private Text sizetext;

    private string roomName;
    private int roomSize;
    private int playerCount;

    public void JoinRoomOnClick()
    {
        PhotonNetwork.JoinRoom(roomName);
    }

    public void SetRoom(string nameInput, int sizeInput, int countinput)
    {
        roomName = nameInput;
        roomSize = sizeInput;
        playerCount = countinput;
        nameText.text = nameInput;
        sizetext.text = countinput + "/" + sizeInput;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
