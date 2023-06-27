using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectMenu : MonoBehaviour
{

    [SerializeField]
    private Button[] charSelectButtons;

    [SerializeField]
    private GameObject[] selectedCharCheckbox;


    public void InitializeCharacterMenu()
    {
        for(int i=0; i<charSelectButtons.Length; i++)
        {
            int charData = DataManager.GetData(TagManager.CHARACTER_DATA + i.ToString());

            if(charData == 0)
            {
                charSelectButtons[i].interactable = false; 
            }

            selectedCharCheckbox[i].SetActive(false);
        }

        selectedCharCheckbox[DataManager.GetData(TagManager.SELECTED_CHARACTER_DATA)].SetActive(true);


    }








}
