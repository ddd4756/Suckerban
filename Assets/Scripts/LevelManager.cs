﻿using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private List<SuckerbanObject> allObjects = new List<SuckerbanObject>();
    private AudioSource audio;
    public Player currentPlayer;
    public GameObject gameOverScreen;

    void Awake()
    {
        audio = GetComponent<AudioSource>();
        gameOverScreen.SetActive(false);
    }
    
	void Update () {

        // Restart current scene
        if (Input.GetKeyDown(KeyCode.R)) {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.buildIndex);
        }
    }

    public void Add(SuckerbanObject obj)
    {
        allObjects.Add(obj);
    }

    public SuckerbanObject GetObjectInPosition(IntVector2 position)
    {
        // Return the first object in given position 
        foreach(SuckerbanObject obj in allObjects) {
            if (obj.positions.Contains(position)) {
                return obj;
            }
        }
        return null;
    }

    public void gameOver()
    {
        Debug.Log("YOU DIED");
        audio.Play();
        gameOverScreen.SetActive(true);
        Destroy(currentPlayer.transform.gameObject);
    }
}
