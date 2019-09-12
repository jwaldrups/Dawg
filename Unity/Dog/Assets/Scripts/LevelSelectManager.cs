using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectManager : MonoBehaviour {

    public string[] floorLevels;
    public GameObject[] locks;
    public bool[] floorUnlocked;
    public float distance;
    public int positionSelect;
    public string[] floorName;
    public float moveSpeed;
    private bool isPressed;



    void Start()
    {
        for(int i = 0; i<floorLevels.Length;i++)
        {
            if (PlayerPrefs.GetInt(floorLevels[i]) == null)
            {
                floorUnlocked[i] = false;

            }else if (PlayerPrefs.GetInt(floorLevels[i])==0 )
            {
                floorUnlocked[i] = false;
            }
            else
            {
                floorUnlocked[i] = true;
            }
            if (floorUnlocked[i])
            {
                locks[i].SetActive(false);
            }

        }

        transform.position = locks[positionSelect].transform.position + new Vector3(distance, 0, 0);

    }

    void Update()
    {
        if (!isPressed)
        {
            if (Input.GetAxis("Vertical") > 0.25f)
            {
                positionSelect += 1;
                isPressed = true;
            }
            if (Input.GetAxisRaw("Vertical") < -0.25f)
            {
                positionSelect -= 1;
                isPressed = true;
            }
            if (positionSelect >= floorLevels.Length) {
                positionSelect = floorLevels.Length - 1;

            }
            if (positionSelect < 0)
            {
                positionSelect = 0;
            }
        }
        if (isPressed)
        {
            if(Input.GetAxisRaw("Vertical") <0.25f&& Input.GetAxis("Vertical") > -0.25f)
            {
                isPressed = false;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, locks[positionSelect].transform.position + new Vector3(distance, 0, 0), moveSpeed * Time.deltaTime);


    }

}
