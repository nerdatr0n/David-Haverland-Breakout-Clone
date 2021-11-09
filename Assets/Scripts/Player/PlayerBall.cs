using UnityEngine;
using Random = UnityEngine.Random;


public class PlayerBall : MonoBehaviour
{
	private bool isOnPaddle = true;

	[SerializeField] private float speed = 10;
	//private Rigidbody rigidbody;

	[SerializeField] private Paddle paddle;

	private Vector3 velocity;
	private void OnCollisionEnter(Collision other)
	{
		// Has died
		if (other.gameObject.CompareTag("KillPlayer"))
		{
			ResetBall(paddle);
			return;
		}

		// If It hits a box
		Box box = other.gameObject.GetComponent<Box>();
		if (box != null)
		{
			box.BreakBox();
		}


		Debug.DrawLine(transform.position,  transform.position + velocity, Color.red, 3);
		Debug.DrawLine(transform.position,  transform.position + other.contacts[0].normal, Color.green, 3);
		velocity = Vector3.Reflect(velocity, other.contacts[0].normal) * speed;
		Debug.DrawLine(transform.position,  transform.position + velocity, Color.blue, 3);
	}

	private void Awake()
	{
		//rigidbody = GetComponent<Rigidbody>();
		ResetBall(paddle);
	}

	public void FireBall()
	{
		if (!isOnPaddle)
		{
			return;
		}

		transform.parent = null;

		isOnPaddle = false;

		Vector3 launchDirection = new Vector3(Random.Range(-1f, 1f), 1, 0);

		launchDirection = launchDirection.normalized * speed;
		velocity = launchDirection;
	}

	public void ResetBall(Paddle paddle)
	{
		transform.parent = paddle.GetBallStartTransform();
		transform.localPosition = Vector3.zero;

		isOnPaddle = true;

		velocity = Vector3.zero;
	}


	private void Update()
	{
		transform.position += velocity.normalized * speed * Time.deltaTime;
	}
}
