using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TargetCounterManager : MonoBehaviour
{
    public static int Targets_Hit = 0;
    public TextMeshProUGUI TargetsText = null;
    public QuitGame quit;

    void Start()
    {
        Targets_Hit = 0;
        TargetsText.text = "Targets Hit: 0/5";
    }

    public void updateCount()
    {
        Targets_Hit++;
        TargetsText.text = "Targets Hit: " + Targets_Hit.ToString() + "/5";

        if (Targets_Hit == 5)
        {
            quit.gameOverFunction(true, false);
        }
    }

}
