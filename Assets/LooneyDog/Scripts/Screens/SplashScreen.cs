using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;
namespace LooneyDog
{
    public class SplashScreen : MonoBehaviour
    {
        public Image LooneyDogLogo { get { return _looneyDogLogo; } set { _looneyDogLogo = value; } }
        [SerializeField] private Image _looneyDogLogo;
        [SerializeField] private TextMeshProUGUI _looneyDogText;
        [SerializeField] private float _transitionSpeed;
        [SerializeField] private float _logoAppearDelay;
        [SerializeField] private float _logoScreenTime;
        [SerializeField] private int _menuSceneIndex;
 
        private void OnEnable()
        {
            StartCoroutine(LogoAppear());
        }


        private IEnumerator LogoAppear()
        {
            yield return new WaitForSeconds(_logoAppearDelay);
            _looneyDogLogo.DOFade(1, _transitionSpeed).OnStart(()=> {
                _looneyDogText.DOFade(1, _transitionSpeed);
            }).OnComplete(() => {
                StartCoroutine(LogoDisappear()); 
            });
        }

        private IEnumerator LogoDisappear()
        {
            LoadMenuScene(); // The limbo Scene is for loading stuff which you need to load before Home Scene loads like advertisements and all
            yield return new WaitForSeconds(_logoScreenTime);
            GameManager.Game.Screen.LoadFadeScreen(GameManager.Game.Screen.Splsh.gameObject, GameManager.Game.Screen.Home.gameObject);
            
        }


        private void LoadMenuScene() {
            SceneManager.LoadScene(_menuSceneIndex);
        }

    }
}