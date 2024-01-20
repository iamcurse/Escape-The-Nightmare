using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float collider2DOffsetX = -0.0056f;
    public float collider2DOffsetY = -0.115f;
    [SerializeField]private float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;
    public Attack attack;
    private Vector2 _movementInput;
    private Rigidbody2D _rb;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private readonly List<RaycastHit2D> _castCollisions = new();

    private bool _canMove = true;
    private static readonly int Attack1 = Animator.StringToHash("attack");
    private static readonly int IsMoving = Animator.StringToHash("isMoving");
    private BoxCollider2D _boxCollider2D;
    private BoxCollider2D _boxCollider2D1;

    // Start is called before the first frame update
    private void Start()
    {
        _boxCollider2D1 = GetComponent<BoxCollider2D>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (!_canMove) return;
        var success = TryMove(_movementInput);
        if (_movementInput != Vector2.zero){
            if (!success){
                success = TryMove(new Vector2(_movementInput.x, 0));

                if (!success){
                    success = TryMove(new Vector2(0, _movementInput.y));
                }
            }

            _animator.SetBool(IsMoving, success);
        } else {
            _animator.SetBool(IsMoving, false);
        }

        switch (_movementInput.x)
        {
            case < 0:
                _spriteRenderer.flipX = true;
                _boxCollider2D.offset = new Vector2(collider2DOffsetX * -1, collider2DOffsetY);
                break;
            case > 0:
                _spriteRenderer.flipX = false;
                _boxCollider2D1.offset = new Vector2(collider2DOffsetX, collider2DOffsetY);
                break;
        }
    }

    private bool TryMove(Vector2 direction)
    {
        if (direction != Vector2.zero){
            var count = _rb.Cast(direction, movementFilter, _castCollisions, moveSpeed * Time.fixedDeltaTime + collisionOffset);

            if (count != 0) return false;
            _rb.MovePosition(_rb.position + direction * (moveSpeed * Time.fixedDeltaTime));
            return true;

        }

        return false;
    }

    private void OnMove(InputValue movementValue){
        _movementInput = movementValue.Get<Vector2>();
    }

    private void OnFire(){
        _animator.SetTrigger(Attack1);
    }

    public void DoAttack(){
        LockMovement();

        if (_spriteRenderer.flipX){
            attack.AttackLeft();
        } else {
            attack.AttackRight();
        }
    }

    public void EndSwordAttack(){
        UnlockMovement();
        attack.StopAttack();
    }

    public void LockMovement(){
        _canMove = false;
    }

    public void UnlockMovement(){
        _canMove = true;
    }
}