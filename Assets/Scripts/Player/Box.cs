using UnityEngine;

public class Box : MonoBehaviour
{
	[SerializeField] private int scoreToAdd = 100;
	[SerializeField] private ParticleSystem explosion;

	public void BreakBox()
	{
		GameManager.AddScore(scoreToAdd);
		gameObject.SetActive(false);
		explosion.Play();
	}
}
