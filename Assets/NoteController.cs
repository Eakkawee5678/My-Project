using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    public GameObject[] roomObjects;
    private int currentRoomIndex = 0;
    private SpriteRenderer spriteRenderer;
    List<BoxCollider[]> emptyColliders = new List<BoxCollider[]>();
    private Vector3 startPoint;

    void Start()
    {
        startPoint = new Vector3(0.38f, 1.73f, 5.49f);
        transform.position = startPoint;    
        spriteRenderer = GetComponent<SpriteRenderer>();
        for (int i = 0; i < roomObjects.Length; i++)
        {
            
            BoxCollider[] collider = roomObjects[i].GetComponentsInChildren<BoxCollider>();
            if (collider != null)
            {
                emptyColliders.Add(collider);
            }
        }



        foreach (BoxCollider[] colliderArray in emptyColliders) // ตามจำนวนห้องโน้ต
        {
            
            foreach (BoxCollider collider in colliderArray) // ตาม component
            {
                Vector3 size = collider.size;
                Vector3 center = collider.center;

                // Do something with the size and center data
                // For example, you can print them to the console
                Debug.Log("Size: " + size);
                Debug.Log("Center: " + center);
            }
            Debug.Log("Found " + colliderArray.Length + " BoxColliders"); 
        }
        SetRoomSprite();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeToNextRoom();
        }
    }

 void SetRoomSprite()
    {
        spriteRenderer.sprite = roomObjects[currentRoomIndex].GetComponent<SpriteRenderer>().sprite;

        // อัปเดต center และ size ของ Box Collider ให้เท่ากับ Object ที่เปลี่ยน Sprite
        //  BoxCollider objectCollider = roomObjects[currentRoomIndex].GetComponent<BoxCollider>();

        // กำหนดค่าให้กับทุกๆ emptyCollider

        for (; currentRoomIndex < emptyColliders.Count; )
        {
            BoxCollider[] colliderArray = emptyColliders[currentRoomIndex];

            for (int j = 0; j < colliderArray.Length; j++)
            {
                BoxCollider collider = colliderArray[j];
                Vector3 size = collider.size;
                Vector3 center = collider.center;
                BoxCollider newCollider = this.gameObject.AddComponent<BoxCollider>();
                newCollider.size = size;
                newCollider.center = center;
                newCollider.isTrigger = true;
            }
            break;
        }



    }


    void ChangeToNextRoom()
    {
        currentRoomIndex++;
        BoxCollider[] boxColliders = GetComponentsInChildren<BoxCollider>();
        for (int i = 0; i < boxColliders.Length; i++)
        {
            Destroy(boxColliders[i]);
        }
        if (currentRoomIndex >= roomObjects.Length)
        {
            currentRoomIndex = 0;
        }
        SetRoomSprite();
    }
}