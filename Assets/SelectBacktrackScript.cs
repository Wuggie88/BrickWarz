using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectBacktrackScript : MonoBehaviour
{
    public GameObject gameManager, selectSpotHolder;
    public GameObject buildHolder, actionHolder, selectEnemyHolder;
    public GameObject[] spots;
    public GameObject[] teamSpots;
    public GameObject parent;

    public GameObject spot;
    public GameObject selector;
    public GameObject attackingSpot;

    public int team;
    public int atkSpot;
    public int damage;
    public int defense;

    public GameObject assignments;
    public int teamTurn;
    public GameControllerScript gameController;

    public string buildingVar;

    public enum buildingType { Attack, Defence};
    public buildingType currentBuilding;

    private void Start() {
        //get refference to the game controller script
        gameController = gameManager.GetComponent<GameControllerScript>();
    }

    //Remebers the selector & action
    public void SetSelector(GameObject action)
    {   
        teamTurn = gameController.teamTurn;
        selector = action;
        //Can maybe use dictinary to refer to arrays and varibles easily instead of running nested switches with multiple switch cases
        switch (selector.name)
        {
            case "BuildNewAttackBtn": case "BuildNewDefBtn":
                parent = buildHolder;
                switch (teamTurn){
                    case 1:
                        //goes through the array of a players buildings and either enables or disables the buttons link to the builds to display the right buttons
                        for(int i = 0; i < gameController.p1Buildings.Length; i++) {
                            if (gameController.p1Buildings[i] == "") {
                                spots[i].SetActive(true);
                            } else {
                                spots[i].SetActive(false);
                            }
                        }
                        if(selector.name == "BuildNewAttackBtn") {
                            currentBuilding = buildingType.Attack;
                        } else {
                            currentBuilding = buildingType.Defence;
                        }
                        break;
                    case 2:
                        for (int i = 0; i < gameController.p2Buildings.Length; i++) {
                            if (gameController.p2Buildings[i] == "") {
                                spots[i].SetActive(true);
                            } else {
                                spots[i].SetActive(false);
                            }
                        }
                        if (selector.name == "BuildNewAttackBtn") {
                            currentBuilding = buildingType.Attack;
                        } else {
                            currentBuilding = buildingType.Defence;
                        }
                        break;
                    case 3:
                        for (int i = 0; i < gameController.p3Buildings.Length; i++) {
                            if (gameController.p3Buildings[i] == "") {
                                spots[i].SetActive(true);
                            } else {
                                spots[i].SetActive(false);
                            }
                        }
                        if (selector.name == "BuildNewAttackBtn") {
                            currentBuilding = buildingType.Attack;
                        } else {
                            currentBuilding = buildingType.Defence;
                        }
                        break;
                    case 4:
                        for (int i = 0; i < gameController.p4Buildings.Length; i++) {
                            if (gameController.p4Buildings[i] == "") {
                                spots[i].SetActive(true);
                            } else {
                                spots[i].SetActive(false);
                            }
                        }
                        if (selector.name == "BuildNewAttackBtn") {
                            currentBuilding = buildingType.Attack;
                        } else {
                            currentBuilding = buildingType.Defence;
                        }
                        break;

                }

                break;
            case "UpgradeBtn":
                parent = buildHolder;
                // There should be an else if (array[i] == "A3" OR "D3" -> SetActive(false)), 
                //as it will show all buildings as able to be upgraded.
                switch (teamTurn) {
                    case 1:
                        for (int i = 0; i < gameController.p1Buildings.Length; i++) {
                            if (gameController.p1Buildings[i] == "") {
                                spots[i].SetActive(false);
                            } else {
                                spots[i].SetActive(true);
                            }
                        }
                        break;
                    case 2:
                        for (int i = 0; i < gameController.p2Buildings.Length; i++) {
                            if (gameController.p2Buildings[i] == "") {
                                spots[i].SetActive(false);
                            } else {
                                spots[i].SetActive(true);
                            }
                        }
                        break;
                    case 3:
                        for (int i = 0; i < gameController.p3Buildings.Length; i++) {
                            if (gameController.p3Buildings[i] == "") {
                                spots[i].SetActive(false);
                            } else {
                                spots[i].SetActive(true);
                            }
                        }
                        break;
                    case 4:
                        for (int i = 0; i < gameController.p4Buildings.Length; i++) {
                            if (gameController.p4Buildings[i] == "") {
                                spots[i].SetActive(false);
                            } else {
                                spots[i].SetActive(true);
                            }
                        }
                        break;
                }
                break;
            case "AttackBtn":
                parent = actionHolder;
                // There should maybe be something with only attack can attack.
                switch (teamTurn) {
                    case 1:
                        for (int i = 0; i < gameController.p1Buildings.Length; i++) {
                            if (gameController.p1Buildings[i] == "" || gameController.p1Buildings[i] == "D1" || gameController.p1Buildings[i] == "D2" || gameController.p1Buildings[i] == "D3") {
                                spots[i].SetActive(false);
                            } else {
                                spots[i].SetActive(true);
                            }
                        }
                        break;
                    case 2:
                        for (int i = 0; i < gameController.p2Buildings.Length; i++) {
                            if (gameController.p2Buildings[i] == "" || gameController.p2Buildings[i] == "D1" || gameController.p2Buildings[i] == "D2" || gameController.p2Buildings[i] == "D3") {
                                spots[i].SetActive(false);
                            } else {
                                spots[i].SetActive(true);
                            }
                        }
                        break;
                    case 3:
                        for (int i = 0; i < gameController.p3Buildings.Length; i++) {
                            if (gameController.p3Buildings[i] == "" || gameController.p3Buildings[i] == "D1" || gameController.p3Buildings[i] == "D2" || gameController.p3Buildings[i] == "D3") {
                                spots[i].SetActive(false);
                            } else {
                                spots[i].SetActive(true);
                            }
                        }
                        break;
                    case 4:
                        for (int i = 0; i < gameController.p4Buildings.Length; i++) {
                            if (gameController.p4Buildings[i] == "" || gameController.p4Buildings[i] == "D1" || gameController.p4Buildings[i] == "D2" || gameController.p4Buildings[i] == "D3") {
                                spots[i].SetActive(false);
                            } else {
                                spots[i].SetActive(true);
                            }
                        }
                        break;
                }
                break;
            default:
                //selected enemy, going to select enemy's building
                parent = actionHolder;
                //issue with backtrack past selectEnemyHolder, so backtracks to actionHolder instead
                switch (selector.name) {
                    case "SelectTeam1Btn":
                        for (int i = 0; i < gameController.p1Buildings.Length; i++) {
                            if (gameController.p1Buildings[i] == "") {
                                spots[i].SetActive(false);
                            } else {
                                spots[i].SetActive(true);
                            }
                        }
                        break;
                    case "SelectTeam2Btn":
                        for (int i = 0; i < gameController.p2Buildings.Length; i++) {
                            if (gameController.p2Buildings[i] == "") {
                                spots[i].SetActive(false);
                            } else {
                                spots[i].SetActive(true);
                            }
                        }
                        break;
                    case "SelectTeam3Btn":
                        for (int i = 0; i < gameController.p3Buildings.Length; i++) {
                            if (gameController.p3Buildings[i] == "") {
                                spots[i].SetActive(false);
                            } else {
                                spots[i].SetActive(true);
                            }
                        }
                        break;
                    case "SelectTeam4Btn":
                        for (int i = 0; i < gameController.p4Buildings.Length; i++) {
                            if (gameController.p4Buildings[i] == "") {
                                spots[i].SetActive(false);
                            } else {
                                spots[i].SetActive(true);
                            }
                        }
                        break;
                }
                break;
        }
    }

    //Called when player want to undo an action
    public void BackTrack()
    {
        parent.SetActive(true);
    }

    public void GetTarget(GameObject spotBtn)
    {
        spot = spotBtn;

        if (selector.name == "AttackBtn") {
            //if you want to attack
            //NEEDS to use spot for which enemy to select from when choosing the actual spot to attack.
            attackingSpot = spot;
            //activates selectEnemyHolder, which contains the enemies available to attack
            selectEnemyHolder.SetActive(true);
            for (int i = 0; i < gameController.amountOfTeams; i++) {
                if (teamTurn - 1 != i) {
                    teamSpots[i].SetActive(true);
                    //maybe have the teamSpots have a distinct color to distingish them in the gamemanager.
                } else {
                    teamSpots[i].SetActive(false);
                }
            }
        } else if (selector.name == "BuildNewAttackBtn" || selector.name == "BuildNewDefBtn") {
            //if you want to build
            switch (teamTurn) {
                //if its player 1's turn
                case 1:
                    switch (spot.name) {
                        //which spot you clicked
                        case "Spot1Btn":
                        case "Spot2Btn":
                        case "Spot3Btn":
                            assignments.gameObject.SetActive(true);
                            assignments.GetComponent<AssignmentScript>().level = 1;
                            assignments.GetComponent<AssignmentScript>().StartAss();
                            break;
                    }
                    break;
                case 2:
                    switch (spot.name) { 
                        case "Spot1Btn":
                        case "Spot2Btn":
                        case "Spot3Btn":
                            assignments.gameObject.SetActive(true);
                            assignments.GetComponent<AssignmentScript>().level = 1;
                            assignments.GetComponent<AssignmentScript>().StartAss();
                            break;
                    }
                    break;
                case 3:
                    switch (spot.name) {
                        case "Spot1Btn":
                        case "Spot2Btn":
                        case "Spot3Btn":
                            assignments.gameObject.SetActive(true);
                            assignments.GetComponent<AssignmentScript>().level = 1;
                            assignments.GetComponent<AssignmentScript>().StartAss();
                            break;
                    }
                    break;

                case 4:
                    switch (spot.name) {
                        case "Spot1Btn":
                        case "Spot2Btn":
                        case "Spot3Btn":
                            assignments.gameObject.SetActive(true);
                            assignments.GetComponent<AssignmentScript>().level = 1;
                            assignments.GetComponent<AssignmentScript>().StartAss();
                            break;
                    }
                    break;
            }
        } else if (selector.name == "UpgradeBtn") {
            //if you want to upgrade
            switch (teamTurn) {
                case 1:
                    switch (spot.name) {
                        case "Spot1Btn":
                            //sets what gets upgraded
                            switch (gameController.p1Buildings[0]) {
                                case "A1":
                                    buildingVar = "A2";
                                    assignments.gameObject.SetActive(true);
                                    assignments.GetComponent<AssignmentScript>().level = 2;
                                    assignments.GetComponent<AssignmentScript>().StartAss();
                                    break;
                                case "A2":
                                    buildingVar = "A3";
                                    assignments.gameObject.SetActive(true);
                                    assignments.GetComponent<AssignmentScript>().level = 3;
                                    assignments.GetComponent<AssignmentScript>().StartAss();
                                    break;
                                case "D1":
                                    buildingVar = "D2";
                                    assignments.gameObject.SetActive(true);
                                    assignments.GetComponent<AssignmentScript>().level = 2;
                                    assignments.GetComponent<AssignmentScript>().StartAss();
                                    break;
                                case "D2":
                                    buildingVar = "D3";
                                    assignments.gameObject.SetActive(true);
                                    assignments.GetComponent<AssignmentScript>().level = 3;
                                    assignments.GetComponent<AssignmentScript>().StartAss();
                                    break;
                                default:
                                    gameController.teamTurn -= 1;
                                    

                                    break;
                            }
                            break;
                        case "Spot2Btn":
                            switch (gameController.p1Buildings[1]) {
                                case "A1":
                                    buildingVar = "A2";
                                    assignments.gameObject.SetActive(true);
                                    assignments.GetComponent<AssignmentScript>().level = 2;
                                    assignments.GetComponent<AssignmentScript>().StartAss();
                                    break;
                                case "A2":
                                    buildingVar = "A3";
                                    assignments.gameObject.SetActive(true);
                                    assignments.GetComponent<AssignmentScript>().level = 3;
                                    assignments.GetComponent<AssignmentScript>().StartAss();
                                    break;
                                case "D1":
                                    buildingVar = "D2";
                                    assignments.gameObject.SetActive(true);
                                    assignments.GetComponent<AssignmentScript>().level = 2;
                                    assignments.GetComponent<AssignmentScript>().StartAss();
                                    break;
                                case "D2":
                                    buildingVar = "D3";
                                    assignments.gameObject.SetActive(true);
                                    assignments.GetComponent<AssignmentScript>().level = 3;
                                    assignments.GetComponent<AssignmentScript>().StartAss();
                                    break;
                                default:
                                    gameController.teamTurn -= 1;
                                    break;
                            }
                            break;
                        case "Spot3Btn":
                            switch (gameController.p1Buildings[2]) {
                                case "A1":
                                    buildingVar = "A2";
                                    assignments.gameObject.SetActive(true);
                                    assignments.GetComponent<AssignmentScript>().level = 2;
                                    assignments.GetComponent<AssignmentScript>().StartAss();
                                    break;
                                case "A2":
                                    buildingVar = "A3";
                                    assignments.gameObject.SetActive(true);
                                    assignments.GetComponent<AssignmentScript>().level = 3;
                                    assignments.GetComponent<AssignmentScript>().StartAss();
                                    break;
                                case "D1":
                                    buildingVar = "D2";
                                    assignments.gameObject.SetActive(true);
                                    assignments.GetComponent<AssignmentScript>().level = 2;
                                    assignments.GetComponent<AssignmentScript>().StartAss();
                                    break;
                                case "D2":
                                    buildingVar = "D3";
                                    assignments.gameObject.SetActive(true);
                                    assignments.GetComponent<AssignmentScript>().level = 3;
                                    assignments.GetComponent<AssignmentScript>().StartAss();
                                    break;
                                default:
                                    gameController.teamTurn -= 1;
                                    break;
                            }
                            break;
                    }
                    break;
                case 2:
                    switch (spot.name) {
                        case "Spot1Btn":
                            switch (gameController.p2Buildings[0]) {
                                case "A1":
                                    buildingVar = "A2";
                                    assignments.gameObject.SetActive(true);
                                    assignments.GetComponent<AssignmentScript>().level = 2;
                                    assignments.GetComponent<AssignmentScript>().StartAss();
                                    break;
                                case "A2":
                                    buildingVar = "A3";
                                    assignments.gameObject.SetActive(true);
                                    assignments.GetComponent<AssignmentScript>().level = 3;
                                    assignments.GetComponent<AssignmentScript>().StartAss();
                                    break;
                                case "D1":
                                    buildingVar = "D2";
                                    assignments.gameObject.SetActive(true);
                                    assignments.GetComponent<AssignmentScript>().level = 2;
                                    assignments.GetComponent<AssignmentScript>().StartAss();
                                    break;
                                case "D2":
                                    buildingVar = "D3";
                                    assignments.gameObject.SetActive(true);
                                    assignments.GetComponent<AssignmentScript>().level = 3;
                                    assignments.GetComponent<AssignmentScript>().StartAss();
                                    break;
                                default:
                                    gameController.teamTurn -= 1;
                                    break;
                            }
                            break;
                        case "Spot2Btn":
                            switch (gameController.p2Buildings[1]) {
                                case "A1":
                                    buildingVar = "A2";
                                    assignments.gameObject.SetActive(true);
                                    assignments.GetComponent<AssignmentScript>().level = 2;
                                    assignments.GetComponent<AssignmentScript>().StartAss();
                                    break;
                                case "A2":
                                    buildingVar = "A3";
                                    assignments.gameObject.SetActive(true);
                                    assignments.GetComponent<AssignmentScript>().level = 3;
                                    assignments.GetComponent<AssignmentScript>().StartAss();
                                    break;
                                case "D1":
                                    buildingVar = "D2";
                                    assignments.gameObject.SetActive(true);
                                    assignments.GetComponent<AssignmentScript>().level = 2;
                                    assignments.GetComponent<AssignmentScript>().StartAss();
                                    break;
                                case "D2":
                                    buildingVar = "D3";
                                    assignments.gameObject.SetActive(true);
                                    assignments.GetComponent<AssignmentScript>().level = 3;
                                    assignments.GetComponent<AssignmentScript>().StartAss();
                                    break;
                                default:
                                    gameController.teamTurn -= 1;
                                    break;
                            }
                            break;
                        case "Spot3Btn":
                            switch (gameController.p2Buildings[2]) {
                                case "A1":
                                    buildingVar = "A2";
                                    assignments.gameObject.SetActive(true);
                                    assignments.GetComponent<AssignmentScript>().level = 2;
                                    assignments.GetComponent<AssignmentScript>().StartAss();
                                    break;
                                case "A2":
                                    buildingVar = "A3";
                                    assignments.gameObject.SetActive(true);
                                    assignments.GetComponent<AssignmentScript>().level = 3;
                                    assignments.GetComponent<AssignmentScript>().StartAss();
                                    break;
                                case "D1":
                                    buildingVar = "D2";
                                    assignments.gameObject.SetActive(true);
                                    assignments.GetComponent<AssignmentScript>().level = 2;
                                    assignments.GetComponent<AssignmentScript>().StartAss();
                                    break;
                                case "D2":
                                    buildingVar = "D3";
                                    assignments.gameObject.SetActive(true);
                                    assignments.GetComponent<AssignmentScript>().level = 3;
                                    assignments.GetComponent<AssignmentScript>().StartAss();
                                    break;
                                default:
                                    gameController.teamTurn -= 1;
                                    break;
                            }
                            break;
                    }
                    break;
                case 3:
                    switch (spot.name) {
                        case "Spot1Btn":
                            switch (gameController.p3Buildings[0]) {
                                case "A1":
                                    buildingVar = "A2";
                                    assignments.gameObject.SetActive(true);
                                    assignments.GetComponent<AssignmentScript>().level = 2;
                                    assignments.GetComponent<AssignmentScript>().StartAss();
                                    break;
                                case "A2":
                                    buildingVar = "A3";
                                    assignments.gameObject.SetActive(true);
                                    assignments.GetComponent<AssignmentScript>().level = 3;
                                    assignments.GetComponent<AssignmentScript>().StartAss();
                                    break;
                                case "D1":
                                    buildingVar = "D2";
                                    assignments.gameObject.SetActive(true);
                                    assignments.GetComponent<AssignmentScript>().level = 2;
                                    assignments.GetComponent<AssignmentScript>().StartAss();
                                    break;
                                case "D2":
                                    buildingVar = "D3";
                                    assignments.gameObject.SetActive(true);
                                    assignments.GetComponent<AssignmentScript>().level = 3;
                                    assignments.GetComponent<AssignmentScript>().StartAss();
                                    break;
                                default:
                                    gameController.teamTurn -= 1;
                                    break;
                            }
                            break;
                        case "Spot2Btn":
                            switch (gameController.p3Buildings[1]) {
                                case "A1":
                                    buildingVar = "A2";
                                    assignments.gameObject.SetActive(true);
                                    assignments.GetComponent<AssignmentScript>().level = 2;
                                    assignments.GetComponent<AssignmentScript>().StartAss();
                                    break;
                                case "A2":
                                    buildingVar = "A3";
                                    assignments.gameObject.SetActive(true);
                                    assignments.GetComponent<AssignmentScript>().level = 3;
                                    assignments.GetComponent<AssignmentScript>().StartAss();
                                    break;
                                case "D1":
                                    buildingVar = "D2";
                                    assignments.gameObject.SetActive(true);
                                    assignments.GetComponent<AssignmentScript>().level = 2;
                                    assignments.GetComponent<AssignmentScript>().StartAss();
                                    break;
                                case "D2":
                                    buildingVar = "D3";
                                    assignments.gameObject.SetActive(true);
                                    assignments.GetComponent<AssignmentScript>().level = 3;
                                    assignments.GetComponent<AssignmentScript>().StartAss();
                                    break;
                                default:
                                    gameController.teamTurn -= 1;
                                    break;
                            }
                            break;
                        case "Spot3Btn":
                            switch (gameController.p3Buildings[2]) {
                                case "A1":
                                    buildingVar = "A2";
                                    assignments.gameObject.SetActive(true);
                                    assignments.GetComponent<AssignmentScript>().level = 2;
                                    assignments.GetComponent<AssignmentScript>().StartAss();
                                    break;
                                case "A2":
                                    buildingVar = "A3";
                                    assignments.gameObject.SetActive(true);
                                    assignments.GetComponent<AssignmentScript>().level = 3;
                                    assignments.GetComponent<AssignmentScript>().StartAss();
                                    break;
                                case "D1":
                                    buildingVar = "D2";
                                    assignments.gameObject.SetActive(true);
                                    assignments.GetComponent<AssignmentScript>().level = 2;
                                    assignments.GetComponent<AssignmentScript>().StartAss();
                                    break;
                                case "D2":
                                    buildingVar = "D3";
                                    assignments.gameObject.SetActive(true);
                                    assignments.GetComponent<AssignmentScript>().level = 3;
                                    assignments.GetComponent<AssignmentScript>().StartAss();
                                    break;
                                default:
                                    gameController.teamTurn -= 1;
                                    break;
                            }
                            break;
                    }
                    break;

                case 4:
                    switch (spot.name) {
                        case "Spot1Btn":
                            switch (gameController.p4Buildings[0]) {
                                case "A1":
                                    buildingVar = "A2";
                                    assignments.gameObject.SetActive(true);
                                    assignments.GetComponent<AssignmentScript>().level = 2;
                                    assignments.GetComponent<AssignmentScript>().StartAss();
                                    break;
                                case "A2":
                                    buildingVar = "A3";
                                    assignments.gameObject.SetActive(true);
                                    assignments.GetComponent<AssignmentScript>().level = 3;
                                    assignments.GetComponent<AssignmentScript>().StartAss();
                                    break;
                                case "D1":
                                    buildingVar = "D2";
                                    assignments.gameObject.SetActive(true);
                                    assignments.GetComponent<AssignmentScript>().level = 2;
                                    assignments.GetComponent<AssignmentScript>().StartAss();
                                    break;
                                case "D2":
                                    buildingVar = "D3";
                                    assignments.gameObject.SetActive(true);
                                    assignments.GetComponent<AssignmentScript>().level = 3;
                                    assignments.GetComponent<AssignmentScript>().StartAss();
                                    break;
                                default:
                                    gameController.teamTurn -= 1;
                                    break;
                            }
                            break;
                        case "Spot2Btn":
                            switch (gameController.p4Buildings[1]) {
                                case "A1":
                                    buildingVar = "A2";
                                    assignments.gameObject.SetActive(true);
                                    assignments.GetComponent<AssignmentScript>().level = 2;
                                    assignments.GetComponent<AssignmentScript>().StartAss();
                                    break;
                                case "A2":
                                    buildingVar = "A3";
                                    assignments.gameObject.SetActive(true);
                                    assignments.GetComponent<AssignmentScript>().level = 3;
                                    assignments.GetComponent<AssignmentScript>().StartAss();
                                    break;
                                case "D1":
                                    buildingVar = "D2";
                                    assignments.gameObject.SetActive(true);
                                    assignments.GetComponent<AssignmentScript>().level = 2;
                                    assignments.GetComponent<AssignmentScript>().StartAss();
                                    break;
                                case "D2":
                                    buildingVar = "D3";
                                    assignments.gameObject.SetActive(true);
                                    assignments.GetComponent<AssignmentScript>().level = 3;
                                    assignments.GetComponent<AssignmentScript>().StartAss();
                                    break;
                                default:
                                    gameController.teamTurn -= 1;
                                    break;
                            }
                            break;
                        case "Spot3Btn":
                            switch (gameController.p4Buildings[2]) {
                                case "A1":
                                    buildingVar = "A2";
                                    assignments.gameObject.SetActive(true);
                                    assignments.GetComponent<AssignmentScript>().level = 2;
                                    assignments.GetComponent<AssignmentScript>().StartAss();
                                    break;
                                case "A2":
                                    buildingVar = "A3";
                                    assignments.gameObject.SetActive(true);
                                    assignments.GetComponent<AssignmentScript>().level = 3;
                                    assignments.GetComponent<AssignmentScript>().StartAss();
                                    break;
                                case "D1":
                                    buildingVar = "D2";
                                    assignments.gameObject.SetActive(true);
                                    assignments.GetComponent<AssignmentScript>().level = 2;
                                    assignments.GetComponent<AssignmentScript>().StartAss();
                                    break;
                                case "D2":
                                    buildingVar = "D3";
                                    assignments.gameObject.SetActive(true);
                                    assignments.GetComponent<AssignmentScript>().level = 3;
                                    assignments.GetComponent<AssignmentScript>().StartAss();
                                    break;
                                default:
                                    gameController.teamTurn -= 1;
                                    break;
                            }
                            break;
                    }
                    break;
            }
        } else if (selector.name == "SelectTeam1Btn" || selector.name == "SelectTeam2Btn" || selector.name == "SelectTeam3Btn" || selector.name == "SelectTeam4Btn") {
            //We have selected who we want to attack and which building
            Debug.Log("Team" + teamTurn + " " + attackingSpot.name + " attacks " + selector.name + " at " + spot.name);
            //reset defense for this attack
            defense = 0;
            //reference to which specific team gets attacked to access array
            switch (selector.name) {
                case "SelectTeam1Btn":
                    team = 0;
                    break;
                case "SelectTeam2Btn":
                    team = 1;
                    break;
                case "SelectTeam3Btn":
                    team = 2;
                    break;
                case "SelectTeam4Btn":
                    team = 3;
                    break;
            }
            //attempt to reduce redundant lines in switches
            switch (attackingSpot.name) {
                case "Spot1Btn":
                    atkSpot = 0;
                    break;
                case "Spot2Btn":
                    atkSpot = 1;
                    break;
                case "Spot3Btn":
                    atkSpot = 2;
                    break;
            }
            //sets the damage based on the level of the offense attacking
            switch (teamTurn) {
                case 1:
                    switch (gameController.p1Buildings[atkSpot]) {
                        case "A1":
                            damage = 1;
                            break;
                        case "A2":
                            damage = 2;
                            break;
                        case "A3":
                            damage = 3;
                            break;
                        case "D1":
                            //does defense deal damage?
                            break;
                        case "D2":
                            //does defense deal damage?
                            break;
                        case "D3":
                            //does defense deal damage?
                            break;
                    }
                    break;
                case 2:
                    switch (gameController.p2Buildings[atkSpot]) {
                        case "A1":
                            damage = 1;
                            break;
                        case "A2":
                            damage = 2;
                            break;
                        case "A3":
                            damage = 3;
                            break;
                        case "D1":
                            //does defense deal damage?
                            break;
                        case "D2":
                            //does defense deal damage?
                            break;
                        case "D3":
                            //does defense deal damage?
                            break;
                    }
                    break;
                case 3:
                    switch (gameController.p3Buildings[atkSpot]) {
                        case "A1":
                            damage = 1;
                            break;
                        case "A2":
                            damage = 2;
                            break;
                        case "A3":
                            damage = 3;
                            break;
                        case "D1":
                            //does defense deal damage?
                            break;
                        case "D2":
                            //does defense deal damage?
                            break;
                        case "D3":
                            //does defense deal damage?
                            break;
                    }
                    break;
                case 4:
                    switch (gameController.p4Buildings[atkSpot]) {
                        case "A1":
                            damage = 1;
                            break;
                        case "A2":
                            damage = 2;
                            break;
                        case "A3":
                            damage = 3;
                            break;
                        case "D1":
                            //does defense deal damage?
                            break;
                        case "D2":
                            //does defense deal damage?
                            break;
                        case "D3":
                            //does defense deal damage?
                            break;
                    }
                    break;
            }
            switch (team) {
                case 0:
                    for (int i = 0; i < gameController.p1Buildings.Length; i++) {
                        switch (gameController.p1Buildings[i]) {
                            case "D1":
                                defense += 5;
                                break;
                            case "D2":
                                defense += 10;
                                break;
                            case "D3":
                                defense += 20;
                                break;
                        }
                    }
                    break;
                case 1:
                    for (int i = 0; i < gameController.p2Buildings.Length; i++) {
                        switch (gameController.p2Buildings[i]) {
                            case "D1":
                                defense += 5;
                                break;
                            case "D2":
                                defense += 10;
                                break;
                            case "D3":
                                defense += 20;
                                break;
                        }
                    }
                    break;
                case 2:
                    for (int i = 0; i < gameController.p3Buildings.Length; i++) {
                        switch (gameController.p3Buildings[i]) {
                            case "D1":
                                defense += 5;
                                break;
                            case "D2":
                                defense += 10;
                                break;
                            case "D3":
                                defense += 20;
                                break;
                        }
                    }
                    break;
                case 3:
                    for (int i = 0; i < gameController.p4Buildings.Length; i++) {
                        switch (gameController.p4Buildings[i]) {
                            case "D1":
                                defense += 5;
                                break;
                            case "D2":
                                defense += 10;
                                break;
                            case "D3":
                                defense += 20;
                                break;
                        }
                    }
                    break;
                }
            int succesrate = Random.Range(0, 100);
            //random succes or fail
            if (succesrate >= 30+defense) {
                //success
                Debug.Log("attack succeded");
                //attacked team loses health (change value?)
                gameController.arrayTeamHealth[team] -= damage;
                gameManager.GetComponent<GameControllerScript>().Turn();
                selectSpotHolder.SetActive(false);
                Debug.Log("succesrate = " + succesrate);
                Debug.Log("Defense = " + defense);
            } else {
                //fail
                Debug.Log("attack failed");
                gameManager.GetComponent<GameControllerScript>().Turn();
                selectSpotHolder.SetActive(false);
                Debug.Log("succesrate = " + succesrate);
                Debug.Log("Defense = " + defense);
            }
        } else {
            //changes turn if something went wrong in function
            Debug.Log("something went wrong with if-statement! next teams turn!");
            //Goes to next teams turn
            gameManager.GetComponent<GameControllerScript>().Turn();
            selectSpotHolder.SetActive(false);
        }
    }

    public void successAssignment() {

        if (selector.name == "AttackBtn") {
            //if you attack, you will get to choose which enemy team to attack

            selectEnemyHolder.SetActive(true);
        } else if (selector.name == "BuildNewAttackBtn" || selector.name == "BuildNewDefBtn") {
            //if you want to build
            switch (teamTurn) {
                //if its player 1's turn
                case 1:
                    switch (spot.name) {
                        //which spot you clicked
                        case "Spot1Btn":

                            //what building type
                            if (currentBuilding == buildingType.Attack) {
                                gameController.p1Buildings[0] = "A1";
                                //This is where we send the building on specific spot to the server
                            } else {
                                gameController.p1Buildings[0] = "D1";
                            }
                            
                            break;
                        case "Spot2Btn":
                            if (currentBuilding == buildingType.Attack) {
                                gameController.p1Buildings[1] = "A1";
                            } else {
                                gameController.p1Buildings[1] = "D1";
                            }
                            break;
                        case "Spot3Btn":
                            if (currentBuilding == buildingType.Attack) {
                                gameController.p1Buildings[2] = "A1";
                            } else {
                                gameController.p1Buildings[2] = "D1";
                            }
                            break;
                    }
                    break;
                case 2:
                    switch (spot.name) {
                        case "Spot1Btn":
                            if (currentBuilding == buildingType.Attack) {
                                gameController.p2Buildings[0] = "A1";
                            } else {
                                gameController.p2Buildings[0] = "D1";
                            }
                            break;
                        case "Spot2Btn":
                            if (currentBuilding == buildingType.Attack) {
                                gameController.p2Buildings[1] = "A1";
                            } else {
                                gameController.p2Buildings[1] = "D1";
                            }
                            break;
                        case "Spot3Btn":
                            if (currentBuilding == buildingType.Attack) {
                                gameController.p2Buildings[2] = "A1";
                            } else {
                                gameController.p2Buildings[2] = "D1";
                            }
                            break;
                    }
                    break;
                case 3:
                    switch (spot.name) {
                        case "Spot1Btn":
                            if (currentBuilding == buildingType.Attack) {
                                gameController.p3Buildings[0] = "A1";
                            } else {
                                gameController.p3Buildings[0] = "D1";
                            }
                            break;
                        case "Spot2Btn":
                            if (currentBuilding == buildingType.Attack) {
                                gameController.p3Buildings[1] = "A1";
                            } else {
                                gameController.p3Buildings[1] = "D1";
                            }
                            break;
                        case "Spot3Btn":
                            if (currentBuilding == buildingType.Attack) {
                                gameController.p3Buildings[2] = "A1";
                            } else {
                                gameController.p3Buildings[2] = "D1";
                            }
                            break;
                    }
                    break;

                case 4:
                    switch (spot.name) {
                        case "Spot1Btn":
                            if (currentBuilding == buildingType.Attack) {
                                gameController.p4Buildings[0] = "A1";
                            } else {
                                gameController.p4Buildings[0] = "D1";
                            }
                            break;
                        case "Spot2Btn":
                            if (currentBuilding == buildingType.Attack) {
                                gameController.p4Buildings[1] = "A1";
                            } else {
                                gameController.p4Buildings[1] = "D1";
                            }
                            break;
                        case "Spot3Btn":
                            if (currentBuilding == buildingType.Attack) {
                                gameController.p4Buildings[2] = "A1";
                            } else {
                                gameController.p4Buildings[2] = "D1";
                            }
                            break;
                    }
                    break;
            }

            gameManager.GetComponent<GameControllerScript>().Turn();
            selectSpotHolder.SetActive(false);
        } else if (selector.name == "UpgradeBtn") {
            //if you want to upgrade
            switch (teamTurn) {
                case 1:
                    switch (spot.name) {
                        case "Spot1Btn":
                            //sets what gets upgraded
                            switch (gameController.p1Buildings[0]) {
                                case "A1":
                                    gameController.p1Buildings[0] = "A2";
                                    break;
                                case "A2":
                                    gameController.p1Buildings[0] = "A3";
                                    break;
                                case "D1":
                                    gameController.p1Buildings[0] = "D2";
                                    break;
                                case "D2":
                                    gameController.p1Buildings[0] = "D3";
                                    break;
                                default:
                                    gameController.teamTurn -= 1;


                                    break;
                            }
                            break;
                        case "Spot2Btn":
                            switch (gameController.p1Buildings[1]) {
                                case "A1":
                                    gameController.p1Buildings[1] = "A2";
                                    break;
                                case "A2":
                                    gameController.p1Buildings[1] = "A3";
                                    break;
                                case "D1":
                                    gameController.p1Buildings[1] = "D2";
                                    break;
                                case "D2":
                                    gameController.p1Buildings[1] = "D3";
                                    break;
                                default:
                                    gameController.teamTurn -= 1;
                                    break;
                            }
                            break;
                        case "Spot3Btn":
                            switch (gameController.p1Buildings[2]) {
                                case "A1":
                                    gameController.p1Buildings[2] = "A2";
                                    break;
                                case "A2":
                                    gameController.p1Buildings[2] = "A3";
                                    break;
                                case "D1":
                                    gameController.p1Buildings[2] = "D2";
                                    break;
                                case "D2":
                                    gameController.p1Buildings[2] = "D3";
                                    break;
                                default:
                                    gameController.teamTurn -= 1;
                                    break;
                            }
                            break;
                    }
                    break;
                case 2:
                    switch (spot.name) {
                        case "Spot1Btn":
                            switch (gameController.p2Buildings[0]) {
                                case "A1":
                                    gameController.p2Buildings[0] = "A2";
                                    break;
                                case "A2":
                                    gameController.p2Buildings[0] = "A3";
                                    break;
                                case "D1":
                                    gameController.p2Buildings[0] = "D2";
                                    break;
                                case "D2":
                                    gameController.p2Buildings[0] = "D3";
                                    break;
                                default:
                                    gameController.teamTurn -= 1;
                                    break;
                            }
                            break;
                        case "Spot2Btn":
                            switch (gameController.p2Buildings[1]) {
                                case "A1":
                                    gameController.p2Buildings[1] = "A2";
                                    break;
                                case "A2":
                                    gameController.p2Buildings[1] = "A3";
                                    break;
                                case "D1":
                                    gameController.p2Buildings[1] = "D2";
                                    break;
                                case "D2":
                                    gameController.p2Buildings[1] = "D3";
                                    break;
                                default:
                                    gameController.teamTurn -= 1;
                                    break;
                            }
                            break;
                        case "Spot3Btn":
                            switch (gameController.p2Buildings[2]) {
                                case "A1":
                                    gameController.p2Buildings[2] = "A2";
                                    break;
                                case "A2":
                                    gameController.p2Buildings[2] = "A3";
                                    break;
                                case "D1":
                                    gameController.p2Buildings[2] = "D2";
                                    break;
                                case "D2":
                                    gameController.p2Buildings[2] = "D3";
                                    break;
                                default:
                                    gameController.teamTurn -= 1;
                                    break;
                            }
                            break;
                    }
                    break;
                case 3:
                    switch (spot.name) {
                        case "Spot1Btn":
                            switch (gameController.p3Buildings[0]) {
                                case "A1":
                                    gameController.p3Buildings[0] = "A2";
                                    break;
                                case "A2":
                                    gameController.p3Buildings[0] = "A3";
                                    break;
                                case "D1":
                                    gameController.p3Buildings[0] = "D2";
                                    break;
                                case "D2":
                                    gameController.p3Buildings[0] = "D3";
                                    break;
                                default:
                                    gameController.teamTurn -= 1;
                                    break;
                            }
                            break;
                        case "Spot2Btn":
                            switch (gameController.p3Buildings[1]) {
                                case "A1":
                                    gameController.p3Buildings[1] = "A2";
                                    break;
                                case "A2":
                                    gameController.p3Buildings[1] = "A3";
                                    break;
                                case "D1":
                                    gameController.p3Buildings[1] = "D2";
                                    break;
                                case "D2":
                                    gameController.p3Buildings[1] = "D3";
                                    break;
                                default:
                                    gameController.teamTurn -= 1;
                                    break;
                            }
                            break;
                        case "Spot3Btn":
                            switch (gameController.p3Buildings[2]) {
                                case "A1":
                                    gameController.p3Buildings[2] = "A2";
                                    break;
                                case "A2":
                                    gameController.p3Buildings[2] = "A3";
                                    break;
                                case "D1":
                                    gameController.p3Buildings[2] = "D2";
                                    break;
                                case "D2":
                                    gameController.p3Buildings[2] = "D3";
                                    break;
                                default:
                                    gameController.teamTurn -= 1;
                                    break;
                            }
                            break;
                    }
                    break;

                case 4:
                    switch (spot.name) {
                        case "Spot1Btn":
                            switch (gameController.p4Buildings[0]) {
                                case "A1":
                                    gameController.p4Buildings[0] = "A2";
                                    break;
                                case "A2":
                                    gameController.p4Buildings[0] = "A3";
                                    break;
                                case "D1":
                                    gameController.p4Buildings[0] = "D2";
                                    break;
                                case "D2":
                                    gameController.p4Buildings[0] = "D3";
                                    break;
                                default:
                                    gameController.teamTurn -= 1;
                                    break;
                            }
                            break;
                        case "Spot2Btn":
                            switch (gameController.p4Buildings[1]) {
                                case "A1":
                                    gameController.p4Buildings[1] = "A2";
                                    break;
                                case "A2":
                                    gameController.p4Buildings[1] = "A3";
                                    break;
                                case "D1":
                                    gameController.p4Buildings[1] = "D2";
                                    break;
                                case "D2":
                                    gameController.p4Buildings[1] = "D3";
                                    break;
                                default:
                                    gameController.teamTurn -= 1;
                                    break;
                            }
                            break;
                        case "Spot3Btn":
                            switch (gameController.p4Buildings[2]) {
                                case "A1":
                                    gameController.p4Buildings[2] = "A2";
                                    break;
                                case "A2":
                                    gameController.p4Buildings[2] = "A3";
                                    break;
                                case "D1":
                                    gameController.p4Buildings[2] = "D2";
                                    break;
                                case "D2":
                                    gameController.p4Buildings[2] = "D3";
                                    break;
                                default:
                                    gameController.teamTurn -= 1;
                                    break;
                            }
                            break;
                    }
                    break;
            }
            //goes to next teams turn
            gameManager.GetComponent<GameControllerScript>().Turn();
            selectSpotHolder.SetActive(false);

        } else {
            //do build, upgrade or actual atack function
            Debug.Log("does action! next teams turn!");
            //Goes to next teams turn
            gameManager.GetComponent<GameControllerScript>().Turn();
            selectSpotHolder.SetActive(false);
        }
    }

    public void failedAssignment() {
        gameManager.GetComponent<GameControllerScript>().Turn();
        selectSpotHolder.SetActive(false);
    }
}
