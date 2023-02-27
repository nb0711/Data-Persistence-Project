using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dataHelper : MonoBehaviour
{
    public static dataHelper Instance;

    public int bestScore;
    public string bestPlayerName;
    public string playerName;

    private void Awake()
    {
        if (Instance != null)  // Eğer scene yeniden yüklenirse mesela alt bir sahne açılıp tekrar geri gelidiğinde bu scrip yeniden oluşur ve 2 tane ayni scrip ten olur. bu sebeple son oluşturulan scrip bu sorguyla yok edilir.
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadScore(); // Diskten BestScore yi çek

    }


    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    [System.Serializable]  // JSON'a dönüştürmek için bunu eklemek zorundayız.
    class SaveData
    {
        public int bestScore;
        public string bestPlayerName;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.bestScore = bestScore;
        data.bestPlayerName = bestPlayerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }


    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestScore = data.bestScore;
            bestPlayerName = data.bestPlayerName;
        }
        else  // Dosya bulunamadı daha önceden best score olmamış
        {
            bestScore = 0;
            bestPlayerName = "";
        }

        Debug.Log("bestScore : " + bestScore);
        Debug.Log("bestPlayerName : " + bestPlayerName);
    }
}
