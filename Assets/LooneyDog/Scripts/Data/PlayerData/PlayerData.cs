using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace LooneyDog
{
    [Serializable]
    public class PlayerData
    {
        public int HighScore { get { return HIGHSCORE; } set { HIGHSCORE = value; } }
        public float CameraSensitivity { get { return CAMERASENSITIVITY; } set { CAMERASENSITIVITY = value; } }
        public bool ShowTutorial { get { return SHOWTUTORIAL; } set { SHOWTUTORIAL = value; } }


        [SerializeField] private int HIGHSCORE;
        [SerializeField] private float CAMERASENSITIVITY = 0.5f;
        [SerializeField] private bool SHOWTUTORIAL = true;
        [SerializeField] private int COINS;

        public void Check()
        {
            
        }

        public void AddRewardCoins(int coins)
        {
            COINS = COINS + coins;
        }

        public void SubstractRewardCoins(int coins)
        {
            if ((COINS - coins) > 0)
            {
                COINS = COINS - coins;
            }
            else
            {
                COINS = 0;
            }
        }

        public bool CheckIfEnoughCoins(int value)
        {
            if (value > COINS)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetCoinData()
        {
            return (Int32)COINS;
        }
        public void SetNormalizedCameraSensitivity(float value)
        {
            CAMERASENSITIVITY = value / 100;
        }
        

    }

    [Serializable]
    public struct LevelDataJson
    {
        public bool LevelCompleted;
        public int StarsObtained;
    }

    public struct VehicleDataJson
    {
        public bool Unlocked;
        public int currentSkin;
    }

}
