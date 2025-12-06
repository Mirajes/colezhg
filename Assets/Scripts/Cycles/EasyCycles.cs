using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyCycles : MonoBehaviour
{
    #region #1
    [SerializeField] private List<Transform> _cubes;
    [SerializeField] private float _distance_x;
    
    private void BubbleSort(ref List<Transform> cubes) 
    {
        for (int i = 0; i < cubes.Count - 1; i++)
        {
            for (int j = 0; j < cubes.Count - i - 1; j++)
                {
                    if (cubes[j].transform.localScale.magnitude < cubes[j + 1].transform.localScale.magnitude)
                        {
                            // меняем местами объекты
                            var temp = cubes[j];
                            cubes[j] = cubes[j + 1];
                            cubes[j + 1] = temp;
                        }
                }
        }   
    }

    public void SortBySize() {
        BubbleSort(ref _cubes);

        float newOffsetDistance_X = 0f;
        foreach (var item in _cubes) {
            newOffsetDistance_X += item.localScale.x + _distance_x;
            item.position = new Vector3(newOffsetDistance_X, 0, 0);

        }
    }
    #endregion

    #region #2
    [SerializeField] private Transform _ball;
    private Rigidbody _ballRigidBody;
    private Renderer _ballRenderer;
    private float _ballHeight;
    private bool _isGrounded;
    [SerializeField] private float _ballForce;
    [SerializeField] private Material _defaultColor;
    [SerializeField] private Material _thresholdColor;
    [SerializeField] private float _speedThreshold; //threshold - порог
    private bool _isCoroutineWorks = false;
    
    private void CheckForGrounded()
    {
        _ballHeight = _ball.localScale.y / 2;
        if (Physics.Raycast(_ball.position, Vector3.down, _ballHeight))
        {
            _isGrounded = true;
        }
        else
        {
            _isGrounded = false;
        }
    }

    private IEnumerator CountTimeBelowThreshold()
    {
        float timeBelowThreshold = 0f;
        do
        {
            float speed = _ballRigidBody.linearVelocity.magnitude;
            if (speed < _speedThreshold)
            {
                timeBelowThreshold += Time.deltaTime;
                _ballRenderer.material = _thresholdColor;
            }
            yield return null;
        } while (_ballRigidBody.linearVelocity.magnitude < _speedThreshold);
        Debug.Log($"Время ниже порога: {timeBelowThreshold} секунд");
        _isCoroutineWorks = false;
        _ballRenderer.material = _defaultColor;
        yield return null;
    }

    #endregion

    private void Awake()
    {
        _ballRigidBody = _ball.GetComponent<Rigidbody>();
        _ballRenderer = _ball.GetComponent<Renderer>();
    }
    private void Start()
    {
        _ballRenderer.material = _defaultColor;
    }

    private void Update()
    {
        CheckForGrounded();

        if (_isGrounded)
        {
            _ballRigidBody.AddForce(new Vector3(0, _ballForce, 0), ForceMode.Force);
        }

        // if (!_isCoroutineWorks && _ballRigidBody.linearVelocity.magnitude < _speedThreshold)
        // {
        //     _isCoroutineWorks = true;
        //     StartCoroutine(CountTimeBelowThreshold());
        // }

        if (!_isCoroutineWorks && _ballRigidBody.linearVelocity.magnitude < _speedThreshold)
        {
            _isCoroutineWorks = true;
            StartCoroutine(CountTimeBelowThreshold());
            }
    }
}
