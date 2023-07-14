using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountBox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // ค้นหาและเรียกใช้งานคอมโพเนนต์ของกล่องชนในวัตถุและวัตถุย่อยทั้งหมด
        BoxCollider[] boxColliders = GetComponentsInChildren<BoxCollider>();

        // แสดงจำนวนคอมโพเนนต์ที่พบ
        Debug.Log("Found " + boxColliders.Length + " BoxColliders");

        // ทำสิ่งที่ต้องการกับคอมโพเนนต์ที่พบ (ตัวอย่างเช่น สลับเปิด/ปิดใช้งาน)
    }

    // Update is called once per frame
}
