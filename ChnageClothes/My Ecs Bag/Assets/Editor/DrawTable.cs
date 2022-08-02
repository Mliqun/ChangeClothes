using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class DrawTable : EditorWindow
{
    public Color mycolo;
    [MenuItem("DrawTable/Draw")]
    static void OpenWindow()
    {
        DrawTable drawTable = (DrawTable)EditorWindow.GetWindow(typeof(DrawTable));
    }
    private void OnGUI()
    {
        GUILayout.BeginVertical("box");
        EditorGUILayout.HelpBox("                                  游戏学院虚拟现实系   1911VR  班级座次表                                        ", MessageType.None);
        EditorGUILayout.HelpBox("                                    教室号:2315    人数:29     班级1911VR                                          ", MessageType.None);
        EditorGUILayout.EndVertical();
        GUILayout.BeginHorizontal("box");
        GUILayout.BeginVertical("box");
        EditorGUILayout.HelpBox("张胜天", MessageType.None);
        EditorGUILayout.HelpBox("张胜天",MessageType.None);
        EditorGUILayout.HelpBox("张胜天",MessageType.None);
        EditorGUILayout.HelpBox("          ",MessageType.None);
        GUILayout.EndVertical();
        GUILayout.BeginVertical("box");
        EditorGUILayout.HelpBox("张胜天", MessageType.None);
        EditorGUILayout.HelpBox("张胜天", MessageType.None);
        EditorGUILayout.HelpBox("张胜天", MessageType.None);
        EditorGUILayout.HelpBox("          ", MessageType.None);
        GUILayout.EndVertical();
        GUILayout.BeginVertical("box");
        EditorGUILayout.HelpBox("张胜天", MessageType.None);
        EditorGUILayout.HelpBox("张胜天", MessageType.None);
        EditorGUILayout.HelpBox("张胜天", MessageType.None);
        EditorGUILayout.HelpBox("          ", MessageType.None);
        GUILayout.EndVertical();
        GUILayout.BeginVertical("box");
        EditorGUILayout.HelpBox("张胜天", MessageType.None);
        EditorGUILayout.HelpBox("张胜天", MessageType.None);
        EditorGUILayout.HelpBox("张胜天", MessageType.None);
        EditorGUILayout.HelpBox("          ", MessageType.None);
        GUILayout.EndVertical();
        GUILayout.BeginVertical("box");
        GUILayout.Button("\n\n过道\n\n");
        GUILayout.EndVertical();
        GUILayout.BeginVertical("box");
        EditorGUILayout.HelpBox("张胜天", MessageType.None);
        EditorGUILayout.HelpBox("张胜天", MessageType.None);
        EditorGUILayout.HelpBox("张胜天", MessageType.None);
        EditorGUILayout.HelpBox("          ", MessageType.None);
        GUILayout.EndVertical();
        GUILayout.BeginVertical("box");
        EditorGUILayout.HelpBox("张胜天", MessageType.None);
        EditorGUILayout.HelpBox("张胜天", MessageType.None);
        EditorGUILayout.HelpBox("张胜天", MessageType.None);
        EditorGUILayout.HelpBox("          ", MessageType.None);
        GUILayout.EndVertical();
        GUILayout.BeginVertical("box");
        EditorGUILayout.HelpBox("张胜天", MessageType.None);
        EditorGUILayout.HelpBox("张胜天", MessageType.None);
        EditorGUILayout.HelpBox("张胜天", MessageType.None);
        EditorGUILayout.HelpBox("          ", MessageType.None);
        GUILayout.EndVertical();
        GUILayout.BeginVertical("box");
        EditorGUILayout.HelpBox("张胜天", MessageType.None);
        EditorGUILayout.HelpBox("张胜天", MessageType.None);
        EditorGUILayout.HelpBox("张胜天", MessageType.None);
        EditorGUILayout.HelpBox("          ", MessageType.None);
        GUILayout.EndVertical();
        GUILayout.EndHorizontal();
        
        //EditorGUILayout.HelpBox("                                                                             ", MessageType.None);
        GUILayout.BeginVertical("box");
        EditorGUILayout.HelpBox("讲台", MessageType.None);
        EditorGUILayout.EndVertical();
        GUILayout.BeginHorizontal("box");
        EditorGUILayout.HelpBox("班长：", MessageType.None);
        EditorGUILayout.HelpBox("                                                    ", MessageType.None);
        EditorGUILayout.HelpBox("书记：", MessageType.None);
        EditorGUILayout.HelpBox("                                                    ", MessageType.None);
        EditorGUILayout.HelpBox("学委：", MessageType.None);
        EditorGUILayout.HelpBox("                                                    ", MessageType.None);
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal("box");
        EditorGUILayout.HelpBox("班长：", MessageType.None);
        EditorGUILayout.HelpBox("                                                    ", MessageType.None);
        EditorGUILayout.HelpBox("书记：", MessageType.None);
        EditorGUILayout.HelpBox("                                                    ", MessageType.None);
        EditorGUILayout.HelpBox("学委：", MessageType.None);
        EditorGUILayout.HelpBox("                                                    ", MessageType.None);
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal("box");
        EditorGUILayout.HelpBox("讲师：", MessageType.None);
        EditorGUILayout.HelpBox("       ", MessageType.None);
        EditorGUILayout.HelpBox("电话：", MessageType.None);
        EditorGUILayout.HelpBox("                      ", MessageType.None);
        EditorGUILayout.HelpBox("辅导员：", MessageType.None);
        EditorGUILayout.HelpBox("                      ", MessageType.None);
        EditorGUILayout.HelpBox("电话：", MessageType.None);
        EditorGUILayout.HelpBox("                         ", MessageType.None);
        GUILayout.EndHorizontal();
        GUILayout.BeginVertical("box");
        EditorGUILayout.HelpBox("                           正课时间:第三、四、六、七节\n                           自习时间:第一、二、五、八节 晚自习9、10、11节", MessageType.None);
        EditorGUILayout.EndVertical();
    }
}
