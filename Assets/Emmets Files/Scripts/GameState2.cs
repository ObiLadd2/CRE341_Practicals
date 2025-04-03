using UnityEngine;

public class GameState2: BaseGameState
{

    public override void EnterState(GameStateManager gState)
    {
        Debug.Log("Checking for NPCS");
    }

    public override void UpdateState(GameStateManager gState)
    {
       if(gState.curentAmount <= 0)
        {
            gState.SwitchState(gState.gameStateStart);
            gState.Playbutton.SetActive(true);
        }
    }
    public override void OnCollisionEnter(GameStateManager gState)
    {

    }
}
