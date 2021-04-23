using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PergerakanKarakter : MonoBehaviour
{
   //variabel
   [SerializeField] private float _moveSpeed;
   [SerializeField] private float _walkSpeed;
   [SerializeField] private float _runSpeed;

    private Vector3 arahGerak;
    private Vector3 velocity;

    [SerializeField] private bool _isGround;
    [SerializeField] private float _groundCheckDistance;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private float _gravity;

    [SerializeField] private float _jumpHeight;


    //referensi
    private CharacterController controller;
    private Animator animasi;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animasi = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        Gerak();
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            Attack();
        }
    }

    private void Gerak()
    {
        _isGround = Physics.CheckSphere(transform.position, _groundCheckDistance, _groundMask);
        if (_isGround && velocity.y < 0) {
            velocity.y = -2f;
        }

        float arahZ = Input.GetAxis("Vertical");

        arahGerak = new Vector3(0, 0, arahZ);
        arahGerak = transform.TransformDirection(arahGerak);

        if (_isGround)
        {
            if (arahGerak != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {
                Jalan();
            }
            else if (arahGerak != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
            {
                Lari();

            }
            else if (arahGerak == Vector3.zero)
            {
                Diam();
            }
            arahGerak *= _moveSpeed;

            if (Input.GetKey(KeyCode.Space))
            {
                Loncat();
            }
        }


        controller.Move(arahGerak * Time.deltaTime);

        velocity.y += _gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void Diam()
    {
        animasi.SetFloat("Speed", 0, 0.1f, Time.deltaTime);
    }

    private void Jalan()
    {
        _moveSpeed = _walkSpeed;
        animasi.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
    }

    private void Lari()
    {
        _moveSpeed = _runSpeed;
        animasi.SetFloat("Speed", 1, 0.1f, Time.deltaTime);
    }

    private void Loncat()
    {
        velocity.y = Mathf.Sqrt(_jumpHeight * -2 * _gravity);
    }

    private void Attack()
    {
        animasi.SetTrigger("Attack");
    }
    

}
