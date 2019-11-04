using UnityEngine;
using UnityEngine.InputSystem;
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
        {
            // ゲームパッドの振動を停止する。
            Gamepad.current?.SetMotorSpeeds(0, 0);
            return;
        }

        // ゲームパッドを振動させる。
        Gamepad.current?.SetMotorSpeeds(1, 1);

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