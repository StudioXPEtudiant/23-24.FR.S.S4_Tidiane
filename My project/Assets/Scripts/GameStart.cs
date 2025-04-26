using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public void ChangeScene(string menu du début)
    {
        SceneManager.LoadScene(partie);
    }
}