using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class WeaponSlotManager : MonoBehaviour
    {
        WeaponHolderSlot leftHandSlot, rightHandSlot;

        DamageCollider leftDamageCollider, rightDamageCollider;

        public WeaponItem attackingWeapon;

        Animator anim;

        QuickSlotUI quickSlotUI;

        PlayerStats playerStats;
        private void Awake()
        {
            anim = GetComponent<Animator>();
            quickSlotUI = FindObjectOfType<QuickSlotUI>();
            playerStats = GetComponentInParent<PlayerStats>();

            WeaponHolderSlot[] weaponHolderSlots = GetComponentsInChildren<WeaponHolderSlot>();

            foreach (WeaponHolderSlot weaponSlot in weaponHolderSlots)
            {
                if (weaponSlot.isLeftHandSlot)
                {
                    leftHandSlot = weaponSlot;
                }
                else if (weaponSlot.isRightHandSlot)
                {
                    rightHandSlot = weaponSlot;
                }
            }
        }

        public void LoadWeaponOnSlot(WeaponItem weaponItem, bool isLeft)
        {
            if (isLeft)
            {
                leftHandSlot.LoadWeaponModel(weaponItem);
                LoadLeftWeaponCollider();
                quickSlotUI.UpdateWeaponQuickSlotsUI(true, weaponItem);

                if (weaponItem != null)
                {
                    anim.CrossFade(weaponItem.leftHandIdle, .2f);
                }
                else
                {
                    anim.CrossFade("Left Arm Empty", .2f);
                }
            }
            else
            {
                rightHandSlot.LoadWeaponModel(weaponItem);
                LoadRightWeaponCollider();
                quickSlotUI.UpdateWeaponQuickSlotsUI(false, weaponItem);

                if (weaponItem != null)
                {
                    anim.CrossFade(weaponItem.rightHandIdle, .2f);
                }
                else
                {
                    anim.CrossFade("Right Arm Empty", .2f);
                }
            }
        }

        #region HandleWeaponStaminaDrainage
        public void DrainStaminaLightAttack()
        {
            playerStats.TakeStaminaDamage(Mathf.RoundToInt(attackingWeapon.baseStamina * attackingWeapon.lightAttackMultiplier));
        }

        public void DrainStaminaHeavyAttack()
        {
            playerStats.TakeStaminaDamage(Mathf.RoundToInt(attackingWeapon.baseStamina * attackingWeapon.heavyAttackMultiplier));
        }

        #endregion

        #region Handle Weapon Damage Collider

        void LoadLeftWeaponCollider()
            {
                leftDamageCollider = leftHandSlot.currentWeaponModel.GetComponentInChildren<DamageCollider>();
            }

            void LoadRightWeaponCollider()
            {
                rightDamageCollider = rightHandSlot.currentWeaponModel.GetComponentInChildren<DamageCollider>();
            }

            public void OpenRightDamageCollider()
            {
                rightDamageCollider.EnableDamageCollider();
            }

            public void OpenLeftDamageCollider()
            {
                leftDamageCollider.EnableDamageCollider();
            }

            public void CloseRightHandDamageCollider()
            {
                rightDamageCollider.DisableDamageCollider();
            }

            public void CloseLeftHandDamageCollider()
            {
                leftDamageCollider.DisableDamageCollider();
            }

            #endregion
        }
    }


