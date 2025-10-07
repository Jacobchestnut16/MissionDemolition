using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum GameMode
{
    idle,
    playing,
    levelEnd
}
public class MissionDemolition : MonoBehaviour
{
    static private MissionDemolition S;

    [Header("Inscribed")] 
    public TMP_Text     uitLevel;
    public TMP_Text     uitShots;
    public Vector3      castlePos;
    public GameObject[] castles;

    [Header("Dynamic")] 
    public int          level;
    public int          levelMax;
    public int          shotsTaken;
    public GameObject   castle;
    public GameMode     mode    = GameMode.idle;
    public string       showing = "Show Slingshot";
    
    
    void Start()
    {
        S = this;

        level = 0;
        shotsTaken = 0;
        levelMax = castles.Length;
        StartLevel();
    }

    public void StartLevel()
    {
        if (castle != null) Destroy(castle);

        Projectile.DESTORY_PROJECTILES();
        
        castle = Instantiate<GameObject>(castles[level]);
        castle.transform.position = castlePos;
        
        Goal.goalMet = false;

        UpdateGUI();
        
        mode = GameMode.playing;
    }

    void UpdateGUI()
    {
        uitLevel.text = "Level: " + (level + 1).ToString() + " of " + levelMax.ToString();
        uitShots.text = "Shots: " + shotsTaken.ToString();
    }

    void Update()
    {
        UpdateGUI();

        if ((mode == GameMode.playing) && Goal.goalMet)
        {
            mode = GameMode.levelEnd;
            
            Invoke("NextLevel", 2f);
        }
    }

    void NextLevel()
    {
        level++;
        if (level == levelMax)
        {
            level = 0;
            shotsTaken = 0;
        }
        StartLevel();
    }

    static public void SHOT_FIRED()
    {
        S.shotsTaken++;
    }

    static public GameObject GET_CASTLE()
    {
        return S.castle;
    }
}
