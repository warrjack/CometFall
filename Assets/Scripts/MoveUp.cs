using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : MonoBehaviour
{
    public Rigidbody rigidbody;
    private float speed = 2.0f;
    private Vector2 direction = new Vector2(0, 1);

    // Update is called once per frame
    void Update()
    {
        rigidbody.velocity = direction * speed;
    }
}
