using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
   
    [SerializeField] private int baseScore = 1000; // Điểm gốc
    simpleManager simpleManager;
    private int coinsCollected = 0; // Số lượng xu thu thập được
    private float healthLost = 0;     // Lượng máu đã mất

    private float finalScore;         // Điểm số cuối cùng

    // Singleton Pattern để dễ dàng truy cập từ các script khác
    public static ScoreManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
 simpleManager=FindObjectOfType<simpleManager>();
        finalScore = baseScore;
       
    }

   
    

    // Tính toán lại điểm số
    private void Update()
    {
        coinsCollected = simpleManager.coinCount;
        healthLost = simpleManager.totalHealthLost;
        finalScore = baseScore + coinsCollected - healthLost;
        finalScore = Mathf.Max(finalScore, 0); // Đảm bảo điểm số không bị âm
              string statsText = 
                            $"Coin earned: {coinsCollected}\n" +
                             $"Hp lost : - {healthLost}\n"+
                           $"Total Score: {finalScore}";

        GetComponent<TextMeshProUGUI>().text = statsText;
    }

    // Cập nhật điểm số trên UI
   

    // Hàm này trả về điểm số cuối cùng
    public float GetFinalScore()
    {
        return finalScore;
    }
}
