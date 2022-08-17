using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCode : MonoBehaviour
{
    //HP
    public int maxHP;
    int currentHP;

    //Energy
    public int maxEnergy;
    int currentEnergy;

    //Movement
    float Speed;
    float walkSpeed;
    float runSpeed;

    public float jumpPower;
    CollisionFlags flags;

    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        Vector3 moveDirection = Vector3.zero;
        flags = controller.Move(moveDirection * Time.deltaTime);
    }
}
