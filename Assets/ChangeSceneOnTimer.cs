using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ChangeSceneOnTimer : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.LoadScene("IntroCutscene2", LoadSceneMode.Single);
    }
}
