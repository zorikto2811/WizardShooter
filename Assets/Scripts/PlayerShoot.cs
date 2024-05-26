using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    private GameObject bulletPrefab;
    [SerializeField] private GameObject[] weapons;
    [SerializeField] private GameObject[] tops;
    private int weaponSwitcher = 0;
    private int currentNumWeap;
    [SerializeField] private Transform shotPos;
    [SerializeField] private float offset;
    private float timeBtwShots;
    private int mana;
    [field: SerializeField] public int Mana { get; set; }
    [SerializeField] private int manaWaste = 10;
    [SerializeField] private Slider manaBar;
    [SerializeField] private float startTimeBtwShoots;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer heroSprite;
    [SerializeField] private AudioClip[] attackSounds;

    private void Start()
    {
        SelectWeapon();
    }
    private void Update()
    {
        ScrollWeapon();
        SetWeapon();
    }

    public void ManaRegen(int manaIncrease, GameObject potion)
    {
        if (Mana < 100)
        {
            Mana += manaIncrease;

            if (Mana > 100)
            {
                Mana = 100;
            }
            Destroy(potion);
        }
    }

    private void SetWeapon()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - shotPos.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        shotPos.rotation = Quaternion.Euler(0, 0, rotZ + offset);

        manaBar.value = Mana;
        if (Mathf.Abs(rotZ) > 90)
        {
            heroSprite.flipX = true;
        }
        else
        {
            heroSprite.flipX = false;
        }

        if (timeBtwShots < 0)
        {
            if (Input.GetMouseButton(0) && Mana > 0)
            {
                animator.SetBool("isAttack", true);
                Instantiate(bulletPrefab, shotPos.position, shotPos.rotation);
                tops[weaponSwitcher].SetActive(false);
                timeBtwShots = startTimeBtwShoots;
                Mana -= manaWaste;
                SoundFXManager.instance.PlaySoundFXClip(attackSounds[weaponSwitcher], transform, 1f);
            }
            else
            {
                animator.SetBool("isAttack", false);
                tops[weaponSwitcher].SetActive(true);
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    private void ScrollWeapon()
    {
        currentNumWeap = weaponSwitcher;
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (weaponSwitcher >= weapons.Length - 1)
            {
                weaponSwitcher = 0;
            }
            else
                weaponSwitcher++;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (weaponSwitcher <= 0)
            {
                weaponSwitcher = weapons.Length - 1;
            }
            else
                weaponSwitcher--;
        }
        if (currentNumWeap != weaponSwitcher)
            SelectWeapon();
    }

    private void SelectWeapon()
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            if (i == weaponSwitcher)
            {
                bulletPrefab = weapons[i];
                tops[i].SetActive(true);
            }
            else
                tops[i].SetActive(false);
        }
    }
}
