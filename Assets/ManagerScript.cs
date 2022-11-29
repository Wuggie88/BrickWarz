using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScript : MonoBehaviour
{
    //this script is used for the manager, it's also used as a "accountant" 

    //teams is how many teams are currently playing
    public int teams = 0;

    //function that takes an int, to set the amount of teams playing the game currently
    public void setTeams(int data)
    {
        //sets amount of teams to the data sent to this function
        teams = data;
    }
}
