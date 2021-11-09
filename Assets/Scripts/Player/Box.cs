using Mirror;
using UnityEngine;

public class Box : NetworkBehaviour
{
	[SerializeField] private int scoreToAdd = 100;
	[SerializeField] private ParticleSystem explosion;

	private bool hasBeenBroken = false;


	[ClientRpc]
	public void BreakBox()
	{
		if (hasBeenBroken)
		{
			return;
		}
		GameManager.AddScore(scoreToAdd);
		gameObject.SetActive(false);
		explosion.Play();

		hasBeenBroken = true;
	}
}
