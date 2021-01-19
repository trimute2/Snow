using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Obstacles : MonoBehaviour
{
    public float speed = 5f;
    public GameObject obstacles;
    private Transform offset;
    float nowpos;

	public int SnowDamage = -1;

	private Collider2D Collider;
    // Start is called before the first frame update
    void Start()
    {
		Collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        obstacles.transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		SnowBallScript SnowBall = collision.GetComponent<SnowBallScript>();
		if(SnowBall != null)
		{
			Collider.enabled = false;
			SnowBall.IncreaseSize(SnowDamage);
		}

	}
}
