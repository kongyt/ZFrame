using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "ZScriptingDefine", menuName = "ZScriptingDefine", order = 1)]
public class ZScriptingDefine : ScriptableObject{
	[Header("Test")]
	public bool TestFlag;

	[Header("Macro")]
	public string[] macro;

	public string GetDefineString(){
		string result = "";
		if(TestFlag){ result += "Z_TEST_FLAG;"; }

		foreach (var item in macro){
			result += item + ";";
		}
		return result;
	}

	[CustomEditor(typeof(ZScriptingDefine))]
	public class ObjectBuilderEditor : Editor {

		public override void OnInspectorGUI(){

			DrawDefaultInspector();

			ZScriptingDefine cfg = (ZScriptingDefine)target;
			if(GUILayout.Button("Apply")){
				string m = cfg.GetDefineString();
				PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.iOS, m);
				PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android, m);
				PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone, m);
				Debug.Log(m);
			}
		}
	}
}
