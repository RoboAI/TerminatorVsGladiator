using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    GameObject Player1;
    GameObject Player2;
    HealthBar Player1_HealthBar;
    HealthBar Player2_HealthBar;
    PlayerData player1Data;
    PlayerData player2Data;

    GameRoundTimer gameRoundTimer;

    public CountdownImages countdownImages;

    public Animator animator;

    public GameEndedImage gameOver;
    public GameEndedImage gameTimesUp;
    public GameEndedImage gamePaused;

    public bool isGamePaused = true;
    public bool isGameEnded = false;

    public int roundTimeInSeconds = 45;

    Coroutine playerWonTask;
    GameObject playerWon;

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        //gameOver = GameObject.Find("GameOverPanel").GetComponent<GameOver>();
        gameOver.Hide();
        gameTimesUp.Hide();
        gamePaused.Hide();

        Player1 = GameObject.Find("PlayerMain1");
        Player2 = GameObject.Find("PlayerMain2");

        player1Data = Player1.GetComponent<PlayerData>();
        player1Data.playerNumber = 1;
        player1Data.otherPlayerNumber = 2;

        player2Data = Player2.GetComponent<PlayerData>();
        player2Data.playerNumber = 2;
        player2Data.otherPlayerNumber = 1;

        Player1_HealthBar = GameObject.Find("Player1_Health").GetComponent<HealthBar>();
        Player1_HealthBar.iAmBarOnLeft = true;
        Player1_HealthBar.playerData = Player1.GetComponent<PlayerData>();
        Player1.GetComponent<PlayerInputs>().AssignKeys(KeyCode.A, KeyCode.D, KeyCode.W, KeyCode.Space);
        Player1.GetComponent<PlayerData>().healthBar = Player1_HealthBar;

        Player2_HealthBar = GameObject.Find("Player2_Health").GetComponent<HealthBar>();
        Player2_HealthBar.iAmBarOnLeft = false;
        Player2_HealthBar.playerData = Player2.GetComponent<PlayerData>();
        Player2.GetComponent<PlayerInputs>().AssignKeys(KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.KeypadEnter);
        Player2.GetComponent<PlayerData>().healthBar = Player2_HealthBar;

        gameRoundTimer = GameObject.Find("TimeDisplay").GetComponent<GameRoundTimer>();

        countdownImages = GameObject.Find("CountdownSprites").GetComponent<CountdownImages>();

        BeginRoundCountDown();

        //GameObject.Find("Quad").GetComponent<Shield>().AssignPlayer(Player1);

      
    }

    public void BeginRoundCountDown()
    {
        countdownImages.StartCountdown(3 ,RoundStartCountDownFinished);
    }
    
    public void RoundStartCountDownFinished()
    {
        Debug.Log("Round counted down");
        BeginRound();
    }

    public void BeginRound()
    {
        isGamePaused = false;
        isGameEnded = false;
        gameRoundTimer.StartRound(roundTimeInSeconds, TenSecondsRemaining);
    }

    public void TenSecondsRemaining()
    {
        Debug.Log("TenSecondsRemaining");
        countdownImages.StartCountdown(10, RoundTimeEnded);
    }

    public void RoundTimeEnded()
    {
        Debug.Log("round finished");

        isGameEnded = true;
             gameTimesUp.Show();
             
        if(!(player1Data.health == player2Data.health))
        {
            playerWon = (player1Data.health > player2Data.health) ? Player1 : Player2;
            playerWonTask = StartCoroutine("StartPlayerWonCoroutine");
        }
    }

    public void RoundGameOver()
    {
        Debug.Log("player died");

        gameRoundTimer.Stop();
        countdownImages.Stop();
        isGameEnded = true;

        gameOver.Show();
    }

    public void IamDead(GameObject playerObject)
    {
        Debug.Log("IamDead");
        playerWon = GetOtherPlayer(playerObject);
        RoundGameOver();
        playerWonTask = StartCoroutine("StartPlayerWonCoroutine");
    }

    GameObject GetOtherPlayer(GameObject player)
    {
        GameObject go1 = GameObject.Find("PlayerMain1");
        GameObject go2 = GameObject.Find("PlayerMain2");

        return (player.name == go1.name) ? go2 : go1;
    }

    private IEnumerator StartPlayerWonCoroutine()
    {
        Debug.Log("Player won started");

        PlayerJump jump =  playerWon.GetComponent<PlayerJump>();
        while (true)
        {
           jump.TryJump2();
            yield return null;
        }

        Debug.Log("Player won finished " );
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //SceneManager.LoadScene("main_menu");
            if(!isGamePaused && !isGameEnded){
                Time.timeScale = 0;
               // Time.fixedDeltaTime = 0;
                gamePaused.Show();
                isGamePaused = true;
            }else{
                Time.timeScale = 1;
                Time.fixedDeltaTime = 0.02f * Time.timeScale;
                gamePaused.Hide();
                isGamePaused = false;
            }
            
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.LoadScene("main_menu");
        }


    }
}
// Player2.transform.position += new Vector3(0.1f, 0, 0);
//Player2.transform.position += new Vector3(0.01f, 0, 0);

//Player1.DoKeyEvents(KeyCode.UpArrow, Input.GetKeyDown(KeyCode.UpArrow));
//Player1.DoKeyEvents(KeyCode.LeftArrow, Input.GetKeyDown(KeyCode.LeftArrow));
//Player1.DoKeyEvents(KeyCode.RightArrow, Input.GetKeyDown(KeyCode.RightArrow));
//Player1.DoKeyEvents(KeyCode.Space, Input.GetKeyDown(KeyCode.Space));

//Player2.DoKeyEvents(KeyCode.UpArrow, Input.GetKeyDown(KeyCode.UpArrow));
//Player2.DoKeyEvents(KeyCode.LeftArrow, Input.GetKeyDown(KeyCode.LeftArrow));
//Player2.DoKeyEvents(KeyCode.RightArrow, Input.GetKeyDown(KeyCode.RightArrow));
//Player2.DoKeyEvents(KeyCode.Space, Input.GetKeyDown(KeyCode.Space));

//Player1.DoKeyEvents();
//Player2.DoKeyEvents();