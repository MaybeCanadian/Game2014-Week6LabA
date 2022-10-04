using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float HorizontalSpeed = 2.0f;
    public float VerticalSpeed = 2.0f;

    public float LerpSpeed = 10.0f;

    public Vector2 startPosition = new Vector2(0.0f, -4.5f);

    private Camera mainCamera;

    public Boundry bounds;

    private void Start()
    {
        mainCamera = Camera.main;
        transform.position = startPosition;
    }
    void Update()
    {
        //ConventionalInput();
        MobileInput();
        Move();
        ClampInBounds();

    }

    private void MobileInput()
    {
        foreach(var touch in Input.touches)
        {
            transform.position = Vector2.Lerp(transform.position, mainCamera.ScreenToWorldPoint(touch.position), Time.deltaTime * LerpSpeed);
        }
    }

    private void ConventionalInput()
    {
        float x = Input.GetAxisRaw("Horizontal") * HorizontalSpeed;
        float y = Input.GetAxisRaw("Vertical") * VerticalSpeed;

        transform.position += new Vector3(x, y, 0) * Time.deltaTime;
    }

    private void Move()
    {
        
    }

    private void ClampInBounds()
    {
        float clampedX = Mathf.Clamp(transform.position.x, bounds.XMin, bounds.XMax);
        float clampedY = Mathf.Clamp(transform.position.y, bounds.YMin, bounds.YMax);

        transform.position = new Vector3(clampedX, clampedY, 0);
    }
}
