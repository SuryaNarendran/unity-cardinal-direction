using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] float rotateSpeed;
    [SerializeField] public CardinalDirection2D myDirection;

    public bool isMoving { get; private set; }

    private void OnEnable()
    {
        InputManager.directionPress += Move;
    }

    private void OnDisable()
    {
        InputManager.directionPress -= Move;
    }

    public void Move(CardinalDirection2D direction)
    {
        if(!isMoving)
        {
            StartCoroutine(MoveRoutine(direction));
        }
    }

    private IEnumerator MoveRoutine(CardinalDirection2D direction)
    {
        isMoving = true;

        if(myDirection != direction)
        {

            float rotation = 0f;
            Quaternion startRotation = transform.localRotation;
            while (rotation < 1f)
            {
                rotation = Mathf.Clamp(rotation + rotateSpeed * Time.deltaTime, 0f, 1f);
                transform.rotation = Quaternion.Slerp(startRotation, direction.AsRotation, rotation);
                yield return null;
            }
            myDirection = direction;
        }

        float distance = 0f;
        Vector2 startPosition = transform.position;
        while(distance < 1f)
        {
            distance = Mathf.Clamp(distance + movementSpeed * Time.deltaTime, 0f, 1f);
            transform.position = Vector3.Lerp(startPosition, startPosition + direction, distance);
            yield return null;
        }

        isMoving = false;
        yield break;
    }
}
