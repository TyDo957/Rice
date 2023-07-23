using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSpawner : MonoBehaviour
{
    [Range(10 , 15)]
    [SerializeField]private  float trajectorVaritance = 15f;
    [Range(-2 , 2)]
    [SerializeField] private  float spawnRate = 2f;   // 2 giây sinh ra chuột 1 lần
    [Range(-2,35)]
    [SerializeField] private  float spawnDistance = 15f;

    [Range(1,1)]
    [SerializeField] private  int spawnAmount = 1;


   [SerializeField] private  Mouse mousePrefab;
    // Start is called before the first frame update
    void Start()
    {
        this.CheckStart();
    }
    private void CheckStart()
    {
        InvokeRepeating(nameof(Spawn), this.spawnRate, this.spawnRate);  // InvokeRepeating là việc lặp đi lặp 1 object
    }
    private void Spawn()
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * this.spawnDistance;
            Vector3 spawnPoint = this.transform.position + spawnDirection;
            float tance = Random.Range(-this.trajectorVaritance, this.trajectorVaritance);
            Quaternion rotation = Quaternion.AngleAxis(tance, Vector3.forward);


            Mouse mouse = Instantiate(this.mousePrefab, spawnPoint, rotation);
            mouse.size = Random.Range(mouse.minSize, mouse.maxSize);
            mouse.SetTrajector(rotation * -spawnDirection);

        }
    }


}
