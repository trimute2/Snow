using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f;
    private Vector2 offset;
    float nowpos;
    void Start()
    {
        offset = new Vector2(0, 0);
        GetComponent<Renderer>().material.SetTextureOffset("_MainTex", offset);
    }

    // Update is called once per frame
    void Update()
    {
        nowpos += speed * Time.deltaTime;
        offset = new Vector2(0f, nowpos);
        GetComponent<Renderer>().material.SetTextureOffset("_MainTex", offset);
    }
}
