using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum BulletDirection 
{
    up, right, down, left
}

public class BulletBehaviour : MonoBehaviour
{

    public BulletDirection direction;
    public float speed;

    public Boundry bounds;
    public Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        switch(direction)
        {
            case BulletDirection.up:
                velocity = Vector3.up * speed * Time.deltaTime;
                break;
            case BulletDirection.right:
                velocity = Vector3.right * speed * Time.deltaTime;
                break;
            case BulletDirection.down:
                velocity = Vector3.down * speed * Time.deltaTime;
                break;
            case BulletDirection.left:
                velocity = Vector3.left * speed * Time.deltaTime;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
    }

    private void Move()
    {
        transform.position += velocity;
    }

    private void CheckBounds()
    {
        if (transform.position.x > bounds.XMax || transform.position.x < bounds.XMin ||
            transform.position.y > bounds.YMax || transform.position.y < bounds.YMin)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
