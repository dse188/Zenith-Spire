using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageTextSpinSlash : MonoBehaviour
{
    [SerializeField] TextMeshPro damageText;
    [SerializeField] WeaponSO weaponSO;
    [SerializeField] IceSpearScript iceSpear;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1f);
        transform.position += new Vector3(0, 0.1f, 0);
        SwordSpinDamageText();



    }

    // Update is called once per frame
    void Update()
    {

    }

    void SwordSpinDamageText()
    {
        damageText.text = weaponSO.attackDamage.ToString();
    }

    void IceSpearDamageText()
    {
        damageText.text = iceSpear.DamageCalculation().ToString();
    }
}
