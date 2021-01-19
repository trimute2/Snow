using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBallScript : MonoBehaviour
{

	public int StartSize;
	public int MinimumSize;
	public int MaximumSize;

	public int SizeGrowIncrement;

	public float SizeScaleIncrement;

	public float GrowTime;

	private float InitialScale;

	private int CurrentSize;
	private float GrowClock;

    // Start is called before the first frame update
    void Start()
    {
		InitialScale = transform.localScale.x;
		CurrentSize = StartSize;
		GrowClock = 0;
    }

    // Update is called once per frame
    void Update()
    {
		if(CurrentSize < MaximumSize)
		{
			GrowClock += Time.deltaTime;
			if(GrowClock >= GrowTime)
			{
				SetSize((int)Mathf.Min(CurrentSize + SizeGrowIncrement, MaximumSize));
			}
		}
    }

	public void SetSize(int newSize)
	{
		if(newSize < MinimumSize)
		{
			//end game
			return;
		}
		GrowClock = 0;
		CurrentSize = newSize;
		float calcSize = newSize - StartSize;
		if(calcSize > 0)
		{
			calcSize = 1 + calcSize * SizeScaleIncrement;
		}
		else
		{
			calcSize = 1 /(SizeScaleIncrement * (Mathf.Abs(calcSize) + (1 / SizeScaleIncrement)));
		}
		float newScale = calcSize * InitialScale;
		transform.localScale = Vector3.one * newScale;
	}
}
