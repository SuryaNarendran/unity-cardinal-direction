using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static event System.Action<CardinalDirection2D> directionPress;


    private void Update()
    {

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            directionPress?.Invoke(CardinalDirection2D.right);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            directionPress?.Invoke(CardinalDirection2D.left);
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            directionPress?.Invoke(CardinalDirection2D.down);
        }
        else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            directionPress?.Invoke(CardinalDirection2D.up);
        }
    }
}
