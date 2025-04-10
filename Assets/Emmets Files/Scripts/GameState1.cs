using UnityEngine;

public class GameState1 : BaseGameState
{
   
    public override void EnterState(GameStateManager gState)
    {
        if (gState.round < 5) 
        {
            gState.npcAmount += 5;
            Debug.Log("increased NPC amount");
        }
       
        gState.SpawnNPC();
        
        
    }

    public override void UpdateState(GameStateManager gState)
    {
        if (gState.curentAmount == 0)
        {
            gState.SwitchState(gState.gameStateStart);
           gState.Playbutton.SetActive(true);
        }
    }   
    public override void OnCollisionEnter(GameStateManager gState)
    {

    }

   
}
