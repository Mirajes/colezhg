using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EasyCoroutine : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button _fireballButton;
    [SerializeField] private Button _freezeButton;
    [SerializeField] private Button _explosionButton;

    [Header("UI")]
    [SerializeField] private Canvas _canvas;

    [Header("AbilityImages")]
    [SerializeField] private Image _fireball;
    [SerializeField] private Image _freeze;
    [SerializeField] private Image _explosion;

    [Header("Audio")]
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _fireballAudio;
    [SerializeField] private AudioClip _freezeAudio;
    [SerializeField] private AudioClip _explosionAudio;

    private AblityData ablityData = new();

    private void InitStructCuzUHaveVeryOldCSharp()
    {
        ablityData.CD_Fireball = 3f;
        ablityData.CD_Freeze = 4f;
        ablityData.CD_Explosion = 10f;
    }

    private IEnumerator MoveFireball(Transform obj, Transform point)
    {
        while (obj.position - point.position != Vector3.zero)
        {
            obj.position = Vector3.MoveTowards(obj.position, point.position, 100f * Time.deltaTime);
            yield return null;
        }

        Destroy(obj.gameObject);
    }

    private IEnumerator WaitDead(GameObject obj)
    {
        yield return new WaitForSeconds(3f);
        Destroy(obj.gameObject);
    }
    private IEnumerator ReloadButton(Image image, float CD_Ability)
    {
        image.fillAmount = 0f;

        while (image.fillAmount < 1)
        {
            image.fillAmount += (1 / CD_Ability) * Time.deltaTime;
            yield return null;
        }
    }
    private bool IsOnCooldown(ref float LT_used_Ability, float CD_Ability)
    {
        bool isOnCooldown = Time.time - LT_used_Ability >= CD_Ability;
        if (isOnCooldown)
        {
            LT_used_Ability = Time.time;
            return isOnCooldown;
        } else
        {
            return isOnCooldown;
        }
    }

    public void FireballRelease()
    {
        if (!IsOnCooldown(ref ablityData.LT_used_Fireball, ablityData.CD_Fireball)) return;

        Image obj = Instantiate(_fireball, _canvas.transform);
        _audioSource.PlayOneShot(_fireballAudio);
        StartCoroutine(MoveFireball(obj.transform, _canvas.transform));
        
        StartCoroutine(ReloadButton(_fireballButton.GetComponent<Image>(), ablityData.CD_Fireball));
    }

    public void FreezeRelease()
    {
        if (!IsOnCooldown(ref ablityData.LT_used_Freeze, ablityData.CD_Freeze)) return;

        Image obj = Instantiate(_freeze, _canvas.transform);
        _audioSource.PlayOneShot(_freezeAudio);

        StartCoroutine(WaitDead(obj.gameObject));

        StartCoroutine(ReloadButton(_freezeButton.GetComponent<Image>(), ablityData.CD_Freeze));
    }

    public void ExplosionRelease()
    {
        if (!IsOnCooldown(ref ablityData.LT_used_Explosion, ablityData.CD_Explosion)) return;

        Image obj = Instantiate(_explosion, _canvas.transform);
        _audioSource.PlayOneShot(_explosionAudio);

        StartCoroutine(WaitDead(obj.gameObject));

        StartCoroutine(ReloadButton(_explosionButton.GetComponent<Image>(), ablityData.CD_Explosion));
    }


    private void Start()
    {
        InitStructCuzUHaveVeryOldCSharp();
    }
    private void Update()
    {
        // potom zamenit na inputSystem
        if (Input.GetKeyDown(KeyCode.Z)) { _fireballButton.onClick.Invoke(); }
        if (Input.GetKeyDown(KeyCode.X)) { _freezeButton.onClick.Invoke(); }
        if (Input.GetKeyDown(KeyCode.C)) { _explosionButton.onClick.Invoke(); }


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
