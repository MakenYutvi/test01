using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Gameplay.Spaceships
{
    //singlton manager. I prefer Zenject for this purpose, but decided not to change Architecture
    public class ScoreManager : MonoBehaviour
    {
            [SerializeField]
            private Text _scoreBar;
            private float _score;

            public static ScoreManager instance = null; 
  
            void Start()
            {
       
                if (instance == null)
                { 
                    instance = this;
                }
                else if (instance == this)
                {
                    Destroy(gameObject);
                }

      
                DontDestroyOnLoad(gameObject);

                InitializeManager();
            }

            private void InitializeManager()
            {
                _score = 0;
                _scoreBar.text = "Scores:" + _score.ToString();
            }
            public void Addscore()
            {
                _score++;
                _scoreBar.text = "Scores:" + _score.ToString();
            }
        }
}


