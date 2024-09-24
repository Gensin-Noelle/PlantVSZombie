using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peashooter : Plant
{
     public PeaBullet peaBulletPrefab;
     public Transform shootPointTransform;
     public float shootDuration = 2;
     public float shootSpeed = 5;
     public int shootDamage = 10;
     private float shootTimer = 0;
     protected bool isShoot = false;

     protected override void EnableUpdate()
     {
          shootTimer += Time.deltaTime;
          if (shootTimer > shootDuration && isShoot)
          {
               Shoot();
               shootTimer = 0;
          }
          PeashooterShoot();
     }

     public virtual void Shoot()
     {
          PeaBullet peaBullet = Instantiate(peaBulletPrefab, shootPointTransform.position, Quaternion.identity);
          peaBullet.SetSpeed(shootSpeed);
          peaBullet.SetDamage(shootDamage);
          AudioManager.Instance.PlayClip(Config.shoot, AudioManager.Instance.GetVolume() / 2);
     }

     public void SetIsShoot(bool isShoot)
     {
          this.isShoot = isShoot;
     }

     public bool GetIsShoot()
     {
          return isShoot;
     }

     protected virtual void PeashooterShoot()
     {
          Vector2 index = GetPlantIndex(this);
          SetIsShoot(IsShoot(index));
     }

     protected virtual bool IsShoot(Vector2 index)
     {
          bool isShoot = false;
          for (int i = (int)index.y; i < 9; i++)
          {
               Cell cell = Cell.Instance.GetCell(new Vector2(index.x, i));
               if (cell != null && cell.GetHaveZombie())
               {
                    isShoot = true;
                    break;
               }
          }
          return isShoot;
     }

     /**
     得到传入植物在方格中的索引
     */
     protected Vector2 GetPlantIndex(Plant plant)
     {
          Dictionary<Plant, Vector2> plantSet = PlantManager.Instance.GetPlantSet();
          foreach ((Plant currentPlant, Vector2 index) in plantSet)
          {
               if (currentPlant == plant)
               {
                    return index;
               }
          }
          return Vector2.zero;
     }
}
