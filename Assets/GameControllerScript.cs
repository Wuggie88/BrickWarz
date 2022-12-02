using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    //current players turn. Starts from player 1.
    public int playerTurn = 1;

    // Start is called before the first frame update
    void Start()
    {
        
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

        Round();
    }

    public void Round() {
        Debug.Log("Start round for player: " + playerTurn);


        playerTurn++;
        if (playerTurn > arrayOfTeams.Length)
            playerTurn = 1;
        //Invoke("Round",5); //Only for test purposes
    }
}
