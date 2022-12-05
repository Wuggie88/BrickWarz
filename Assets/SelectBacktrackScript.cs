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
            case "BuildNewBtn":
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
                        break;
                    case 2:
                        for (int i = 0; i < gameController.p2Buildings.Length; i++) {
                            if (gameController.p2Buildings[i] == "") {
                                spots[i].SetActive(true);
                            } else {
                                spots[i].SetActive(false);
                            }
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
                            break;
                    case 4:
                        for (int i = 0; i < gameController.p4Buildings.Length; i++) {
                            if (gameController.p4Buildings[i] == "") {
                                spots[i].SetActive(true);
                            } else {
                                spots[i].SetActive(false);
                            }
                        }
                            break;

                }

                break;
            case "UpgradeBtn":
                parent = buildHolder;
                //set text in GUI to what building you want to upgrade
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
        if (selector.name == "AttackBtn") {
            //if you attack, you will get to choose which enemy team to attack
            spot = spotBtn;
            selectEnemyHolder.SetActive(true);
        }
        else
        {
            //do build, upgrade or actual atack function
            Debug.Log("does action! next teams turn!");
            //Goes to next teams turn
            gameManager.GetComponent<GameControllerScript>().Turn();
            roundStartHolder.SetActive(true);
            selectSpotHolder.SetActive(false);
        }
    }
}
