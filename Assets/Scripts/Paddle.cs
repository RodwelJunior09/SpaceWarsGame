using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // Configuration Variables
    [SerializeField] float screenWidthUnits = 16;
    [SerializeField] float minScreenSize;
    [SerializeField] float maxScreenSize;

    // Update is called once per frame
    void Update()
    {
        var xMouse = Input.mousePosition.x / Screen.width * screenWidthUnits;
        Vector2 movement = new Vector2(transform.position.x, transform.position.y);
        movement.x = Mathf.Clamp(xMouse, minScreenSize, maxScreenSize);
        transform.position = movement;
    }
}
