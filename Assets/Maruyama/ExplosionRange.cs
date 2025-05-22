using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionRange : MonoBehaviour
{
    [SerializeField] private int _explosionDamage = 100;
    //[SerializeField] private float _damageWaitTime = 0.1f;
    [SerializeField] private float _destroyWaitTime = 0.1f;

    private HashSet<CharactorBase> objectsInside = new HashSet<CharactorBase>();

    private void OnEnable()
    {
        //StartCoroutine("ExplosionDamage");
        Destroy(gameObject, _destroyWaitTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out CharactorBase charactor))
        {
            //objectsInside.Add(charactor);
            // Debug.Log("追加 : " + charactor.gameObject.name);
            charactor.DamageBehaviour(_explosionDamage);
            Debug.Log($"<color=yellow>着火！！  犠牲者{charactor.gameObject.name}</color>");
        }
    }

    //    public IEnumerable ExplosionDamage()
    //    {
    //        yield return new WaitForSeconds(_damageWaitTime);

    //#if UNITY_EDITOR
    //        Debug.Log($"<color=yellow>着火！！  犠牲者{objectsInside.Count}名</color>");
    //#endif

    //        foreach (var charactor in objectsInside)
    //        {
    //            charactor.DamageBehaviour(_explosionDamage);
    //        }
    //    }
}
