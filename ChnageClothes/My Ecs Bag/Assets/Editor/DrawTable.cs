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
        EditorGUILayout.HelpBox("                                  ��ϷѧԺ������ʵϵ   1911VR  �༶���α�                                        ", MessageType.None);
        EditorGUILayout.HelpBox("                                    ���Һ�:2315    ����:29     �༶1911VR                                          ", MessageType.None);
        EditorGUILayout.EndVertical();
        GUILayout.BeginHorizontal("box");
        GUILayout.BeginVertical("box");
        EditorGUILayout.HelpBox("��ʤ��", MessageType.None);
        EditorGUILayout.HelpBox("��ʤ��",MessageType.None);
        EditorGUILayout.HelpBox("��ʤ��",MessageType.None);
        EditorGUILayout.HelpBox("          ",MessageType.None);
        GUILayout.EndVertical();
        GUILayout.BeginVertical("box");
        EditorGUILayout.HelpBox("��ʤ��", MessageType.None);
        EditorGUILayout.HelpBox("��ʤ��", MessageType.None);
        EditorGUILayout.HelpBox("��ʤ��", MessageType.None);
        EditorGUILayout.HelpBox("          ", MessageType.None);
        GUILayout.EndVertical();
        GUILayout.BeginVertical("box");
        EditorGUILayout.HelpBox("��ʤ��", MessageType.None);
        EditorGUILayout.HelpBox("��ʤ��", MessageType.None);
        EditorGUILayout.HelpBox("��ʤ��", MessageType.None);
        EditorGUILayout.HelpBox("          ", MessageType.None);
        GUILayout.EndVertical();
        GUILayout.BeginVertical("box");
        EditorGUILayout.HelpBox("��ʤ��", MessageType.None);
        EditorGUILayout.HelpBox("��ʤ��", MessageType.None);
        EditorGUILayout.HelpBox("��ʤ��", MessageType.None);
        EditorGUILayout.HelpBox("          ", MessageType.None);
        GUILayout.EndVertical();
        GUILayout.BeginVertical("box");
        GUILayout.Button("\n\n����\n\n");
        GUILayout.EndVertical();
        GUILayout.BeginVertical("box");
        EditorGUILayout.HelpBox("��ʤ��", MessageType.None);
        EditorGUILayout.HelpBox("��ʤ��", MessageType.None);
        EditorGUILayout.HelpBox("��ʤ��", MessageType.None);
        EditorGUILayout.HelpBox("          ", MessageType.None);
        GUILayout.EndVertical();
        GUILayout.BeginVertical("box");
        EditorGUILayout.HelpBox("��ʤ��", MessageType.None);
        EditorGUILayout.HelpBox("��ʤ��", MessageType.None);
        EditorGUILayout.HelpBox("��ʤ��", MessageType.None);
        EditorGUILayout.HelpBox("          ", MessageType.None);
        GUILayout.EndVertical();
        GUILayout.BeginVertical("box");
        EditorGUILayout.HelpBox("��ʤ��", MessageType.None);
        EditorGUILayout.HelpBox("��ʤ��", MessageType.None);
        EditorGUILayout.HelpBox("��ʤ��", MessageType.None);
        EditorGUILayout.HelpBox("          ", MessageType.None);
        GUILayout.EndVertical();
        GUILayout.BeginVertical("box");
        EditorGUILayout.HelpBox("��ʤ��", MessageType.None);
        EditorGUILayout.HelpBox("��ʤ��", MessageType.None);
        EditorGUILayout.HelpBox("��ʤ��", MessageType.None);
        EditorGUILayout.HelpBox("          ", MessageType.None);
        GUILayout.EndVertical();
        GUILayout.EndHorizontal();
        
        //EditorGUILayout.HelpBox("                                                                             ", MessageType.None);
        GUILayout.BeginVertical("box");
        EditorGUILayout.HelpBox("��̨", MessageType.None);
        EditorGUILayout.EndVertical();
        GUILayout.BeginHorizontal("box");
        EditorGUILayout.HelpBox("�೤��", MessageType.None);
        EditorGUILayout.HelpBox("                                                    ", MessageType.None);
        EditorGUILayout.HelpBox("��ǣ�", MessageType.None);
        EditorGUILayout.HelpBox("                                                    ", MessageType.None);
        EditorGUILayout.HelpBox("ѧί��", MessageType.None);
        EditorGUILayout.HelpBox("                                                    ", MessageType.None);
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal("box");
        EditorGUILayout.HelpBox("�೤��", MessageType.None);
        EditorGUILayout.HelpBox("                                                    ", MessageType.None);
        EditorGUILayout.HelpBox("��ǣ�", MessageType.None);
        EditorGUILayout.HelpBox("                                                    ", MessageType.None);
        EditorGUILayout.HelpBox("ѧί��", MessageType.None);
        EditorGUILayout.HelpBox("                                                    ", MessageType.None);
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal("box");
        EditorGUILayout.HelpBox("��ʦ��", MessageType.None);
        EditorGUILayout.HelpBox("       ", MessageType.None);
        EditorGUILayout.HelpBox("�绰��", MessageType.None);
        EditorGUILayout.HelpBox("                      ", MessageType.None);
        EditorGUILayout.HelpBox("����Ա��", MessageType.None);
        EditorGUILayout.HelpBox("                      ", MessageType.None);
        EditorGUILayout.HelpBox("�绰��", MessageType.None);
        EditorGUILayout.HelpBox("                         ", MessageType.None);
        GUILayout.EndHorizontal();
        GUILayout.BeginVertical("box");
        EditorGUILayout.HelpBox("                           ����ʱ��:�������ġ������߽�\n                           ��ϰʱ��:��һ�������塢�˽� ����ϰ9��10��11��", MessageType.None);
        EditorGUILayout.EndVertical();
    }
}
