using System.Collections;
using Cinemachine;
using UnityEngine;
using UnityEngine.Events;
public class TurnBig : MonoBehaviour
{ Vector3 originalScale; public bool isBig; public GameObject Explo; SkillCd SkillCd; 
  public UnityEvent manaUp, manaDown;
public CinemachineVirtualCamera cinemachineVirtualCamera; // Reference to the Cinemachine Virtual Camera
    //public float zoomSpeed = 2f;  // Speed of zooming
       // Minimum zoom level
   
    public int manaBar=0, maxMana=10;  healthMain healthMain; float bonusHealth=300; float ogHealth;
    public float maxZoom = 10f;   // Maximum zoom level
    public float splashRadius = 20f; public float splashDmg; //public GameObject Explo;
     public CinemachineImpulseSource impulseSource; public float shakePow=20f; private float shaketime=0, shakeDuration=5f;
     //private CinemachineImpulseSource impulseSources;
    
     private void Start() {
         impulseSource = GetComponent<CinemachineImpulseSource>();
            //CinemachineBasicMultiChannelPerlin cperlin= impulseSource.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
  SkillCd=FindObjectOfType<SkillCd>();
  healthMain=FindAnyObjectByType<healthMain>();
     }
    


private void Update() {
     if(Input.GetKeyDown(KeyCode.E)&&manaBar>maxMana&&isBig){
           MinusMana(2);
               //StartCoroutine(TriggerShake());  // Start shake
               TriggerShake();
            Debug.Log("Shaking");
      
            shaketime += Time.deltaTime;
            if (shaketime >= 1)
            {
                StopShake();
                 Debug.Log("End Shaking");
      
            
        }
    //jump animation
    DealAoE();
   

}
     //Make the player bigger
    if(Input.GetKeyDown(KeyCode.Q)&& SkillCd.isCooldown && manaBar>maxMana){
        isBig=true;
        ogHealth=healthMain.health;
healthMain.health+=bonusHealth;

        MinusMana(5);
       
        StartCoroutine(TurnBigger());
      
    }
}
    public IEnumerator TurnBigger(){
        originalScale=transform.localScale;
        transform.localScale = new Vector3(1,1,1)*10;
         //float currentZoom = cinemachineVirtualCamera.m_Lens.OrthographicSize;
         //currentZoom = maxZoom;
         cinemachineVirtualCamera.m_Lens.OrthographicSize = maxZoom;
//Skill 1: Zoom out the map, jump and smash enemy
 
/*
//SKill 2: Zoom in the map, player immortal for second, use the hand to smash enemy
if(Input.GetKeyDown(KeyCode.Q)){
    //jump animation
     cinemachineVirtualCamera.m_Lens.OrthographicSize = maxZoom/2;
    DealAoE();

}
*/
    yield return new WaitForSecondsRealtime(10);

//transform.localScale = originalScale;
transform.localScale = new Vector3(1,1,0); isBig=false;
healthMain.health=ogHealth;

         cinemachineVirtualCamera.m_Lens.OrthographicSize = 3;

    }
void TriggerShake()
    {
        cinemachineVirtualCamera.m_Lens.OrthographicSize = maxZoom/3*2;
        impulseSource.m_ImpulseDefinition.m_AmplitudeGain = shakePow;
        // Generate the impulse when E is pressed
        impulseSource.GenerateImpulse();
       
        
        
        shaketime = 0f;
      
    }

    void StopShake()
    {cinemachineVirtualCamera.m_Lens.OrthographicSize = maxZoom;
        // Set the impulse source amplitude gain to zero to stop shaking
        impulseSource.m_ImpulseDefinition.m_AmplitudeGain = 0f;
        
    }
    public void AddMana(int manaAmount){
        
        manaBar+=manaAmount;
        Debug.Log("mana ++");
       
        
        manaUp.Invoke();
    }
     public void MinusMana(int manaAmount){
        manaBar-=manaAmount;
        manaDown.Invoke();
    }
     private void DealAoE()
    {
        // Find all enemies within the splash radius
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position,splashRadius );

       foreach (Collider2D enemyCollider in enemies)
        {
            IEnemy enemy = enemyCollider.GetComponent<IEnemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(100);
            }
        }  GameObject explosion = Instantiate(Explo, transform.position, Quaternion.identity);
        explosion.transform.localScale = new Vector3( 50, 50, 1f);
         
// Instantiate explosion effect and scale it based on the splash radius
 //   GameObject explosion = Instantiate(Explo, transform.position, Quaternion.identity);
    
        // Add Shake earthquake bla bla
       
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, splashRadius);
    }
}
