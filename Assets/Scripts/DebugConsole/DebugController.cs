using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DebugController : MonoBehaviour
{
    bool showConsole;
    bool showHelp;

    bool showStats;

    string input;

    public static DebugCommand KILL_ALL_ENEMIES;
    public static DebugCommand<int> SPAWN_WAVE;

    public static DebugCommand SHOWSTATS;
    public static DebugCommand HELP;

    public List<object> commandList;

    public void OnToggleDebug(InputValue value) {
        showConsole = !showConsole;
    }
    
    public void OnReturn(InputValue value) {
        if (showConsole) {
            HandleInPut();
            input = "";
        }
    }

    private void Awake() {

        KILL_ALL_ENEMIES = new DebugCommand("kill_all_enemies", "Removes all Enemy's from the screen.", "kill_all_enemies", () => {
            //call the kill all enemies function
            EnemySpawner.instance.kill_All_Enemies();
        });

        SPAWN_WAVE = new DebugCommand<int>("spawn_enemies", "spawns enemies based in the inputed number", "spawn_enemies <enemy amount>", (x) => {
            EnemySpawner.instance.SpawnWave(x);
        });

        SHOWSTATS = new DebugCommand("show_stats", "show statistics of the game like fps it works like a toggle", "show_stats", ()=>{
            FPSDisplay.instance.toggleShowStats();
        });

        HELP = new DebugCommand("help", "shows a list of commands", "help", () => {
            showHelp = true;
        });



        commandList = new List<object> {
            KILL_ALL_ENEMIES,
            SPAWN_WAVE,
            SHOWSTATS,
            HELP
        };
    }


    Vector2 scroll;
    private void OnGUI() {

        if(!showConsole){  showHelp = false; return; }

        float y = 0f;

        if (showHelp) {
            GUI.Box(new Rect(0, y, Screen.width, 100), "");

            Rect viewport = new Rect(0, 0, Screen.width - 30, 20 * commandList.Count);

            scroll = GUI.BeginScrollView(new Rect(0, y + 5f, Screen.width, 90), scroll, viewport);

            for(int i = 0; i < commandList.Count; i++) {
                DebugCommandbase command = commandList[i] as DebugCommandbase;

                string label = $"{command.commandFormat} - {command.commandDescription}";

                Rect labelRect = new Rect(5, 20 * i, viewport.width - 100, 20);

                GUI.Label(labelRect, label);
            }

            GUI.EndScrollView();

            y += 100f;
        }

        GUI.Box(new Rect(0, y, Screen.width, 30), "");
        GUI.backgroundColor = new Color(0, 0, 0, 0);
        input = GUI.TextField(new Rect(10f, y + 5f, Screen.width - 20f, 20f), input);
    }

    private void HandleInPut() {

        string[] properties = input.Split(' ');

        for(int i=0; i < commandList.Count; i++) {
            DebugCommandbase commandbase = commandList[i] as DebugCommandbase;

            if (input.Contains(commandbase.commandId)) {

                if(commandList[i] as DebugCommand != null) {
                    (commandList[i] as DebugCommand).Invoke();
                }
                else if(commandList[i] as DebugCommand<int> != null) {
                    (commandList[i] as DebugCommand<int>).Invoke(int.Parse(properties[1]));
                }
            }
        }
    }
}
