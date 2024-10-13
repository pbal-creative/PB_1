using UnityEngine;

namespace GHashes
{
    class GCharacterNameHashes
    {
        // Move
        static public int IDLE = Animator.StringToHash("Idle");
        static public int WALK = Animator.StringToHash("Walk");
        static public int RUN = Animator.StringToHash("Run");
        static public int RUN_FAST = Animator.StringToHash("Run Fast");
        
        // Attack
        static public int SLASH_ATTACK_1 = Animator.StringToHash("SlashAttack1");
        static public int SLASH_ATTACK_2 = Animator.StringToHash("SlashAttack2");
        static public int SLAM_ATTACK = Animator.StringToHash("SlamAttack");
        static public int SPIN_ATTACK = Animator.StringToHash("SpinAttack");
        static public int ROLL_ATTACK = Animator.StringToHash("RollAttack");
        static public int FALL_ATTACK = Animator.StringToHash("FallAttack");
        
        // ETC
        static public int DAMAGED = Animator.StringToHash("Damaged");
        static public int DEATH = Animator.StringToHash("Death");
    }

    class GStatNameHashes
    {
        static public int MOVE_SPEED = Animator.StringToHash("MoveSpeed");
        static public int ATTACK_SPEED = Animator.StringToHash("AttackSpeed");
    }
};