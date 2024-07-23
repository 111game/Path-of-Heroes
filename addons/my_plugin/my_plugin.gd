@tool
extends EditorPlugin

func _enter_tree():
    # 插件初始化
    var console_output = get_editor_interface().get_debugger().get_debug_output()
    console_output.connect("output", self, "_on_console_output")
    print("MyPlugin initialized")

func _exit_tree():
    # 插件退出时的清理
    var console_output = get_editor_interface().get_debugger().get_debug_output()
    console_output.disconnect("output", self, "_on_console_output")
    print("MyPlugin deinitialized")

func _on_console_output(message: String):
    var regex = RegEx.new()
    regex.compile(r"(res://.+\.\w+):(\d+)")
    var result = regex.search(message)
    if result:
        var file_path = result.get_string(1)
        var line_number = result.get_string(2).to_int()
        _open_file_at_line(file_path, line_number)

func _open_file_at_line(file_path: String, line_number: int):
    var script = ResourceLoader.load(file_path)
    if script:
        var editor_interface = get_editor_interface()
        var script_editor = editor_interface.get_script_editor()
        script_editor.open_script(script)
        script_editor.goto_line(line_number - 1)
