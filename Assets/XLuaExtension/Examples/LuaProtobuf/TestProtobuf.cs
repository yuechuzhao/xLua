using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using XLua;
using XLua.LuaDLL;

public class TestProtobuf : MonoBehaviour {
    private LuaEnv _env = new LuaEnv();
	// Use this for initialization
	void Start () {
		_env.AddBuildin("pb", Lua.LoadPB);
		_env.AddBuildin("pb.io", Lua.LoadPB_IO);
		_env.AddBuildin("pb.conv", Lua.LoadPB_CONV);
		_env.AddBuildin("pb.buffer", Lua.LoadPB_BUFFER);
		_env.AddBuildin("pb.slice", Lua.LoadPB_SLICE);
	}

    void OnGUI() {
        if (GUI.Button(new Rect(0, 0, 120, 30), "load protobuf")) {
            LoadProtobuf();
        }
    }

    private void LoadProtobuf() {
        string luaScript = Application.dataPath + "/XLuaExtension/Examples/LuaProtobuf/test_protobuf.lua";

        string script = "";
        var reader = File.OpenText(luaScript);
        _env.DoString(reader.ReadToEnd());
    }
}
