using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator _playerAnim;
    private int _isMovingHash;
    private float _attackCooldown;
    private float _jumpLenght;

    private void Start()
    {
        _attackCooldown = 0;
        _jumpLenght = 0;
        _isMovingHash = Animator.StringToHash("isMoving");
    }
    void Update()
    {
        Move();
        Attack();
        Jump();
    }

    void Move()
    {
        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            _playerAnim.SetBool(_isMovingHash, false);
        }
        else
        {
            _playerAnim.SetBool(_isMovingHash, true);
        }
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _attackCooldown = 0.3f;
            _playerAnim.SetBool("isAttacking", false);
            _playerAnim.SetBool("isAttacking", true);
            _playerAnim.Play("Base Layer.ghost_attack", 0, 0f);
        }

        if (_attackCooldown > 0) _attackCooldown -= Time.deltaTime;
        else _playerAnim.SetBool("isAttacking", false);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            _jumpLenght = 0.5f;
            _playerAnim.SetBool("isJumping", false);
            _playerAnim.SetBool("isJumping", true);
            _playerAnim.Play("Base Layer.ghost_surprised", 0, 0f);
        }

        if (_jumpLenght > 0) _jumpLenght -= Time.deltaTime;
        else _playerAnim.SetBool("isJumping", false);
    }
}
