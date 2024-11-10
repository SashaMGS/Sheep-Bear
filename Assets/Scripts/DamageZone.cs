using System.Collections;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    public short _damage = 1;
    private bool _canDamage;
    private Collider _gameObject;
    private bool _onTrigger;
    private ParticleSystem _particleSystem;

    private void Start()
    {
        if (transform.childCount != 0 && transform.GetChild(0).GetComponent<ParticleSystem>())
        {
            _particleSystem = transform.GetChild(0).GetComponent<ParticleSystem>();
            StartCoroutine(DelayZone());
        }
        else
            _canDamage = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "Player_1" || other.tag == "Player_2") && !_onTrigger && _canDamage)
        {
            _gameObject = other;
            _onTrigger = true;
            StartCoroutine(DamageTime());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player_1" || other.tag == "Player_2")
        {
            _gameObject = other;
            _onTrigger = false;
            StopCoroutine(DamageTime());
        }
    }

    private IEnumerator DamageTime()
    {
        while (_onTrigger)
        {
            _gameObject.GetComponent<HpScript>().Damage(_damage);
            yield return new WaitForSeconds(3f);
        }
        yield break;
    }

    private IEnumerator DelayZone()
    {
        while (true)
        {
            _particleSystem.Play();
            _canDamage = true;
            yield return new WaitForSeconds(Random.Range(2f, 4f));
            _particleSystem.Stop();
            _canDamage = false;
            yield return new WaitForSeconds(2f);
        }
    }
}
