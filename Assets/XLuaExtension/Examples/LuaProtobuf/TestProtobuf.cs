using System.Collections;
using System.Collections.Generic;
using System.IO;
using tutorial;
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

        if (GUI.Button(new Rect(0, 0, 120, 30), "save protobuf")) {
            SaveProtobuf();
        }

        if (GUI.Button(new Rect(0, 40, 120, 30), "load protobuf")) {
            LoadProtobuf();
        }
    }

    private void SaveProtobuf() {
        tutorial.Person alice = new Person();
        alice.test.Add(1);
        alice.email = "alice@qq.com";
        alice.name = "Alice";
        alice.phone.Add(new Person.PhoneNumber() {
            number = "12344566",
            type = Person.PhoneType.HOME
        });
        ProtoSerializer serializer = new ProtoSerializer();
        string outputPath = Application.dataPath + "/XLuaExtension/Resources/proto/personData.bytes";
        FileStream fs = new FileStream(outputPath, FileMode.OpenOrCreate);
        serializer.Serialize(fs, alice);
        fs.Close();
    }

    private void LoadProtobuf() {
        string luaScript = Application.dataPath + "/XLuaExtension/Examples/LuaProtobuf/test_protobuf.lua";

        string script = "";
        var reader = File.OpenText(luaScript);
        _env.DoString(reader.ReadToEnd());
    }
}
