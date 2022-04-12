using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{

    [SerializeField] Transform bulletPos;
    float speed = 20f;
    [SerializeField]
    private GameObject bullet;
    //[SerializeField] private GameObject shootParticle; //Shoot particle
    private float timer;
    private float maxTimer = 0.1f;

    public InputActionMap playerInput;
    //[SerializeField] private AudioSource bulletFire;
    PlayerControls controls;
    PlayerControls.MovementActions movement;

    private void Awake()
    {
        controls = new PlayerControls();
        movement = controls.Movement;

        movement.Shoot.performed += _ => Shoot();
    }
    private void Update()
    {
        timer += Time.deltaTime;
    }

    
    public void Shoot()
    {
            Debug.Log("Shot");
            //* movementInput = ctx.ReadValue<Vector2>();
            GameObject projectile = Instantiate(bullet, bulletPos.position, bulletPos.rotation);
            projectile.transform.position = bulletPos.position;
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.velocity = bulletPos.transform.forward * speed;
            //bulletFire.Play();
            //Instantiate(shootParticle, bulletPos.position, bulletPos.rotation);
            timer = 0;

    }
}

