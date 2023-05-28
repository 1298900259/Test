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
        // 获取FruitType枚举类型的FieldInfo对象
        FieldInfo appleField = typeof(ModelType).GetField("Wash");
        FieldInfo bananaField = typeof(ModelType).GetField("Take");

        // 获取Apple和Banana的值
        int appleValue = (int)appleField.GetValue(null);
        int bananaValue = (int)bananaField.GetValue(null);

        // 交换Apple和Banana的值
        appleField.SetValue(null, bananaValue);
        bananaField.SetValue(null, appleValue);

        // 输出交换后的值
        Debug.Log("Wash = " + (int)ModelType.Wash);
        Debug.Log("Take = " + (int)ModelType.Take);
    }
}
