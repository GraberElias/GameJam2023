using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float acc;
    public float maxSpeed;
    public Transform spawnPoint;
    private Rigidbody2D _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(_rigidbody.velocity.magnitude) < maxSpeed)
        {
            _rigidbody.AddForce(new Vector2(acc, 0));
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("endpoint"))
        {
            _rigidbody.position = new Vector2(spawnPoint.position.x, _rigidbody.position.y);
        }
    }

}
