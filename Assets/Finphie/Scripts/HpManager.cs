using UnityEngine;
using UnityEngine.UI;

public class HpManager : MonoBehaviour
{
    [SerializeField]
    int maxHp = default;

    [SerializeField]
    int damage = default;

    [SerializeField]
    Slider slider = default;

    int hp;
    bool isDamage;

    void Start()
        => hp = maxHp;

    void FixedUpdate()
    {
        if (!isDamage)
            return;

        hp -= damage;
        slider.value = (float)hp / maxHp;
        isDamage = false;
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag != "Enemy")
            return;

        isDamage = true;
    }
}