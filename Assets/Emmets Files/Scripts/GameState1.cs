using UnityEngine;

public class GameState1 : BaseGameState
{
   
    public override void EnterState(GameStateManager gState)
    {
        gState.npcAmount += 5;
        gState.SpawnNPC();
        
        
    }

    public override void UpdateState(GameStateManager gState)
    {
        if (gState.curentAmount <= gState.RestartSequenceAtThisAmount)
        {
            gState.SwitchState(gState.gameStateStart);
            gState.Playbutton.SetActive(true);
        }
    }   
    public override void OnCollisionEnter(GameStateManager gState)
    {

    }

   
}
