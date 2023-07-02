using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayController : MonoBehaviour
{
    public static GamePlayController instance;

    [HideInInspector]
    public int selectedCharacter = 0;

    [SerializeField]
    private int char2UnlockScore = 200, char3UnlockScore = 500;

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

        /*Debug.Log("Game data value: " + gameData);*/

        if(gameData == 0 )
        {

            // first time running the game, initialize data
            selectedCharacter = 0;

            DataManager.SaveData(TagManager.SELECTED_CHARACTER_DATA, selectedCharacter);

            DataManager.SaveData(TagManager.HIGHSCORE_DATA, 0);

            DataManager.SaveData(TagManager.MUSIC_DATA, 1);

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

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }


    void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
    {
        
        if(scene.name == TagManager.GAMEPLAY_SCENE_NAME)
        {
            //SoundManager.instance.PlayBGMusic(true);

            Instantiate(player[selectedCharacter]);     

            Camera.main.GetComponent<CameraFollow>().PlayerRefernece();
        }
        else
        {
            //SoundManager.instance.PlayBGMusic(false);
        }

    }


    public void CheckToUnlockCharacter(int score)
    {
        if(score > char3UnlockScore)
        {
            DataManager.SaveData(TagManager.CHARACTER_DATA + "1", 1);
            DataManager.SaveData(TagManager.CHARACTER_DATA + "2", 1);
        }

        else if(score > char2UnlockScore)
            DataManager.SaveData(TagManager.CHARACTER_DATA + "1", 1);
    }

}
