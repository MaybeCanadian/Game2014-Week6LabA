using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarBehaviour : MonoBehaviour
{

    public float ScrollSpeed = 1.0f;
    public Boundry bounds;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
    }

    private void Move()
    {
        transform.position -= new Vector3(0, ScrollSpeed, 0);
    }

    private void ResetStars()
    {
        transform.position = new Vector2(0, bounds.YMax);
    }

    private void CheckBounds()
    {
        if(transform.position.y < bounds.YMin)
        {
            ResetStars();
        }
    }
}
