using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SH;

public enum GameState { Intro, Crash, Recover }

public class GameManager : MonoBehaviour {

    public ControlPanelManager cpManager;
    public ShakyHandsManager shManager;
    public HallwayManager hwManager;


    public GameObject HUD;


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

        activateHUD();

    }

    public void activateHUD()
    {
        if(this.gameState != GameState.Intro) {
        //    print("hi");
            HUD.SetActive(true);
        }
    }

	public GameState GetGameState() {
		return this.gameState;
	}

    public void ChangeGameState(GameState gs)
    {
        gameState = gs;
    }

    public void EnableHallwayManager() {
        hwManager.Enable();
    }

}
