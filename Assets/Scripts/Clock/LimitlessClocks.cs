using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LimitlessClocks : MonoBehaviour
{
    [SerializeField] private Image _clocks;
    [SerializeField] private GameObject _startButton;
    private float filledAmount = 0;
    private int cyclesAmount = 0;
    private float cycleTime = 5f;

    [SerializeField]
    private TMP_Text countOfCyclesText;

    private bool isPaused = true;

    private void Start()
    {
        _clocks.fillAmount = 1;
        filledAmount = _clocks.fillAmount;
    }

    private void Update()
    {
        if (isPaused) return;

        if (filledAmount > 0)
        {
            _clocks.fillAmount -= Time.deltaTime / cycleTime;
            filledAmount = _clocks.fillAmount;
        }
        else
        {
            _clocks.fillAmount = 1;
            filledAmount = _clocks.fillAmount;

            cyclesAmount += 1;
            countOfCyclesText.text = "Кол-во циклов: " + cyclesAmount;

            isPaused = true;
            _startButton.SetActive(true);
        }

    }

    public void StartCycle()
    {
        _startButton.SetActive(false);
        isPaused = false;
    }
}
