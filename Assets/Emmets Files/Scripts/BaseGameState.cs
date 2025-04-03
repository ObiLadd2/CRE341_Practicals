using UnityEngine;

public abstract class BaseGameState
{



    public abstract void EnterState(GameStateManager gState);


    public abstract void UpdateState(GameStateManager gState);


    public abstract void OnCollisionEnter(GameStateManager gState);

}


