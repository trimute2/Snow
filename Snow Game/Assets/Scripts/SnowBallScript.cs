using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnowBallScript : MonoBehaviour
{

	public int StartSize;
	public int MinimumSize;
	public int MaximumSize;

	public int SizeGrowIncrement;

	public float StartScoreVal = 0.05f;
	public float ScoreScalVal = 0.9f;

	public float SizeScaleIncrement;

	public float GrowTime;

	private float InitialScale;

	public int CurrentSize
	{
		get
		{
			return _currentSize;
		}
	}

	private int _currentSize;
	private float GrowClock;
	private float CurrentScoreVal;
	private float ScoreHandle;

	private SpriteRenderer spriteRenderer;
	private float redTime;

    // Start is called before the first frame update
    void Start()
    {
		InitialScale = transform.localScale.x;
		_currentSize = StartSize;
		GrowClock = 0;
		CurrentScoreVal = StartScoreVal;
		ScoreHandle = 0;
		spriteRenderer = GetComponent<SpriteRenderer>();
		redTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
		if(_currentSize < MaximumSize)
		{
			GrowClock += Time.deltaTime;
			if(GrowClock >= GrowTime)
			{
				//SetSize((int)Mathf.Min(_currentSize + SizeGrowIncrement, MaximumSize));
				IncreaseSize(SizeGrowIncrement);
			}
		}
		ScoreHandle += CurrentScoreVal;
		if (ScoreHandle > 0)
		{
			ScoreManager.Instance.IncrementScore(Mathf.FloorToInt(ScoreHandle));
			ScoreHandle -= Mathf.FloorToInt(ScoreHandle);
		}

		if(redTime > 0)
		{
			redTime -= Time.deltaTime;
			if(redTime <= 0)
			{
				spriteRenderer.color = Color.white;
				redTime = 0;
			}
		}
    }

	private void SetSize(int newSize)
	{
		if(newSize < MinimumSize)
		{
			SceneManager.LoadScene("ScoreScreen");
			return;
		}
		GrowClock = 0;
		_currentSize = newSize;
		float calcSize = newSize - StartSize;
		float calcScore = StartScoreVal + calcSize;
		if(calcSize > 0)
		{
			calcSize = 1 + calcSize * SizeScaleIncrement;
			calcScore = 1 + calcScore * ScoreScalVal;
		}
		else
		{
			calcSize = 1 /(SizeScaleIncrement * (Mathf.Abs(calcSize) + (1 / SizeScaleIncrement)));
			calcScore = 1 / (ScoreScalVal * (Mathf.Abs(calcScore) + (1 / ScoreScalVal)));
		}
		float newScale = calcSize * InitialScale;
		int CurrentScore = Mathf.RoundToInt(calcScore * StartScoreVal);
		transform.localScale = Vector3.one * newScale;
	}

	public void IncreaseSize(int ChangeInSize, bool IgnoreMax = false)
	{

		if(ChangeInSize < 0 && spriteRenderer != null)
		{
			spriteRenderer.color = Color.red;
			redTime = 0.5f;
		}

		int newSize = _currentSize + ChangeInSize;
		if (!IgnoreMax)
		{
			newSize = Mathf.Min(newSize, MaximumSize);
		}

		SetSize(newSize);
	}
}
