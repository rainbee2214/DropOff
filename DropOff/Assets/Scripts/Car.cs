using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

//Every time a car enters a new road segment, it will see if that road contains the turn its trying to do
//If not, it will keep going the direction it's going
//If the car keeps going the direction it's going and the tile does not have that direction, the car will explode
public class Car : MonoBehaviour
{
    Rigidbody2D rb2d;
    SpriteRenderer sr;

    public int playerNumber = 0;
    public static float topRotation = 0, rightRotation = -90, bottomRotation = -180, leftRotation = -270;
    public Direction goingTowards = Direction.Top;
    public Vector2 vel = Vector2.up;
    public float speed = 1f;

    public bool turnTop, turnRight, turnLeft, turnBottom;
    public bool canTurnTop, canTurnRight, canTurnLeft, canTurnBottom;
    public Direction nextTurn;
    public List<Person> people;

    float temp;

    public Image upButton, downButton, leftButton, rightButton;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
        nextTurn = goingTowards;
        people = new List<Person>();
        temp = speed;

    }
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void Pickup(Person person)
    {
        people.Add(person);
    }

    public void DropOff(Person person)
    {
        people.Remove(person);
    }
    public void ChangeDirection(Direction newDirection)
    {
        goingTowards = newDirection;
        switch (goingTowards)
        {
            case Direction.Top:
                vel = Vector2.up;
                rb2d.rotation = topRotation;
                break;
            case Direction.Right:
                vel = Vector2.right;
                rb2d.rotation = rightRotation;
                break;
            case Direction.Left:
                vel = Vector2.left;
                rb2d.rotation = leftRotation;
                break;
            case Direction.Bottom:
                vel = Vector2.down;
                rb2d.rotation = bottomRotation;
                break;
        }

        canTurnBottom = false;
        canTurnLeft = false;
        canTurnRight = false;
        canTurnTop = false;
        rb2d.position = new Vector2(Mathf.RoundToInt(rb2d.position.x), Mathf.RoundToInt(rb2d.position.y));
    }

    public void ChangeDirection()
    {
        Direction newDirection = goingTowards;

        //Based on current direction, turn either left or right
        switch (goingTowards)
        {
            case Direction.Top:
                newDirection = (Random.Range(0, 10) % 2 == 0) ? Direction.Left : Direction.Right;
                break;
            case Direction.Right:
                newDirection = (Random.Range(0, 10) % 2 == 0) ? Direction.Top : Direction.Bottom;
                break;
            case Direction.Left:
                newDirection = (Random.Range(0, 10) % 2 == 0) ? Direction.Bottom : Direction.Top;
                break;
            case Direction.Bottom:
                newDirection = (Random.Range(0, 10) % 2 == 0) ? Direction.Right : Direction.Left;
                break;
        }

        //ChangeDirection(newDirection);
    }
    public void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + vel * speed * Time.deltaTime);

        if (Input.GetButtonDown("Top" + (playerNumber+1) )) //+1 to avoid off by one in the button names (named 1-4)
        {
            turnTop = true;
            turnRight = false;
            turnLeft = false;
            turnBottom = false;
            nextTurn = Direction.Top;

        }
        if (Input.GetButtonDown("Right" + (playerNumber + 1)))
        {
            turnRight = true;
            turnTop = false;
            turnLeft = false;
            turnBottom = false;
            nextTurn = Direction.Right;
        }
        if (Input.GetButtonDown("Left" + (playerNumber + 1)))
        {
            turnLeft = true;
            turnTop = false;
            turnBottom = false;
            turnRight = false;

            nextTurn = Direction.Left;
        }
        if (Input.GetButtonDown("Bottom" + (playerNumber + 1)))
        {
            turnBottom = true;
            turnTop = false;
            turnRight = false;
            turnLeft = false;
            nextTurn = Direction.Bottom;
        }

        if (turnTop && canTurnTop)
        {
            turnTop = false;
            canTurnTop = false;
            ChangeDirection(Direction.Top);
        }
        else if (turnRight && canTurnRight)
        {
            turnRight = false;
            canTurnRight = false;
            ChangeDirection(Direction.Right);
        }
        else if (turnLeft && canTurnLeft)
        {
            turnLeft = false;
            canTurnLeft = false;
            ChangeDirection(Direction.Left);
        }
        else if (turnBottom && canTurnBottom)
        {
            turnBottom = false;
            canTurnBottom = false;
            ChangeDirection(Direction.Bottom);
        }

        upButton.color = GameController.controller.uController.GetPlayerColor(turnTop ? this : null);
        downButton.color = GameController.controller.uController.GetPlayerColor(turnBottom ? this : null);
        leftButton.color = GameController.controller.uController.GetPlayerColor(turnLeft ? this : null);
        rightButton.color = GameController.controller.uController.GetPlayerColor(turnRight ? this : null);
    }

    public void HitRoadTile(bool hasTop, bool hasRight, bool hasLeft, bool hasBottom)
    {
        //Debug.Log("Hit road tile " + hasTop + " " + hasRight + " " + hasLeft + " " + hasBottom);
        canTurnLeft = hasLeft;
        canTurnRight = hasRight;
        canTurnTop = hasTop;
        canTurnBottom = hasBottom;

        switch (nextTurn)
        {
            case Direction.Top:
                if (!canTurnTop && !CanTurn(goingTowards, hasTop, hasRight, hasLeft, hasBottom))
                {
                    HasDied();
                }
                break;
            case Direction.Right:
                if (!canTurnRight && !CanTurn(goingTowards, hasTop, hasRight, hasLeft, hasBottom))
                {
                    HasDied();
                }
                break;
            case Direction.Left:
                if (!canTurnLeft && !CanTurn(goingTowards, hasTop, hasRight, hasLeft, hasBottom))
                {
                    HasDied();
                }
                break;
            case Direction.Bottom:
                if (!canTurnBottom && !CanTurn(goingTowards, hasTop, hasRight, hasLeft, hasBottom))
                {
                    HasDied();
                }
                break;
        }
    }

    public void HasDied()
    {
        StartCoroutine(StartDeath());
    }
    public IEnumerator StartDeath()
    {
        //Play explosion
        Death();
        AudioController.controller.PlayAudio(AudioType.Death);
        yield return new WaitForSeconds(1f);
        TurnBackOn();
        yield return null;
    }

    void Death()
    {
        //Reset anything else that needs to be
        ////Affect the score
        //gameObject.SetActive(false);
        //Debug.Log("You crashed");
        sr.enabled = false;
        temp = speed;
        speed = 0;
        rb2d.velocity = Vector2.zero;
    }

    void TurnBackOn()
    {
        GameController.controller.TurnOnCar(this);
        sr.enabled = true;
        speed = temp;
        ChangeDirection(Direction.Top);
        //Reset position and then flicker back on
    }

    //Check if you can go in direction on a certain tile
    bool CanTurn(Direction d, bool t, bool r, bool l, bool b)
    {
        switch (d)
        {
            case Direction.Top:
                return t;
            case Direction.Right:
                return r;
            case Direction.Left:
                return l;
            case Direction.Bottom:
                return b;
        }
        return false;
    }

    public void LeftRoadTile(bool hasTop, bool hasRight, bool hasLeft, bool hasBottom)
    {
        canTurnLeft = false;
        canTurnRight = false;
        canTurnTop = false;
        canTurnBottom = false;
    }

    public void ChangeSpeed(float speedUpTime, float multiplier)
    {
        StartCoroutine(SpeedUp(speedUpTime, multiplier));
    }
    public IEnumerator SpeedUp(float speedUpTime, float multiplier)
    {
        Debug.Log("Changing Speed1");
        float t = speed;
        speed *= multiplier;
        yield return new WaitForSeconds(speedUpTime);
        Debug.Log("Changing Speed2");
        speed = t;
        Debug.Log("Changing Speed3");
        yield return null;
    }
}
