using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainControl : MonoBehaviour
{
    public static MainControl Instance;
    public int playerScore;

    // Start is called before the first frame update

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    [System.Serializable]
    class SaveData
    {
        public int playerScore; 
    }
    public void SaveScore()
    {
        SaveData myData = new SaveData();
        myData.playerScore = playerScore;
        string json = JsonUtility.ToJson(myData);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData myData = JsonUtility.FromJson<SaveData>(json);
            playerScore = myData.playerScore;
        }
    }



}
