using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public enum ModelType
{
    Ready,
    Enter,
    Teach,
    Wash,
    Take,
    Eat,
    Outdoor,
}


public class EnumChange : MonoBehaviour
{
    public ModelType modelType;

    private void Start()
    {
        ModifyEnum(ModelType.Teach);
        Debug.Log("modelType:"+modelType);
        SwapFruitTypes();
        ModifyEnum(++modelType);
        Debug.Log("modelType:"+modelType);
    }

    public void ModifyEnum(ModelType type)
    {
        
        modelType = type;
    }


    public void SwapFruitTypes()
    {
        // ��ȡFruitTypeö�����͵�FieldInfo����
        FieldInfo appleField = typeof(ModelType).GetField("Wash");
        FieldInfo bananaField = typeof(ModelType).GetField("Take");

        // ��ȡApple��Banana��ֵ
        int appleValue = (int)appleField.GetValue(null);
        int bananaValue = (int)bananaField.GetValue(null);

        // ����Apple��Banana��ֵ
        appleField.SetValue(null, bananaValue);
        bananaField.SetValue(null, appleValue);

        // ����������ֵ
        Debug.Log("Wash = " + (int)ModelType.Wash);
        Debug.Log("Take = " + (int)ModelType.Take);
    }
}
