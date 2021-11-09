using Mirror;
using TMPro;
using UnityEngine;

public class GameManager : NetworkManager
{
	[SerializeField] private Transform topSpawn;
	[SerializeField] private Transform bottomSpawn;

	// for singleton
	private static GameManager gameManager;
	public static GameManager GetGameManager => gameManager;

	[Header("Game Manager Things")]
	[SerializeField] private TextMeshProUGUI scoreText;

	[SyncVar]
	private static int score = 0;

	[SerializeField] private PlayerBall playerBall;
	public PlayerBall PlayerBall => playerBall;

	private static Paddle playerOne;
	public Paddle PlayerOne => playerOne;

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

    public static bool SetPlayerOne(Paddle paddle)
    {
	    if (playerOne)
	    {
		    return false;
	    }
	    playerOne = paddle;
	    GetGameManager.playerBall.ResetBall(paddle);


	    return true;
    }
}
