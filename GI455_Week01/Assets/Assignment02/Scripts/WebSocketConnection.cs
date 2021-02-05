using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using UnityEngine.UI;

namespace ProgramChat
{
    public class WebSocketConnection : MonoBehaviour
    {
        private WebSocket websocket;

        public InputField chatInput;
        public InputField ip;
        public InputField port;
        public GameObject port_ui, chat_ui;
        public GameObject message;
        //public GameObject SenderText;
        //public GameObject ReceiverText;


        // Start is called before the first frame update
        void Start()
        {  

            //websocket = new WebSocket("ws://127.0.0.1:23729");

            //websocket.OnMessage += OnMessage;

            //websocket.Connect();

            //websocket.Send("Hello world");
        }

        // Update is called once per frame
        void Update()
        {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    SendMsg();
                }
            
        }

        public void Connect()
        {
            websocket = new WebSocket("ws://" + ip.text + ":" + port.text);

            websocket.OnMessage += OnMessage;
            port_ui.SetActive(false);
            chat_ui.SetActive(true);
            websocket.Connect();
        }

        private void OnDestroy()
        {
            if(websocket != null)
            {
                websocket.Close();
            }
        }
        public void SendMsg()
        {
            if (websocket.ReadyState == WebSocketState.Open)
            {
                websocket.Send(chatInput.text + "");
                chatInput.text = string.Empty;
            }
        }

        public void OnMessage(object sender, MessageEventArgs messageEventArgs)
        {
            message.GetComponent<Text>().text += "" + messageEventArgs.Data + "\n";
            Debug.Log("Recieve msg : " + messageEventArgs.Data);
        }


    }
}


