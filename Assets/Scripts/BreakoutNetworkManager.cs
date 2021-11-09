using Mirror;

public class BreakoutNetworkManager : NetworkManager
{
	// for singleton
	private static NetworkManager networkManager;
	public static NetworkManager GetNetworkManager => networkManager;



	// public override void OnStartServer()
	// {
	// 	base.OnStartServer();
	// }
	//
	// public override void OnStopServer()
	// {
	// 	base.OnStopServer();
	// }
}
