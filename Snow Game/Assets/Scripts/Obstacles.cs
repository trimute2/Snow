using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public float speed = 5f;
    public GameObject obstacles;
    private Transform offset;
    float nowpos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        obstacles.transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);
    }
}
