using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScript : MonoBehaviour
{
    public int teams = 0;

    public void setTeams(int data)
    {
        Debug.Log("Manager script reached");
        teams = data;
    }
}
