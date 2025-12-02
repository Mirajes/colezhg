using UnityEngine;

public class Ability_Data
{
    private float _cd_makeBlue = 5f;
    private float _cd_castMeteor = 10f;
    private float _cd_healYourself = 1f;

    public float cd_MakeBlue => _cd_makeBlue;
    public float cd_CastMeteor => _cd_castMeteor;
    public float cd_HealYourself => _cd_healYourself;


}
