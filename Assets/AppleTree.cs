using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]
    // Prefab for instantiating apples
    public GameObject applePrefab;
    // Speed at which the AppleTree moves left and right
    public float speed = 1f;
    // Distance where AppleTree turns around
    public float leftAndRightEdge = 10f;
    // Chance that the AppleTree will change directions
    public float changeDirChance = 0.1f;
    // Seconds between Apple instantiations
    public float appleDropDelay = 1f;

    void Start()
    {
        // Start dropping apples
        Invoke( "DropApple", 2f );
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>( applePrefab );
        apple.transform.position = transform.position;
        Invoke( "DropApple", appleDropDelay );
    }

    void Update()
    {
        // Basic Movement
        transform.Translate( speed * Time.deltaTime, 0, 0 );

        // Changing Direction at edges
        if ( transform.position.x < -leftAndRightEdge )
        {
            speed = Mathf.Abs( speed ); // Move right
        }
        else if ( transform.position.x > leftAndRightEdge )
        {
            speed = -Mathf.Abs( speed ); // Move left
        }
    }

    void FixedUpdate()
    {
        // Random chance to change direction
        if ( Random.value < changeDirChance )
        {
            speed *= -1; // Change Direction
        }
    }
}