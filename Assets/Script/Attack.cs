using UnityEngine;

public class Attack : MonoBehaviour
{
    public Collider2D attackCollider;
    public float damage = 3;

    private Vector2 _rightAttackOffset;

    private void Start(){
        _rightAttackOffset = transform.position;
    }
    public void AttackRight(){
        attackCollider.enabled = true;
        transform.localPosition = _rightAttackOffset;
    }

    public void AttackLeft(){
        attackCollider.enabled = true;
        transform.localPosition = new Vector3(_rightAttackOffset.x * -1, _rightAttackOffset.y);
    }

    public void StopAttack(){
        attackCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Enemy")){
            EnemyScript enemy = other.GetComponent<EnemyScript>();

            if (enemy != null) {
                enemy.Health -= damage;
            }
        }
    }
}
