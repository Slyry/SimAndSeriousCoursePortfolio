using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour                                //search for:  NORMAL CONTROLS - or - TANK CONTROLS
{
    #region Fields
    Rigidbody rb;
    Vector3 moveDirection;  //the direction the player should move
    Vector3 currDirection;  //the direction of the player is facing (whether or not the player is moving)
    private Quaternion curRotation;
    //float deadZone = 0.2f;

    [SerializeField] float movementSpeed;

    //Connect each "Personality Type" (enum value) with an "Amount" of that type (int)
    public Dictionary<QuestionManager.PersonalityTrait, int> playerPersonality = new Dictionary<QuestionManager.PersonalityTrait, int>();
    #endregion

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }

        ////thanks to Kasper Holdum for the condition (how to get number of items defined in an enum) at: http://stackoverflow.com/questions/856154/total-number-of-items-defined-in-an-enum
        //add a new key to the dictionary for each enum value
        for (int x = 0; x < System.Enum.GetNames(typeof(QuestionManager.PersonalityTrait)).Length; x++)
        {
            playerPersonality.Add((QuestionManager.PersonalityTrait)x, 0);
        }
    }

    void FixedUpdate()
    {
        if (currDirection != Vector3.zero)
        {
            //move the player using velocity- NORMAL CONTROLS
            rb.velocity = moveDirection * movementSpeed * Time.deltaTime;
        }
        else
        {
            transform.eulerAngles = currDirection;
            rb.velocity = Vector3.zero;
        }
    }
    void Update()
    {
        UpdateDirection(GetJoystickInput());     //changes the Vector2 Direction and the DirectionState
        UpdateMove();   //changes the velocity depending on input
        curRotation = transform.rotation;
    }

    #region Movement Methods


    Vector3 GetJoystickInput()
    {
        return new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }

    void UpdateMove()
    {
        //rb.velocity = Vector3.zero;

        //get direction
        moveDirection = GetJoystickInput();
    }

    void UpdateDirection(Vector3 desiredDirection)
    {
        //if(desiredDirection.magnitude > deadZone)
        //{
            currDirection = desiredDirection;
        //}
        
        //NORMAL CONTROLS
        transform.rotation = Quaternion.LookRotation(currDirection);
    }
    #endregion
}
