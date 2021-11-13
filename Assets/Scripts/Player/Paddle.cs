using Mirror;
using UnityEngine;

public class Paddle : NetworkBehaviour
{
	[SerializeField] private float maxSpeed = 0;
	[SerializeField] private float accelerationRate = 20;

	private float currentSpeed;

	[SerializeField] private float maxX = 20;
	[SerializeField] private float minX = 10;

	[SerializeField] private Transform ballStartTransform;
	public Transform GetBallStartTransform() => ballStartTransform;
	[SerializeField] private GameObject ball;

	private GameObject myBall;

	private int lives;

	private void Awake()
	{
		GameManager.SetPlayerOne(this);
	}

	private void Update()
	{
		if (!isLocalPlayer)
		{
			return;
		}

		Vector3 position = transform.position;
		float input = Input.GetAxis("Horizontal");

		position.x += input * accelerationRate * Time.deltaTime;
		position.x = Mathf.Clamp(position.x, minX, maxX);

		transform.position = position;

		if (Input.GetButtonDown("Jump") && ball == null)
		{
			SpawnBall(ballStartTransform.position);
		}
	}

	[Command]
	public void SpawnBall(Vector3 spawnPosition)
	{
		GameObject newBall = Instantiate(GameManager.GetGameManager.spawnPrefabs.Find(prefab => prefab.name == "Ball"), spawnPosition, Quaternion.identity);
		NetworkServer.Spawn(newBall);

		newBall.GetComponent<PlayerBall>().FireBall(spawnPosition);

		ball = newBall;
	}

}
