using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    [System.Serializable]

    [CreateAssetMenu(menuName = "Items/Weapon Item")]
    public class WeaponItem : Item
    {
        public GameObject modelPrefab;
        public bool isUnarmed;

        [Header("Idle Animations")]
        public string rightHandIdle, leftHandIdle;

        [Header("Attack Animations")]
        public string OH_Light_Attack_1, OH_Heavy_Attack_1;
        public string OH_Light_Attack_2, OH_Heavy_Attack_2;

        [Header("Stamina Costs")]
        public int baseStamina;
        public float lightAttackMultiplier, heavyAttackMultiplier;
    }
}