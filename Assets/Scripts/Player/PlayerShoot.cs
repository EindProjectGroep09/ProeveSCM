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

    //[SerializeField] private AudioSource bulletFire;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= maxTimer)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
    }

    public void Shoot()
    {
        GameObject projectile = Instantiate(bullet, bulletPos.position, bulletPos.rotation);
        projectile.transform.position = bulletPos.position;
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.velocity = bulletPos.transform.forward * speed;
        //bulletFire.Play();
        //Instantiate(shootParticle, bulletPos.position, bulletPos.rotation);
        timer = 0;

    }
}

