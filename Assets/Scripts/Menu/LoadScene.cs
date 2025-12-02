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
    private bool _isRunning = false;
    private float _currentAlpha = 0f;

    [SerializeField] private GameObject _blackoutObj;
    private Image _blackoutImage;


    public void InitBlackout()
    {
        StartCoroutine(SceneBlackout());
        StartCoroutine(SceneLightout());

    }


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else 
            Destroy(Instance);


        DontDestroyOnLoad(Instance);

        _blackoutImage = _blackoutObj.GetComponent<Image>();
    }


    private void OnEnable()
    {
        SceneManager.activeSceneChanged += OnChangeScene;
    }

    private void OnChangeScene(Scene arg0, Scene arg1)
    {
            
    }






    private IEnumerator SceneBlackout()
    {
        _isRunning = true;
        _blackoutObj.SetActive(true);

        while (_currentAlpha != 1)
        {
            _currentAlpha += Time.deltaTime / _blackoutTime;
            if (_currentAlpha > 1)
                _currentAlpha = 1;

            _blackoutImage.color = new Color(0, 0, 0, _currentAlpha);
            yield return null;
        }
        SceneManager.LoadScene("Coroutine");

        _isRunning = false;
        yield return null;
    }

    private IEnumerator SceneLightout()
    {
        yield return new WaitUntil(() => _isRunning == false);

        _isRunning = true;

        while (_currentAlpha != 0)
        {
            _currentAlpha -= Time.deltaTime / _blackoutTime;
            if (_currentAlpha < 0)
                _currentAlpha = 0;

            _blackoutImage.color = new Color(0, 0, 0, _currentAlpha);
            yield return null;
        }

        _isRunning = false;
        _blackoutObj.SetActive(false);
        yield return null;
    }
}
