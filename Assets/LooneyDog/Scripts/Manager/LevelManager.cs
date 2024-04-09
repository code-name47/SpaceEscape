using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LooneyDog
{
    public class LevelManager : MonoBehaviour
    {

        public int LevelNumber { get => _levelNumber; set => _levelNumber = value; }
        public GameDifficulty Difficulty { get => _difficulty; set => _difficulty = value; }

        [SerializeField] private int _levelNumber;
        [SerializeField] private GameDifficulty _difficulty;
        [SerializeField] private LevelData[] levelDatas;
        private LevelDataStruct Currentleveldata;

        public void SetCurrentLevelDetails(int levelnumber, GameDifficulty difficulty) //Called From LoadingScreen 
        {
            LevelNumber = levelnumber;
            Difficulty = difficulty;
        }

        public void GetLevelData(int levelNumber, GameDifficulty gamedifficulty)
        {
            if (levelNumber == levelDatas[levelNumber - 1].LevelNumber)//-1 coz sciptable object array starts from 0
            {
                Currentleveldata = levelDatas[levelNumber - 1].GetLevelData(gamedifficulty);//-1 coz sciptable object array starts from 0
            }
            else
            {
                Debug.Log("LevelNumber Mismatch");
            }
        }
    }
}
