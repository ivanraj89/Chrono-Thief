using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UiController : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI savedText;

    private void Awake()
    {
        SceneCheck();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(2); 
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(2);
    }

    public void Tutorial()
    {
        SceneManager.LoadScene(1);
    }

    public void SceneCheck() // check to see if current scene is game over scene and if it is then load saved score into the text field
    {
        Scene currenScene = SceneManager.GetActiveScene();

        string sceneName = currenScene.name;

        if(sceneName == "GOverScene")
        {
            MainControl.Instance.LoadScore();
            savedText.text = $"{MainControl.Instance.playerScore}";

        }
    }

}
