﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    public delegate void UpdateHealth(double newHealth);
    public static event UpdateHealth OnUpdateHealth;
    public static double hpMultiplier = 1;
    public  double health = 100;
    private Animator gunAnim;
    void Start()
    {
        health = health * hpMultiplier;
      
        gunAnim = GetComponent<Animator>();
        SendHealthData();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
         
            GetComponent<Animator>().SetBool("isFiring", true);
            
        }
        if (Input.GetMouseButtonUp(0))
        {
            GetComponent<Animator>().SetBool("isFiring", false);
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        SendHealthData();
        if (health <= 0)
        {
            Die();
            SceneManager.LoadScene("Game Over");
        }
    }
    void Die()
    {
        gameObject.SetActive(false);
    }
    void SendHealthData()
    {
        if (OnUpdateHealth != null)
        {
            OnUpdateHealth(health);
        }
    }

}