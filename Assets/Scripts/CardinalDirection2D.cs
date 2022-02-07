using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR

using UnityEditor;
#endif //UNITY_EDITOR

/// <summary>
/// A 2D vector representation that is limited to the four cardinal directions - up, down, left, right.
/// </summary>
[System.Serializable]
public struct CardinalDirection2D
{
    [System.Serializable]
    private enum CardinalDirection2DID { Up=0, Down=1, Right=2, Left=3 }

    [SerializeField] CardinalDirection2DID directionID;

    public static CardinalDirection2D up { get => new CardinalDirection2D(CardinalDirection2DID.Up); }
    public static CardinalDirection2D down { get => new CardinalDirection2D(CardinalDirection2DID.Down); }
    public static CardinalDirection2D left { get => new CardinalDirection2D(CardinalDirection2DID.Left); }
    public static CardinalDirection2D right { get => new CardinalDirection2D(CardinalDirection2DID.Right); }

    private CardinalDirection2D(CardinalDirection2DID id)
    {
        directionID = id;
    }

    #region math operator overloads

    public override bool Equals(System.Object obj)
    {
        if (obj == null || !GetType().Equals(obj.GetType()))
            return false;
        CardinalDirection2D casted = (CardinalDirection2D)obj;
        return directionID == casted.directionID;
    }

    public override int GetHashCode()
    {
        return (int)directionID;
    }

    public static bool operator == (CardinalDirection2D a, CardinalDirection2D b)
    {
        return a.Equals(b);
    }

    public static bool operator != (CardinalDirection2D a, CardinalDirection2D b)
    {
        return !(a == b);
    }

    public static Vector2Int operator + (CardinalDirection2D a, Vector2Int b)
    {
        return (Vector2Int)a + b;
    }

    public static Vector2Int operator +(Vector2Int a, CardinalDirection2D b)
    {
        return a + (Vector2Int)b;
    }

    public static Vector2Int operator - (CardinalDirection2D a, Vector2Int b)
    {
        return (Vector2Int)a - b;
    }

    public static Vector2Int operator -(Vector2Int a, CardinalDirection2D b)
    {
        return a - (Vector2Int)b;
    }

    public static Vector2Int operator * (CardinalDirection2D a, Vector2Int b)
    {
        return (Vector2Int)a * b;
    }

    public static Vector2Int operator *(Vector2Int a, CardinalDirection2D b)
    {
        return a * (Vector2Int)b;
    }

    public static Vector2 operator + (CardinalDirection2D a, Vector2 b)
    {
        return (Vector2)a + b;
    }

    public static Vector2 operator + (Vector2 a, CardinalDirection2D b)
    {
        return a + (Vector2)b;
    }

    public static Vector2 operator - (CardinalDirection2D a, Vector2 b)
    {
        return (Vector2)a - b;
    }

    public static Vector2 operator - (Vector2 a, CardinalDirection2D b)
    {
        return a - (Vector2)b;
    }

    public static Vector2 operator * (CardinalDirection2D a, Vector2 b)
    {
        return (Vector2)a * b;
    }

    public static Vector2 operator * (Vector2 a, CardinalDirection2D b)
    {
        return a * (Vector2)b;
    }

    public static Vector2 operator / (CardinalDirection2D a, Vector2 b)
    {
        return (Vector2)a / b;
    }

    public static Vector2 operator / (Vector2 a, CardinalDirection2D b)
    {
        return a / (Vector2)b;
    }

    public static Vector2 operator * (CardinalDirection2D a, float b)
    {
        return (Vector2)a * b;
    }

    public static Vector2Int operator * (CardinalDirection2D a, int b)
    {
        return (Vector2Int)a * b;
    }

    public static Vector2 operator / (CardinalDirection2D a, float b)
    {
        return (Vector2)a / b;
    }

    public static Vector3 operator +(CardinalDirection2D a, Vector3 b)
    {
        return (Vector3)a + b;
    }

    public static Vector3 operator +(Vector3 a, CardinalDirection2D b)
    {
        return a + (Vector3)b;
    }

    public static Vector3 operator -(CardinalDirection2D a, Vector3 b)
    {
        return (Vector3)a - b;
    }

    public static Vector3 operator -(Vector3 a, CardinalDirection2D b)
    {
        return a - (Vector3)b;
    }

    #endregion

    #region conversion operators
    public static implicit operator Vector2Int(CardinalDirection2D direction)
    {
        switch (direction.directionID)
        {
            case CardinalDirection2DID.Up:
                return Vector2Int.up;
            case CardinalDirection2DID.Right:
                return Vector2Int.right;
            case CardinalDirection2DID.Down:
                return Vector2Int.down;
            case CardinalDirection2DID.Left:
                return Vector2Int.left;
            default:
                throw new System.FormatException("CardinalDirection2D directionID is invalid.");
        }
    } 

    public static implicit operator CardinalDirection2D(Vector2 vector2)
    {
        if (vector2.x == 0 || vector2.y == 0)
        {
            Vector2Int vector = new Vector2Int((int)Mathf.Sign(vector2.x), (int)Mathf.Sign(vector2.y));

            if (vector == Vector2Int.up) return up;
            if (vector == Vector2Int.right) return right;
            if (vector == Vector2Int.down) return down;
            if (vector == Vector2Int.left) return left;
        }

        throw new System.FormatException("the given Vector2Int cannot be converted to a valid CardinalDirection!");
    }

    public static implicit operator CardinalDirection2D(Vector2Int vector2Int)
    {
        return vector2Int;
    }

    public static implicit operator Vector2(CardinalDirection2D direction)
    {
        return (Vector2Int)direction;
    }

    public static implicit operator Vector3(CardinalDirection2D direction)
    {
        return (Vector2)direction;
    }

    #endregion

    #region direction operations

    /// <summary>
    /// Returns the opposite-facing direction of the given direction.
    /// </summary>
    public CardinalDirection2D Opposite
    {
        get
        {
            return (Vector2Int)this * -1;
        }
    }

    /// <summary>
    /// Returns the direction 90 degress clockwise of the given direction.
    /// </summary>
    public CardinalDirection2D RotateClockwise
    {
        get
        {
            switch (directionID)
            {
                case CardinalDirection2DID.Up:
                    return right;
                case CardinalDirection2DID.Right:
                    return down;
                case CardinalDirection2DID.Down:
                    return left;
                case CardinalDirection2DID.Left:
                    return up;
                default:
                    throw new System.FormatException("Invalid direction code");
            }
        }
    }

    /// <summary>
    /// Returns the direction 90 degress anticlockwise of the given direction.
    /// </summary>
    public CardinalDirection2D RotateAntiClockWise
    {
        get
        {
            switch (directionID)
            {
                case CardinalDirection2DID.Up:
                    return left;
                case CardinalDirection2DID.Right:
                    return up;
                case CardinalDirection2DID.Down:
                    return right;
                case CardinalDirection2DID.Left:
                    return down;
                default:
                    throw new System.FormatException("Invalid direction code");
            }
        }
    }

    /// <summary>
    /// Returns a quaternion that represents a rotation around the forward axis in the given direction.
    /// </summary>
    public Quaternion AsRotation
    {
        get
        {
            switch (directionID)
            {
                case CardinalDirection2DID.Up:
                    return Quaternion.Euler(new Vector3(0, 0, 0));
                case CardinalDirection2DID.Right:
                    return Quaternion.Euler(new Vector3(0, 0, 270));
                case CardinalDirection2DID.Down:
                    return Quaternion.Euler(new Vector3(0, 0, 180));
                case CardinalDirection2DID.Left:
                    return Quaternion.Euler(new Vector3(0, 0, 90));
                default:
                    throw new System.FormatException("Invalid direction code");
            }
        }
    }

    #endregion

    #region helpful utilities

    /// <summary>
    /// <para>Generates a CardinalDirection2D from a string.</para>
    /// <para>Valid values include 'up', 'down', 'right', and 'left'.</para>
    /// </summary>
    /// <param name="stringValue"></param>
    /// <returns></returns>
    public static CardinalDirection2D FromString(string stringValue)
    {
        switch (stringValue)
        {
            case "up":
            case "Up":
                return up;
            case "down":
            case "Down":
                return down;
            case "right":
            case "Right":
                return right;
            case "left":
            case "Left":
                return left;

            default: throw new System.FormatException("String value does not correspond to a valid direction");
        }
    }

    /// <summary>
    /// <para>Returns the closest CardinalDirection to the given Vector2.</para>
    /// <para>If x and y values of the Vector2 are equal, defaults to up or down 
    /// depending on the polarity of the y value</para>
    /// </summary>
    /// <param name="vector2"></param>
    /// <returns></returns>
    public static CardinalDirection2D RoundedFromVector(Vector2 vector2)
    {
        Vector2Int cardinalizedDirection = Vector2Int.zero;
        if(Mathf.Abs(vector2.x) > Mathf.Abs(vector2.y))
        {
            cardinalizedDirection.x = (int)(vector2.x / Mathf.Abs(vector2.x));
        }
        else
        {
            cardinalizedDirection.y = (int)(vector2.y / Mathf.Abs(vector2.y));
        }

        return cardinalizedDirection;
    }

    /// <summary>
    /// returns true if the Vector2 can be converted to a valid CardinalDirection2D without rounding, false otherwise.
    /// </summary>
    /// <param name="vector2"></param>
    /// <param name="outDirection"></param>
    /// <returns></returns>
    public static bool TryGetDirection(Vector2 vector2, out CardinalDirection2D outDirection)
    {
        outDirection = up;
        if (vector2.x == 0 || vector2.y == 0)
        {
            Vector2Int vector = new Vector2Int((int)Mathf.Sign(vector2.x), (int)Mathf.Sign(vector2.y));

            if (vector == Vector2Int.up) outDirection = up;
            else if (vector == Vector2Int.right) outDirection = right;
            else if (vector == Vector2Int.down) outDirection = down;
            else if (vector == Vector2Int.left) outDirection = left;
            else return false;

            return true;
        }

        return false;
    }

    //public static CardinalDirection2D RoundedFromVector(Vector3 vector3)
    //{
    //    return RoundedFromVector(vector3);
    //}

    #endregion
}

#if UNITY_EDITOR

[CustomPropertyDrawer(typeof(CardinalDirection2D))]
class CardinalDirection2DPropertyDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        //GUIContent propertylabel = new GUIContent(ObjectNames.NicifyVariableName(property.name));
        //Rect fieldPosition = new Rect(position.x + 50, position.y, 50, position.height);
        EditorGUI.PropertyField(position, property.FindPropertyRelative("directionID"), label);

        EditorGUI.EndProperty();
    }
}

#endif //UNITY_EDITOR
