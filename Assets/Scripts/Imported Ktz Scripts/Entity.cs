using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public float speed;
    public float maxHealth;
    public float currentHealth;
    protected bool moveAllowed;
    protected GameObject target;
    protected Vector3 originalScale;
    public int projCount;


}
