using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataManager
{


    // int's are going to represent bool's
    // 0 will be false, 1 will be true;


    public static void SaveData(string dataName, int value)
    {
        PlayerPrefs.SetInt(dataName, value);
    }

    public static int GetData(string dataName)
    {
        return PlayerPrefs.GetInt(dataName);
    }



}

