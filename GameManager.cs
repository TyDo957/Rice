using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private  Player player;
    [SerializeField] private float respawnTime = 3f;
    [SerializeField] private  float respawmBeta = 3f;
    [SerializeField] private  int live = 3;
    // Start is called before the first frame update
 public void PlayerDie()
    {
        this.live--;
        if(this.live <= 0)
        {
            GameOver();
        }
        else
        {
            Invoke(nameof(Respawn), this.respawnTime);

        }
    }
    private void Respawn()
    {
        this.player.transform.position = Vector3.zero;
        this.player.gameObject.layer = LayerMask.NameToLayer("Beta");
        this.player.gameObject.SetActive(true);

        Invoke(nameof(TurOncolisions), this.respawmBeta);
    }
    private void TurOncolisions()
    {
        this.player.gameObject.layer = LayerMask.NameToLayer("Player");
    }
    private void GameOver()
    {

    }
}
