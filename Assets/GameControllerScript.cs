using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using KyleDulce.SocketIo;

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

    //event gameobject
    public GameObject eventHandler;
    //event int
    public int eventHappening;

    //round Holder Gameobject
    public GameObject RoundHolder;

    //current players turn. Starts from player 1.
    public int teamTurn = 0;
    //amount of total turns played
    public int totalTurns = 0;
    //current players UI. 
    public Text teamTurnTxt;
    public Slider teamHealthSlider;
    public Text teamHealthTxt;

    //network
    Socket s;
    private bool runLocal = true;

    // Start is called before the first frame update
    void Start()
    {
        p1Buildings = new string[3] { "", "", "" };
        p2Buildings = new string[3] { "", "", "" };
        p3Buildings = new string[3] { "", "", "" };
        p4Buildings = new string[3] { "", "", "" };

    }

    void ConnectToServer() {

        if (runLocal) {
            Debug.Log("Local server");
            s = SocketIo.establishSocketConnection("ws://192.168.24.209:80");
        } else {
            Debug.Log("There is no Online Server");

        }

        s.connect();
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
        if (teamTurn + 1 > arrayOfTeams.Length)
            teamTurn = 0;

        //do something with the board lights here

        teamTurn++;
        totalTurns++;

        Debug.Log("Start round for team: " + (teamTurn));
        teamTurnTxt.text = "Team " + (teamTurn) + "'s turn";
        setHealth();


        //random event
        eventHappening = Random.Range(0, 11);

        if(eventHappening >= 3 && totalTurns > ((amountOfTeams * 2) - 1)) {
            eventHandler.SetActive(true);
            eventHandler.GetComponent<EventScript>().startEvent();
        } else {
            RoundHolder.SetActive(true);
        }


        //Invoke("Turn",5); //Only for test purposes
    }

    public void setHealth() {
        teamHealthTxt.text = "Fortress' Health: " + arrayTeamHealth[teamTurn -1];
        teamHealthSlider.value = arrayTeamHealth[teamTurn -1];
    }

    public void SelectSpot() {
        //array of spots (free for build new, filled for upgrade, enemy filled spots for targeting)
        //array linked with the teams array
        //button connected to each spot -> gets activated or deactivated if available or not
    }
}
