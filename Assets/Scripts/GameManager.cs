using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	// for singleton
	private static GameManager gameManager;

	[SerializeField] private TextMeshProUGUI scoreText;

	private static int score = 0;

    private void Awake()
    {
	    // sets the singleton
	    if (gameManager == null)
	    {
			gameManager = this;
	    }
	    else
	    {
		    Debug.LogError("There are two game managers and there shouldn't be");
	    }
    }

    private void Update()
    {
	    UpdateScoreText();
    }

    private void UpdateScoreText()
    {
	    scoreText.text = score.ToString();
    }


    public static void ResetScore()
    {
	    score = 0;
    }

    public static void AddScore(int scoreToAdd)
    {
	    score += scoreToAdd;
    }

}
