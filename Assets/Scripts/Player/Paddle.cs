using UnityEngine;

public class Paddle : MonoBehaviour
{
	[SerializeField] private float maxSpeed = 1;
	[SerializeField] private float accelerationRate = 1;

	private float currentSpeed;

	[SerializeField] private float maxX = 10;
	[SerializeField] private float minX = 0;

	[SerializeField] private PlayerBall playerBall;

	[SerializeField] private Transform ballStartTransform;
	public Transform GetBallStartTransform() => ballStartTransform;

	private int lives;

	private void Update()
	{
		Vector3 position = transform.position;
		float input = Input.GetAxis("Horizontal");


		position.x += input * accelerationRate * Time.deltaTime;


		//currentSpeed = Mathf.Clamp(currentSpeed, -maxSpeed, maxSpeed);

		//position.x += currentSpeed * Time.deltaTime;

		position.x = Mathf.Clamp(position.x, minX, maxX);

		transform.position = position;


		if (Input.GetButtonDown("Jump"))
		{
			playerBall.FireBall();
		}
	}

}
