using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class difficulty : MonoBehaviour
{
    private Button button;
    private gameManager _gameManager;
    public int difficultyNum;
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
        _gameManager = GameObject.Find("Game Manager").GetComponent<gameManager>();
    }

    void SetDifficulty()
    {
        _gameManager.StartGame(difficultyNum);
    }
}
