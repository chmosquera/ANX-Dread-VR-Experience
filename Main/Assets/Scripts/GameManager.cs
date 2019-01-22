using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SH;

public enum GameState { Intro, Crash, Recover }

public class GameManager : MonoBehaviour {

    public ControlPanelManager cpManager;
    public ShakyHandsManager shManager;
    

    [SerializeField] private GameState gameState;

    void Start()
    {
        gameState = GameState.Intro;
    }

    void Update() {

        cpManager.gameState = this.gameState;
        shManager.gameState = this.gameState;

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

 //   public OpenScreenScript openScreenBtn;
 //   public GameObject SH_Door;
 //   public FocusSphere fadeOutSphere;
 //   public Light CR_areaLight;

 //   private GameState gameState;

 //   // Use this for initialization
 //   void Start () {
 //       gameState = GameState.Intro;
	//}
	
	//// Update is called once per frame
	//void Update () {

 //       // trigger a scene state transition
 //       if (openScreenBtn.screenActive == true) gameState = GameState.ShakyHands;

 //       // update according to scenestate
 //           switch (gameState) {
 //           case GameState.Intro:
 //               SH_Door.GetComponentInChildren<door>().doorstate = SH.DoorState.closed;
 //               CR_areaLight.intensity = 0.1f;
 //               break;
 //           case GameState.ShakyHands:
 //               fadeOutSphere.fadeActive = true;
 //               //SH_Door.GetComponentInChildren<door>().doorstate = SH.DoorState.broken;
 //               SH_Door.GetComponentInChildren<door>().SetBroken();
 //               if (CR_areaLight.intensity < 1.0f) {
 //                   CR_areaLight.intensity += 0.01f;
 //               }
 //               break;

 //       }        
	//}

 //   public void SwitchGameState(GameState gs)
 //   {
 //       gameState = gs;
 //   }
}
