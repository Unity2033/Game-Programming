using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField] Dropdown dropdown;
    [SerializeField] Canvas lobbyCanvas;

    private void Awake()
    {
        if (PhotonNetwork.IsConnected)
        {
            lobbyCanvas.gameObject.SetActive(false);
        }
    }

    public void Connect()
    {
        // ������ �����ϴ� �Լ�
        PhotonNetwork.ConnectUsingSettings();

        lobbyCanvas.gameObject.SetActive(false);
    }

    public override void OnConnectedToMaster()
    {
        // JoinLobby : Ư�� �κ� �����Ͽ� �����ϴ� �Լ�
        PhotonNetwork.JoinLobby
        (
           new TypedLobby
           (
               dropdown.options[dropdown.value].text,
               LobbyType.Default
           )
        );
    }
}