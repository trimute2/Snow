using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public float speed;

    public Transform MovePosition;

    private Rigidbody Rig;
    private float horizontal;

    // Start is called before the first frame update
    void Start()
    {
        Rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        Rig.velocity = new Vector3(speed * horizontal, Rig.velocity.y, Rig.velocity.z);
    }
}
