using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void NextScene(int index)
    {
        SceneManager.LoadScene("HwengSroll");
        PlayerPrefs.SetInt("savePoint", index);
    }

    public void NextScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
