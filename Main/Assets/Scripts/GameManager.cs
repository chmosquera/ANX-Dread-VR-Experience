﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SH;

public enum GameState { Intro, Crash, Recover }

public class GameManager : MonoBehaviour {

    public ControlPanelManager cpManager;
    public ShakyHandsManager shManager;
    public HallwayManager hwManager;
    

    [SerializeField] private GameState gameState;

    void Start()
    {
        gameState = GameState.Intro;
    }

    void Update() {

        cpManager.gameState = this.gameState;
        shManager.gameState = this.gameState;
        hwManager.gameState = this.gameState;

        switch (gameState) {
            case GameState.Intro:
                
                break;
            case GameState.Crash:
                
                break;
            case GameState.Recover:
                
                break;

        }
    }

    public void ChangeGameState(GameState gs)
    {
        gameState = gs;
    }

}
