using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Collider2D attackCollidor;
    public float Damage = 3;

    Vector2 rightAttackOffset;

    private void Start(){
        rightAttackOffset = transform.position;
    }
    public void AttackRight(){
        attackCollidor.enabled = true;
        transform.localPosition = rightAttackOffset;
    }

    public void AttackLeft(){
        attackCollidor.enabled = true;
        transform.localPosition = new Vector3(rightAttackOffset.x * -1, rightAttackOffset.y);
    }

    public void StopAttack(){
        attackCollidor.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Enemy"){
            EnemyScript enemy = other.GetComponent<EnemyScript>();

            if (enemy != null) {
                enemy.Health -= Damage;
            }
        }
    }
}
