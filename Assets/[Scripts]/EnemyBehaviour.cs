using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public Boundry bounds;
    public Vector2 HorizontalSpeedBounds = new Vector2(2.0f, 6.0f);

    private float HorizontalSpeed;

    // Start is called before the first frame update
    void Start()
    {
        float randomXPosition = Random.Range(bounds.XMin, bounds.XMax);
        float randomYPosition = Random.Range(bounds.YMin, bounds.YMax);

        HorizontalSpeed = Random.Range(HorizontalSpeedBounds.x, HorizontalSpeedBounds.y);

        transform.position = new Vector3(randomXPosition, randomYPosition, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        var HorizontalLength = bounds.XMax - bounds.XMin;
        transform.position = new Vector3(Mathf.PingPong(Time.time * HorizontalSpeed, HorizontalLength) - bounds.XMax,
            transform.position.y, transform.position.z);
    }
}
