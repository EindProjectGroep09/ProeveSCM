using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    AudioController audioController;
    
    PlayerInputHandler PIH;

    [SerializeField] Transform bulletPos;
    float speed = 20f;
    [SerializeField]
    private GameObject bullet;
    //[SerializeField] private GameObject shootParticle; //Shoot particle
    private float timer = 0f;
    private float maxTimer = 2f;

    //public InputActionMap playerInput;
    ///PlayerControls controls;
    //PlayerControls.MovementActions movement;

    private void Awake()
    {
        PIH = FindObjectOfType<PlayerInputHandler>();
        audioController = GameObject.FindObjectOfType<AudioController>();
       /// controls = new PlayerControls();
        //movement = controls.Movement;

        //movement.Shoot.performed += _ => Shoot();
    }
    private void Update()
    {
        timer += Time.deltaTime;
    }

    
    public void Shoot()
    {
        if (timer >= 1f)
        {
            GameObject projectile = Instantiate(bullet, bulletPos.position, bulletPos.rotation);
            projectile.transform.position = bulletPos.position;
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.velocity = bulletPos.transform.forward * speed;
            audioController.gameSounds[12].Play();
            timer = 0;
        }
    }
}

