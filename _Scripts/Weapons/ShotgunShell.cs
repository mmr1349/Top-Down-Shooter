using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapons
{
    public class ShotgunShell : Projectile
    {

        [SerializeField] private GameObject shotGunPellet;
        [SerializeField] private int pelletCount;
        [SerializeField] private float spreadDegrees;

        public override void OnTriggerEnter(Collider other) {
            //Do nothing
        }

        // Start is called before the first frame update
        void Start() {
            for (int i = 0; i < pelletCount; i++) {
                GameObject pellet = Instantiate(shotGunPellet, transform.position, Quaternion.identity);
                pellet.transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y + Random.Range(-spreadDegrees / 2f, spreadDegrees / 2f), 0f);
            }
            Destroy(this.gameObject);
        }
    }
}