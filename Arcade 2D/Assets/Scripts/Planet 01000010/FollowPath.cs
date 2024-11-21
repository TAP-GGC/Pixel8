using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    //Array of waypoints placed on moveable tiles
    public Transform[] waypoints;

    //Move speed variable that can be set in inspector
    [SerializeField] private float moveSpeed = 0.5f;
    
    //Holds current number of waypoint player occupies
    [HideInInspector] public int waypointIndex = 0;
    
    //If current player is allowed to move or not (for multiplayer)
    public bool moveAllowed = false;

    // Start is called before the first frame update
    void Start()
    {
        //Places player at the first waypoint
        moveAllowed = false;
        waypointIndex = 0;
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Moves the player only if movement is allowed
        if (moveAllowed)
        {
            Move();
        }
    }

    private void Move()
    {
        //Moves player to each waypoint until it reaches the last waypoint
        //At last waypoint, player stops moving
        if (waypointIndex <= waypoints.Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position,
            waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);

            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex++;
            }
        }
    }
}
