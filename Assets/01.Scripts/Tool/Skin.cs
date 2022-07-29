using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SkinType
{
    SpriteNone,

    Carp, // �ؾ�
    Goldfish,  // �ݺؾ�
    Squid, // ��¡��
    Blowfish, // ����
    Flyingfish, // ��ġ 
    ElectricEll, // ���� ����� 

}

[System.Serializable]
public class SkinData
{
    public static Dictionary<SkinType, Sprite> _spriteDictionary = new Dictionary<SkinType, Sprite>();
    public static Dictionary<CardNamingType, List<SkinData>> _skinDictionary = new Dictionary<CardNamingType, List<SkinData>>();

    public SkinType _skinType = SkinType.SpriteNone;

    /// <summary>
    /// ��Ų �����͸� ��ųʸ��� �߰�
    /// </summary>
    public void AddSkinDataIntCardDictionary(CardNamingType cardNamingType)
    {
        if (!_skinDictionary.TryGetValue(cardNamingType, out var name))
        {
            _skinDictionary.Add(cardNamingType, new List<SkinData>());
        }
        _skinDictionary[cardNamingType].Add(this);
    }

    /// <summary>
    /// �ش� Ÿ�� ī���� ��Ų����Ʈ ��������
    /// </summary>
    /// <param name="cardNamingType"></param>
    /// <returns></returns>
    public static List<SkinData> GetSkinDataList(CardNamingType cardNamingType)
    {
        _skinDictionary.TryGetValue(cardNamingType, out var skinList);
        return skinList;
    }

    /// <summary>
    /// ��Ų�� ��������Ʈ�� ��ȯ�Ѵ�.
    /// </summary>
    /// <param name="skinType"></param>
    /// <returns></returns>
    public static Sprite GetSkin(SkinType skinType)
    {
        Sprite sprite = null;
        if (_spriteDictionary.TryGetValue(skinType, out sprite))
        {
            return sprite;

        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// �������� ��Ų�� ��������Ʈ�� ����Ѵ�.
    /// </summary>
    /// <param name="skinType"></param>
    public static void SetSkin(SkinType skinType)
    {
        if (_spriteDictionary.TryGetValue(skinType, out var data))
        {
            return;
        }
        else
        {
            string name = System.Enum.GetName(typeof(SkinType), skinType);
            
            // ��������Ʈ �ҷ����� ��������Ʈ ��ųʸ��� �߰� 
            AddressableTool.GetAddressableAssetDicAsync<SkinType, Sprite>(AddSpriteDictionary, skinType, name); 
        }
    }

    /// <summary>
    /// ��ųʸ��� Ű�� ��������Ʈ�� �߰��Ѵ�
    /// </summary>
    /// <param name="skinType"></param>
    /// <param name="sprite"></param>
    private static void AddSpriteDictionary(SkinType skinType, Sprite sprite)
    {
        if (_spriteDictionary.TryGetValue(skinType, out var data))
        {
            return;
        }
        else
        {
            _spriteDictionary.Add(skinType, sprite);
        }
    }
}

