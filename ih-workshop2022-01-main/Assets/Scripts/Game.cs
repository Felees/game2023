using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    IGameInput input;
    public PlayerController Player;
    public Camera Cam;
    public float PlayerTrackingMinX = -3.0f;
    public float PlayerTrackingMaxX;
    
    public Transform Goal;

    public GameObject ButtonRetry;
    public GameObject ButtonNextLevel;
    public GameObject TextWon;
    public GameObject TextLost;
    public GameObject TextPaused;
    public Text TextHealth;

    bool isPaused;
    float camDeltaX;
    bool gameOver;
    
    void Awake()
    {
        input = new GameInputSimpleKeyboard();
        AssignPlayer();
        AssignCamera();
        PlayerTrackingMaxX = Goal.transform.position.x - 3.0f;
    }

    void AssignPlayer()
    {
        if(Player == null)
            Player = FindObjectOfType<PlayerController>();
        if(Player == null)
            ErrorMissingComponent("player");
    }

    void AssignCamera()
    {
        if(Cam == null)
            Cam = Camera.main;
        if(Cam == null)
            ErrorMissingComponent("camera");

        camDeltaX = Cam.transform.position.x - PlayerTrackingMinX;
    }

    void ErrorMissingComponent(string label)
    {
        throw new Exception($"Couldn't find a {label} object on this level. Are you sure it exists in the scene {SceneManager.GetActiveScene().name}");
    }

    void Update()
    {
        if(input.IsPausePressed())
            TogglePause();

        if(isPaused || gameOver)
            return;

        TextHealth.text = $"Health: {(int)Player.Health}";
        Player.Move(input.GetMovementDirection(), input.IsJumpPressed(), input.IsCrouchPressed());
        
        if(Player.transform.position.x > Goal.transform.position.x)
            Win();
        else if(Player.Health < 0)
            Lose();
    }

    //Making camera trail the player in LateUpdate because player's new position is ready by then
    void LateUpdate()
    {
        CameraUpdateTrailing();
    }

    void CameraUpdateTrailing()
    {
        float playerX = Player.transform.position.x;
        if(playerX < PlayerTrackingMinX || playerX > PlayerTrackingMaxX)
            return;
            
        var camTfm = Cam.transform;
        var camPos = camTfm.position;

        camPos.x = playerX + camDeltaX;

        camTfm.position = camPos;
    }

    public void TogglePause()
    {
        SetPause(!isPaused);
    }

    public void SetPause(bool pause)
    {
        PauseGame(pause);
        TextPaused.SetActive(pause);
    }

    public void PauseGame(bool pause)
    {
        Time.timeScale = pause ? 0.0f : 1.0f;
        isPaused = pause;
    }

    public void Win()
    {
        GameOver();
        TextWon.SetActive(true);
        ButtonNextLevel.SetActive(true);
    }

    public void Lose()
    {
        GameOver();
        TextLost.SetActive(true);
        ButtonRetry.SetActive(true);
    }

    public void GameOver()
    {
        gameOver = true;
        PauseGame(true);
    }

    public void RestartLevel()
    {
        PauseGame(false);
        var level = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(level);
    }
    public void Second_Level()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }
    public void Third_Level()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1f;
    }
}
