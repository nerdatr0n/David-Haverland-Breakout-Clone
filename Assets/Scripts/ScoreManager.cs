using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class ScoreManager : NetworkBehaviour
{
	private void Awake()
	{
		Instance = this;
	}

	public static ScoreManager Instance;

	[SyncVar]
	public int score = 0;
}
