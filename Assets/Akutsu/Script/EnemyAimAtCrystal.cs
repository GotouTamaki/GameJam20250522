using UnityEngine;

public class EnemyAimAtCrystal : EnemyAimAtAlly
{
    protected override void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Crystal")
        {
            _isFoundPlayer = true;
            _targetDirection = (collision.transform.position - _muzzleTransform.position).normalized;
            //_muzzleTransform.rotation = Quaternion.Euler(_targetDirection);
        }
    }

    protected override void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Crystal")
        {
            _isFoundPlayer = false;
        }
    }
}
