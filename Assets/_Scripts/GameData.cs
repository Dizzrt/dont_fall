using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    [Header("Game base")]
    public bool Gaming;
    public int degree;
    public int GameMode;//0 is normal, 1 is diversified
    public float JumpForce;
    public int Score = -1;

    [Header("Bar")]
    public int BarID;
    public GameObject[] Bar;
    public Transform[] SpawnPoint;

    [Header("-------------")]
    public Transform Index;
    public GameObject Default;
    public GameObject GamingShow;

    [System.Serializable]
    public class SideBorderData
    {
        public float UpForce;
        public float RightForce;
    }
    public SideBorderData SBD;

    [System.Serializable]
    public class MainData
    {
        [Header("Controll")]
        public float CurrentSpeed;
        public int LastSpawnPoint;
        public int CurrentSpawnPoint;
        public float LastSpawnTime;
        public float SpawnTimeDelta;

        [Header("Setting")]
        public Vector2 AngleLimit;
        public Vector2 SpeedLimit;
        public Vector2 SpawnTimeDeltaLimit;

        public float JumpForceRate;
        public float MaxJumpForce;
        public float BeginSpeed;
        public float BeginTimeDelta;
        public float CheckDistance;
    }
    [Space]
    public MainData Data;
    public MainData Eazy;
    public MainData Hard;
}
