﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour {

    public void PlayGame(int buildIndex)
    {       
        SceneManager.LoadScene(buildIndex);
    }
}
