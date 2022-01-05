using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;

public class SolarSystemNetworkManager : NetworkManager
{
    [SyncVar] private string _name;

    [Command]
    private void CmdSetName(string name)
    {
        _name = name;
    }

    private void SetPort()
    {
        base.networkPort = 7777;
    }

    private void SetIPAdress()
    {
        base.networkAddress = "localhost";
    }

    public void StartHosting()
    {
        SetPort();
        var text = GameObject.Find("NameInputField").GetComponent<TMP_InputField>().text;
        CmdSetName(text);
        base.StartHost();
    }

    public void JoinGame()
    {
        SetIPAdress();
        SetPort();
        var text = GameObject.Find("NameInputField").GetComponent<TMP_InputField>().text;
        CmdSetName(text);
        base.StartClient();
    }

    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
        var spawnTransform = GetStartPosition();

        var player = Instantiate(playerPrefab, spawnTransform.position, spawnTransform.rotation);
        
        player.GetComponent<ShipController>().RpcSetInput(_name);
        NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
    }

    private void OnLevelWasLoaded(int level)
    {
        if (level == 0)
        {
            SetupStartSceneButtons();
        }
        else
        {
            SetupMainSceneButtons();
        }
    }

    private void SetupMainSceneButtons()
    {
        GameObject.Find("DisconnectButton").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("DisconnectButton").GetComponent<Button>().onClick.AddListener(base.StopHost);
    }

    private void SetupStartSceneButtons()
    {
        GameObject.Find("StartHostButton").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("StartHostButton").GetComponent<Button>().onClick.AddListener(StartHosting);

        GameObject.Find("JoinGameButton").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("JoinGameButton").GetComponent<Button>().onClick.AddListener(JoinGame);

    }

}