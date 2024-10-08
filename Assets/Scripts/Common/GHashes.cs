using UnityEngine;

namespace GHashes
{
    class GCharacterNameHashes
    {
        static public int IDLE = Animator.StringToHash("Idle");

        static public int WALK = Animator.StringToHash("Walk");
        static public int RUN = Animator.StringToHash("Run");
        static public int RUN_FAST = Animator.StringToHash("Run Fast");
        
        static public int ATTACK_1 = Animator.StringToHash("Attack1");
        static public int ATTACK_2 = Animator.StringToHash("Attack2");
        static public int BOW_ATTACK = Animator.StringToHash("BowAttack");
        static public int DAMAGED = Animator.StringToHash("Damaged");
        static public int DEATH = Animator.StringToHash("Death");
    }

    class GStatNameHashes
    {
        static public int SPEED = Animator.StringToHash("Speed");
        static public int MAX_SPEED = Animator.StringToHash("MaxSpeed");
    }
};