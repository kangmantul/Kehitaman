using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadHandler_PlayerPref : MonoBehaviour
{
    void Start()
    {
        //save data
        PlayerPrefs.SetString("username", "binusian");
        PlayerPrefs.SetString("bgm", "test123");
        PlayerPrefs.SetInt("exp", 1001);

        //read data
        PlayerPrefs.GetString("username");
        PlayerPrefs.GetInt("exp");

        //json
    }

}
