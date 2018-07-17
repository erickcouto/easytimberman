using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TryAgain : MonoBehaviour
{

    public void GameBegin()
    {

        Soundmanager.instance.playSound(Soundmanager.instance.play);
        SceneManager.LoadScene("Game");

    }
}