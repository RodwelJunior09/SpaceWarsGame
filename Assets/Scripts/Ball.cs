using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Config Params
    [SerializeField] Paddle paddle;
    bool hasStarted = false;
    [SerializeField] float launchX;
    [SerializeField] float launchY;

    //State
    Vector2 paddleToBall;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBall = transform.position - paddle.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
        }
        LaunchBall();
    }

    private void LaunchBall() 
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(launchX, launchY);
        }    
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddleToBall + paddlePos;
    }
}
