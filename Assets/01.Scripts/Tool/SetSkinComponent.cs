using UnityEngine; 
public class SetSkinComponent : MonoBehaviour
{
    [SerializeField]
    private SkinListSO _skinListSO;

    [SerializeField]
    private SkinType skinType; // 테스트용 변수 
    [SerializeField]
    private SpriteRenderer spriteRenderer; // 테스트용 변수 
    private void Start()
    {
        SetSkin(); 
    }

    [ContextMenu("GetSkinTest")]
    private void TestGetSkin()
    {
        spriteRenderer.sprite = SkinData.GetSkin(skinType);
    }
    /// <summary>
    /// 스프라이트 딕셔너리에 넣어두기 
    /// </summary>
    private void SetSkin()
    {
        int count = _skinListSO.skinList.Count; 
        
        for(int i = 0; i < count; i++)
        {
            CardNamingSkins cardNamingSkins = _skinListSO.skinList[i];
            int skinCount = cardNamingSkins.skinDataList.Count;

            for (int j = 0; j < skinCount; j++)
            {
                SkinData skinData = cardNamingSkins.skinDataList[j];
                skinData.AddSkinDataIntCardDictionary(cardNamingSkins.cardNamingType);
                SkinData.SetSkin(skinData._skinType);
            }
        }
    }
}

