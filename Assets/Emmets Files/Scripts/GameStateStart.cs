using UnityEngine;

public class GameStateStart: BaseGameState
{


   
    public override void EnterState(GameStateManager gState)
    {
        gState.Playbutton.SetActive(true);
    }

    public override void UpdateState(GameStateManager gState)
    {
        
    }
    public override void OnCollisionEnter(GameStateManager gState)
    {

    }

}
