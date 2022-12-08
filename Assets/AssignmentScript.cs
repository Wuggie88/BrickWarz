using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssignmentScript : MonoBehaviour
{
    public Sprite[] AssLevelOne;
    public Sprite[] AssLevelTwo;
    public Sprite[] AssLevelThree;
    public Image AssContainer;
    public int SelectedAss;
    public float TimerValue;
    public GameObject Manager;
    public Text AssTimerTxt;
    public int level;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        if (TimerValue > 0.4f) {
            TimerValue -= 0.02f;
            AssTimerTxt.text = TimerValue.ToString("#");
            if (TimerValue <= 10f) {
                AssTimerTxt.color = Color.red;
            }
        } else if (TimerValue <= 0.4f) {
            TimerValue = 0f;
            AssTimerTxt.text = "0";
        }           
    }

    public void StartAss() {
        SelectAss();
        TimerValue = Manager.GetComponent<ManagerScript>().roundTimer;
        AssTimerTxt.color = Color.white;
    }

    public void SelectAss() {
        switch (level) {
            case 1:
                SelectedAss = Random.Range(0, AssLevelOne.Length);

                AssContainer.sprite = AssLevelOne[SelectedAss];
                break;
            case 2:
                SelectedAss = Random.Range(0, AssLevelTwo.Length);

                AssContainer.sprite = AssLevelTwo[SelectedAss];

                break;
            case 3:
                SelectedAss = Random.Range(0, AssLevelThree.Length);

                AssContainer.sprite = AssLevelThree[SelectedAss];
                break;
        }
    }
}
