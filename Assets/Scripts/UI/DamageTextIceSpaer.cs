using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageTextIceSpaer : MonoBehaviour
{
    [SerializeField] TextMeshPro damageText;
    [SerializeField] IceSpearScript iceSpear;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1f);
        transform.position += new Vector3(0, 0.1f, 0);
        IceSpearDamageText();



    }

    // Update is called once per frame
    void Update()
    {

    }

    void IceSpearDamageText()
    {
        damageText.text = iceSpear.DamageCalculation().ToString();
    }

    public void SetDamageText(float damage)
    {
        damageText.text = damage.ToString("F0");
    }
}
