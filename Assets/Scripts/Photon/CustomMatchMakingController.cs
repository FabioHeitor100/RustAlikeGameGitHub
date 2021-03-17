using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;


public class CustomMatchMakingController : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject lobbyConnectButton;
    [SerializeField]
    private GameObject LobbyPanel;
    [SerializeField]
    private GameObject mainPanel;
    [SerializeField]
    private InputField PlayerNameInput;


    private string Room_Name;
    private int Room_Size;

    private List<RoomInfo> roomListings;

    [SerializeField]
    private Transform roomsContainer;
    [SerializeField]
    private GameObject roomListingPrefab;


    public override void OnConnectedToMaster()
    {
        Debug.Log("OnConnectedToMaster() was called by PUN.");
        PhotonNetwork.AutomaticallySyncScene = true;
        lobbyConnectButton.SetActive(true);
        roomListings = new List<RoomInfo>();
        if (PlayerPrefs.HasKey("NickName"))
        { 
            if(PlayerPrefs.GetString("NickName") == "")
          {
                PhotonNetwork.NickName = "Player" + Random.Range(0, 1000);
          } else
            {
                PhotonNetwork.NickName = PlayerPrefs.GetString("NickName");
            }

        } else
        {
            PhotonNetwork.NickName = "Player" + Random.Range(0, 1000);
        }
        PlayerNameInput.text = PhotonNetwork.NickName;
       
    }


    public void PlayerNameUpdate(string nameInput)
    {
        PhotonNetwork.NickName = nameInput;
        PlayerPrefs.SetString("NickName", nameInput);
        PlayerNameInput.text = nameInput;
    }

    public void JoinLobbyOnClick()
    {
        Debug.Log("JOIN LOBBY CLICKED");
        mainPanel.SetActive(false);
        LobbyPanel.SetActive(true);
        PhotonNetwork.JoinLobby();
    }


    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        int tempIndex;
        foreach(RoomInfo room in roomList)
        {
            if(roomListings != null)
            {
                tempIndex = roomListings.FindIndex(ByName(room.Name));
            } else
            {
                tempIndex = -1;
            }

            if(tempIndex != -1)
            {
                roomListings.RemoveAt(tempIndex);
                Destroy(roomsContainer.GetChild(tempIndex).gameObject);
            }

            if(room.PlayerCount > 0)
            {
                roomListings.Add(room);
                ListRoom(room);
            }
        }

        base.OnRoomListUpdate(roomList);
    }

    static System.Predicate<RoomInfo> ByName(string name)
    {
        return delegate (RoomInfo room)
        {
            return room.Name == name;
        };
    }

    void ListRoom(RoomInfo room)
    {
        if(room.IsOpen && room.IsVisible)
        {
            GameObject tempListing = Instantiate(roomListingPrefab, roomsContainer);
            RoomButton tempButton = tempListing.GetComponent<RoomButton>();
            tempButton.SetRoom(room.Name, room.MaxPlayers, room.PlayerCount);
        }
    }

    public void OnRoomNameChanged(string nameIn)
    {
        Room_Name = nameIn;
    }

    public void OnRoomSizeChanged(string sizeIn)
    {
        Room_Size = int.Parse(sizeIn);
    }

    public void CreateRoom()
    {
        Debug.Log("CREATING ROOM");
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = (byte)Room_Size };
        PhotonNetwork.CreateRoom(Room_Name, roomOps);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("ROOM CREATED FAILED");
    }

    public void MatchmakingCancel()
    {
        mainPanel.SetActive(true);
        LobbyPanel.SetActive(false);
        PhotonNetwork.LeaveLobby();
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
