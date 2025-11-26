using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    public static LoadScene Instance;

    public void ChangeScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    [SerializeField] private float _blackoutTime = 5f;
    //[SerializeField] private bool _isRunning = false;
    private float _currentAlpha = 0f;

    [SerializeField] private GameObject _blackoutObj;
    [SerializeField] private Image _blackoutImage;


    public void InitBlackout()
    {
        _blackoutObj.SetActive(true);
        StartCoroutine(SceneBlackout());
    }

    private IEnumerator SceneBlackout()
    {

        while (_currentAlpha != 1)
        {
            _currentAlpha += Time.deltaTime / _blackoutTime;
            if (_currentAlpha > 1)
                _currentAlpha = 1;

            _blackoutImage.color = new Color(0, 0, 0, _currentAlpha);
            yield return null;
        }
    }



    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(Instance);
    }


    private void OnEnable()
    {
        SceneManager.activeSceneChanged += OnChangeScene;
    }

    private void OnChangeScene(Scene arg0, Scene arg1)
    {

    }
}
