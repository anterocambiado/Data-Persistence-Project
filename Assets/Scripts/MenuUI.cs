using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    public TMP_InputField playerName;
    // Start is called before the first frame update
    void Start()
    {
        if (SaveSystem.Instance.highScore != 0)
        {
            playerName.text = SaveSystem.Instance.playerName;
        }
        //DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {

            SaveSystem.Instance.SetCurrentPlayerName(playerName.text);
            gameObject.SetActive(false);
            SceneManager.LoadScene(1);


        }
    }

    public void StartNew()
    {
        SaveSystem.Instance.SetCurrentPlayerName(playerName.text);
        gameObject.SetActive(false);
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif
    }
}