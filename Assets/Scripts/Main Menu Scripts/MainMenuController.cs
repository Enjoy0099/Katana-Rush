using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject characterSelectMenuPanel;

    [SerializeField]
    private Text highScoreTxt;

    private CharacterSelectMenu charSelectMenu;

    [SerializeField]
    private Image musicImg;

    [SerializeField]
    private Sprite musicOnSprite, musicOffSprite;

    private void Awake()
    {
        if(DataManager.GetData(TagManager.MUSIC_DATA) == 1)
        {
            musicImg.sprite = musicOnSprite;
        }
        else
        {
            musicImg.sprite = musicOffSprite;
        }
    }


    private void Start()
    {
        highScoreTxt.text = "HighScore: " + DataManager.GetData(TagManager.HIGHSCORE_DATA) + "m";
        charSelectMenu = GetComponent<CharacterSelectMenu>();
    }

    public void openCloseCharacterSelectMenu(bool open)
    {
        if(open)
        {
            charSelectMenu.InitializeCharacterMenu();
        }

        characterSelectMenuPanel.SetActive(open);
    }

    public void SelectCharacter()
    {
        int selectedChar =
            int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

        GamePlayController.instance.selectedCharacter = selectedChar;

        DataManager.SaveData(TagManager.SELECTED_CHARACTER_DATA, selectedChar);

        charSelectMenu.InitializeCharacterMenu();
    }


    public void PlayGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(TagManager.GAMEPLAY_SCENE_NAME);
    } 



    public void TurnMusicOn_Off()
    {
        if (DataManager.GetData(TagManager.MUSIC_DATA) == 1)
        {
            DataManager.SaveData(TagManager.MUSIC_DATA, 0);
            musicImg.sprite = musicOffSprite;
            SoundManager.instance.StopBGMusic();    
        }
        else
        {
            DataManager.SaveData(TagManager.MUSIC_DATA, 1);
            musicImg.sprite = musicOnSprite;
            SoundManager.instance.PlayBGMusic(false);
        }
    }

}
