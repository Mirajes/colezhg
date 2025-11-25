using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SceneDark : MonoBehaviour
{
    [SerializeField] private float _blackoutTime = 5f;
    [SerializeField] private bool _isRunning = false;
    private float _currentAlpha = 0f;

    [SerializeField] private GameObject _blackoutObj;
    [SerializeField] private Image _blackoutImage;

    public static SceneDark Instance;

    public void InitBlackout()
    {
        _blackoutObj.SetActive(true);
        SceneBlackout();
    }

    private IEnumerator SceneBlackout()
    {

        while (_currentAlpha <= 255)
        {
            _currentAlpha += Time.deltaTime / _blackoutTime;
            byte a = Convert.ToByte(_currentAlpha);
            _blackoutImage.color = new Color32(255, 255, 255, a);
        }


        yield return null;

    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        DontDestroyOnLoad(Instance);
    }
}
