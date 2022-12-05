using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectBacktrackScript : MonoBehaviour
{
    public GameObject buildHolder, actionHolder, selectEnemyHolder;
    public GameObject parent;

    public GameObject spot;
    public GameObject selector;

    //Remebers the selector & action
    public void SetSelector(GameObject action)
    {
        selector = action;
        switch (selector.name)
        {
            case "BuildNewBtn":
                parent = buildHolder;
                //set text in GUI to what building you want to build
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
        spot = spotBtn;
    }
}
