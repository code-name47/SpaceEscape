using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace LooneyDog
{
    public class HomeScreen : MonoBehaviour
    {
        public Button StartButton { get => _startButton; set => _startButton = value; }
        [SerializeField] private Button _startButton;

        private void Awake()
        {
            _startButton.onClick.AddListener(OnCLickStartButton);    
        }
        
        public void OnCLickStartButton() {
            Debug.Log("this button is pressed");
            GameManager.Game.Screen.LoadFadeScreen(this.gameObject, GameManager.Game.Screen.Load.gameObject);
        }
    }
}
