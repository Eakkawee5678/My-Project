using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NoteCheck : MonoBehaviour
{
    public Transform startPosition;
    public Transform endPosition;
    public int BPM = 80;


    void Update()
    {
        float velocity =  (BPM / 60) * Time.deltaTime;

        // ตรวจสอบว่าวัตถุกำลังเคลื่อนที่หรือไม่


        // เคลื่อนที่วัตถุไปยังตำแหน่งปลายทาง
        transform.position = Vector3.MoveTowards(transform.position, endPosition.position, velocity);

        // ตรวจสอบว่าวัตถุเคลื่อนที่ถึงตำแหน่งปลายทางหรือไม่
        if (transform.position == endPosition.position)
            {
            // เปลี่ยนตำแหน่งปลายทางเป็นตำแหน่งเริ่มต้น
            transform.position = startPosition.position;

               
                
            }
        


    }

    private void OnTriggerEnter(Collider target)
    {
        if (target.CompareTag("Note"))
        {
            Debug.Log("Triggered Pass");
        }
    }
}
