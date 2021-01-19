using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
	public delegate void UpdateScoreHandler(int score);

	public event UpdateScoreHandler OnUpdateScore;

	private int score;

	public static ScoreManager Instance
	{
		get
		{
			if(_instance != null)
			{
				return _instance;
			}
			GameObject obj = new GameObject("Score Manager");
			_instance = obj.AddComponent<ScoreManager>();
			return _instance;
		}
	}

	public static bool InstanceExists
	{
		get
		{
			return (_instance != null);
		}
	}
	private static ScoreManager _instance;

    // Start is called before the first frame update
    void Start()
    {
        if(_instance != this || _instance != null)
		{
			_instance = this;
		}
		else
		{
			Destroy(this);
			return;
		}
		DontDestroyOnLoad(this);
		score = 0;
    }

	public void IncrementScore(int IncrementValue)
	{
		score += IncrementValue;
		OnUpdateScore?.Invoke(score);
	}

	public void SetScore(int newScore)
	{
		score = newScore;
		OnUpdateScore?.Invoke(score);
	}

	public int GetScore()
	{
		return score;
	}
}
