using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectBacktrackScript : MonoBehaviour
{
    public GameObject gameManager, roundStartHolder, selectSpotHolder;
    public GameObject buildHolder, actionHolder, selectEnemyHolder;
    public GameObject[] spots;
    public GameObject parent;

    public GameObject spot;
    public GameObject selector;
    public int teamTurn;
    public GameControllerScript gameController;

    public enum buildingType { Attack, Defence};
    public buildingType currentBuilding;

    private void Start() {
        gameController = gameManager.GetComponent<GameControllerScript>();
    }

    //Remebers the selector & action
    public void SetSelector(GameObject action)
    {   
        teamTurn = gameController.teamTurn;
        selector = action;
        switch (selector.name)
        {
            case "BuildNewAttackBtn": case "BuildNewDefBtn":
                parent = buildHolder;
                switch (teamTurn){
                    case 1:
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
                //set text in GUI to what building you want to use
                break;
            default:
                //selected enemy, going to select enemy's building
                parent = selectEnemyHolder;
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
            //if you attack, you will get to choose which enemy team to attack
            
            selectEnemyHolder.SetActive(true);
        } else if (selector.name == "BuildNewAttackBtn" || selector.name == "BuildNewDefBtn") {

            switch (teamTurn) {
                case 1:
                    switch (spot.name) {
                        case "Spot1Btn":
                            if(currentBuilding == buildingType.Attack) {
                                gameController.p1Buildings[0] = "A1";
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
            roundStartHolder.SetActive(true);
            selectSpotHolder.SetActive(false);
        } else if (selector.name == "UpgradeBtn") {
            switch (teamTurn) {
                case 1:
                    switch (spot.name) {
                        case "Spot1Btn":
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

            gameManager.GetComponent<GameControllerScript>().Turn();
            roundStartHolder.SetActive(true);
            selectSpotHolder.SetActive(false);

        }
        else {
            //do build, upgrade or actual atack function
            Debug.Log("does action! next teams turn!");
            //Goes to next teams turn
            gameManager.GetComponent<GameControllerScript>().Turn();
            roundStartHolder.SetActive(true);
            selectSpotHolder.SetActive(false);
        }
    }
}
