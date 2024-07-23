@tool
extends EditorPlugin

func _enter_tree():
    # 插件初始化，添加菜单按钮
    add_tool_menu_item("Enable Jump to Print", _on_enable_jump_to_print)
    print("Jump to Print plugin initialized")

func _exit_tree():
    # 插件退出时的清理
    remove_tool_menu_item("Enable Jump to Print")
    print("Jump to Print plugin deinitialized")

func _on_enable_jump_to_print():
    var console_output = get_editor_interface().get_debugger().get_debug_output()
    console_output.connect("output", _on_console_output)

func _on_console_output(message: String):
    var regex = RegEx.new()
    regex.compile(r"(res://.+\.\w+):(\d+)")
    var result = regex.search(message)
    if result:
        var file_path = result.get_string(1)
        var line_number = result.get_string(2).to_int()
        var script = ResourceLoader.load(file_path)
        if script:
            var editor_interface = get_editor_interface()
            var script_editor = editor_interface.get_script_editor()
            script_editor.open_script(script)
            script_editor.goto_line(line_number - 1)