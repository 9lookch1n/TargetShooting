using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Gun_Script : MonoBehaviour
{
    //set up damage and range
    public float damage = 10f;
    public float range = 100;

    //set up variable camera name fpsCam
    public Camera fpsCam;

    //set up variable ParticleSystem name Flash
    //Particle
    public ParticleSystem Flash;

    //Set up anything for ammo
    public int maxAmmo = 12;
    public int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;

    public Animator animator;

    private void Start()
    {
        //set up currentAmmo equal to maxAmmo
        currentAmmo = maxAmmo;
    }
    private void Update()
    {
        //All the time
        if (isReloading)
        {
            return;
        }
        //Check ammo
        if (currentAmmo <=0)
        {
            //Animation Reload
            StartCoroutine(Reload());
            return;
        }
        if(Input.GetButtonDown("Fire1"))
        {
            //Run Method Shoot
            Shoot();
        }

    }
    //Acting like a null ,void method
    IEnumerator Reload()
    {
        //when isReloading is true
        isReloading = true;
        //Play Animation Reload
        animator.SetBool("Reloading", true);
        //Stop Particle
        Flash.Stop();
        //wait reloadTime 0.25 sec
        yield return new WaitForSeconds(reloadTime - .25f);

        //Stop Animation Reload//
        animator.SetBool("Reloading", false);
        //wait out reloadTime 0.25 sec
        yield return new WaitForSeconds(.25f);

        //when isReloading is true
        currentAmmo = maxAmmo;
        isReloading = false;
        //Play Particle
        Flash.Play();
    }
    void Shoot()
    {
        //Play Particle
        Flash.Play();
        //reduce ammo
        currentAmmo--;

        //Hit
        RaycastHit hit;
        //Use Physics of transform position and forward
        //out hit
        //out range
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            //Script HP_Target set up variable
            HP_Target target = hit.transform.GetComponent<HP_Target>();
            //not null
            if (target != null )
            {
                //TakeDamage wth float damage
                target.TakeDamage(damage);
            }
        }
    }

}
