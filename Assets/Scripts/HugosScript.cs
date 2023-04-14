using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HugosScript : MonoBehaviour
{

    [SerializeField]
    private float speed = 1;

    public Tilemap tilemap;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * speed);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("collision");
    }


}
