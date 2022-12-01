using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScript : MonoBehaviour
{
    //this script is used for the manager, it's also used as a "accountant" 

    //teams is how many teams are currently playing
    public int teams = 0;
    //variable for the time each build round should have
    public int roundTimer = 0;
    //variable for the amount of lives each team has
    public int t1Lives = 0;
    public int t2Lives = 0;
    public int t3Lives = 0;
    public int t4Lives = 0;
    //Variable for counting the current round being played
    public int currentRound = 0;

    //function that takes an int, to set the amount of teams playing the game currently
    public void setTeams(int data){
        //sets amount of teams to the data sent to this function
        teams = data;
    }

    //function that takes an int, to set the amount of time each build round should take
    public void setTimer(int data) {
        roundTimer = data;
    }
}
