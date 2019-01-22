using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : Controller
{
    public bool canMove = true;
    public bool canInteract = true;
    public Transform interactRayOrigin;
    public float interactRayLength = 8;

    // Use this for initialization
    public override void Start()
    {
        base.Start();

        currentDirection = SOUTH;
        currentDir = south;
    }

    // Called once every frame
    public override void Update()
    {
        base.Update();
        
        //check for input
        if(canMove)
        {
            CheckInput();
            SendAnimInfo();
        }
        else
        {
            rb.velocity = Vector2.zero;
            currentDirection = lastDirection;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && canInteract)
        {
            RaycastHit2D rc = Physics2D.Raycast(interactRayOrigin.position, currentDirection, interactRayLength);
            if (rc.collider != null && rc.collider.CompareTag("Interactable"))
            {
                Debug.Log("bip");
                rc.collider.gameObject.SendMessage("Interact");
            }
        }
    }

    /// <summary>
    /// Checks if input is valid and tells this object to move. Cleaner than before, but some mess slipped through
    /// </summary>
    void CheckInput()
    {
        // Movement
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        
        if (h != 0 ^ v != 0)
        {
            isMoving = true;
            if (!isAttacking)
            {
                Move(h, v);
            }
            else
            {
                Move(0, 0);
            }
        }
        else if (h != 0 && v != 0)
        {
            //do nothing (prevents diagonal movement, moving the player in the current direction)
        }
        else//this might not be triggered
        {
            isMoving = false;
            rb.velocity = Vector2.zero;
        }

    }
    
    /// <summary>
    /// Moves the object depending on the passed in values.
    /// </summary>
    /// <param name="h">Value of horizontal input</param>
    /// <param name="v">Value of vertical</param>
    public void Move(float h, float v)
    {
        if (!bc.IsTouchingLayers(Physics2D.AllLayers))
        {
            lastDirection = rb.velocity;
        }
        //lastDirection = rb.velocity;
        deltaForce = new Vector2(h, v);
        CalculateMovement(deltaForce * speed);
        DetermineDirection(deltaForce);
    }

    public void MoveVector(Vector2 movement)
    {
        Move(movement.x, movement.y);
    }

    /// <summary>
    /// Does the actual movement of the object.
    /// </summary>
    /// <param name="playerForce">The direction to move this object</param>
    void CalculateMovement(Vector2 playerForce)
    {
        rb.velocity = Vector2.zero;
        rb.AddForce(playerForce, ForceMode2D.Impulse);
    }

    /// <summary>
    /// Determines the current direction the player is moving and facing.
    /// </summary>
    void DetermineDirection(Vector2 dir)
    {
        y = Input.GetAxisRaw("Vertical");
        x = Input.GetAxisRaw("Horizontal");
        if (dir.y > 0)
        {
            currentDirection = NORTH;
            currentDir = north;
        }
        else if (dir.y < 0)
        {
            currentDirection = SOUTH;
            currentDir = south;
        }

        if (dir.x > 0)
        {
            currentDirection = EAST;
            currentDir = east;
        }
        else if (dir.x < 0)
        {
            currentDirection = WEST;
            currentDir = west;
        }

        lastDirection = currentDirection;
        if (dir.x == 0 && dir.y == 0)
        {
            //currentDirection = lastDirection;
        }
    }
    
    void Freeze(bool freezing)
    {
        anim.SetBool("isMoving", false);
        canMove = !freezing;
    }
}
