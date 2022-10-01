using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    private static GameAssets _i;

    public static GameAssets i{
        get{
            if(_i == null) _i = Instantiate(Resources.Load<GameAssets>("GameAssets"));
            return _i;

        }


    }

    public Transform DamagePopup;
    public GameObject Fireball;
    public GameObject Bomb;
    public GameObject iceArrow;


}
