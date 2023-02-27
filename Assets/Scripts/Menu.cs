using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Menu : MonoBehaviour
{
    public Button playButton;
    public TMP_InputField playerName;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayGame()
    {
        if (playerName.text != "")
        {
            dataHelper.Instance.playerName = playerName.text;
            SceneManager.LoadScene(1);
        }
    }

}
