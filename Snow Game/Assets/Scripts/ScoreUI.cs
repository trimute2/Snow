using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ScoreUI : MonoBehaviour
{
	public bool ResetScoreOnLoad = false;
	private Text textComponent;
    // Start is called before the first frame update
    void Start()
    {
		textComponent = GetComponent<Text>();
		if (ResetScoreOnLoad)
		{
			ScoreManager.Instance.SetScore(0);
		}
		SetScoreUI(ScoreManager.Instance.GetScore());
		ScoreManager.Instance.OnUpdateScore += SetScoreUI;
    }

	public void SetScoreUI(int score)
	{
		textComponent.text = "SCORE : " + score;
	}

	public void OnDestroy()
	{
		if (ScoreManager.InstanceExists)
		{
			ScoreManager.Instance.OnUpdateScore -= SetScoreUI;
		}
	}
}
