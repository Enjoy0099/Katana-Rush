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

    private void Start()
    {
        highScoreTxt.text = "HighScore: " + DataManager.GetData(TagManager.HIGHSCORE_DATA) + "m";
        charSelectMenu = GetComponent<CharacterSelectMenu>();
    }

    public void openCloseCharacterSelectMenu(bool open)
    {
        characterSelectMenuPanel.SetActive(open);
    }

    public void SelectCharacter()
    {
        int selectedChar =
            int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

    }


    public void PlayGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(TagManager.GAMEPLAY_SCENE_NAME);
    } 

}
