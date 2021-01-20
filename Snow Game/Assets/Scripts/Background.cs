using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f;
    public GameObject obstacles;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        obstacles.transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);
    }
}
