using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject inventory;
    public GameObject m_weapon;
    public GameObject m_sheathedWeapon;
    public GameObject character;
    Animator m_animator;

    bool m_shouldBeSheathed = true;
    bool m_isPaused = false;
    bool m_shouldUnpause = false;

    private void Awake()
    {
        m_animator = character.GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            SheatheWeapon();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !m_isPaused)
        {
            PauseGame();
            Cursor.lockState = CursorLockMode.None;
        }
        else if(Input.GetKeyDown(KeyCode.Escape))
        {
            ResumeGame();
            Cursor.lockState = CursorLockMode.Locked;
        }

        if(Input.GetKeyDown(KeyCode.I) && !m_isPaused)
        {
            PauseGame();
            Cursor.lockState = CursorLockMode.None;
            inventory.SetActive(true);
        }
        else if(Input.GetKeyDown(KeyCode.I))
        {
            ResumeGame();
            Cursor.lockState = CursorLockMode.Locked;
            inventory.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.V))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            /*
            if (Physics.RaycastNonAlloc(ray, out hit, 100))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();

            }
            */
        }
    }


    private void OnMouseDown()
    {
        m_shouldUnpause = true;
    }

    void PauseGame()
    {
        Time.timeScale = 0;
        m_isPaused = true;
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
        m_isPaused = false;
    }

    private void SheatheWeapon()
    {


        StartCoroutine(WaitToSheathe());
        m_sheathedWeapon.SetActive(!m_sheathedWeapon.activeSelf);
        m_weapon.SetActive(!m_weapon.activeSelf);
    }

    IEnumerator WaitToSheathe()
    {
        if (m_shouldBeSheathed) m_animator.SetBool("SheatheWeapon", true);
        else m_animator.SetBool("WithdrawWeapon", true);

        yield return new WaitForSeconds(1f);

        if (m_shouldBeSheathed) m_animator.SetBool("SheatheWeapon", false);
        else m_animator.SetBool("WithdrawWeapon", false);

        m_shouldBeSheathed = !m_shouldBeSheathed;
    }
}
