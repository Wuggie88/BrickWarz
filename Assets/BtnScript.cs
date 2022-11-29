using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnScript : MonoBehaviour
{
    //variable for the amount of teams this button should send
    public int teams = 0;
    //GameObject for the manager that keeps track of teams
    public GameObject manager;

    //timers can go here
    public int buildTimer = 60;

    private void Start()
    {
        //sets the manager
        manager = GameObject.Find("Manager");
    }

    public void sendTeams()
    {
        //sends the team amount to the manager
        manager.GetComponent<ManagerScript>().setTeams(teams);
    }
}
