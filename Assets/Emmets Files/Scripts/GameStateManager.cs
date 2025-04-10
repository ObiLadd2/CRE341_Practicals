using UnityEngine;
using UnityEngine.UI;




public class GameStateManager : MonoBehaviour
{
    public static GameStateManager instance;
    public MapGenerator mapGenerator;

   
    public  int npcAmount;  //the number of npcs that will spawn
    public int curentAmount;  // current number of npcs on the board
    public int round; // current Round

   // public int RestartSequenceAtThisAmount = 0;// wouldnt switch state hwen curentamount was 0 so checking for different kind of value.
    public GameObject Playbutton;
                            
    BaseGameState CurentState;
    public GameStateStart gameStateStart = new GameStateStart();
    public GameState1 gameState1 = new GameState1();
    private void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        CurentState = gameStateStart;

        CurentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        CurentState.UpdateState(this);
        Debug.Log(CurentState);

       
    }
    public void SwitchState(BaseGameState state)
    {
        CurentState = state;
        state.EnterState(this);
    }
    public void SpawnNPC() 
    {
        mapGenerator.SpawnNPCs(npcAmount);
        curentAmount = npcAmount;// 
        
    }
    public void StartSpawnSequence()//starts the spawning sequence when the player presses play
    {
       SwitchState(gameState1);//swiches states to gradually increase the amount of enemies spawning
        round += 1;
        Playbutton.SetActive(false);
        Debug.Log(round);
    }
}
