using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "ScriptingDefine", menuName = "ScriptingDefine", order = 1)]
public class ScriptingDefine : ScriptableObject{
	[Header("Test")]
	public bool TestFlag;

	[Header("Macro")]
	public string[] macro;

	public string GetDefineString(){
		string result = "";
		if(TestFlag){ result += "TEST_FLAG;"; }

		foreach (var item in macro){
			result += item + ";";
		}
		return result;
	}

	[CustomEditor(typeof(ScriptingDefine))]
	public class ObjectBuilderEditor : Editor {

		public override void OnInspectorGUI(){

			DrawDefaultInspector();

			ScriptingDefine cfg = (ScriptingDefine)target;
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
