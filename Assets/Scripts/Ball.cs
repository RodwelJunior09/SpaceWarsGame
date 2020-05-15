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
    [SerializeField] AudioClip[] audioSources;
    [SerializeField] float randomFactor = 0.7f;

    //State
    Vector2 paddleToBall;

    //Cache the component
    AudioSource myAudioSource;
    Rigidbody2D myrigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBall = transform.position - paddle.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myrigidbody2D = GetComponent<Rigidbody2D>();
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
            myrigidbody2D.velocity = new Vector2(launchX, launchY);
        }    
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddleToBall + paddlePos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(Random.Range(0f, randomFactor), Random.Range(0f, randomFactor));
        if (hasStarted)
        {
            AudioClip clip = audioSources[Random.Range(0, audioSources.Length)];
            myAudioSource.PlayOneShot(clip);
            myrigidbody2D.velocity += velocityTweak;
        }
    }
}
