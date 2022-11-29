using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnScript : MonoBehaviour
{
    public int teams = 0;
    public GameObject manager;

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
