﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour
{
    //array of teams
    public int[] arrayOfTeams;
    //Manager gameobject
    public GameObject manager;
    //current amount of teams playing
    public int amountOfTeams = 0;
    //team lives
    public int teamHealth = 50;
    //array for teamHealth
    public int[] arrayTeamHealth;
    //arrays for buildings
    public string[] p1Buildings;
    public string[] p2Buildings;
    public string[] p3Buildings;
    public string[] p4Buildings;

    //current players turn. Starts from player 1.
    public int teamTurn = 0;
    //current players UI. 
    public Text teamTurnTxt;
    public Slider teamHealthSlider;
    public Text teamHealthTxt;

    // Start is called before the first frame update
    void Start()
    {
        p1Buildings = new string[3] { "", "", "" };
        p2Buildings = new string[3] { "", "", "" };
        p3Buildings = new string[3] { "", "", "" };
        p4Buildings = new string[3] { "", "", "" };
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame() {
        amountOfTeams = manager.GetComponent<ManagerScript>().teams;
        arrayTeamHealth = manager.GetComponent<ManagerScript>().teamLives;

        arrayOfTeams = new int[amountOfTeams];
        arrayTeamHealth = new int[amountOfTeams];

        Debug.Log("Start game ran");
        for (int i = 0; i < arrayOfTeams.Length; i++) {
            arrayOfTeams[i] += i + 1;
            Debug.Log("Array of teams added: " + arrayOfTeams[i]);
            arrayTeamHealth[i] = teamHealth;
            Debug.Log("Team" + i + "health: " + arrayTeamHealth[i]);
            manager.GetComponent<ManagerScript>().teamLives = arrayTeamHealth;
        }
        Turn();
    }

    public void Turn() {
        Debug.Log("Start round for team: " + (teamTurn + 1));
        teamTurnTxt.text = "Team " + (teamTurn + 1) + "'s turn";
        teamHealthTxt.text = "Fortress' Health: " + arrayTeamHealth[teamTurn];
        teamHealthSlider.value = arrayTeamHealth[teamTurn];

        teamTurn++;
        if (teamTurn + 1 > arrayOfTeams.Length)
            teamTurn = 0;

        //Invoke("Turn",5); //Only for test purposes
    }

    public void SelectSpot() {
        //array of spots (free for build new, filled for upgrade, enemy filled spots for targeting)
        //array linked with the teams array
        //button connected to each spot -> gets activated or deactivated if available or not
    }
}
