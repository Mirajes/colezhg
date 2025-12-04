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

    private bool IsOnCooldown(float LT_used_Ability, float CD_Ability) => Time.time - LT_used_Ability >= CD_Ability;

    public void FireballRelease()
    {
        if (IsOnCooldown(ablityData.LT_used_Fireball, ablityData.CD_Fireball)) {
            ablityData.LT_used_Fireball = Time.time;
            _audioSource.PlayOneShot(_fireballAudio);
        }

    }

    public void FreezeRelease()
    {
        if (IsOnCooldown(ablityData.LT_used_Freeze, ablityData.CD_Freeze)) {
            ablityData.LT_used_Freeze = Time.time;
            _audioSource.PlayOneShot(_freezeAudio);
        }
    }

    public void ExplosionRelease()
    {
                if (IsOnCooldown(ablityData.LT_used_Explosion, ablityData.CD_Explosion)) {
            ablityData.LT_used_Explosion = Time.time;
            _audioSource.PlayOneShot(_explosionAudio);
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
