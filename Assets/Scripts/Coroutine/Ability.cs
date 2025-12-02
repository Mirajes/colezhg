//using System.Collections;
//using UnityEngine;
//using UnityEngine.UI;

//public class Ability : MonoBehaviour
//{
//    [SerializeField] private Canvas _canvas;
//    private Ability_Data _data = new Ability_Data();

//    private int _maxHealth = 100;
//    private int _health;

//    [Header("AbilitySettings")]
//    [SerializeField] private Material _blueMaterial;
//    [SerializeField] private float _damageAmplifier;
//    [SerializeField] private int _meteorDamage;
//    [SerializeField] private Image _meteorImage;
//    [SerializeField] private int _healAmount;


//    #region Enemy
//    private GameObject _currentEnemy;
//    private bool _isBlue = false;
//    private int _enemyHealh;

//    private int _maxEnemyHealth = 10;
//    private int _enemyIndex = 0;
//    private float _enemyHealthScale = 1.2f;

//    private void OnEnemyDie()
//    {
//        Destroy(_currentEnemy);
//        _enemyIndex += 1;

//        _isBlue = false;
//        _enemyHealh = (int)(_maxEnemyHealth * _enemyHealthScale * _enemyIndex);
//    }
//    #endregion

//    #region Abilities
//    public void MakeBlue()
//    {
//        _currentEnemy.GetComponent<Renderer>().material = _blueMaterial;
//    }

//    public void CastMeteor()
//    {
//        Image meteorImage = Instantiate(_meteorImage, _canvas.transform);

//    }

//    private IEnumerator MoveMeteorFromAbove(Image meteor)
//    {
//        while (true)
//        {

//            yield return null;
//        }
//    }

//    private IEnumerator ReloadAbility(Image abilityIcon, float cd)
//    {
//        while (abilityIcon.fillAmount < 1)
//        {
//            abilityIcon.fillAmount += (1 / cd) * Time.deltaTime;
//            yield return null;
//        }
//    }

//    public void HealYourself()
//    {
//        if (_health + _healAmount > _maxHealth)
//            _health = _maxHealth;
//        else 
//            _health += _healAmount;
//    }

//    //private bool 
//    #endregion

//    private void Init()
//    {
//        _health = _maxHealth;
//    }

//    private void UpdateUI()
//    {

//    }

//    private void Awake()
//    {
//        Init();
//    }

//    private void Update()
//    {

//    }
//}

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Ability : MonoBehaviour
{
    [SerializeField] private float _cd_fireball;
    [SerializeField] private float _cd_freeze;
    [SerializeField] private float _cd_screamer;

    public void CastFireball(GameObject button)
    {
        button.GetComponent<Button>().enabled = false;

        button.TryGetComponent<Image>(out Image icon);

        if (icon != null)
        {
            StartReload(icon);
        }
    }

    public void CastFreeze(GameObject button)
    {



        button.GetComponent<Button>().enabled = false;

        button.TryGetComponent<Image>(out Image icon);

        if (icon != null)
        {
            StartReload(icon);
        }
    }

    public void MakeScreamer(GameObject button)
    {


        button.GetComponent<Button>().enabled = false;

        button.TryGetComponent<Image>(out Image icon);

        if (icon != null)
        {
            StartReload(icon);
        }
    }

    private IEnumerator StartReload(Image icon)
    {
        while (icon.fillAmount < 1)
        {
            icon.fillAmount += (1 / _cd_fireball) * Time.deltaTime;

            if (icon.fillAmount >= 1)
                icon.fillAmount = 1;

            yield return null;
        }
    }
}
