using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SavedController : MonoBehaviour
{
    public Color colorPlayer = Color.white;
    public Color colorEnemy = Color.white;

    public string namePlayer;
    public string nameEnemy;

    private string saveWinnerKey = "SavedWinner";

    
    private static SavedController _instance;

    public static SavedController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<SavedController>();

                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(SavedController).Name);
                    _instance = singletonObject.AddComponent<SavedController>();
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        DontDestroyOnLoad(this.gameObject);
    }
    public string GetName(bool isPlayer)
    {
        return isPlayer ? namePlayer : nameEnemy;
    }

    public void Reset()
    {
        nameEnemy = "";
        namePlayer = "";
        colorEnemy = Color.white;
        colorPlayer = Color.white;
    }

    public void SaveWinner(string winner)
    {
        PlayerPrefs.SetString(saveWinnerKey, winner);
    }

    public string GetLastWinner()
    {
        return PlayerPrefs.GetString(saveWinnerKey);
    }

    public void ClearSave()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
