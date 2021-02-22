using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomPropertyDrawer(typeof(MinMaxRangeAttribute))]
public class MinMaxRangePropertyDrawer : PropertyDrawer
{

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label){

        var minMaxAttribute = (MinMaxRangeAttribute)attribute;
        var propertyType = property.propertyType;

        label.tooltip = minMaxAttribute.min.ToString() + " to " + minMaxAttribute.max.ToString();

        //PrefixLabel returns the rect of the right part of the control. It leaves out the label section. We don't have to worry about it. Nice!
        Rect controlRect = EditorGUI.PrefixLabel(position, label);
        
        Rect[] splittedRect = SplitRect(controlRect,3);

        EditorGUI.BeginChangeCheck();

        float minVal = property.FindPropertyRelative("minValue").intValue;
        float maxVal = property.FindPropertyRelative("maxValue").intValue;

        minVal = EditorGUI.FloatField(splittedRect[0], minVal);
        maxVal = EditorGUI.FloatField(splittedRect[2], maxVal);

        EditorGUI.MinMaxSlider(splittedRect[1], ref minVal, ref maxVal, minMaxAttribute.min, minMaxAttribute.max);

        if(minVal < minMaxAttribute.min){
            maxVal = minMaxAttribute.min;
        }

        if(minVal > minMaxAttribute.max){
            maxVal = minMaxAttribute.max;
        }

        if(EditorGUI.EndChangeCheck()){
            property.FindPropertyRelative("minValue").intValue = Mathf.FloorToInt(minVal > maxVal ? maxVal : minVal);
            property.FindPropertyRelative("maxValue").intValue = Mathf.FloorToInt(maxVal);

        }



    }

    Rect[] SplitRect(Rect rectToSplit, int n){


        Rect[] rects = new Rect[n];

        for(int i = 0; i < n; i++){

            rects[i] = new Rect(rectToSplit.position.x + (i * rectToSplit.width / n), rectToSplit.position.y, rectToSplit.width / n, rectToSplit.height);
        
        }

        int padding = (int)rects[0].width - 40;
        int space = 5;

        rects[0].width -= padding + space;
        rects[2].width -= padding + space;

        rects[1].x -= padding;
        rects[1].width += padding * 2;

        rects[2].x += padding + space;
        

        return rects;

    }
    
} 
