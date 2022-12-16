using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventScript : MonoBehaviour
{
    public Sprite[] events;
    public Image eventImage;
    public int eventNumber;
    public GameObject RoundStartHolder;
    public GameObject gameController;
    public Text eventTxt;
    public int teamTurn;
    public GameObject acceptBtn;

    public void startEvent() {
        acceptBtn.SetActive(true);
        eventNumber = Random.Range(0, events.Length);
        eventImage.sprite = events[eventNumber];
        teamTurn = gameController.GetComponent<GameControllerScript>().teamTurn;

        switch (eventNumber) {
            case 0:
                //dannebrog falder event
                eventTxt.text = "Dannebrog falder";
                gameController.GetComponent<GameControllerScript>().arrayTeamHealth[teamTurn - 1] += 4;
                gameController.GetComponent<GameControllerScript>().setHealth();
                break;
            case 1:
                //Nuke event
                eventTxt.text = "Hiroshima & Nagasaki";
                for (int i = 0; i < gameController.GetComponent<GameControllerScript>().arrayTeamHealth.Length; i++) {
                    for (int j = 0; j < gameController.GetComponent<GameControllerScript>().p1Buildings.Length; j++) {
                        switch (i) {
                            case 0:
                                if (gameController.GetComponent<GameControllerScript>().p1Buildings[j] != "") {
                                    gameController.GetComponent<GameControllerScript>().arrayTeamHealth[i] -= 4;
                                }
                                break;
                            case 1:
                                if (gameController.GetComponent<GameControllerScript>().p2Buildings[j] != "") {
                                    gameController.GetComponent<GameControllerScript>().arrayTeamHealth[i] -= 4;
                                }
                                break;
                            case 2:
                                if (gameController.GetComponent<GameControllerScript>().p3Buildings[j] != "") {
                                    gameController.GetComponent<GameControllerScript>().arrayTeamHealth[i] -= 4;
                                }
                                break;
                            case 3:
                                if (gameController.GetComponent<GameControllerScript>().p4Buildings[j] != "") {
                                    gameController.GetComponent<GameControllerScript>().arrayTeamHealth[i] -= 4;
                                }
                                break;
                        }
                    }
                    gameController.GetComponent<GameControllerScript>().setHealth();
                }
                break;
            case 2:
                //nordsøen event
                eventTxt.text = "Danmark giver nordsøen til Norge";
                gameController.GetComponent<GameControllerScript>().arrayTeamHealth[teamTurn - 1] -= 3;
                if (gameController.GetComponent<GameControllerScript>().arrayTeamHealth[teamTurn - 1] == gameController.GetComponent<GameControllerScript>().arrayTeamHealth.Length - 1) {
                    gameController.GetComponent<GameControllerScript>().arrayTeamHealth[0] += 3;
                } else {
                    gameController.GetComponent<GameControllerScript>().arrayTeamHealth[teamTurn] += 3;
                }
                gameController.GetComponent<GameControllerScript>().setHealth();

                break;
            case 3:
                //Tsunami event
                eventTxt.text = "Meget vand rammer Japan";
                StartCoroutine(skipTurn());
                acceptBtn.SetActive(false);
                break;
        }
    }

    IEnumerator skipTurn() {
        yield return new WaitForSeconds(10);
        gameController.GetComponent<GameControllerScript>().Turn();
        this.gameObject.SetActive(false);
    }
}
