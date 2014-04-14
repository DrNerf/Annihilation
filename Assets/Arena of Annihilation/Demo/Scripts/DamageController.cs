using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DamageController : Photon.MonoBehaviour 
{
    public int Health = 100;
    public Transform DamageStart;
    public GameObject DamagePrefab;
    public Texture CenterHUD;
    public Texture HealthHUD;
    public Texture EnergyHUD;
    public float HealthWidth = 233;
    public float HealthXnewWidth = 233;
    public float EnergyXpos = 233;
    public float EnergyXnewPos = 233;
    public GameObject BloodPrefab;
    public Transform BloodPoint;
    public Transform SplatterPoint;
    public List<GameObject> Splatters;
    public bool IsHealthBarLocked;
    public Rect HealthBarPosition;
    public bool BloodEnabled = false;

    private bool DoesItLerp = false;
    private GameObject DamageObjectHolder;
    private bool IsDead = false;
    private GameObject BloodObject;
    

	// Use this for initialization
	void Start () 
    {
        HealthBarPosition = new Rect(0, 0, 280, 160);
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Health <= 0)
        {
            Die();
        }
	}

    void OnGUI()
    {
        if (photonView.isMine)
        {
            //GUI.Label(new Rect(Screen.width - 150, Screen.height - 25, 150, 25), "Health : " + this.Health);
            HealthXnewWidth = 233.0f * ((float)Health / 100.0f);

            //GUI.BeginGroup(new Rect(Screen.width - 400, Screen.height - 160, 400, 160), "Box");
            //GUI.DrawTexture(new Rect(0, 0, 400, 160), CenterHUD);
            //GUI.DrawTexture(new Rect(28, 32, HealthWidth, 36), HealthHUD);
            //GUI.DrawTexture(new Rect(28, 95, 233, 36), EnergyHUD);
            //GUI.EndGroup();

            HealthBarPosition = GUI.Window(4, HealthBarPosition, DrawHealthBar, "");

            HealthWidth = Mathf.Lerp(HealthWidth, HealthXnewWidth, Time.deltaTime * 2);
            EnergyXpos = Mathf.Lerp(EnergyXpos, EnergyXnewPos, Time.deltaTime * 2);

            //if dead output it
            if (IsDead)
            {
                GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "YOU ARE DEAD !");
            }

            if(GUILayout.Button("TakeDamage"))
            {
                TakeDamage(1);
            }
        }
        
    }

    void OnTriggerEnter(Collider Other)
    {
        if (Other.tag == "AttackTrigger")
        {
            TakeDamage(10);
        }
    }

    void TakeDamage(int Damage)
    {
        this.Health -= Damage;
        OutputDamage();
        if (BloodEnabled)
        {
            Instantiate(BloodPrefab, BloodPoint.position, BloodPoint.rotation);
            int temp = Random.Range(0, 4);
            Instantiate(Splatters[temp], SplatterPoint.position, SplatterPoint.rotation);
        }

    }

    void OutputDamage()
    {
        GameObject.Instantiate(DamagePrefab, DamageStart.transform.position, DamageStart.transform.rotation);
    }

    void Die()
    {
        IsDead = true;
        //GetComponent<CharacterMotor>().canControl = false;
    }

    void DrawHealthBar(int id)
    {
        GUI.DrawTexture(new Rect(0, 0, 400, 160), CenterHUD);
        GUI.DrawTexture(new Rect(28, 32, HealthWidth, 36), HealthHUD);
        GUI.DrawTexture(new Rect(28, 95, 233, 36), EnergyHUD);
        if (!IsHealthBarLocked)
        {
            GUI.DragWindow();
        }
    }
}
