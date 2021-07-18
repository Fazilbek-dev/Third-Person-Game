using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 10f;
    [SerializeField] private float _gravity = 20f;
    [SerializeField] public Animator _anim;
    [SerializeField] private int _state;
    [SerializeField] private Animator _targetAnimator;
    [SerializeField] private GameObject _target;
    [SerializeField] private GameObject _sword;
    [SerializeField] private GameObject _gun;
    [SerializeField] private GameObject _text;
    [SerializeField] private GameObject _quest1;

    Vector3 _direction;
    CharacterController _controller;

    private void Awake()
    {
        _text.SetActive(false);
        _sword.SetActive(false);
        _gun.SetActive(true);
        _anim.SetInteger("State", 0);
        _anim = GetComponent<Animator>();
        _controller = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (_controller.isGrounded)
        {
            _direction = new Vector3(x, 0f, z);
            _direction = transform.TransformDirection(_direction) * _movementSpeed;
        }

        if(z > 0)
        {
            _anim.SetInteger("State", 1);
        } 
        if(z < 0)
        {
            _anim.SetInteger("State", 4);
        } 
        if(x > 0)
        {
            _anim.SetInteger("State", 2);
        } 
        if(x < 0)
        {
            _anim.SetInteger("State", 3);
        }
        if(x == 0 && z == 0)
        {
            _anim.SetInteger("State", 0);
        }
        if (Input.GetMouseButton(0))
        {
            _anim.SetInteger("State", 5);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            _targetAnimator.enabled = false;
        }
        _direction.y -= _gravity * Time.deltaTime;
        _controller.Move(_direction * Time.deltaTime);

        float distance = Vector3.Distance(this.transform.position, _target.transform.position);

        DIstanceFromEnemy(distance);
        
        if (Input.GetMouseButton(1))
        {
            var direction = Input.mousePosition - Camera.main.WorldToScreenPoint(this.transform.position);
            var angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, angle, 0);
        }
    }
    private IEnumerator Kill()
    {
        yield return new WaitForSeconds(0.7f);
        _targetAnimator.enabled = false;
    }

    private void DIstanceFromEnemy(float distance)
    {
        if (distance <= 5f)
        {
            _text.SetActive(true);
            _gun.SetActive(false);
            _sword.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine(Kill());
            }
        }
    }

    private void Quest1()
    {
        float distanceFromTarget = Vector3.Distance(this.transform.position, _quest1.transform.position);

        if (distanceFromTarget <= 5f)
        {
            Quest._quest1 = true;
        }
    }
}
