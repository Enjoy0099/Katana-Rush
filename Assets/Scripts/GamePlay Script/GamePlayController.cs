using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayController : MonoBehaviour
{
    public static GamePlayController instance;

    [HideInInspector]
    public int selectedCharacter = 0;

    [SerializeField]
    private int char2UnlockScore = 10, char3UnlockScore = 20;

    [SerializeField]
    private GameObject[] player;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }
    }

    private void Start()
    {


        //check if game is initialized
        int gameData = DataManager.GetData(TagManager.DATA_INITIALIZED);

        Debug.Log("Game data value: " + gameData);

        if(gameData == 0 )
        {
            // first time running the game, initialize data
            selectedCharacter = 0;

            DataManager.SaveData(TagManager.SELECTED_CHARACTER_DATA, selectedCharacter);

            DataManager.SaveData(TagManager.HIGHSCORE_DATA, 0);

            DataManager.SaveData(TagManager.CHARACTER_DATA + "0", 1);
            DataManager.SaveData(TagManager.CHARACTER_DATA + "1", 0);
            DataManager.SaveData(TagManager.CHARACTER_DATA + "2", 0);

            DataManager.SaveData(TagManager.DATA_INITIALIZED, 1);
        }
        else if(gameData == 1)
        {
            selectedCharacter = DataManager.GetData(TagManager.SELECTED_CHARACTER_DATA);
        }

    }



}
