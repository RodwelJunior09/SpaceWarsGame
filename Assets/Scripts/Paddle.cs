using UnityEngine;

public class Paddle : MonoBehaviour
{
    // Configuration Variables
    [SerializeField] float screenWidthUnits = 16;
    [SerializeField] float minScreenSize;
    [SerializeField] float maxScreenSize;

    //Cache variables
    Ball ball;
    GameStatus gameStatus;

    private void Start()
    {
        ball = FindObjectOfType<Ball>();
        gameStatus = FindObjectOfType<GameStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = new Vector2(transform.position.x, transform.position.y);
        movement.x = Mathf.Clamp(GetXpos(), minScreenSize, maxScreenSize);
        transform.position = movement;
    }

    private float GetXpos()
    {
        if (gameStatus.isAutoPlayedEnabled())
        {
            return ball.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthUnits;
        }
    }
}
