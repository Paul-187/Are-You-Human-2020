using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelHandler : MonoBehaviour
{
   private List<Level> _levels = new List<Level>();

   public static LevelHandler Instance;

   private int _currentLevel;
   
   private void Awake()
   {
      if (Instance == null)
      {
         Instance = this;
      }
      else
      {
         Destroy(gameObject);
      }
      
      for (int i = 0; i < transform.childCount; i++)
      {
         if (transform.GetChild(i).GetComponent<Level>())
         {
            _levels.Add(transform.GetChild(i).GetComponent<Level>()); 
         }
      }
   }

   private void OnEnable()
   {
      // foreach (var levelComponent in FindObjectsOfType<LevelComponent>())
      // {
      //    levelComponent.OnBallLeftLevel += ResetScene;
      // }

      ParticleBall.OnBallPickedUp += StartGame;
      ParticleBall.OnBallLeftLevel += ResetScene;
   }

   private void OnDisable()
   {
      // foreach (var levelComponent in FindObjectsOfType<LevelComponent>())
      // {
      //    levelComponent.OnBallLeftLevel -= ResetScene;
      // }
      
      ParticleBall.OnBallPickedUp -= StartGame;
      ParticleBall.OnBallLeftLevel -= ResetScene;
   }

   private void Start()
   {
      HideAllLevels();
   }

   private void StartGame()
   {
      ShowLevel(0);
   }

   public void NextLevel()
   {
      if (_currentLevel + 1 >= _levels.Count) return;
      
      _currentLevel++;
      ShowLevel(_currentLevel);
   }

   private void ShowLevel(int levelIndex)
   {
      HideAllLevels();
      _levels[levelIndex].Show();
   }
   
   private void HideAllLevels()
   {
      foreach (var level in _levels)
      {
         level.Hide();
      }
   }
   
   private void ResetScene()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }

 
}
