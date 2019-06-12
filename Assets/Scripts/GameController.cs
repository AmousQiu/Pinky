﻿using UnityEngine;

public class GameController : MonoBehaviour
{
    private DataController dataController;
    private GameData gameData;
    private GameSceneData gameSceneData;
    private string winScene, gameOverScene;
    public GameObject startScene,gameScene;
    void OnEnable()
    {
       
        //Declaring our DataController reference.//
        dataController = FindObjectOfType<DataController>();
        gameData = dataController.GetGameData();
        gameSceneData = gameData.gameSceneData;
        int wicksNeededToWin = gameSceneData.wicksNeededToWin;
        PlayerController.SetWicksNeededToWin(wicksNeededToWin);

        float forceOfGravity = gameSceneData.forceOfGravity;
        PlayerController.setForceofGravity(forceOfGravity);

        float sideVelocity = gameSceneData.sideVelocity;
        PlayerController.setSideVelocity(sideVelocity);

        float upThrust = gameSceneData.upThrust;
        PlayerController.setUpThrust(upThrust);

        float wickHeight = gameSceneData.wickHeight;
        Candle.setWickHeight(wickHeight);

        float stickHeight = gameSceneData.stickHeight;
        Candle.setStickHeight(stickHeight); 

        winScene = gameSceneData.winScene;
        gameOverScene = gameSceneData.gameOverScene;
    }
}