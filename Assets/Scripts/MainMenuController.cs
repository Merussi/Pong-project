using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public TextMeshProUGUI uiWinner;


    void Start()
    {
        SavedController.Instance.Reset();
        string lastWinner = SavedController.Instance.GetLastWinner();

        if (lastWinner != "")
            uiWinner.text = "Ultimo vencedor: " + lastWinner;
        else
            uiWinner.text = "";
    }

    
}
