using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DamagePopup : MonoBehaviour
{
    private TextMeshPro textMesh;
    private float disappearTimer = 0.5f;
    private float moveYspeed = 0.5f;
    public static DamagePopup Create(Vector3 pos,float damageAmount){

        Transform damagePopupTransform = Instantiate(GameAssets.i.DamagePopup,pos,Quaternion.identity);
        DamagePopup damagePopup = damagePopupTransform.GetComponent<DamagePopup>();
        damagePopup.setup(damageAmount);

        return damagePopup;

    }

    private void Awake(){
        textMesh = transform.GetComponent<TextMeshPro>();
    }
    public void setup(float damage){
        textMesh.SetText(damage.ToString());

    }

    private void Update(){
        
        transform.position += new Vector3(0,moveYspeed)*Time.deltaTime;

        disappearTimer -= Time.deltaTime;
        if(disappearTimer<0){
            Destroy(this.gameObject);
        }

    }
}
