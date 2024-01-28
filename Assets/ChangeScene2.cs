using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ChangeScene2 : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.LoadScene("Tutorial", LoadSceneMode.Single);
    }
}
