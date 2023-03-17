# Namespace generation

This asset is for generating or regenerating namespaces in scripts.

To generate a namespace in scipts need to select the script for which you want to do it and right-click right on this script and use the context menu `Generate` > `Namespaces For Seleccted C# Scripts` this starts the process of generation a namespace for the selected script, you can also select multiple scripts and it will work the same as for 
a single script.

If you call this context menu for folder or several folders, then namespaces will be generated for all scripts in selected folders and in their child folders

![image](https://user-images.githubusercontent.com/62827937/225692870-397ecf67-7af6-4f58-8c10-f9d66da6c1f9.png)

To regenerate existing namespaces in scripts use context menu `Generate` > `Namespaces For Seleccted C# Scripts (Forced)`. It is also work for folders

# Setting up namespace generation

To set ignored folders to namespaces, call the settings window with the menu `Window` > `Generator` > `Settings`.

<img width="375" src="https://user-images.githubusercontent.com/62827937/225817416-1b921866-8958-479a-8c7f-9fe0090cf550.png">

`Dont Include Folders In Namespace` is an array of folders name that are not included in namespaces when generated

<img width="547" src="https://user-images.githubusercontent.com/62827937/225817479-a456d362-23ae-4fe4-96b6-1e4c3419a66b.png">
