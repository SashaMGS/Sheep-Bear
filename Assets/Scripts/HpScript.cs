using UnityEngine;

public class HpScript : MonoBehaviour
{
    public short _hp = 3;
    public ParticleSystem _partDamageAnimal;
    public ParticleSystem _partDamageCam;
    public void Damage(short dmg)
    {
        if (_hp > 0)
        {
            _hp -= dmg;
            ShakeCam _shakeCamScript = GameObject.FindGameObjectWithTag("MainCamera").transform.GetChild(0).GetComponent<ShakeCam>();
            _shakeCamScript.ShakeCamera(_shakeCamScript._dur, _shakeCamScript._magnitude, _shakeCamScript._noize);
            _partDamageAnimal.Play();
            _partDamageCam.Play();
        }
        if (_hp <= 0)
            GameObject.FindGameObjectWithTag("ScriptObj").GetComponent<Menu_Script>().Die();
    }
}
