using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePosition : MonoBehaviour
{
    private string saveKey = "PlayerPosition";
    private void Start()
    {
        LoadPosition();
    }
    private void OnApplicationQuit()
    {
        SaveCurrentPosition();
    }
    public void SaveCurrentPosition()
    {
        Vector3 currentPosition = transform.position;

        PlayerPrefs.SetFloat(saveKey + "X", currentPosition.x);
        PlayerPrefs.SetFloat(saveKey + "Y", currentPosition.y);
        PlayerPrefs.SetFloat(saveKey + "Z", currentPosition.z);

        PlayerPrefs.Save();
    }

    public void LoadPosition()
    {
        if (PlayerPrefs.HasKey(saveKey + "X"))
        {
            float x = PlayerPrefs.GetFloat(saveKey + "X");
            float y = PlayerPrefs.GetFloat(saveKey + "Y");
            float z = PlayerPrefs.GetFloat(saveKey + "Z");

            transform.position = new Vector3(x, y, z);
        }
    }
}
