using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private Animator _animator;
    public float Health {
        set {
            health = value;
            if (health <= 0){
                Defeated();
            }
        }
        get => health;
    }

    public float health = 1;
    private static readonly int IsDefeated = Animator.StringToHash("Defeated");

    private void Start(){
        _animator = GetComponent<Animator>();
    }

    public void Defeated(){
        _animator.SetTrigger(IsDefeated);
    }

    public void DestroyEnemy() {
        Destroy(gameObject);
    }
}
