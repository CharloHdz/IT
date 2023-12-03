using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using UnityEngine;

public class ConsoleActive : MonoBehaviour
{
    public GameObject console;
    public KeyCode toggleKey;
    public KeyCode sendCommand;

    public Text backgroundTXT;
    public InputField inputTXT;

    public delegate void TemplateMethod();
    public Dictionary<string, commandData> commands = new Dictionary<string, commandData>();

    public static ConsoleActive instance;

    private void Awake(){

        Clear();
        Write("Inicializando... \n\nPrueba escribiendo -h");

        if(instance != null){

            GameObject.Destroy(this.gameObject);
        }
        else{
            
            instance = this;

            RegisterCommand("-cls", Clear, "Limpia la consola.");
            RegisterCommand("-h", Help, "Muestra los comandos existentes.");

            //Como instanciar nuevos comandos en otras scripts
            // ConsoleActive.instance.RegisterCommand("name", command, "description");
            //public void comando(){ accion }

        }
    }

    public void RegisterCommand(string cmdName, TemplateMethod cmdCommand, string description){
        
        var cdata = new commandData();
        cdata.name = cmdName;
        cdata.command = cmdCommand;
        cdata.description = description;

        commands.Add(cmdName, cdata);
    }

    private void Update(){

        if (Input.GetKeyDown(toggleKey))
        {
            if (console.activeSelf)
            {
                // Si el menú actual está activado, lo desactivamos
                console.SetActive(false);
            }
            else
            {
                // Si el menú actual está desactivado, lo activamos
                console.SetActive(true);
            }
                // Si el menú actual está activado, centra el foco en  dicho objeto
            if(console.activeSelf){
                inputTXT.Select();
            }
        }
        //Envía el comando al presionar la tecla asignada
        if (console.activeSelf){
            if(Input.GetKeyDown(sendCommand)){

                Write(inputTXT.text);

                if(commands.ContainsKey(inputTXT.text)){

                    try{
                        commands[inputTXT.text].command.Invoke();
                    }
                    catch(NullReferenceException nullError){
                        Write("Ha ocurrido un error null: " + nullError.Message + "\n\n" + nullError.StackTrace);
                    }
                    catch(Exception error){
                        Write("Ha ocurrido un error: " + error.Message + "\n\n" + error.StackTrace);
                    }
                    finally{

                    }

                    inputTXT.Select();
                }

                inputTXT.Select();

                inputTXT.text = "";

            }
        }
    }

    public void Write(string text){

        backgroundTXT.text += "\n" + text;
    }

    public void Clear(){

        backgroundTXT.text = "";
    }

    public void Help(){

        Write("Esta es la lista de comandos: \n");

        foreach (var item in commands){

            Write(item.Value.name + "  " + item.Value.command + "  " + item.Value.description);
        }
    }
}
