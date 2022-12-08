using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ConfirmScript : MonoBehaviour
{
    public bool emptySpot;
    public GameObject gameController;
    public GameControllerScript gameControllerScript;
    public Button confirmBtn;
    public int player;
    public Text confirmTitle;


    private void Start() {
        StartCoroutine(ConfirmLogic());
    }

    IEnumerator ConfirmLogic() {
        emptySpot = false;
        gameControllerScript = gameController.GetComponent<GameControllerScript>();
        player = gameControllerScript.teamTurn;
        confirmTitle.text = "Build new building";

        switch (player) {
            case 1:
                for (int i = 0; i < gameControllerScript.p1Buildings.Length; i++) {
                    if (gameControllerScript.p1Buildings[i] == "") {
                        emptySpot = true;
                        break;
                    }
                }
                break;
            case 2:
                for (int i = 0; i < gameControllerScript.p2Buildings.Length; i++) {
                    if (gameControllerScript.p2Buildings[i] == "") {
                        emptySpot = true;
                        break;
                    }
                }
                break;
            case 3:
                for (int i = 0; i < gameControllerScript.p3Buildings.Length; i++) {
                    if (gameControllerScript.p3Buildings[i] == "") {
                        emptySpot = true;
                        break;
                    }
                }
                break;
            case 4:
                for (int i = 0; i < gameControllerScript.p4Buildings.Length; i++) {
                    if (gameControllerScript.p4Buildings[i] == "") {
                        emptySpot = true;
                        break;
                    }
                }
                break;
        }
        yield return new WaitForEndOfFrame();
        if(emptySpot == false) {
            confirmBtn.gameObject.SetActive(false);
            confirmTitle.text = "No free spots";
        }

    }
    void startConfirm() {
        StartCoroutine(ConfirmLogic());
    }
}
