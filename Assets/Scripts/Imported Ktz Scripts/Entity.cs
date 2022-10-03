using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public float speed;
    public float maxHealth;
    public float currentHealth;
    protected bool moveAllowed = true;
    public GameObject target;
    protected Vector3 originalScale;
    public int projCount;
    public float timeBetweenHits;
    protected float timeTillNextHit;
}
