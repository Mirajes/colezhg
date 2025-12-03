using UnityEngine;
using UnityEngine.UI;

public class EasyCoroutine : MonoBehaviour
{
    [SerializeField] private Button _fireballButton;
    [SerializeField] private Button _freezeButton;
    [SerializeField] private Button _explosionButton;

    [SerializeField] private GameObject _fireball;
    [SerializeField] private GameObject _freeze;
    [SerializeField] private GameObject _explosion;

    private void Update()
    {
        // можно сделать через inputSystem
        if (Input.GetKeyDown(KeyCode.Z)) { _fireballButton.onClick.Invoke(); }
        if (Input.GetKeyDown(KeyCode.X)) { _freezeButton.onClick.Invoke(); }
        if (Input.GetKeyDown(KeyCode.C)) { _explosionButton.onClick.Invoke(); }

        {

        }
    }

    
}

public struct AblityData
{
    public float CD_Fireball;
    public float CD_Freeze;
    public float CD_Explosion;

    public float LT_used_Fireball;
    public float LT_used_Freeze;
    public float LT_used_Explosion;
}
